using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ConfigMessageCodeRepository : ModuleBaseRepository<ConfigMessageCode>, IConfigMessageCodeRepository
    {
        public ConfigMessageCodeRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        public async Task<IConfigMessageCode> AddNew(IConfigMessageCode entity)
        {
            try
            {
                ConfigMessageCode tEntity = entity as ConfigMessageCode;
                return await base.AddNewEntity(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string messageCode)
        {
            try
            {
                return await this.Connection.DeleteAsync<ConfigMessageCode>(i => i.MessageCode == messageCode);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IConfigMessageCode>> GetAll()
        {

            return await this.Connection.SelectAsync<ConfigMessageCode>();
                    }

        public async Task<IConfigMessageCode> GetByMessageCode(string messageCode)
        {
            return await this.Connection.SingleAsync<ConfigMessageCode>(i => i.MessageCode == messageCode);            
        }

        public async Task<int> Update(IConfigMessageCode entity)
        {
            try
            {
                ConfigMessageCode tEntity = entity as ConfigMessageCode;

                var updateOnlyFields = this.Connection
                                           .From<ConfigMessageCode>()
                                           .Update(x => new
                                           {
                                               x.Description,
                                               x.DeleteFlag,
                                               x.OnStatements,
                                               x.OnClaims,
                                               x.Available,
                                               x.Category,
                                               x.Task,
                                               x.Visible
                                           })
                                           .Where(i => i.MessageCode == entity.MessageCode);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }
    }
}
