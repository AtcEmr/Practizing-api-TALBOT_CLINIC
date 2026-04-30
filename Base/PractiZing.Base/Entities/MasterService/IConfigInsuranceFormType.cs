using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigInsuranceFormType : IActive
    {
        Int16 Id { get; set; }
        string FTName { get; set; }
        Int16? MaxDiagnoses { get; set; }
        Int16? MaxServices { get; set; }
        string ImagePath { get; set; }
    }
}
