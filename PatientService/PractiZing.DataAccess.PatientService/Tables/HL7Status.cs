using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class HL7Status : IHL7Status
    {
        [Key]
        [AutoIncrement]
        public long Id { get; set; }
        public int PracticeId { get; set; }
        public string MessageType { get; set; }
        public string BillingId { get; set; }
        public string StatusCode { get; set; }
        public string SentBy { get; set; }
        public DateTime SentDate { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ErrorMessage { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public string FileContent { get; set; }

        [Ignore]
        public string PatientName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }

        [Ignore]
        public string AccessionNumber
        {
            get
            {
                return $"{FileName.Substring(0, 12)}";
            }
        }

        //[Ignore]
        //public string BillingID
        //{
        //    get
        //    {
        //        return this.BillingId.ToString();
        //    }
        //}

        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
    }
}
