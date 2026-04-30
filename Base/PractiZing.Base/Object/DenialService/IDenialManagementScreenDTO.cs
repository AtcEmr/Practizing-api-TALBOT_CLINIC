using PractiZing.Base.Model.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IDenialManagementScreenDTO
    {
        int TotalClaimCountInDenial { get; set; }
        decimal TotalClaimAmountInDenial { get; set; }
        int TotalClaimCountAssignedToMe { get; set; }
        decimal TotalClaimAmountAssignedToMe { get; set; }
        decimal TotalFollowUpAmount { get; set; }
        int TotalFollowUpCount { get; set; }

        IEnumerable<IDenialManagementDTO> DenialManagements { get; set; }
        IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementsByCompany { get; set; }
        IEnumerable<IDenailForAdjustment> DenialManagementsByAdjustments { get; set; }
        IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementsByCompanyType { get; set; }
        IEnumerable<IDenialManagementDTO> DenialManagementsByDenialQueue { get; set; }
        IClaimDetailForDenialDTO ClaimDetailForDenialDTO { get; set; }
    }
}
