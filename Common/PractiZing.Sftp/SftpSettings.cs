namespace PractiZing.Sftp
{
	public class SftpSettings : SftpConnection
	{
		public SftpSettings(int clearingHouseId, string host, int port, string userName, string password, string folder, string claimDirectory, string claimExtension,string eRADirectory, string eRAExtension, string ackDirectory, string ackExtension) : base(host, port, userName, password)
		{
			Folder = folder;
			ClearingHouseId = clearingHouseId;
            ClaimDirectory = claimDirectory;
            ClaimExtension = claimExtension;
            ERADirectory = eRADirectory;
            ERAExtension = eRAExtension;
            AckDirectory = ackDirectory;
            AckExtension = ackExtension;

        }
		public string Folder { get; }

		public int ClearingHouseId { get; }

        public  string ClaimDirectory;
        public  string ClaimExtension;
        public string ERAExtension;
        public  string ERADirectory;
        public  string AckDirectory;
        public  string AckExtension;
    }
}
