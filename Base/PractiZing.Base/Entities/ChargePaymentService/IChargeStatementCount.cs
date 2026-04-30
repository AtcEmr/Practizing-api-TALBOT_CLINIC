using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChargeStatementCount 
    {
        int Id { get; set; }
        int ChargeId { get; set; }
        int StatementCount { get; set; }
        decimal ChargeDueAmount { get; set; }
        DateTime StatementDate { get; set; }
        int PatientStatementId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
