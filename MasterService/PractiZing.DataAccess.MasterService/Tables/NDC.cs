using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class NDC : INDC
    {
        [Key]
        public Int16 Code { get; set; }

        
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(13, ErrorMessage = "NDCCode - Must not enter more than 13 characters.")]
        public string NDCCode { get; set; }
        public Int16? Format { get; set; }
        public Int16? UoM { get; set; }
        public decimal? DrugQty { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(40, ErrorMessage = "Description - Must not enter more than 40 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CptCode { get; set; }

        [Ignore]
        public string UoMDesc { get; set; }

        [Ignore]
        public string FormatDesc { get; set; }

        [Ignore]
        public Guid CPTCodeUId { get; set; }
    }
}
