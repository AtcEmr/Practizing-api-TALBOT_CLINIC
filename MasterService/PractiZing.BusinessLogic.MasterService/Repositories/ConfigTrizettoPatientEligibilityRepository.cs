using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigTrizettoPatientEligibilityRepository : ModuleBaseRepository<ConfigTrizettoPatientEligibility>, IConfigTrizettoPatientEligibilityRepository
    {
        public ConfigTrizettoPatientEligibilityRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

       
        public async Task<IConfigTrizettoPatientEligibility> GetAll()
        {
            return (await this.Connection.SelectAsync<ConfigTrizettoPatientEligibility>()).FirstOrDefault();
        }


        public async Task<int> UpdateTransactionNumber(IConfigTrizettoPatientEligibility entity)
        {
            try
            {
                ConfigTrizettoPatientEligibility tEntity = entity as ConfigTrizettoPatientEligibility;                                            

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ConfigTrizettoPatientEligibility>()
                                           .Update(x => new
                                           {
                                               x.ISA13CntrlNumber,
                                               x.TRN01
                                           })
                                           .Where<ConfigTrizettoPatientEligibility>(i => i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch
            {
                throw;
            }
        }
    }
}
