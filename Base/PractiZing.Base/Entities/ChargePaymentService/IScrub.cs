using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IScrub
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        int DestinationId { get; set; }
        bool Active { get; set; }

        short Priority { get; set; }
        short Order { get; set; }

        string StoredProcedure { get; set; }

        //bool IsProcedure { get; set; }

        //bool IsPracticeCentral { get; set; }

        //bool IsAutoScrub { get; set; }

        short ScrubStatus { get; set; }
    }
}
