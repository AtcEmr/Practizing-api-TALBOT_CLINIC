using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface ILabVendorInsuranceCodesRepository
    {
        Task<int> DeleteByInsuranceCompanyId(int insuranceCompanyId);
    }
}
