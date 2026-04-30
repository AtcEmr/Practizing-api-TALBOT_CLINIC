using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface ICPTModifierRepository
    {
        Task<IEnumerable<ICPTModifier>> Get();
        Task<ICPTModifier> Get(Guid uid);
        Task<int> Update(ICPTModifier entity);
        Task<ICPTModifier> AddNew(ICPTModifier entity);
        Task<int> Delete(Guid uId);
        Task<ICPTModifier> GetByCode(string code);
    }
}
