using System;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface ICPTCodeFilter
    {
        string CPT { get; set; }
        string Description { get; set; }
        Int16? DefaultQuantity { get; set; }
        string ToS { get; set; } //2 characters long
        byte? RevCode { get; set; }
        bool? IsCPTCodeForClaim { get; set; }
    }
}
