using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigProviderPosition : IConfigProviderPosition
    {
        [Key]
        public Int16 Id { get; set; }
        public string PositionName { get; set; }
        public bool IsActive { get; set; }
    }
}
