using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;
using PractiZing.DataAccess.DenialService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.DenialService.Repositories
{
    public class ARGroupReasonCodeRepository : ModuleBaseRepository<ARGroupReasonCode>, IARGroupReasonCodeRepository
    {
        public ARGroupReasonCodeRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IARGroupReasonCode> AddNew(IARGroupReasonCode entity)
        {
            try
            {
                ARGroupReasonCode tEntity = entity as ARGroupReasonCode;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewEntity(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ARGroupReasonCode>(i => i.Id == id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IARGroupReasonCode>> Get()
        {

            var result = (await this.Connection.SelectAsync<ARGroupReasonCode>())
                        .OrderBy(i => i.ReasonCode);
            return result;
        }

        public async Task<IARGroupReasonCode> Get(int id)
        {
            var result = await this.Connection.SingleAsync<ARGroupReasonCode>(i => i.Id == id
                                                                     );
            return result;
        }

        public async Task<int> Update(IARGroupReasonCode entity)
        {
            try
            {
                ARGroupReasonCode tEntity = entity as ARGroupReasonCode;

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ARGroupReasonCode>()
                                       .Update(x => new
                                       {
                                           x.ARGroupId,
                                           x.ReasonCode
                                       })
                                       .Where(i => i.Id == entity.Id);

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