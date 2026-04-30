

namespace PractiZing.Sftp
{
    public class SftpConnection
    {
        public SftpConnection(string host, int port, string userName, string password)
        {
            // there may be an insurance company, like 'Paper only' that does not have an sftp connection
            //Contract.RequiresNotEmpty(host, $"For sftp settings argument '{nameof(host)}' is empty.");
            //Contract.RequiresNotEmpty(userName, $"For sftp settings argument '{nameof(userName)}' is empty.");
            //Contract.RequiresNotEmpty(password, $"For sftp settings argument '{nameof(password)}' is empty.");

            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }

        public SftpConnection(string host, int port, string userName, string password, string privateKeyFilePath)
        {
            // there may be an insurance company, like 'Paper only' that does not have an sftp connection
            //Contract.RequiresNotEmpty(host, $"For sftp settings argument '{nameof(host)}' is empty.");
            //Contract.RequiresNotEmpty(userName, $"For sftp settings argument '{nameof(userName)}' is empty.");
            //Contract.RequiresNotEmpty(password, $"For sftp settings argument '{nameof(password)}' is empty.");

            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
            PrivateKeyFilePath = privateKeyFilePath;
        }

        public string Host { get; }

        public int Port { get; }

        public string UserName { get; }

        public string Password { get; }

        public string PrivateKeyFilePath { get; set; }
    }
}