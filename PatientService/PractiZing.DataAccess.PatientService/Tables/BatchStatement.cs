using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class BatchStatement : IBatchStatement
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public string BatchFileName { get; set; }
        public DateTime? SentDate { get; set; }
        public bool? IsXml { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PracticeId { get; set; }
        public bool? IsSent { get; set; }
        public int? StatementCount { get; set; }
        public decimal? BatchTotal { get; set; }
        public string SentBy { get; set; }
        [Ignore]
        public int Count { get; set; }

    }
}
