using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.DenialService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class DenialManagementScreenDTO : IDenialManagementScreenDTO
    {
        public DenialManagementScreenDTO()
        {
            this.DenialManagements = new List<DenialManagementDTO>();
            this.DenialManagementsByCompany = new List<DenialManagementInsuranceTypeDTO>();
            this.DenialManagementsByAdjustments = new List<DenailForAdjustment>();
            this.DenialManagementsByCompanyType = new List<DenialManagementInsuranceTypeDTO>();
            this.DenialManagementsByDenialQueue = new List<DenialManagementDTO>();
            this.ClaimDetailForDenialDTO = new ClaimDetailForDenialDTO();
        }

        public int TotalClaimCountInDenial { get; set; }
        public decimal TotalClaimAmountInDenial { get; set; }
        public int TotalClaimCountAssignedToMe { get; set; }
        public decimal TotalClaimAmountAssignedToMe { get; set; }
        public decimal TotalFollowUpAmount { get; set; }
        public int TotalFollowUpCount { get; set; }
        public IEnumerable<IDenialManagementDTO> DenialManagements { get; set; }
        public IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementsByCompany { get; set; }
        public IEnumerable<IDenailForAdjustment> DenialManagementsByAdjustments { get; set; }
        public IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementsByCompanyType { get; set; }
        public IEnumerable<IDenialManagementDTO> DenialManagementsByDenialQueue { get; set; }
        public IClaimDetailForDenialDTO ClaimDetailForDenialDTO { get; set; }
    }
}
