using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Renci.SshNet.Common;
using Renci.SshNet;

namespace PractiZing.Sftp
{
    /// <summary>
    /// Sftp Client
    /// </summary>
    public class SftpClient : IDisposable
    {
        private bool _disposed;

        private readonly Lazy<Renci.SshNet.SftpClient> _sftpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SftpConnection"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public SftpClient(SftpConnection connection)
        {
            if (string.IsNullOrWhiteSpace(connection.PrivateKeyFilePath))
            {
                _sftpClient =
                new Lazy<Renci.SshNet.SftpClient>(
                    () =>
                        new Renci.SshNet.SftpClient(connection.Host, connection.Port, connection.UserName,
                            connection.Password));
            }
            else
            {

                var privateKey = new PrivateKeyFile(connection.PrivateKeyFilePath);
                var connectionInfo = new ConnectionInfo(connection.Host, connection.UserName, new PasswordAuthenticationMethod(connection.UserName, connection.Password), new PrivateKeyAuthenticationMethod(connection.UserName, privateKey));
                connectionInfo.Timeout = TimeSpan.FromMinutes(10);
                _sftpClient =
               new Lazy<Renci.SshNet.SftpClient>(
                   () =>
                       new Renci.SshNet.SftpClient(connectionInfo));
            }

        }

        public async Task<IEnumerable<SftpFile>> ListDirectoryAsync(string path)
        {
            

            Task<IEnumerable<Renci.SshNet.Sftp.SftpFile>> listFilesTask = null;
            await CallAsync(client => listFilesTask = Task.Factory.FromAsync(client.BeginListDirectory(path, null, null), client.EndListDirectory));
            var listFiles = await listFilesTask;

            return listFiles.Select(item =>
            {
                var attributes = new SftpFileAttributes
                {
                    IsDirectory = item.IsDirectory,
                    GroupCanExecute = item.GroupCanExecute,
                    GroupCanRead = item.GroupCanRead,
                    GroupCanWrite = item.GroupCanWrite,
                    IsRegularFile = item.IsRegularFile,
                    IsSymbolicLink = item.IsSymbolicLink,
                    LastAccessTime = item.LastAccessTime,
                    LastWriteTime = item.LastWriteTime,
                    OthersCanExecute = item.OthersCanExecute,
                    OthersCanRead = item.OthersCanRead,
                    OthersCanWrite = item.OthersCanWrite,
                    OwnerCanExecute = item.OwnerCanExecute,
                    OwnerCanRead = item.OwnerCanRead,
                    OwnerCanWrite = item.OwnerCanWrite,
                    Size = item.Length
                };

                return new SftpFile(item.Name, item.FullName, attributes);
            });
        }

        /// <summary>Creates remote directory specified by path.</summary>
        /// <param name="path">Directory path to create.</param>
        public Task CreateDirectoryAsync(string path)
        {
            return CallAsync(client => client.CreateDirectory(path));
        }

        /// <summary>Deletes remote directory specified by path.</summary>
        /// <param name="path">Directory to be deleted path.</param>
        public Task DeleteDirectoryAsync(string path)
        {
            return CallAsync(client => client.DeleteDirectory(path));
        }

        public async Task<bool> ExistsAsync(string path)
        {
            var result = false;
            await CallAsync(client => {result = client.Exists(path); });

            return result;
        }

        public Task DownloadFileAsync(string path, Stream output)
        {
            return CallAsync(client => Task.Factory.FromAsync(client.BeginDownloadFile(path, output), client.EndDownloadFile));
        }

        public Task UploadFileAsync(Stream input, string path)
        {
            return CallAsync(client => Task.Factory.FromAsync(client.BeginUploadFile(input, path), client.EndUploadFile));
        }

        public Task DeleteFileAsync(string path)
        {
            return CallAsync(client => client.DeleteFile(path));
        }

        public Task RenameFileAsync(string oldPath, string newPath)
        {
            return CallAsync(client => client.RenameFile(oldPath, newPath));
        }

        public Task SymbolicLinkAsync(string path, string linkPath)
        {
            return CallAsync(client => client.SymbolicLink(path, linkPath));
        }

