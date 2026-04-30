using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public sealed class InsuranceService : IInsuranceService
    {
        private readonly ICharges _charge;
        //private readonly IClaim _claim;

        #region Properties
        public string Suppl => _charge.NDCCode;

        public string Emg => _charge.EMG;
        //_charge.RenderingProvider != null && _charge.RenderingProvider.Details.GrpType != GrpType.None ? Enum.GetName(typeof(GrpType), _charge.RenderingProvider.Details.GrpType) : null;

        public string LocalA => _grp;

        public int DateOfServiceFromMonth => _charge.BillFromDate.Month;

        public int DateOfServiceFromDay => _charge.BillFromDate.Day;

        public int DateOfServiceFromYear => _charge.BillFromDate.Year;

        public int DateOfServiceToMonth => _charge.BillToDate.Month;

        public int DateOfServiceToDay => _charge.BillToDate.Day;

        public int DateOfServiceToYear => _charge.BillToDate.Year;

        public string PlaceOfService => _charge.POSId;

        public string Type => _charge.TOSDescription;

        public string Cpt => _charge.CPTCode;

        public string Mod => _charge.Mod1;

        public string ModA => _charge.Mod2;

        public string ModB => _charge.Mod3;

        public string ModC => _charge.Mod4;

        public string Diag => _charge.DiagnoseCode;


        public decimal Charge => _charge.Amount;

        public uint Quantity => Convert.ToUInt16(_charge.Qty);

        public string Description => _charge.Description;

        public string Plan => null;

        //public string Local => _claim.BillingFacilityNPI;
        public string Local => _billingFacilityNPI;

        public string RevCode => _charge.CPTCode;
        #endregion Properties

        private string _grp;
        private string _billingFacilityNPI;

        public InsuranceService(ICharges charge, string grp,string billingFacilityNPI)
        {
            _grp = grp;
            _charge = charge;
            _billingFacilityNPI = billingFacilityNPI;

        }
    }
}
