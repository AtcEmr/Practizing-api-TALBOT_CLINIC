using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.DataAccess.ERAService;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ERAService;

namespace PractiZing.BussinessLogic.ERAService.Repositiories
{
    public class ERAClaimRepository : BaseRepository<ERAClaim>, IERAClaimRepository
    {
        public ERAClaimRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IERAClaim>> Get()
        {
            return await this.Connection.SelectAsync<ERAClaim>();
        }

        public async Task<IERAClaim> GetbyId(long id)
        {
            return await this.Connection.SingleAsync<ERAClaim>(i => i.Id == id);
        }

        public async Task<IEnumerable<IERAClaim>> GetbyERARootId(long id)
        {
            return await this.Connection.SelectAsync<ERAClaim>(i => i.ERARootID == id);
        }

        public async Task<IEnumerable<IERAClaim>> GetbyERARootId(IEnumerable<long> ids)
        {
            return await this.Connection.SelectAsync<ERAClaim>(i => ids.Contains(i.ERARootID));
        }

        public async Task<IEnumerable<IERAClaim>> GetbyPaymentIds(IEnumerable<string> paymentIds)
        {
            var query = this.Connection.From<ERAClaim>()
                       .LeftJoin<ERAClaim, Claim>((e, c) => e.PatientControlNumber == c.PatientAccountNumber && e.PaymentUID != null)
                       .SelectDistinct<ERAClaim, Claim>((ec, clm) => new
                       {
                           ec,
                           ClaimLevel = clm.InsLevel

                       }).Where<ERAClaim>(i => paymentIds.ToList().Contains(i.PaymentUID));                    

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ERAClaim>.MapList(queryResult);
            
            return result;
            //return await this.Connection.SelectAsync<ERAClaim>(i => paymentIds.ToString().Contains(i.PaymentUID));
        }

        public async Task<int> Update(IERAClaim entity)
        {
            try
            {
                ERAClaim tEntity = entity as ERAClaim;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ERAClaim>()
                                           .Update(x => new
                                           {
                                               x.ErrorLog
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(int eraClaimId)
        {
            try
            {
                ERAClaim tEntity = await this.GetbyId(eraClaimId) as ERAClaim;
                tEntity.StatusId = (int)StatusEnum.FileInserted;
                tEntity.IsReprocessRecord = true;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ERAClaim>()
                                           .Update(x => new
                                           {
                                               x.StatusId,
                                               x.IsReprocessRecord
                                           })
                                           .Where(i => i.Id == tEntity.Id);

                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IERAClaim>> GetAllErrorRecords()
        {
            return await this.Connection.SelectAsync<ERAClaim>(i => i.StatusId == 3);
        }

        public async Task<IEnumerable<IERAClaim>> GetbyERARootId_ErroClaims(long id)
        {
            return await this.Connection.SelectAsync<ERAClaim>(i => i.ERARootID == id && i.StatusId == 3);
        }
    }
}