        public Task SynchronizeDirectoriesAsync(string sourcePath, string destinationPath, string searchPattern)
        {
            return CallAsync(client => Task.Factory.FromAsync(client.BeginSynchronizeDirectories(sourcePath, destinationPath, searchPattern, null, null), 
                             client.EndSynchronizeDirectories));
        }

        public async Task<byte[]> ReadAllBytesAsync(string path)
        {
            byte[] bytes = null;
            await CallAsync(client => bytes = client.ReadAllBytes(path));

            return bytes;
        }

        public Task WriteAllBytesAsync(string path, byte[] bytes)
        {
            return CallAsync(client => client.WriteAllBytes(path, bytes));
        }

        public Task WriteAllTextAsync(string path, string content)
        {
            return CallAsync(client => client.WriteAllText(path,content, System.Text.Encoding.UTF8));
        }

        public Task UploadAsync(string path, Stream stream, bool canOverride = true)
        {
            return CallAsync(client => Task.Factory.FromAsync(client.BeginUploadFile(stream, path, canOverride, null, null, null),
                   client.EndUploadFile));
        }

        public async Task<SftpFileAttributes> GetAttributesAsync(string path)
        {
            Renci.SshNet.Sftp.SftpFileAttributes attributes = null;
            await CallAsync(client => attributes = client.GetAttributes(path));

            if (attributes == null) return null;
            return new SftpFileAttributes
            {
                IsDirectory = attributes.IsDirectory,
                GroupCanExecute = attributes.GroupCanExecute,
                GroupCanRead = attributes.GroupCanRead,
                GroupCanWrite = attributes.GroupCanWrite,
                IsRegularFile = attributes.IsRegularFile,
                IsSymbolicLink = attributes.IsSymbolicLink,
                LastAccessTime = attributes.LastAccessTime,
                LastWriteTime = attributes.LastWriteTime,
                OthersCanExecute = attributes.OthersCanExecute,
                OthersCanRead = attributes.OthersCanRead,
                OthersCanWrite = attributes.OthersCanWrite,
                OwnerCanExecute = attributes.OwnerCanExecute,
                OwnerCanRead = attributes.OwnerCanRead,
                OwnerCanWrite = attributes.OwnerCanWrite,
                Size = attributes.Size
            };
        }

        private Task CallAsync(Action<Renci.SshNet.SftpClient> action, params Func<System.Exception, SftpException>[] converters)
        {
            var client = _sftpClient.Value;
            try
            {
                if (!client.IsConnected)
                    client.Connect();

                action(client);
            }
            catch (SshConnectionException ex)
            {
                throw new SftpConnectionException(ex.Message, ex);
            }
            catch (SftpPermissionDeniedException ex)
            {
                throw new SftpPermissionDeniedException(ex.Message, ex);
            }
            catch (SftpPathNotFoundException ex)
            {
                throw new SftpNotFoundException(ex.Message, ex);
            }
            catch (SftpException ex)
            {
                throw new SftpException(ex.Message, ex);
            }

            return Task.FromResult(0);
        }

        private async Task CallAsync(Func<Renci.SshNet.SftpClient, Task> action, params Func<System.Exception, SftpException>[] converters)
        {
            var client = _sftpClient.Value;
            try
            {
                client.OperationTimeout = TimeSpan.FromMilliseconds(60000);
                if (!client.IsConnected)
                {
                    
                    client.Connect();                    
                }
                    

                await action(client);
            }
            catch (SshConnectionException ex)
            {
                throw new SftpConnectionException(ex.Message, ex);
            }
            catch (SftpPermissionDeniedException ex)
            {
                throw new SftpPermissionDeniedException(ex.Message, ex);
            }
            catch (SftpPathNotFoundException ex)
            {
                throw new SftpNotFoundException(ex.Message, ex);
            }
            catch (SftpException ex)
            {
                throw new SftpException(ex.Message, ex);
            }
        }

        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);

            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        ~SftpClient()
        {
            Dispose(false);
        }

        public void Connect()
        {
            if(!_sftpClient.Value.IsConnected)
                _sftpClient.Value.Connect();
        }

        public void Disconnect()
        {
            if (_sftpClient.Value.IsConnected)
                _sftpClient.Value.Disconnect();
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            Disconnect();

            if (disposing)
            {
                if(_sftpClient.IsValueCreated)
                    _sftpClient.Value.Dispose();
            }

            _disposed = true;
        }
    }
}

