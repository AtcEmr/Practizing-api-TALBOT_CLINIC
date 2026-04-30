using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IFSDiscountRepository
    {
        Task<IEnumerable<IFSDiscount>> GetAll();
        Task<IFSDiscount> GetById(short id);
        Task<IEnumerable<IFSDiscount>> GetCPTDiscount(short fsChargeId, DateTime fromDate, string providerUId, string insuranceCompanyUId);
        Task<IFSDiscount> GetByInsuranceCompanyId(int companyId);
        Task<IEnumerable<IFSDiscount>> GetByChargeId(int chargeId);
        Task<bool> UpdateEntities(IEnumerable<IFSDiscount> entities, short fsChargeId);
        Task<int> Update(IFSDiscount entity);
        Task<bool> AddNewEntities(IEnumerable<IFSDiscount> entities, short fsChargeId);
        Task<int> DeleteDiscountByCharge(short fsChargeId);
        Task<int> Delete(short id);
        Task FeeDiscountEffectiveDate();
        Task FeeDiscountValidation();
        Task ValidateFsDisocunt();
    }
}
