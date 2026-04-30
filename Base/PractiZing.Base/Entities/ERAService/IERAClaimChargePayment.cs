using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ERAService
{
    public interface IERAClaimChargePayment
    {
        long Id { get; set; }

        long ERAClaimID { get; set; }

        long ChgNo { get; set; }

        string CPTCode { get; set; }

        string RevenueCode { get; set; }

        decimal Amount { get; set; }

        string ServiceDate { get; set; }

        decimal ChargeAmount { get; set; }

        string RemarkCodes { get; set; }
        string AdjustmentCodes { get; set; }
        decimal AdjustmentAmount { get; set; }
        string ErrorLog { get; set; }

        IEnumerable<IERAClaimChargeAdjustment> Adjustments { get; set; }

        IEnumerable<IERAClaimChargeRemark> Remarks { get; set; }

        decimal CoPay { get; set; }
        decimal CoIns { get; set; }
        decimal LastFilled { get; set; }
        decimal AllowedDed { get; set; }
        decimal Deductible { get; set; }
    }
}
