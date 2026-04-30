using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IClearingHouse : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        Int16 Id { get; set; }
        string Name { get; set; }
        string SENDER_ID { get; set; }
        string RECVR_ID { get; set; }
        string SENDERCODE { get; set; }
        string RECVRCODE { get; set; }
        string RCV_IDCODE { get; set; }
        string SENDERTYPE { get; set; }
        string RECVRTYPE { get; set; }
        string AuthorizationInformationQualifier { get; set; }
        string AuthorizationInformation { get; set; }
        string SecurityInformationQualifier { get; set; }
        string SecurityInformation { get; set; }
        string BillingContactFirstName { get; set; }
        string BillingContactLastName { get; set; }
        string BillingContactMiddle { get; set; }
        string BillingContactPhoneNumber { get; set; }
        string ReasonForWriteOff { get; set; }
        byte? Format { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        int? HostPort { get; set; }
        string WorkingDirectory { get; set; }
        bool AcknowledgementRequested { get; set; }
        bool TestMode { get; set; }
        string ClaimDirectory { get; set; }
        string ClaimExtension { get; set; }
        string ERAExtension { get; set; }
        string AckDirectory { get; set; }
        string AckExtension { get; set; }
        string ERADirectory { get; set; }
        string TransactionType { get; set; }
        string FolderName { get; set; }
        string StatementDirectory { get; set; }
        string StatementExtension { get; set; }
        Int64? TransactionNumber { get; set; }
        bool? ISForFFSClaim { get; set; }
        long ClaimBatchNumber { get; set; }
        bool? IsOhioMedicaid { get; set; }
        string PrivateKeyFilePath { get; set; }

    }
}
