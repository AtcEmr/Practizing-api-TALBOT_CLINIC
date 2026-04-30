
using PractiZing.Base.Entities.ERAService;
using ServiceStack.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ERAService.Tables
{
    public class ERAClaimChargePayment : IERAClaimChargePayment
    {
        public ERAClaimChargePayment()
        {
            this.Adjustments = new List<ERAClaimChargeAdjustment>();
            this.Remarks = new List<ERAClaimChargeRemark>();
        }
        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public long ERAClaimID { get; set; }

        public long ChgNo { get; set; }

        public string CPTCode { get; set; }

        public string RevenueCode { get; set; }

        public decimal Amount { get; set; }

        public string ServiceDate { get; set; }

        public decimal ChargeAmount { get; set; }
        public string ErrorLog { get; set; }

        [Ignore]
        public string RemarkCodes { get; set; }
        [Ignore]
        public string AdjustmentCodes { get; set; }
        [Ignore]
        public decimal AdjustmentAmount { get; set; } 
        [Ignore]
        public decimal CoPay { get; set; }
        [Ignore]
        public decimal AllowedDed { get; set; }
        [Ignore]
        public decimal CoIns { get; set; }
        [Ignore]
        public decimal LastFilled { get; set; }
        [Ignore]
        public decimal TotalBilledAmount { get; set; }
        [Ignore]
        public decimal TotalAllowedDed { get; set; }
        [Ignore]
        public decimal TotalCoPay { get; set; }
        [Ignore]
        public decimal TotalCoIns { get; set; }
        [Ignore]
        public decimal TotalLastFilled { get; set; }
        [Ignore]
        public decimal TotalAdjustments { get; set; }
        [Ignore]
        public decimal TotalPrevPaid { get; set; }
        [Ignore]
        public decimal Deductible { get; set; }

        [Ignore]
        public IEnumerable<IERAClaimChargeAdjustment> Adjustments { get; set; }

        [Ignore]
        public IEnumerable<IERAClaimChargeRemark> Remarks { get; set; }

    }
}
