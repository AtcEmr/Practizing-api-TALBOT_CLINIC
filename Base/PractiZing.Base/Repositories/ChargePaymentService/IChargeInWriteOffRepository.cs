using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargeInWriteOffRepository
    {
        Task<IChargeInWriteOff> AddNew(IChargeInWriteOff entity);
        Task AddAll(IEnumerable<IChargeInWriteOff> entities);
        Task<int> Delete(int id);
        Task<IEnumerable<IChargeInWriteOff>> Get();
        Task<int> UpdateEntity(IEnumerable<IChargeInWriteOff> entities);
        Task<int> UpdateEntityAsPosted(int Id);
    }
}
