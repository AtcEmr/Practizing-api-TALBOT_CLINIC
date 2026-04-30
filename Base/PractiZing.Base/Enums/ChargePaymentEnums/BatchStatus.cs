using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
    public enum BatchStatus
    {
        [Description("Batch doesn't send")]
        NotSend,

        [Description("Batch was sent")]
        Pending,        

        [Description("Batch was successfully delivered")]
        Success,

        [Description("Batch is in process")]
        InProcess,

        [Description("Batch was delivered with errors")]
        Error
    }
}
