using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigTOS : IConfigTOS
    {
        public string Code { get; set; }
        public string Descr { get; set; }
       public bool IsActive { get; set; }
    }
}
