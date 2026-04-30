using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.DenialService
{
    public interface IDenialManagementInsuranceTypeFilterDTO
    {
        string Header { get; set; }
        IEnumerable<IDenialManagementInsuranceTypeDTO> DenialManagementInsuranceTypeDTOs { get; set; }
    }
}
