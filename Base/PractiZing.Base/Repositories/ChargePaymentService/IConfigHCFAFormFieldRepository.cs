using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IConfigHCFAFormFieldRepository
    {
        Task<IEnumerable<IConfigHCFAFormField>> Get(string insuranceCompanyUId);
        Task<IConfigHCFAFormField> GetByInsuranceCompanyUId(string insuranceCompanyUId);
        Task<IEnumerable<IConfigHCFAFormField>> GetAllByInsuranceCompanyUId(int insuranceCompanyId, int insuranceCompanyTypeId, string insuranceCompanyUId, bool IsAddNew);
        Task<IConfigHCFAFormField> AddNew(IConfigHCFAFormField entity);
        Task<int> Update(IConfigHCFAFormField entity);
        Task<int> Delete(int InsuranceCompanyOrTypeId);
    }
}
