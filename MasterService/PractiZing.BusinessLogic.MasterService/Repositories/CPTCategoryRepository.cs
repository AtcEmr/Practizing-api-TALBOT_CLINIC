using AutoMapper;
using PractiZing.Base.Common;
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
    public class CPTCategoryRepository : ModuleBaseRepository<CPTCategory>, ICPTCategoryRepository
    {
        private readonly IMapper _mapper;
        public CPTCategoryRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           IMapper mapper
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
        }

        public async Task<ICPTCategory> AddNew(ICPTCategory entity)
        {
            try
            {
                CPTCategory tEntity = entity as CPTCategory;

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

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<CPTCategory>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICPTCategory>> Get()
        {
            var result = (await this.Connection.SelectAsync<CPTCategory>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.CategoryName);
            result.ToList().ForEach(i => i.CategoryName = i.CategoryName.Trim());
            return result;
        }

        public async Task<IEnumerable<ICategoryDDO>> GetCategoryDTO()
        {
            var categories = await this.Connection.SelectAsync<CPTCategory>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true);
            var result = _mapper.Map<List<CategoryDDO>>(categories);
            return result.OrderBy(i => i.CategoryName);
        }

        public async Task<ICPTCategory> Get(short id)
        {
            return await this.Connection.SingleAsync<CPTCategory>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<ICPTCategory> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<CPTCategory>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> Update(ICPTCategory entity)
        {
            try
            {
                CPTCategory tEntity = entity as CPTCategory;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<CPTCategory>()
                                       .Update(x => new
                                       {
                                           x.CategoryName,
                                           x.RevenueCode,
                                           x.Description,
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

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(CPTCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var CPTCategory = await this.Connection.SelectAsync<CPTCategory>(i => (i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim()
                                                                    || i.RevenueCode.ToLower().Trim() == tEntity.RevenueCode.ToLower().Trim())
                                                                    && i.PracticeId == LoggedUser.PracticeId);

            var categoryName = CPTCategory.Where(i => i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim());
            if (categoryName.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CategoryNameAlreadyExists]));

            var revenueCode = CPTCategory.Where(i => i.RevenueCode.ToLower().Trim() == tEntity.RevenueCode.ToLower().Trim());
            if (revenueCode.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.RevenueCodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(CPTCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var _category = await this.Connection.SelectAsync<CPTCategory>(i => (i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim()
                                                                    || i.RevenueCode.ToLower().Trim() == tEntity.RevenueCode.ToLower().Trim())
                                                                    && i.PracticeId == LoggedUser.PracticeId
                                                                    && i.UId != tEntity.UId);

            var categoryName = _category.Where(i => i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim());
            if (categoryName.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CategoryNameAlreadyExists]));

            var revenueCode = _category.Where(i => i.RevenueCode.ToLower().Trim() == tEntity.RevenueCode.ToLower().Trim());
            if (revenueCode.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.RevenueCodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }
    }
}
