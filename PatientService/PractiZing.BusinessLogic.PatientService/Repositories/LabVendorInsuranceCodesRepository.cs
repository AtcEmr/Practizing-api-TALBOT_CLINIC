using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class LabVendorInsuranceCodesRepository : ModuleBaseRepository<LabVendorInsuranceCodes>, ILabVendorInsuranceCodesRepository
    {

        public LabVendorInsuranceCodesRepository(ValidationErrorCodes errorCodes,
                                                 DataBaseContext dbContext,
                                                 ILoginUser loggedUser
                                                 ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<int> DeleteByInsuranceCompanyId(int insuranceCompanyId)
        {
            try
            {
                 return await this.Connection.DeleteAsync<LabVendorInsuranceCodes>(i => i.InsuranceCompanyID == insuranceCompanyId);
            }
            catch
            {
                throw;
            }
        }
    }
}
