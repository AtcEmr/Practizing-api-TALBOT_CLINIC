
namespace PractiZing.Sftp
{
    public class SftpCredentials
    {
        public SftpCredentials(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; }

        public string Password { get; }
    }
}