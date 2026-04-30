using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    internal sealed class InsuranceService
    {
        #region Properties
     
        internal string Suppl { get; private set; }

     
        internal string Emg { get; private set; }

     
        internal string LocalA { get; private set; }

     
        internal string DateOfServiceFromMonth { get; private set; }
     
        internal string DateOfServiceFromDay { get; private set; }
     
        internal int DateOfServiceFromYear { get; private set; }

     
        internal string DateOfServiceToMonth { get; private set; }
     
        internal string DateOfServiceToDay { get; private set; }
     
        internal int DateOfServiceToYear { get; private set; }

     
        internal string PlaceOfService { get; private set; }

        //[SingleFormFieldTemplatedName(template: "topmostSubform[0].Page1[0].type{0}[0]")]
        //internal string Type { get; private set; }

     
        internal string Cpt { get; private set; }

     
        internal string Mod { get; private set; }
     
        internal string ModA { get; private set; }
     
        internal string ModB { get; private set; }
     
        internal string ModC { get; private set; }

     
        internal string Diag { get; private set; }

     
        internal string Charge { get; private set; }

     
        internal uint Quantity { get; private set; }
     
        internal string Plan { get; private set; }

     
        internal string Local { get; private set; }
        #endregion Properties

        internal InsuranceService(IInsuranceService data)
        {
            Suppl = data.Suppl;
            Emg = data.Emg;
            LocalA = data.LocalA;
            DateOfServiceFromMonth = data.DateOfServiceFromMonth.ToString("D2");
            DateOfServiceFromDay = data.DateOfServiceFromDay.ToString("D2");
            DateOfServiceFromYear = data.DateOfServiceFromYear % 100;
            DateOfServiceToMonth = data.DateOfServiceToMonth.ToString("D2");
            DateOfServiceToDay = data.DateOfServiceToDay.ToString("D2");
            DateOfServiceToYear = data.DateOfServiceToYear % 100;
            PlaceOfService = data.PlaceOfService;
            //Type = data.Type;
            Cpt = data.Cpt;
            Mod = data.Mod;
            ModA = data.ModA;
            ModB = data.ModB;
            ModC = data.ModC;
            Diag = data.Diag;

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = " ";
            nfi.CurrencySymbol = "";
            nfi.CurrencyGroupSeparator = "";

            Charge = data.Charge.ToString("C", nfi);
            Quantity = data.Quantity;
            Plan = data.Plan;
            Local = data.Local;
        }
    }
}
