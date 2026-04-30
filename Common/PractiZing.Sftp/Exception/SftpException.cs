namespace PractiZing.Sftp
{
    public class SftpException : System.Exception
    {
        public SftpException(string message): base(message)
        {
            
        }

        public SftpException(string message, System.Exception exception):base(message, exception)
        {
            
        }
    }
}