using PractiZing.Base.Entities;
using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Tables
{
    [Alias("PatientCase")]
    public class PatientCase : IPatientCase
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(15, ErrorMessage = "CaseIdNumber - Must not enter more than 15 characters.")]
        public string CaseIdNumber { get; set; }
        public long PatientId { get; set; }
        public int? CaseTypeId { get; set; }
        public int? ProviderId { get; set; }
        public int? FacilityId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
