using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IBankReconciliationDTO
    {
        int MonthId { get; set; }
        int YearId { get; set; }
        decimal? ClinicTotalPayment { get; set; }
        decimal? LabTotalPayment { get; set; }
        decimal? ResTotalPayment { get; set; }
    }
}
