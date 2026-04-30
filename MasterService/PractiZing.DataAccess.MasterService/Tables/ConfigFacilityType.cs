using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigFacilityType : IConfigFacilityType
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeValue { get; set; }
       public bool IsActive { get; set; }
    }
}
