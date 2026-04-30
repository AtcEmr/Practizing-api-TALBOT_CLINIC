using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IClaimStatusInquiryChildRepository
    {
        Task AddNew(IEnumerable<IClaimStatusInquiryChild> entities);
    }
}
