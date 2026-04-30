using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "Charge")]
    public class ChargeStatementDTO
    {
        public string Date { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string CPTCode { get; set; }
    }
}
