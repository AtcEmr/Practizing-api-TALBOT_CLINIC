using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChasePaymentChild
    {
        int Id { get; set; }
        int ChasePaymentId { get; set; }
        int BankReconciliationId { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}
