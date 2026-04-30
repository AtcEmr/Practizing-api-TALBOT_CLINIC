namespace PractiZing.Sftp
{
    public class SftpNotFoundException : SftpException
    {
        public SftpNotFoundException(string message) : base(message)
        {
        }

        public SftpNotFoundException(string message, System.Exception exception) : base(message, exception)
        {
        }
    }
}