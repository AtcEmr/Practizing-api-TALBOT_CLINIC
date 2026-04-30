using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Common;
using System;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigSupervisionTypeRepository : ModuleBaseRepository<ConfigSupervisionType>, IConfigSupervisionTypeRepository
    {
        public ConfigSupervisionTypeRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser)
                                     : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IConfigSupervisionType>> Get()
        {
            return (await this.Connection.SelectAsync<ConfigSupervisionType>()).OrderBy(i => i.Id);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ConfigSupervisionType tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();            

            //var iCPTModifiers = await this.Connection.SelectAsync<CPTModifier>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim());
            //var entityErrors = await base.ValidateEntity(tEntity);
            //errors.AddRange(entityErrors);
            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ConfigSupervisionType tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            return errors;
        }
    }
}
