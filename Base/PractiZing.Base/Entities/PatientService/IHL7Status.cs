using System;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IHL7Status : IStamp, IPracticeDTO
    {
        long Id { get; set; }
        string MessageType { get; set; }
        string BillingId { get; set; }
        string StatusCode { get; set; }
        string SentBy { get; set; }
        DateTime SentDate { get; set; }
        string FileName { get; set; }
        string FilePath { get; set; }
        DateTime? ProcessedDate { get; set; }
        string ErrorMessage { get; set; }
        string PatientName { get; }
        // string BillingID { get; }
        string AccessionNumber { get; }
        string FileContent { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
