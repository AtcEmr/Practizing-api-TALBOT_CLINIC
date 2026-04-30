using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ARSCategoryReasonCodeRepository : ModuleBaseRepository<ARSCategoryReasonCode>, IARSCategoryReasonCodeRepository
    {
        public ARSCategoryReasonCodeRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IARSCategoryReasonCode>> GetAll(string reasonCode = "")
        {
            reasonCode = reasonCode ?? string.Empty;
            return (await this.Connection.SelectAsync<ARSCategoryReasonCode>(i => (reasonCode == "" || i.ReasonCode.Contains(reasonCode)))).OrderBy(i => i.ReasonCode);
        }

        public async Task<IEnumerable<IARSCategoryReasonCode>> GetByUId(IEnumerable<long> Ids)
        {
            return await this.Connection.SelectAsync<ARSCategoryReasonCode>(i => Ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IARSCategoryReasonCode> GetById(long Id)
        {
            return await this.Connection.SingleAsync<ARSCategoryReasonCode>(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IARSCategoryReasonCode> AddNew(IARSCategoryReasonCode entity)
        {
            try
            {
                ARSCategoryReasonCode tEntity = entity as ARSCategoryReasonCode;

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

        public async Task AddEntities(IEnumerable<IARSCategoryReasonCode> entities, int noteCategoryId)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.NotesCategoryId = noteCategoryId;
                    await this.AddNew(item);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IARSCategoryReasonCode entity)
        {
            try
            {
                ARSCategoryReasonCode tEntity = entity as ARSCategoryReasonCode;

                var updateOnlyFields = this.Connection
                                           .From<ARSCategoryReasonCode>()
                                           .Update(x => new
                                           {
                                               x.NotesCategoryId,
                                               x.ReasonCode
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateEntities(IEnumerable<IARSCategoryReasonCode> entities, int noteCategoryId)
        {
            try
            {
                foreach (var item in entities)
                {
                    item.NotesCategoryId = noteCategoryId;
                    if (item.Id == 0 && !item.IsReasonCodeDeleted)
                        await this.AddNew(item);
                    else
                        await this.DeleteByReasonCode(noteCategoryId, item.ReasonCode);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(long id)
        {
            try
            {
                return await this.Connection.DeleteAsync<ARSCategoryReasonCode>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> DeleteByReasonCode(long notesCategoryId, string reasonCode)
        {
            try
            {
                return await this.Connection.DeleteAsync<ARSCategoryReasonCode>(i => i.NotesCategoryId == notesCategoryId
                                                                                  && i.ReasonCode == reasonCode
                                                                                  && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ARSCategoryReasonCode tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            if (string.IsNullOrEmpty(tEntity.ReasonCode))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ReasonCodeCannotBeNullOrEmpty]));

            var codes = await this.Connection.SelectAsync<ARSCategoryReasonCode>(i => i.NotesCategoryId == tEntity.NotesCategoryId
                                                                             && i.ReasonCode.ToLower().Trim() == tEntity.ReasonCode.ToLower().Trim());

            var result = codes.Where(i => i.ReasonCode == tEntity.ReasonCode);
            if (result.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ReasonCodeAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}