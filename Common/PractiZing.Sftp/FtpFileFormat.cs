

namespace PractiZing.Sftp
{
    public abstract class FileFormat
    {
        public string Extension { get; private set; }

        protected FileFormat(string extension)
        {
            Extension = extension;
        }
    }

    public sealed class FtpFileFormat : FileFormat
    {
        #region Static fields
        public static readonly FtpFileFormat Ara = new FtpFileFormat(".ara");
        public static readonly FtpFileFormat Clm = new FtpFileFormat(".clm");
        public static readonly FtpFileFormat Xml = new FtpFileFormat(".xml");
        public static readonly FtpFileFormat Acknowledgement = new FtpFileFormat(".999");
        #endregion Static fields

        private FtpFileFormat(string extension) : base(extension)
        { }
    }


}
