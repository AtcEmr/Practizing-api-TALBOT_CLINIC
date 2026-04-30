namespace PractiZing.Sftp
{
    public class SftpConnectionException : SftpException
    {
        public SftpConnectionException(string message, System.Exception ex) : base(message, ex)
        {
        }
    }
}