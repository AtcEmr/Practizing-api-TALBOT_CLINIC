using System;
using System.Collections.Generic;
using System.Text;
using PractiZing.Base.Model.ChargePaymentService;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class ClaimAckDTO: IClaimAckDTO
    {
        public int Id { get; set; }
        public string AccessionNumber { get; set; }
        public double TotalBilled { get; set; }
        public DateTime? SentDate { get; set; }
        public int LabClientID { get; set; }
        public int? CaseType { get; set; }
        public int InvoiceId { get; set; }
    }
}
