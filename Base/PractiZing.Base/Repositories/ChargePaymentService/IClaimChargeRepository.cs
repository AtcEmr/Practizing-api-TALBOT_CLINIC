using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IClaimChargeRepository
    {
        Task<IEnumerable<IClaimCharge>> GetAll();
        Task<IClaimCharge> GetById(int id);
        Task<IClaimCharge> GetByChargeId(int id);
        Task<IClaimCharge> AddNew(IClaimCharge entity);
        Task AddNew(IEnumerable<IClaimCharge> entities);
        Task<int> Update(IClaimCharge entity);
        Task<int> Delete(int id);
        Task<int> DeleteByClaimId(int claimId);
        Task<int> CheckChargeForDelete(int chargeId);
        Task<IEnumerable<ICharges>> GetByClaim(long claimId, long invoiceId, int? pageNumber);
        Task<int> CheckForDelete(int chargeId, bool isDelete);
        Task<IEnumerable<IClaimCharge>> GetByIds(int claimId);
        Task<IEnumerable<ICharges>> GetByClaim(int[] claimIds);
        Task<int> DeleteByChargeId(int chargeId);
        Task<int> DeleteByClaimId(int[] claimIds);
    }
}
