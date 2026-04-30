using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IClaimTotalRepository
    {
        Task<IEnumerable<IClaimTotal>> GetAll();
        Task<IClaimTotal> GetById(int id);
        Task<IEnumerable<IClaimTotal>> GetByClaimId(int id, long pageNumber);
        Task<IClaimTotal> AddNew(IClaimTotal entity);
        Task<int> Update(IClaimTotal entity);
        Task<int> Delete(int id);
        Task<int> DeleteByClaimId(int claimId);
        Task<int> DeleteByClaimId(int[] claimIds);
    }
}
