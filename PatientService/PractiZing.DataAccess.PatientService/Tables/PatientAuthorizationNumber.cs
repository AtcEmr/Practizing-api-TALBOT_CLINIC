using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class PatientAuthorizationNumber : IPatientAuthorizationNumber
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }

        public long InsurancePolicyId { get; set; }

        [MaxLength(50, ErrorMessage = "AuthorizationNumber - Must not enter more than 50 characters.")]
        public string AuthorizationNumber { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        [Ignore]
        public bool isDeleted { get; set; }
    }
}
