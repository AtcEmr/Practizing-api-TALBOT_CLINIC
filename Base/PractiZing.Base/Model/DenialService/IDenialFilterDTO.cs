using PractiZing.Base.Object.DenialService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.DenialService
{
    public interface IDenialFilterDTO
    {
        string Header { get; set; }
        IEnumerable<IDenialManagementDTO> DenialManagementDTOs { get; set; }
    }
}
