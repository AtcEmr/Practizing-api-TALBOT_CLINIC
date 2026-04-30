using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.SecurityService.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using PractiZing.Base.Entities.MasterService;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Linq;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class AdjustmentReasonCodeRepository : ModuleBaseRepository<AdjustmentReasonCode>, IAdjustmentReasonCodeRepository
    {
        private IConfigAdjustmentReasonCodeRepository _configAdjustmentReasonCodeRepository;
        public AdjustmentReasonCodeRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser, IConfigAdjustmentReasonCodeRepository configAdjustmentReasonCodeRepository)
          : base(errorCodes, dbContext, loggedUser)
        {
            this._configAdjustmentReasonCodeRepository = configAdjustmentReasonCodeRepository;
        }

        public async Task<IAdjustmentReasonCode> AddNew(IAdjustmentReasonCode entity)
        {
            try
            {
                AdjustmentReasonCode tEntity = entity as AdjustmentReasonCode;
                tEntity.PracticeId = LoggedUser.PracticeId;
                tEntity.IsActive = true;

                var checkGroupCode = await this._configAdjustmentReasonCodeRepository.GetByReasonCode(tEntity.GroupCode, tEntity.Code);
                if (checkGroupCode != null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodesAlreadyExists, tEntity.Code, tEntity.GroupCode]));

                //var checkCode = await this.Connection.SingleAsync<AdjustmentReasonCode>(i => i.PracticeId == LoggedUser.PracticeId && i.Code == tEntity.Code && i.GroupCode == tEntity.GroupCode);
                //if (checkCode != null)
                //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodesAlreadyExists, tEntity.Code, tEntity.GroupCode]));

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

        public async Task<IEnumerable<IAdjustmentReasonCode>> Get(string reasonCode)
        {
            reasonCode = reasonCode == null ? string.Empty : reasonCode;
            return (await this.Connection.SelectAsync<AdjustmentReasonCode>(i => i.IsActive == true && i.PracticeId == LoggedUser.PracticeId && (reasonCode == "" || i.Code.Contains(reasonCode)) || (reasonCode == "" || i.GroupCode.Contains(reasonCode)))).OrderBy(i => i.Code);
        }

        public async Task<IAdjustmentReasonCode> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<AdjustmentReasonCode>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> Update(IAdjustmentReasonCode entity)
        {
            try
            {
                AdjustmentReasonCode tEntity = entity as AdjustmentReasonCode;

                var checkGroupCode = await this._configAdjustmentReasonCodeRepository.GetByReasonCode(tEntity.GroupCode, tEntity.Code);

                if (checkGroupCode != null)
                {
                    if (tEntity.Id + 9000 != checkGroupCode.Id)
                        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodesAlreadyExists, tEntity.Code, tEntity.GroupCode]));
                }

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<AdjustmentReasonCode>()
                                           .Update(x => new
                                           {
                                               x.Code,
                                               x.Description,
                                               x.GroupCode,
                                               x.IsDenailCode,
                                               x.IsForWriteOff,
                                               x.IsActive
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }
    }
}
