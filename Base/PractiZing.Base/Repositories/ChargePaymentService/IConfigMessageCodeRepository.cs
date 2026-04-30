using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IConfigMessageCodeRepository
    {
        Task<IEnumerable<IConfigMessageCode>> GetAll();
        Task<IConfigMessageCode> GetByMessageCode(string messageCode);
        Task<IConfigMessageCode> AddNew(IConfigMessageCode entity);
        Task<int> Update(IConfigMessageCode entity);
        Task<int> Delete(string messageCode);
    }
}
