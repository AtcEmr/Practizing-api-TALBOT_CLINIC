using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Object.ERAService;
using PractiZing.DataAccess.ERAService.Object;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ERAService.Tables
{
    public class ERAClaim : IERAClaim
    {
        public ERAClaim()
        {
            this.Payments = new List<ERAClaimChargePayment>();
            this.ClaimChargeTotalDTO = new ClaimChargeTotalDTO();
            this.ERARoot = new ERARoot();
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public long ERARootID { get; set; }

        public string PatientControlNumber { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public string PatientMiddleName { get; set; }

        public string PolicyNumber { get; set; }

        public decimal ClaimPaymentAmount { get; set; }

        public string PayerClaimControlNumber { get; set; }

        public short ClaimFreqency { get; set; }

        public string ErrorLog { get; set; }

        public string LastError { get; set; }

        public DateTime ProcessStartTime { get; set; }

        public DateTime? ProcessCompleteTime { get; set; }

        public int StatusId { get; set; }
        public string PaymentUID { get; set; }

        public int? ClaimStatusCode { get; set; }

        public bool IsReprocessRecord { get; set; }
        [Ignore]
        public IERARoot ERARoot { get; set; }
        [Ignore]
        public IEnumerable<IERAClaimChargePayment> Payments { get; set; }
        [Ignore]
        public IClaimChargeTotalDTO ClaimChargeTotalDTO { get; set; }
        [Ignore]
        public Guid PaymentBatchUId { get; set; }
        [Ignore]
        public Guid? PatientUId { get; set; }

        [Ignore]
        public string TempPolicyNumber { get; set; }

        [Ignore]
        public short? ClaimLevel { get; set; }
    }
}
