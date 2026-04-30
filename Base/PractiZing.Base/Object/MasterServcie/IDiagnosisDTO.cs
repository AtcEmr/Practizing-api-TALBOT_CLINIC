using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IDiagnosisDTO
    {
        string Code { get; set; }
        string Description { get; set; }
        bool IsExistInFavouriteList { get; set; }
        int? IcdClassification { get; set; }
    }
}
