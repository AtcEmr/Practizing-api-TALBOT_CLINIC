using System;

namespace PractiZing.Sftp
{
    public class SftpFileAttributes
    {
        public DateTime LastAccessTime { get; internal set; }

        public DateTime LastWriteTime { get; internal set; }

        public long Size { get; internal set; }

        public bool IsSymbolicLink { get; internal set; }

        public bool IsRegularFile { get; internal set; }

        public bool IsDirectory { get; internal set; }

        public bool OwnerCanRead { get; internal set; }

        public bool OwnerCanWrite { get; internal set; }

        public bool OwnerCanExecute { get; internal set; }

        public bool GroupCanRead { get; internal set; }

        public bool GroupCanWrite { get; internal set; }

        public bool GroupCanExecute { get; internal set; }

        public bool OthersCanRead { get; internal set; }

        public bool OthersCanWrite { get; internal set; }

        public bool OthersCanExecute { get; internal set; }
    }
}
