using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentRemarkCode: ICreatedStamp 
    {
        int Id { get; set; }
        int PaymentChargeId { get; set; }
        string RemarkCode { get; set; }
        string RemarkQualifier { get; set; }
    }
}
