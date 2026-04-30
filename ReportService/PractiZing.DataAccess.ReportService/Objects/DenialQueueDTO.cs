using PractiZing.Base.Object.DenialService;
using PractiZing.Base.Object.ReportService;
using PractiZing.DataAccess.DenialService.Object;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ReportService.Objects
{
    public class DenialQueueDTO : IDenialQueueDTO
    {
        public DenialQueueDTO()
        {
            this.AssignedFollowUpDTO = new AssignedFollowUpDTO();
            this.DenialStatDTO = new List<DenialStatDTO>();
        }

        public IEnumerable<IDenialStatDTO> DenialStatDTO { get; set; }
        public IAssignedFollowUpDTO AssignedFollowUpDTO { get; set; }
    }
}
