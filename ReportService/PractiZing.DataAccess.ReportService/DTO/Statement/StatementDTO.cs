using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "Statement")]
    public class StatementDTO
    {
        public string StatementDate { get; set; }
        public string PayByWeb { get; set; }
        public string PayByPhoneNumber { get; set; }
        public PracticeDTO Practice { get; set; }
        public RemitAddressDTO RemitAddress { get; set; }
        public PatientStatementDTO Patient { get; set; }
        public GuarantorDTO Guarantor { get; set; }
        public List<TransactionDTO> Transactions { get; set; }
        public AgingBalancesDTO AgingBalances { get; set; }
        public string RemitMessage { get; set; }
        public string Note { get; set; }
        public decimal AmountPatientDue { get; set; }        
        public string DueDate { get; set; }
    }
}
