using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class EDIEligibilityLog : IEDIEligibilityLog
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PatientEligibilityId { get ; set ; }
        public string Transaction270 { get ; set ; }
        public string Transaction271 { get ; set ; }
        public string CreatedBy { get ; set ; }
        public DateTime CreatedDate { get ; set ; }
        public string ModifiedBy { get ; set ; }
        public DateTime? ModifiedDate { get ; set ; }
    }
}
