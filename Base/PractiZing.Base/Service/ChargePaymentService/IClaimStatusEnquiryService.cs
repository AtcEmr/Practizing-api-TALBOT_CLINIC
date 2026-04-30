using System;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IClaimStatusEnquiryService
    {        
        Task<string> SentClaimStatusInquiry();
    }
}
