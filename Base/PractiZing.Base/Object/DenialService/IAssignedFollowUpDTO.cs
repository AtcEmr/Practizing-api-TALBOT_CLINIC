using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.DenialService
{
    public interface IAssignedFollowUpDTO
    {
        int UnAssignedCount { get; set; }
        int AssignedToMeCount { get; set; }
        int AssignedToOthersCount { get; set; }
        int FollowUpCount { get; set; }
    }
}
