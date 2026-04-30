using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigCaseType : IConfigCaseType
    {
        [Key]
        public Int16 Id { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
