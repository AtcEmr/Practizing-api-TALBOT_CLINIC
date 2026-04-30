namespace PractiZing.Sftp
{
    public class SftpPermissionDeniedException : SftpException
    {
        public SftpPermissionDeniedException(string message) : base(message)
        {
        }

        public SftpPermissionDeniedException(string message, System.Exception exception) : base(message, exception)
        {
        }
    }
}