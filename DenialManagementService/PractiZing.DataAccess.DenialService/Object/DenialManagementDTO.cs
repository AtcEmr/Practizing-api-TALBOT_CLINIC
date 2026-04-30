using PractiZing.Base.Object.DenialService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class DenialManagementDTO : IDenialManagementDTO
    {
        public int PatientCount { get; set; }
        public decimal BalanceAmount { get; set; }
        public string Tag { get; set; }
        public string FromDays { get; set; }
        public string ToDays { get; set; }
        public string Category { get; set; }

        [Ignore]
        public bool IsSelected { get; set; }
    }
}
