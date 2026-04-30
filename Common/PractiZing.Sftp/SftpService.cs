using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PractiZing.Sftp
{
    public class SftpService
    {
        #region Fields
        private readonly string _host;
        private readonly int _port;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _claimDirectory;
        public readonly string claimExtension;
        private readonly string _eRAExtension;
        private readonly string _eRADirectory;
        private readonly string _ackDirectory;
        private readonly string _ackExtension;
        private string _currentDirectory;
        private string _currentExtension;
        private readonly string _statementDirectory;
        private readonly string _statementExtension;
        private string _privateKeyfilePath;
        #endregion Fields

        public SftpService(string host, int port, string userName, string password, string claimDirectory, string claimExtension, string eRADirectory, string eRAExtension,
            string ackDirectory, string ackExtension, string statementDirectory, string statementExtension)
        {
            _host = host;
            _port = port;
            _userName = userName;
            _password = password;
            _claimDirectory = claimDirectory;
            this.claimExtension = claimExtension;
            _eRAExtension = eRAExtension;
            _eRADirectory = eRADirectory;
            _ackDirectory = ackDirectory;
            _ackExtension = ackExtension;
            _statementDirectory = statementDirectory;
            _statementExtension = statementExtension;
        }

        public SftpService(string host, int port, string userName, string password, string claimDirectory, string claimExtension, string eRADirectory, string eRAExtension, string ackDirectory, string ackExtension, string privateKeyfilePath)
        {
            _host = host;
            _port = port;
            _userName = userName;
            _password = password;
            _claimDirectory = claimDirectory;
            this.claimExtension = claimExtension;
            _eRAExtension = eRAExtension;
            _eRADirectory = eRADirectory;
            _ackDirectory = ackDirectory;
            _ackExtension = ackExtension;
            _privateKeyfilePath = privateKeyfilePath;
        }

        public async Task<List<(string Name, byte[] Contents)>> DownloadAllAsync()
        {
            return await DownloadAllAsync(_currentExtension);
        }

        public async Task<List<(string Name, byte[] Contents)>> DownloadAllAsync(string fileExtension)
        {
            _currentExtension = fileExtension;
            SetCurrentDirectory(_currentExtension);
            var result = new List<(string Name, byte[] Contents)>();
            var connection = GetConnection();

            using (var sftp = new SftpClient(connection))
            {
                if (!await WorkingFolderExists(sftp))
                    return result;

                foreach (var file in await GetWorkingFilesAsync(sftp, fileExtension))
                {
                    if (!file.Attributes.IsDirectory)
                    {
                        result.Add((file.Name, await sftp.ReadAllBytesAsync(file.Path)));
                    }
                }

                return result;
            }
        }

        public void SetCurrentDirectory(string fileExtension)
        {
            if (_eRAExtension == fileExtension)
            {
                _currentDirectory = _eRADirectory;
            }
            else if (claimExtension == fileExtension)
            {
                _currentDirectory = _claimDirectory;
            }
            else if (_statementExtension == fileExtension)
            {
                _currentDirectory = _statementDirectory;
            }
            else
            {
                _currentDirectory = _ackDirectory;
            }
        }

        public async Task UploadAsync(string fileName, string fileExtension, byte[] contents)
        {
            try
            {

                _currentExtension = fileExtension;
                SetCurrentDirectory(_currentExtension);
                var connection = GetConnection();
                using (var sftp = new SftpClient(connection))
                {
                    if (!await WorkingFolderExists(sftp))
                    {
                        await sftp.CreateDirectoryAsync(_currentDirectory);
                    }

                    await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UploadStediAsync(string fileName, string fileExtension, byte[] contents)
        {
            try
            {

                _currentExtension = fileExtension;
                SetCurrentDirectory(_currentExtension);
                var connection = GetConnection();
                using (var sftp = new SftpClient(connection))
                {
                    if (!await WorkingFolderExists(sftp))
                    {
                        await sftp.CreateDirectoryAsync(_currentDirectory);
                    }
                    string desPath = _currentDirectory + "/" + fileName + _currentExtension;
                    await sftp.WriteAllBytesAsync(desPath, contents);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task UploadDeloitteAsync(string fileName, string fileExtension, byte[] contents)
        //{
        //    try
        //    {

        //        _currentExtension = fileExtension;
        //        SetCurrentDirectory(_currentExtension);
        //        var connection = GetDeloitteConnection();
        //        using (var sftp = new SftpClient(connection))
        //        {

        //            //if (!await WorkingFolderExists(sftp))
        //            //{
        //            //    await sftp.CreateDirectoryAsync(_currentDirectory);
        //            //}
        //            sftp.Connect();
        //            await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
        //            sftp.Disconnect();

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public async Task UploadDeloitteAsync(string fileName, string fileExtension, byte[] contents)
        {
            try
            {

                _currentExtension = fileExtension;
                SetCurrentDirectory(_currentExtension);
                var connection = GetDeloitteConnection();
                using (var sftp = new SftpClient(connection))
                {
                    string desPath = _currentDirectory + "/" + fileName + _currentExtension;
                    Stream stream = new MemoryStream(contents);
                    sftp.Connect();

                    await sftp.UploadFileAsync(stream, desPath);



                    sftp.Disconnect();

                    //await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Upload837FileToDeloitteAsync(string[] fileNames, string fileExtension,string folderPath)
        {
            try
            {
                _currentExtension = fileExtension;
                SetCurrentDirectory(_currentExtension);
                var connection = GetDeloitteConnection();
                using (var sftp = new SftpClient(connection))
                {                    
                    sftp.Connect();

                    
                    foreach (var item in fileNames)
                    {
                        string[] splitname = item.Split("/")[2].Split(".");
                        string filePath = Path.Combine(folderPath, splitname[0] + _currentExtension);

                        string desPath = _currentDirectory + "/" + splitname[0] + _currentExtension;
                        var content = await File.ReadAllBytesAsync(filePath);
                        Stream stream = new MemoryStream(content);
                        await sftp.UploadFileAsync(stream, desPath);

                        string fileMovedPath = Path.Combine(folderPath, "Archived", splitname[0] + _currentExtension);
                        File.Move(filePath, fileMovedPath);
                    }

                    sftp.Disconnect();
                    //await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UploadDeloitteAsync(string fileName, string fileExtension, string contents)
        {
            try
            {

                _currentExtension = fileExtension;
                SetCurrentDirectory(_currentExtension);
                var connection = GetDeloitteConnection();
                
                using (var sftp = new SftpClient(connection))
                {                    
                    string desPath = _currentDirectory + "/" + fileName + _currentExtension;
                    //Stream stream = new MemoryStream(contents);
                    //await sftp.UploadFileAsync(stream, desPath);

                    await sftp.WriteAllTextAsync(desPath, contents);

                    //await sftp.WriteAllBytesAsync(Path.Combine(_currentDirectory, $"{fileName}{_currentExtension}"), contents);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task ClearWorkingFolder(List<string> exceptFiles)
        {
            try
            {

                var connection = GetConnection();
                using (var sftp = new SftpClient(connection))
                {
                    if (await WorkingFolderExists(sftp))
                    {
                        var filesToDelete = (await GetWorkingFilesAsync(sftp)).Where(f => !exceptFiles.Contains(f.Name));
                        foreach (var file in filesToDelete)
                        {
                            await sftp.DeleteFileAsync(file.Path);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private SftpConnection GetConnection()
        {
            return new SftpConnection(_host, _port, _userName, _password);
        }

        public SftpConnection GetDeloitteConnection()
        {
            return new SftpConnection(_host, _port, _userName, _password, _privateKeyfilePath);
        }


        private async Task<bool> WorkingFolderExists(SftpClient sftp)
        {
            try
            {

                var result = await sftp.ExistsAsync(_currentDirectory);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        private async Task<IEnumerable<SftpFile>> GetWorkingFilesAsync(SftpClient sftp)
        {
            return await GetWorkingFilesAsync(sftp, _currentExtension);
        }

        private async Task<IEnumerable<SftpFile>> GetWorkingFilesAsync(SftpClient sftp, string fileExtension)
        {
            return (await sftp.ListDirectoryAsync(_currentDirectory)).Where(f => f.Name.EndsWith(fileExtension));
            // return (await sftp.ListDirectoryAsync(_workingFolder)).Where(f => MatchFileName(f, fileType));
        }

        private bool MatchFileName(SftpFile file, EdiFileType type)
        {
            return Regex.IsMatch(file.Name, GetMatchPattern(type));
        }

        private string GetMatchPattern(EdiFileType type)
        {
            switch (type)
            {
                //Start with CR835 and doesn't contains 'Rpt' substring
                case EdiFileType.Payment:
                    return @"CR835_(?!.*Rpt)";
                //Start with CR99X
                case EdiFileType.Acknowledgement:
                    return @"CR99X_(\S+)";
                default:
                    throw new InvalidOperationException("Unexpected edi file type");
            }
        }
    }

}
