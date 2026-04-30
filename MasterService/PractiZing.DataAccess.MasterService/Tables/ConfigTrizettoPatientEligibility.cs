using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigTrizettoPatientEligibility : IConfigTrizettoPatientEligibility
    {
        [Key]
        public int Id { get ; set ; }
        public Guid UId { get; set; }
        public string ISA01AuthQual { get ; set ; }
        public string ISA02AuthInfo { get ; set ; }
        public string ISA03SecQual { get ; set ; }
        public string ISA04SecInfo { get ; set ; }
        public string ISA06SenderId { get ; set ; }
        public string ISA08ReceiverId { get ; set ; }
        public string ISA15UsageIndi { get ; set ; }
        public string GS02SenderId { get ; set ; }
        public string GS03ReceiverId { get ; set ; }
        public string SubmitterEntity { get ; set ; }
        public string SubmitterOrgName { get ; set ; }
        public string SubmitterQual { get ; set ; }
        public string SubmitterNM141Id { get ; set ; }
        public string UserName { get ; set ; }
        public string Password { get ; set ; }
        public long ISA13CntrlNumber { get ; set ; }
        public long TRN01 { get ; set ; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
