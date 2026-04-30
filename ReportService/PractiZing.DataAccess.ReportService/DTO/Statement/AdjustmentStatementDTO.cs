using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "Adjustment")]
    public class AdjustmentStatementDTO
    {
        public string Date { get; set; }

        public string Description { get; set; }

        public decimal AdjustmentAmount { get; set; }
    }
}
