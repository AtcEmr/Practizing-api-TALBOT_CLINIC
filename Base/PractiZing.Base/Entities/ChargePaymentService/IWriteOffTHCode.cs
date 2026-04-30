using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IWriteOffTHCode
    {
        int Id { get; set; }
        int InvoiceId { get; set; }
        DateTime CreatedDate { get; set; }
        bool IsAckNeeded { get; set; }
    }
}
