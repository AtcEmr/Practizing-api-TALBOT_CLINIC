using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "Transaction")]
    public class TransactionDTO
    {
        public List<ChargeStatementDTO> Charges { get; set; }

        public List<PaymentStatementDTO> Payments { get; set; }
        public List<AdjustmentStatementDTO> Adjustments { get; set; }
    }
}
