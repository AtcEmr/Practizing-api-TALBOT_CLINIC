using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeBatchTabsCount : IChargeBatchTabsCount
    {
        public ChargeBatchTabsCount()
        {
            this.Charge = new List<Charges>();
        }

        public long AllCount { get; set; }
        public long ClaimNotMadeCount { get; set; }
        public long ClaimNotSentCount { get; set; }
        public long ClaimSentCount { get; set; }
        public long AllPatientCount { get; set; }
        public long ClaimNotMadePatientCount { get; set; }
        public long ClaimNotSentPatientCount { get; set; }
        public long ClaimSentPatientCount { get; set; }
        public long ChargeHasErrorCount { get; set; }
        public long ChargeHasErrorPatientCount { get; set; }
        public long ChargeBillableCount { get; set; }
        public long ChargeBillablePatientCount { get; set; }
        public long ChargeRolledUpCount { get; set; }
        public long ChargeRolledUpPatientCount { get; set; }
        public long ChargeSelfPayCount { get; set; }
        public long ChargeSelfPayPatientCount { get; set; }
        public long ChargeRejctedCount { get; set; }
        public long ChargeRejctedPatientCount { get; set; }

        public long ClaimErrorCount { get; set; }
        public long ClaimErrorPatientCount { get; set; }

        public long SecondaryChargeCount { get; set; }
        public long SecondaryChargePatientCount { get; set; }

        public IEnumerable<ICharges> Charge { get; set; }
        public IEnumerable<ICharges> SecondaryCharge { get; set; }
    }
}
