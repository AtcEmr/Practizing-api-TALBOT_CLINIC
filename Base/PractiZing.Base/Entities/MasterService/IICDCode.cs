using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IICDCode : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        int ID { get; set; }

        bool VisitType { get; set; }
        string Code { get; set; }
        string Description { get; set; }
        string DefaultPlan { get; set; }
        bool Common { get; set; }
        string SNOMEDCT { get; set; }
        string CodeSystem { get; set; }
        string ICD_10Code { get; set; }

        bool SendToBilling { get; set; }
        bool ShowInActiveProblems { get; set; }
        bool IsICDAddToFavourite { get; set; }
        int? IcdType { get; set; }
        int? IsChronic { get; set; }
    }
}

