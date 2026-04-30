using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientAlert : IPatientAlert
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string AlertText { get; set; }
        public int PatientId { get; set; }        
        public Guid UId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public Guid PatientUId { get; set; }
    }
}
