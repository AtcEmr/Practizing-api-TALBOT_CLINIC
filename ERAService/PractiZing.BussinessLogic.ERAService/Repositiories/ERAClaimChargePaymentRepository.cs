using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.DataAccess.ERAService;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.BusinessLogic.Common;

namespace PractiZing.BussinessLogic.ERAService.Repositiories
{
    class ERAClaimChargePaymentRepository : BaseRepository<ERAClaimChargePayment>, IERAClaimChargePaymentRepository

    {
        public ERAClaimChargePaymentRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        
        public async Task<IEnumerable<IERAClaimChargePayment>> GetByClaimId(long[] id)
        {
            return await this.Connection.SelectAsync<ERAClaimChargePayment>(i => id.Contains(i.ERAClaimID));
        }

        public async Task<int> Update(IERAClaimChargePayment entity)
        {
            try
            {
                ERAClaimChargePayment tEntity = entity as ERAClaimChargePayment;
                tEntity.ErrorLog = "No charge exists with this charge no and amount in charge table.";

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ERAClaimChargePayment>()
                                           .Update(x => new
                                           {
                                               x.ErrorLog
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
