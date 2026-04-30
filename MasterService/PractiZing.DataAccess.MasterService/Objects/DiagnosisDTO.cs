using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class DiagnosisDTO : IDiagnosisDTO
    {
        public string Code { get ; set ; }
        public string Description { get ; set ; }
        public bool IsExistInFavouriteList { get; set; }
        public int? IcdClassification { get; set; }
    }
}
