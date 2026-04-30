using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargeBatchTabsCount
    {
        long AllCount { get; set; }
        long ClaimNotMadeCount { get; set; }
        long ClaimNotSentCount { get; set; }
        long ClaimSentCount { get; set; }
        long AllPatientCount { get; set; }
        long ClaimNotMadePatientCount { get; set; }
        long ClaimNotSentPatientCount { get; set; }
        long ClaimSentPatientCount { get; set; }
        long ChargeHasErrorCount { get; set; }
        long ChargeHasErrorPatientCount { get; set; }
        long ChargeBillableCount { get; set; }
        long ChargeBillablePatientCount { get; set; }
        long ChargeRolledUpCount { get; set; }
        long ChargeRolledUpPatientCount { get; set; }
        long ChargeSelfPayCount { get; set; }
        long ChargeSelfPayPatientCount { get; set; }
        long ClaimErrorCount { get; set; }
        long ClaimErrorPatientCount { get; set; }
        IEnumerable<ICharges> Charge { get; set; }
        IEnumerable<ICharges> SecondaryCharge { get; set; }
        long SecondaryChargeCount { get; set; }
        long SecondaryChargePatientCount { get; set; }
    }
}
