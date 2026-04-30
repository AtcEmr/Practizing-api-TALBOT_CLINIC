using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;

using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class DenialCategoryRepository : ModuleBaseRepository<DenialCategory>, IDenialCategoryRepository
    {
        private readonly IDenialCategoryReasonCodeRepository _denialCategoryReasonCodeRepository;
        public DenialCategoryRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser, IDenialCategoryReasonCodeRepository denialCategoryReasonCodeRepository )
                                    : base(errorCodes, dbContext, loggedUser)
        {
            _denialCategoryReasonCodeRepository = denialCategoryReasonCodeRepository;
        }

        public async Task<IEnumerable<IDenialCategory>> GetAll()
        {
            var query = this.Connection.From<DenialCategory>()
                                  .Join<DenialCategory, DenialCategoryReasonCode>((d, dc) => d.Id == dc.DenialCategoryId)                                  
                                  .Select<DenialCategory, DenialCategoryReasonCode>((d,dc) => new
                                  {
                                      d.UId,
                                      d.DenialCategoryName,

                                      d.Id,
                                      ReasonCode = dc.ReasonCode
                                      
                                  })
                                  .OrderBy<DenialCategory>(j => j.DenialCategoryName);

            
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var denialCategories = Mapper<DenialCategory>.MapList(queryResult);
            var result = denialCategories.GroupBy(d => d.UId).Select(g => new DenialCategory
            {
                UId = g.FirstOrDefault().UId,
                Id = g.FirstOrDefault().Id,
                DenialCategoryName = g.FirstOrDefault().DenialCategoryName,
                
                ReasonCodes = string.Join(",", g.Select(i => i.ReasonCode)).Split(",")
            });
            return result;
        }
        

        public async Task<IDenialCategory> AddNew(IDenialCategory entity)
        {
            try
            {
                DenialCategory tEntity = entity as DenialCategory;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewAsync(tEntity);
                List<DenialCategoryReasonCode> denialCategoryReasonCodes = CreateDenialCategoryReasonCodes(tEntity, result.Id);

                await this._denialCategoryReasonCodeRepository.AddEntities(denialCategoryReasonCodes);
                return result;
            }
            catch
            {
                throw;
            }
        }

        private static List<DenialCategoryReasonCode> CreateDenialCategoryReasonCodes(DenialCategory tEntity, int denialCategoryId)
        {
            List<DenialCategoryReasonCode> denialCategoryReasonCodes = new List<DenialCategoryReasonCode>();
            foreach (var item in tEntity.ReasonCodes)
            {
                DenialCategoryReasonCode denialCategoryReason = new DenialCategoryReasonCode();
                denialCategoryReason.ReasonCode = item;
                denialCategoryReason.DenialCategoryId = denialCategoryId;
                denialCategoryReasonCodes.Add(denialCategoryReason);
            }

            return denialCategoryReasonCodes;
        }

        public async Task<int> Update(IDenialCategory entity)
        {
            try
            {
                DenialCategory tEntity = entity as DenialCategory;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection.From<DenialCategory>()
                                                        .Update(x => new
                                                        {
                                                           x.DenialCategoryName
                                                        })
                                                        .Where<DenialCategory>(i => i.UId == entity.UId);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                List<DenialCategoryReasonCode> denialCategoryReasonCodes = CreateDenialCategoryReasonCodes(tEntity, tEntity.Id);

                await this._denialCategoryReasonCodeRepository.DeleteAllByActionCategory(Convert.ToInt32(tEntity.Id));

                await this._denialCategoryReasonCodeRepository.AddEntities(denialCategoryReasonCodes);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid UId)
        {
            try
            {
                var denialCategoryId = await base.GetId<DenialCategory>(UId, false);
                await this._denialCategoryReasonCodeRepository.DeleteAllByActionCategory(Convert.ToInt32(denialCategoryId));
                var result = await this.Connection.DeleteAsync<DenialCategory>(i => i.Id == Convert.ToInt32(denialCategoryId));
                return result;
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(DenialCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var denialCategories = await this.Connection.SelectAsync<DenialCategory>(i => i.DenialCategoryName.ToLower().Trim() == tEntity.DenialCategoryName.ToLower().Trim()
                                                                          && i.PracticeId == LoggedUser.PracticeId);
            if (denialCategories.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DenialCategoryNameAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(DenialCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var denialCategories = await this.Connection.SelectAsync<DenialCategory>(i => i.DenialCategoryName.ToLower().Trim() == tEntity.DenialCategoryName.ToLower().Trim()
                                                                          && i.PracticeId == LoggedUser.PracticeId && i.UId != tEntity.UId);
            if (denialCategories.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DenialCategoryNameAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);
            return errors;
        }

    }
}
