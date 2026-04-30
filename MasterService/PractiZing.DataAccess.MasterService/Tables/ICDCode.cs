using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ICDCode : IICDCode
    {
        [Key]
        [AutoIncrement]
        public int ID { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public bool VisitType { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(10, ErrorMessage = "Code - Must not enter more than 10 characters.")]
        public string Code { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(255, ErrorMessage = "Description - Must not enter more than 255 characters.")]
        public string Description { get; set; }

        [MaxLength(5000, ErrorMessage = "DefaultPlan - Must not enter more than 5000 characters.")]
        public string DefaultPlan { get; set; }
        public bool Common { get; set; }

        [MaxLength(20, ErrorMessage = "SNOMEDCT - Must not enter more than 20 characters.")]
        public string SNOMEDCT { get; set; }

        [MaxLength(10, ErrorMessage = "CodeSystem - Must not enter more than 10 characters.")]
        public string CodeSystem { get; set; }

        [MaxLength(8, ErrorMessage = "ICD_10Code - Must not enter more than 8 characters.")]
        public string ICD_10Code { get; set; }
        public bool SendToBilling { get; set; }
        public bool ShowInActiveProblems { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? IcdType { get; set; }
        public int? IsChronic { get; set; }

        [Ignore]
        public bool IsICDAddToFavourite { get; set; }
    }
}
