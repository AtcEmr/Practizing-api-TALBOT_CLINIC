using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientNote : IPatientNote
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string Note { get; set; }
        public int PatientId { get; set; }
        public int PracticeId { get; set; }
        public Guid UId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
