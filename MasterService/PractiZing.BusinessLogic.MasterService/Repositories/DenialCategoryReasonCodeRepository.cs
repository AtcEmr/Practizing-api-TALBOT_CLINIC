using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class DenialCategoryReasonCodeRepository : ModuleBaseRepository<DenialCategoryReasonCode>, IDenialCategoryReasonCodeRepository
    {
        public DenialCategoryReasonCodeRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IDenialCategoryReasonCode>> GetAll()
        {
            return (await this.Connection.SelectAsync<DenialCategoryReasonCode>());
        }

        public async Task<bool> AddEntities(IEnumerable<IDenialCategoryReasonCode> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    await this.AddNew(item);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IDenialCategoryReasonCode> AddNew(IDenialCategoryReasonCode entity)
        {
            try
            {
                DenialCategoryReasonCode tEntity = entity as DenialCategoryReasonCode;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IDenialCategoryReasonCode entity)
        {
            try
            {
                DenialCategoryReasonCode tEntity = entity as DenialCategoryReasonCode;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection.From<DenialCategoryReasonCode>()
                                                        .Update(x => new
                                                        {
                                                           x.ReasonCode
                                                        })
                                                        .Where<DenialCategoryReasonCode>(i => i.DenialCategoryId == entity.DenialCategoryId);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEntities(IEnumerable<IDenialCategoryReasonCode> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    await this.Update(item);
                }
                return true;
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
                var result = await this.Connection.DeleteAsync<DenialCategoryReasonCode>(i => i.Id == id);
                return result;
            }
            catch
            {
                throw;
            }
        }
       
        public async Task<int> DeleteAllByActionCategory(int denialCategoryId)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<DenialCategoryReasonCode>(i => i.DenialCategoryId == denialCategoryId);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
