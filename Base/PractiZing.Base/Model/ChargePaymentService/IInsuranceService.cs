using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IInsuranceService
    {
        string Suppl { get; }
        string Emg { get; }
        string LocalA { get; }
        int DateOfServiceFromMonth { get; }
        int DateOfServiceFromDay { get; }
        int DateOfServiceFromYear { get; }
        int DateOfServiceToMonth { get; }
        int DateOfServiceToDay { get; }
        int DateOfServiceToYear { get; }
        string PlaceOfService { get; }
        string Type { get; }
        string Cpt { get; }
        string Mod { get; }
        string ModA { get; }
        string ModB { get; }
        string ModC { get; }
        string Diag { get; }
        decimal Charge { get; }
        uint Quantity { get; }
        string Plan { get; }
        string Local { get; }

        string Description { get; }
        string RevCode { get; }
    }
}
