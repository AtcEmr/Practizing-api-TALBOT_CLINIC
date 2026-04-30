using PractiZing.Base.Object.ERAService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ERAService
{
    public interface IERAClaim
    {

        long Id { get; set; }

        long ERARootID { get; set; }

        string PatientControlNumber { get; set; }

        string PatientFirstName { get; set; }

        string PatientLastName { get; set; }

        string PatientMiddleName { get; set; }

        string PolicyNumber { get; set; }

        decimal ClaimPaymentAmount { get; set; }

        string PayerClaimControlNumber { get; set; }

        short ClaimFreqency { get; set; }
        string ErrorLog { get; set; }
        string LastError { get; set; }
        int StatusId { get; set; }
        string PaymentUID { get; set; }
        DateTime ProcessStartTime { get; set; }
        DateTime? ProcessCompleteTime { get; set; }
        bool IsReprocessRecord { get; set; }
        int? ClaimStatusCode { get; set; }
        IERARoot ERARoot { get; set; }

        IEnumerable<IERAClaimChargePayment> Payments { get; set; }

        IClaimChargeTotalDTO ClaimChargeTotalDTO { get; set; }
        Guid PaymentBatchUId { get; set; }
        Guid? PatientUId { get; set; }
        string TempPolicyNumber { get; set; }
        short? ClaimLevel { get; set; }

    }
}
