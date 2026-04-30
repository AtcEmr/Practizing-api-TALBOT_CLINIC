using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class MasterCPT : IMasterCPT
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
