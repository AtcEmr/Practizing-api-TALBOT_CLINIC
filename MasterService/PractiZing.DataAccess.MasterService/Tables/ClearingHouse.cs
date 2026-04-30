using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ClearingHouse : IClearingHouse
    {
        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string SENDER_ID { get; set; }
        public string RECVR_ID { get; set; }
        public string SENDERCODE { get; set; }
        public string RECVRCODE { get; set; }
        public string RCV_IDCODE { get; set; }
        public string SENDERTYPE { get; set; }
        public string RECVRTYPE { get; set; }
        public string AuthorizationInformationQualifier { get; set; }
        public string AuthorizationInformation { get; set; }
        public string SecurityInformationQualifier { get; set; }
        public string SecurityInformation { get; set; }
        public string BillingContactFirstName { get; set; }
        public string BillingContactLastName { get; set; }
        public string BillingContactMiddle { get; set; }
        public string BillingContactPhoneNumber { get; set; }
        public string ReasonForWriteOff { get; set; }
        public byte? Format { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int? HostPort { get; set; }
        public string WorkingDirectory { get; set; }
        public bool AcknowledgementRequested { get; set; }
        public bool TestMode { get; set; }
        public string ClaimDirectory { get; set; }
        public string ClaimExtension { get; set; }
        public string ERAExtension { get; set; }
        public string AckDirectory { get; set; }
        public string AckExtension { get; set; }
        public string ERADirectory { get; set; }
        public bool IsActive { get; set; }
        public string TransactionType { get; set; }
        public int PracticeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string FolderName { get; set; }
        public string StatementDirectory { get; set; }
        public string StatementExtension { get; set; }
        public Int64? TransactionNumber { get; set; }
        public bool? ISForFFSClaim { get; set; }
        public long ClaimBatchNumber { get; set; }
        public bool? IsOhioMedicaid { get; set; }
        public string PrivateKeyFilePath { get; set; }
    }
}
