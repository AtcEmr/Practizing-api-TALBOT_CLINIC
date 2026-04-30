using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IDefaultReasonCodeRepository
    {
        Task<IEnumerable<IDefaultReasonCode>> GetAll();
    }
}
