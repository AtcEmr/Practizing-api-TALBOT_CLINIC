using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class MasterICD10 : IMasterICD10
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
