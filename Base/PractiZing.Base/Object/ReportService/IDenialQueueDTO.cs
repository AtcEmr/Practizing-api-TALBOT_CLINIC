using PractiZing.Base.Object.DenialService;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ReportService
{
    public interface IDenialQueueDTO
    {
        IEnumerable<IDenialStatDTO> DenialStatDTO { get; set; }
        IAssignedFollowUpDTO AssignedFollowUpDTO { get; set; }
    }
}
