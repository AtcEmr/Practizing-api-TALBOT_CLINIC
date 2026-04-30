using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public enum ClaimStatusEnum
    {
        CREATED,
        SCRUBBED,
        PROCESSING,
        SENT,
        PRINTED,
        DENIED,
        PASSED,
        POSTED,
        UPDATED
    }
}
