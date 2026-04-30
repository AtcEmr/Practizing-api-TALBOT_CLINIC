using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class ChargesForDenialManagementDTO : IChargesForDenialManagementDTO
    {
        public ChargesForDenialManagementDTO()
        {
            this.ChargesAdjustments = new List<Charges>();
            this.ChargesCompany = new List<Charges>();
            this.ChargesDenialQueue = new List<Charges>();
            this.ChargesCompanyType = new List<Charges>();
            this.ChargesFollowUp = new List<Charges>();
        }

        public IEnumerable<ICharges> ChargesCompany { get; set; }
        public IEnumerable<ICharges> ChargesCompanyType { get; set; }
        public IEnumerable<ICharges> ChargesDenialQueue { get; set; }
        public IEnumerable<ICharges> ChargesAdjustments { get; set; }
        public IEnumerable<ICharges> ChargesFollowUp { get; set; }
    }
}
