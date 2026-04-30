using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargeInWriteOffRepository : ModuleBaseRepository<ChargeInWriteOff>, IChargeInWriteOffRepository
    {
        
        public ChargeInWriteOffRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                      IConfigERARemarkCodesRepository configERARemarkCodesRepository)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            
        }

        public async Task<IChargeInWriteOff> AddNew(IChargeInWriteOff entity)
        {
            try
            {
                ChargeInWriteOff tEntity = entity as ChargeInWriteOff;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// add list of remark codes.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddAll(IEnumerable<IChargeInWriteOff> entities)
        {
            try
            {
                List<ChargeInWriteOff> tEntity = entities as List<ChargeInWriteOff>;

                await base.AddAllAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateEntity(IEnumerable<IChargeInWriteOff> entities)
        {
            try
            {

                foreach (var item in entities)
                {
                    ChargeInWriteOff tEntity = item as ChargeInWriteOff;
                    tEntity.ModifiedDate = DateTime.Now;
                    tEntity.ModifiedBy = this.LoggedUser.UserName;

                    var updateOnlyFields = this.Connection
                                           .From<ChargeInWriteOff>()
                                           .Update(x => new
                                           {
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.StatusId
                                           })
                                           .Where(i => i.ChargeId == tEntity.ChargeId);

                    await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> Delete(int id)
        {
            var result = await this.Connection.DeleteAsync<ChargeInWriteOff>(i => i.Id==id);
            return result;
        }

        public async Task<IEnumerable<IChargeInWriteOff>> Get()
        {
            var result = await this.Connection.SelectAsync<ChargeInWriteOff>();
            return result;
        }

        public async Task<int> UpdateEntityAsPosted(int Id)
        {
            try
            {

                ChargeInWriteOff tEntity = await this.GetById(Id);
                tEntity.IsPosted = true;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;

                var updateOnlyFields = this.Connection
                                       .From<ChargeInWriteOff>()
                                       .Update(x => new
                                       {
                                           x.ModifiedBy,
                                           x.ModifiedDate,
                                           x.IsPosted
                                       })
                                       .Where(i => i.ChargeId == tEntity.ChargeId);

                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);

                return 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
