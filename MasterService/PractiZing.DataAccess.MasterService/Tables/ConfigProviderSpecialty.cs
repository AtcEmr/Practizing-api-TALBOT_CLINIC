using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigProviderSpecialty : IConfigProviderSpecialty
    {
        [Key]
        public Int16 Id { get; set; }
        public string Description { get; set; }
        public bool? Visible { get; set; }
        public bool Active { get; set; }
    }
}
