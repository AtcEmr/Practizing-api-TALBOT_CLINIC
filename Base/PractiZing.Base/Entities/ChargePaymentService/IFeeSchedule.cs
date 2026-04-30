using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IFeeSchedule : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        Int16 Id { get; set; }
        string Name { get; set; }
        Int16? FSLocalityCarrierId { get; set; }

        DateTime ExpiryDate { get; set; }
        IEnumerable<IFSCharge> FSCharges { get; set; }
        DateTime EffectiveDate { get; set; }
    }
}
