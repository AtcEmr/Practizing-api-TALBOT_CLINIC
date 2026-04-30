using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.DenialService.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Model
{
    public class DenialManagementFilterDTO : IDenialManagementFilterDTO
    {
        public DenialManagementFilterDTO()
        {
            this.DenialManagements = new DenialFilterDTO();
            this.DenialManagementsByCompany = new DenialManagementInsuranceTypeFilterDTO();
            this.DenialManagementsByAdjustments = new DenailForAdjustmentFilter();
            this.DenialManagementsByCompanyType = new DenialManagementInsuranceTypeFilterDTO();
            this.DenialManagementsByDenialQueue = new DenialFilterDTO();
        }

        public IDenialFilterDTO DenialManagements { get; set; }
        public IDenialManagementInsuranceTypeFilterDTO DenialManagementsByCompany { get; set; }
        public IDenailForAdjustmentFilter DenialManagementsByAdjustments { get; set; }
        public IDenialManagementInsuranceTypeFilterDTO DenialManagementsByCompanyType { get; set; }
        public IDenialFilterDTO DenialManagementsByDenialQueue { get; set; }
        public int IsFilterTrue { get; set; }
    }
}
