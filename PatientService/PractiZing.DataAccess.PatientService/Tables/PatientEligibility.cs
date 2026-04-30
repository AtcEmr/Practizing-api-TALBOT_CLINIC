using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientEligibility : IPatientEligibility
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PatientId { get ; set ; }
        public int PracticeId { get; set; }
        public DateTime? EntryDate { get; set; }
        public string TRN { get ; set ; }
        public DateTime EligibilityDate { get ; set ; }
        public string ErrorMessage { get ; set ; }        
        public string CreatedBy { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string ModifiedBy { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }        
    }
}
