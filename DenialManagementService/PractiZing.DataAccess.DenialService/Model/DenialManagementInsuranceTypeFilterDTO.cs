using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.DenialService.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Model
{
    public class DenialManagementInsuranceTypeFilterDTO: IDenialManagementInsuranceTypeFilterDTO
    {
        public DenialManagementInsuranceTypeFilterDTO()
        {
            this.DenialManagementInsuranceTypeDTOs = new List<DenialManagementInsuranceTypeDTO>();
        }

        public string Header { get; set; }
        public IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementInsuranceTypeDTOs { get; set; }
    }
}
