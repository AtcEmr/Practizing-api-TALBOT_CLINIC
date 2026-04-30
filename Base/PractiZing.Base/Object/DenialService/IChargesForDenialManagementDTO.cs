using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IChargesForDenialManagementDTO
    {
        IEnumerable<ICharges> ChargesCompany { get; set; }
        IEnumerable<ICharges> ChargesCompanyType { get; set; }
        IEnumerable<ICharges> ChargesDenialQueue { get; set; }
        IEnumerable<ICharges> ChargesAdjustments { get; set; }
        IEnumerable<ICharges> ChargesFollowUp { get; set; }
    }
}
