using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class NotesCategoryRepository : ModuleBaseRepository<NotesCategory>, INotesCategoryRepository
    {
        public NotesCategoryRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<INotesCategory> AddNew(INotesCategory entity)
        {
            try
            {
                NotesCategory tEntity = entity as NotesCategory;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if ((bool)tEntity.IsARSCategory)
                    tEntity.IsDenial = true;

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(NotesCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            var user = await this.Connection.SingleAsync<NotesCategory>(i => i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim()
                                                                          && i.PracticeId == LoggedUser.PracticeId);

            if (user != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CategoryNameAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<int> Delete(string uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<NotesCategory>(i => i.UId == Guid.Parse(uid) && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<INotesCategory> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<NotesCategory>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<INotesCategory>> GetAll()
        {
            return (await this.Connection.SelectAsync<NotesCategory>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.CategoryName);
        }

        public async Task<int> Update(INotesCategory entity)
        {
            try
            {
                NotesCategory tEntity = entity as NotesCategory;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<NotesCategory>()
                                           .Update(x => new
                                           {
                                               x.CategoryName,
                                               x.AttachmentRequired,
                                               x.DefaultNote,
                                               x.IsActive,
                                               x.HasFollowUp,
                                               x.ResponseBy,
                                               x.ParentID,
                                               x.FollowUpPeriod,
                                               x.IsDenial,
                                               x.IsARSCategory,
                                               x.IsDisputed
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

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(NotesCategory tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (string.IsNullOrEmpty(tEntity.CategoryName))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CategoryNameCannotBeNullOrEmpty]));

            var categoryNames = await this.Connection.SelectAsync<NotesCategory>(i => i.CategoryName.ToLower().Trim() == tEntity.CategoryName.ToLower().Trim()
                                                                              && i.ID != tEntity.ID
                                                                              && i.PracticeId == LoggedUser.PracticeId);


            if (categoryNames.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CategoryNameAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<IPaginationQuery<INotesCategory>> GetNotesCategoryGrid(SearchQuery<INotesCategoryFilter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<NotesCategory>()
                              .Select<NotesCategory>((p) => new
                              {
                                  p
                              })
                               .OrderBy(i => i.CategoryName);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                string whereExpression = await WhereClauseProvider<INotesCategoryFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;
                string defaultExpression = null;


                defaultExpression = $"{query.Where<NotesCategory>(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<NotesCategory, INotesCategoryFilter>(entity, selectExpression, whereExpression, countExpression);


                foreach (var item in result.Data)

                {
                    var res = (result.Data.FirstOrDefault<NotesCategory>(i => i.ID == item.ParentID));
                    if (res != null)
                        item.ParentCategoryName = res.CategoryName;
                }

                return new PaginationQuery<INotesCategory>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<INotesCategory>> GetNotesCategoryData(int categoryId)
        {
            try
            {
                var result = await this.Connection.SelectAsync<NotesCategory>(i => (i.ID == 0 && i.ParentID == null
                                                                         && ((i.IsDisputed.HasValue && i.IsDisputed == false) || i.IsDisputed == null)
                                                                          && (i.IsARSCategory == false || i.IsARSCategory == null)
                                                                           || i.ParentID == categoryId));

                result.ToList().ForEach(x => x.HasFollowUp = (x.HasFollowUp.HasValue ? x.HasFollowUp : false));

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
