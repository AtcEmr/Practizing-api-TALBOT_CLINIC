using PractiZing.Base.Object.DenialService;
using System.Collections.Generic;

namespace PractiZing.DataAccess.DenialService.Object
{
    public class AssignedFollowUpDTO : IAssignedFollowUpDTO
    {
        public int UnAssignedCount { get; set; }
        public int AssignedToMeCount { get; set; }
        public int AssignedToOthersCount { get; set; }
        public int FollowUpCount { get; set; }
    }
}
