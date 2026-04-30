using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.DenialService
{
    public interface IDenialManagementFilterDTO
    {
        IDenialFilterDTO DenialManagements { get; set; }
        IDenialManagementInsuranceTypeFilterDTO DenialManagementsByCompany { get; set; }
        IDenailForAdjustmentFilter DenialManagementsByAdjustments { get; set; }
        IDenialManagementInsuranceTypeFilterDTO DenialManagementsByCompanyType { get; set; }
        IDenialFilterDTO DenialManagementsByDenialQueue { get; set; }
        int IsFilterTrue { get; set; }
    }
}
