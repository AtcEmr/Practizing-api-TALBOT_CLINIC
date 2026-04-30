using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "AgingBalances")]
    public class AgingBalancesDTO
    {
        public decimal Current { get; set; } = 0;

        public decimal Over30Days { get; set; } = 0;

        public decimal Over60Days { get; set; } = 0;

        public decimal Over90Days { get; set; } = 0;

        public decimal Over120Days { get; set; } = 0;
        public string DunningMessage { get; set; }
    }
}
