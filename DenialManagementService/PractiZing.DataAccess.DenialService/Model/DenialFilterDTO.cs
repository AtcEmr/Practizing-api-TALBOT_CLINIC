using PractiZing.Base.Model.DenialService;
using PractiZing.Base.Object.DenialService;
using PractiZing.DataAccess.DenialService.Object;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.DenialService.Model
{
    public class DenialFilterDTO : IDenialFilterDTO
    {
        public DenialFilterDTO()
        {
            this.DenialManagementDTOs = new List<DenialManagementDTO>();
        }

        public string Header { get; set; }
        public IEnumerable<IDenialManagementDTO> DenialManagementDTOs { get; set; }
    }
}
