using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigSupervisionType : IConfigSupervisionType
    {
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public string SupervisionType { get; set; }        
    }
}
