

namespace PractiZing.Sftp
{
    /// <summary>
    /// Ftp File Info
    /// </summary>
    public class SftpFile
    {
        public SftpFile(string name, string path, SftpFileAttributes attributes)
        {
            Name = name;
            Path = path;
            Attributes = attributes;
        }

        public string Name { get;}

        public string Path { get; }
        
        public SftpFileAttributes Attributes { get; }
    }
}
