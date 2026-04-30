using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IInsurancePolicyExceptionRepository
    {   
        Task AddAll(IEnumerable<IInsurancePolicyException> entities);
        Task<int> Delete(int id);
        Task<int> DeleteByPolicyId(int id);
    }
}
