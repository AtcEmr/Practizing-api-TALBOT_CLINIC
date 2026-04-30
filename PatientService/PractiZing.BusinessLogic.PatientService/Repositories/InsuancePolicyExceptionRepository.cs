using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.PatientEnums;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X12EDI;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.Base.Object.PatientService;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class InsurancePolicyExceptionRepository : ModuleBaseRepository<InsurancePolicyException>, IInsurancePolicyExceptionRepository
    {

        private readonly ILogger _logger;

        public InsurancePolicyExceptionRepository(ValidationErrorCodes errorCodes,
                                         DataBaseContext dbContext,
                                         ILoginUser loggedUser,
                                         ILoggerFactory loggerFactory) : base(errorCodes, dbContext, loggedUser)
        {

            _logger = loggerFactory.CreateLogger<InsurancePolicyRepository>();
        }

        public async Task AddAll(IEnumerable<IInsurancePolicyException> entities)
        {
            try
            {
                List<InsurancePolicyException> tEntity = entities as List<InsurancePolicyException>;
                await this.DeleteAll();
                await base.AddAllAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            var result = await this.Connection.DeleteAsync<InsurancePolicyException>(i => i.Id == id);
            return result;
        }

        public async Task<int> DeleteByPolicyId(int id)
        {
            var result = await this.Connection.DeleteAsync<InsurancePolicyException>(i => i.PolicyId== id);
            return result;
        }

        public async Task<int> DeleteAll()
        {
            var result = await this.Connection.DeleteAsync<InsurancePolicyException>(i=>i.CreatedDate<DateTime.Now.AddDays(-1));
            return result;
        }
    }
}
