using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class CPTCategory : ICPTCategory
    {
        [Key]
        [AutoIncrement]
        public short Id { get; set; }
        public Guid UId { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "CategoryName is required")]
        [MaxLength(50, ErrorMessage = "CategoryName - Must not enter more than 50 characters.")]
        public string CategoryName { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "RevenueCode is required")]
        [MaxLength(10, ErrorMessage = "RevenueCode - Must not enter more than 10 characters.")]
        public string RevenueCode { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description - Must not enter more than 500 characters.")]
        public string Description { get; set; }
        public int PracticeId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
