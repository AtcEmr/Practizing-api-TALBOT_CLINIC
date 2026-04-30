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
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ClearingHouseRepository : ModuleBaseRepository<ClearingHouse>, IClearingHouseRepository
    {
        public ClearingHouseRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IClearingHouse>> Get()
        {
            return (await this.Connection.SelectAsync<ClearingHouse>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true))
                                         .OrderBy(i => i.Name);
        }

        public async Task<IClearingHouse> GetById(int id)
        {
            return await this.Connection.SingleAsync<ClearingHouse>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClearingHouse> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<ClearingHouse>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClearingHouse> GetByName(string name)
        {
            return await this.Connection.SingleAsync<ClearingHouse>(i => i.Name == name && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClearingHouse> AddNew(IClearingHouse entity)
        {
            try
            {
                ClearingHouse tEntity = entity as ClearingHouse;

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

        public async Task<int> Update(IClearingHouse entity)
        {
            try
            {
                ClearingHouse tEntity = entity as ClearingHouse;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ClearingHouse>()
                                           .Update(x => new
                                           {
                                               x.Name,
                                               x.SENDER_ID,
                                               x.RECVR_ID,
                                               x.SENDERCODE,
                                               x.RECVRCODE,
                                               x.RCV_IDCODE,
                                               x.SENDERTYPE,
                                               x.RECVRTYPE,
                                               x.AuthorizationInformationQualifier,
                                               x.AuthorizationInformation,
                                               x.SecurityInformationQualifier,
                                               x.SecurityInformation,
                                               x.BillingContactFirstName,
                                               x.BillingContactLastName,
                                               x.BillingContactMiddle,
                                               x.BillingContactPhoneNumber,
                                               x.ReasonForWriteOff,
                                               x.Format,
                                               x.UserName,
                                               x.Password,
                                               x.Host,
                                               x.HostPort,
                                               x.WorkingDirectory,
                                               x.AcknowledgementRequested,
                                               x.TestMode,
                                               x.ClaimDirectory,
                                               x.ClaimExtension,
                                               x.ERAExtension,
                                               x.AckDirectory,
                                               x.AckExtension,
                                               x.ERADirectory,
                                               x.TransactionType
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<ClearingHouse>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateClaimBatchTransactionNumber(IClearingHouse entity)
        {
            try
            {
                ClearingHouse tEntity = entity as ClearingHouse;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ClearingHouse>()
                                           .Update(x => new
                                           {
                                               x.ClaimBatchNumber
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateTransactionNumber(IClearingHouse entity)
        {
            try
            {
                ClearingHouse tEntity = entity as ClearingHouse;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ClearingHouse>()
                                           .Update(x => new
                                           {
                                               x.TransactionNumber
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClearingHouse>> GetForOHIOUI()
        {
            return await this.Connection.SelectAsync<ClearingHouse>(i => i.Id != 2 && i.PracticeId == LoggedUser.PracticeId);
        }
    }
}
