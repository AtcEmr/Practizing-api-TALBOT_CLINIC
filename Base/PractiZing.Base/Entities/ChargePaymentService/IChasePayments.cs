using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IChasePayments
    {
        int Id { get; set; }
        int MonthId { get; set; }
        int YearId { get; set; }
        string Details { get; set; }
        DateTime PostingDate { get; set; }
        string Description { get; set; }
        decimal Amount { get; set; }
        string ChaseType { get; set; }
        decimal? Balance { get; set; }
        string CheckOrSlip { get; set; }
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        decimal? PaymentAmount { get; set; }
        decimal? DiffAmount { get; set; }
        string CheckNumber { get; set; }
        bool IsOwnerDeposit { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
