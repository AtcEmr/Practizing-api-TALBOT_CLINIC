using Microsoft.AspNetCore.Http;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.DenialService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService;
using PractiZing.DataAccess.DenialService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PractiZing.BusinessLogic.DenialService.Repositories
{
    public class ActionCategoryRepository : ModuleBaseRepository<ActionCategory>, IActionCategoryRepository
    {
        private IAttFileRepository _attFileRepository;
        public ActionCategoryRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           IAttFileRepository attFileRepository
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            _attFileRepository = attFileRepository;
        }

        public async Task<IEnumerable<IActionCategory>> Get(bool forGrid)
        {
            IEnumerable<ActionCategory> result = null;
            if (!forGrid)
                result = (await this.Connection.SelectAsync<ActionCategory>(i => i.PracticeId == LoggedUser.PracticeId && i.ParentCategoryId == null))
                                                                                .OrderBy(i => i.CategoryName);

            else
                result = (await this.Connection.SelectAsync<ActionCategory>(i => i.PracticeId == LoggedUser.PracticeId))
                                                                .OrderBy(i => i.CategoryName);


            foreach (var item in result)
                item.AttFiles = await this._attFileRepository.GetByTableId(item.Id, AttTableConstant.ActionCategory);

            return result;
        }

        public async Task<IActionCategory> Get(int id)
        {
            var result = await this.Connection.SingleAsync<ActionCategory>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            if (result != null)
                result.AttFiles = await this._attFileRepository.GetByTableId(result.Id, AttTableConstant.ActionCategory);
            return result;
        }

        public async Task<IActionCategory> GetById(int id)
        {
            var result = await this.Connection.SingleAsync<ActionCategory>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task ParentCategoryExist(Guid uid)
        {
            var _category = await this.GetSubCategoryByCategoryUId(/*_actionAategory.*/uid);
            if (_category.Count() > 0)
            {
                var errors = await this.ValidateEntityToDelete(_category.FirstOrDefault());
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
            }
        }

        public async Task<IActionCategory> Get(Guid UId)
        {
            var result = await this.Connection.SingleAsync<ActionCategory>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
            if (result != null && result.ParentCategoryId != null)
            {
                var parent = await this.Connection.SingleAsync<ActionCategory>(i => i.Id == result.ParentCategoryId && i.PracticeId == LoggedUser.PracticeId);
                result.ParentCategoryUId = parent?.UId;
            }

            return result;
        }

        public async Task<IEnumerable<IActionCategory>> GetSubCategoryByCategoryUId(Guid categoryUId)
        {
            var _category = await this.Connection.SingleAsync<ActionCategory>(i => i.UId == categoryUId);
            _category.Id = _category == null ? 0 : _category.Id;

            var result = await this.Connection.SelectAsync<ActionCategory>(i => i.ParentCategoryId == _category.Id
                                                         && i.PracticeId == LoggedUser.PracticeId);

            foreach (var item in result)
                item.AttFiles = await this._attFileRepository.GetByTableId(item.Id, AttTableConstant.ActionCategory);

            return result;
        }

        public async Task<IEnumerable<int>> GetByUIds(string uids)
        {
            try
            {
                var uidList = uids.Split(',');
                var categories = await this.Connection.SelectAsync<ActionCategory>(i => uidList.Contains(i.UId.ToString()));
                if (categories.Count() > 0)
                {
                    var ids = categories.Select(i => i.Id);
                    return ids;
                }
                return null;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IActionCategory> AddNew(IActionCategory entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                ActionCategory tEntity = entity as ActionCategory;
                if (entity.ParentCategoryUId != null)
                    entity.ParentCategoryId = (await this.Get(entity.ParentCategoryUId.Value))?.Id;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewAsync(tEntity);

                foreach (var formFile in formFiles)
                {
                    var addAttachment = await this._attFileRepository.CreateAttachments(formFile, result.Id, AttTableConstant.ActionCategory, formFile.FileName);
                    var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.ActionCategory);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Update(IActionCategory entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                ActionCategory tEntity = entity as ActionCategory;
                if (entity.ParentCategoryUId != null)
                    entity.ParentCategoryId = (await this.Get(entity.ParentCategoryUId.Value))?.Id;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ActionCategory>()
                                       .Update(x => new
                                       {
                                           x.ParentCategoryId,
                                           x.CategoryName,
                                           x.IsAttachmentRequired,
                                           x.DefaultNote,
                                           x.IsActive,
                                           x.HasFollowUp,
                                           x.ResponseByCD,
                                           x.FollowUpPeriodCD
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);

                foreach (var formFile in formFiles)
                {
                    var addAttachment = await this._attFileRepository.CreateAttachments(formFile, tEntity.Id, AttTableConstant.ActionCategory, formFile.FileName);
                    var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.ActionCategory);
                }

                return value;
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> Update(IActionCategory entity)
        {
            try
            {
                ActionCategory tEntity = entity as ActionCategory;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ActionCategory>()
                                       .Update(x => new
                                       {
                                           x.ParentCategoryId
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
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

                return await this.Connection.DeleteAsync<ActionCategory>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
                //int[] categoryData = null;
                //var getData = await base.GetById(id);
                //if (getData != null && getData.ParentCategoryId != null)
                //{
                //    var parentData = await this.Connection.SelectAsync<ActionCategory>(i => i.ParentCategoryId == getData.ParentCategoryId.Value);
                //    categoryData = parentData.Select(i => i.Id).ToArray();

                //    await this.Connection.DeleteAsync<ActionNote>(i => categoryData.Contains(i.ActionCategoryId));
                //    foreach (var item in categoryData)
                //    {
                //        await this.Connection.DeleteAsync<ActionCategory>(i => i.Id == item);
                //    }
                //}
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToDelete(IActionCategory entity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ParentCategoryExist], entity.ParentCategoryId.ToString()));

            return errors;
        }
    }
}
