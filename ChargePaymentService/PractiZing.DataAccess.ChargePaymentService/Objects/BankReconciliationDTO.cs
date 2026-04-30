using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class BankReconciliationDTO : IBankReconciliationDTO
    {
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal? ClinicTotalPayment { get; set; }
        public decimal? LabTotalPayment { get; set; }
        public decimal? ResTotalPayment { get; set; }
    }
    
}
