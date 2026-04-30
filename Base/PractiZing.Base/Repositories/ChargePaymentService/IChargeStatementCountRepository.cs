using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargeStatementCountRepository
    {
        Task<bool> AddNew(IEnumerable<IChargeStatementCount> entities);
        Task<IEnumerable<string>> GetList();
    }
}
