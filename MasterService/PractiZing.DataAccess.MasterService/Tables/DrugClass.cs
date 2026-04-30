using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class DrugClass : IDrugClass
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "DrugCode - Must not enter more than 50 characters.")]
        public string DrugCode { get; set; }
        [MaxLength(200, ErrorMessage = "Description - Must not enter more than 200 characters.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
