using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientStatement : IPatientStatement
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PatientId { get; set; }
        public Guid UId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PracticeId { get; set; }
        public int BatchStatementId { get; set; }
        public bool? IsXml { get; set; }
        public string Note { get; set; }
        public bool? IsFromEMR { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
