using PractiZing.Base.Entities.ERAService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ERAService
{
    public interface IERAClaimRepository
    {
        Task Update(int eraClaimId);
        Task<IEnumerable<IERAClaim>> Get();
        Task<IERAClaim> GetbyId(long id);
        Task<IEnumerable<IERAClaim>> GetbyERARootId(long id);
        Task<int> Update(IERAClaim entity);
        Task<IEnumerable<IERAClaim>> GetbyERARootId(IEnumerable<long> ids);
        Task<IEnumerable<IERAClaim>> GetAllErrorRecords();
        Task<IEnumerable<IERAClaim>> GetbyERARootId_ErroClaims(long id);
        Task<IEnumerable<IERAClaim>> GetbyPaymentIds(IEnumerable<string> paymentIds);
    }
}
