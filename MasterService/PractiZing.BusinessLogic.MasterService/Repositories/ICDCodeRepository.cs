using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
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

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ICDCodeRepository : ModuleBaseRepository<ICDCode>, IICDCodeRepository
    {
        private readonly DefaultSettings _settings;

        public ICDCodeRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           MyConfiguration configuration
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            this._settings = configuration.settings.DefaultSettings;
        }

        public async Task<IPaginationQuery<IICDCode>> Get(SearchQuery<IICDCodeFilter> entity)
        {
            try
            {
                var query = this.Connection
                             .From<ICDCode>()
                             .Select<ICDCode>((p) => new
                             {
                                 p
                             })
                             .OrderBy(i => i.Code);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                string whereExpression = await WhereClauseProvider<IICDCodeFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;

                string defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<ICDCode, IICDCodeFilter>(entity, selectExpression, whereExpression, countExpression);
                return new PaginationQuery<IICDCode>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IICDCode> GetByUId(Guid uid)
        {
            var item=await this.Connection.SingleAsync<ICDCode>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            if(!item.IcdType.HasValue)
            {
                item.IcdType = 3;
            }
            return item;
        }

        public async Task<IEnumerable<IICDCode>> GetAllActiveICD()
        {
            return (await this.Connection.SelectAsync<ICDCode>(i => i.IsActive == true && i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.Code);
        }

        public async Task<IICDCode> GetICDCode(string code)
        {
            return await this.Connection.SingleAsync<ICDCode>(i => i.Code == code && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IICDCode>> GetICDCodes(List<string> codes)
        {
            return await this.Connection.SelectAsync<ICDCode>(i => codes.Contains(i.Code.Trim()) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> GetICDCodesByEncounterTypeId(List<string> codes,int encounterId)
        {
            var list= await this.Connection.SelectAsync<ICDCode>(i => codes.Contains(i.Code) && i.IcdType== encounterId && i.PracticeId == LoggedUser.PracticeId);

            return list!=null?list.Count:0;
        }


        public async Task<IEnumerable<IDiagnosisDTO>> CheckIfICDExists(IEnumerable<IDiagnosisDTO> diagnoses)
        {
            try
            {
                var codeThoseExists = await this.GetICDCodes(diagnoses.Select(i => i.Code.Trim().Replace(".","")).ToList());

                //foreach (var item in diagnoses)
                //{
                //    var result = await this.GetICDCode(item.Code);
                //    if (result != null)
                //        item.IsExistInFavouriteList = true;
                //    else
                //        item.IsExistInFavouriteList = false;
                //}

                foreach (var item in diagnoses)
                {
                    item.IsExistInFavouriteList = codeThoseExists.Any(i => i.Code.Trim() == item.Code.Trim().Replace(".",""));                    
                }

                return diagnoses;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IICDCode> AddNew(IICDCode entity)
        {
            try
            {
                ICDCode tEntity = entity as ICDCode;
                tEntity.Code = tEntity.Code.Trim();
                if (tEntity.IsICDAddToFavourite)
                    tEntity.CodeSystem = this._settings.CodeSystem;

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

        public async Task<int> Update(IICDCode entity)
        {
            try
            {
                ICDCode tEntity = entity as ICDCode;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                       .From<ICDCode>()
                                       .Update(x => new
                                       {
                                           x.VisitType,
                                           x.Code,
                                           x.Description,
                                           x.DefaultPlan,
                                           x.Common,
                                           x.SNOMEDCT,
                                           x.CodeSystem,
                                           x.ICD_10Code,
                                           x.SendToBilling,
                                           x.ShowInActiveProblems,
                                           x.IsActive,
                                           x.ModifiedDate,
                                           x.ModifiedBy,
                                           x.IcdType
                                       })
                                       .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await this.Connection.DeleteAsync<ICDCode>(i => i.ID == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(ICDCode tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors = CheckForNull(tEntity, errors);

            var icdCodes = await this.Connection.SelectAsync<ICDCode>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim()
                                                                    && i.PracticeId == LoggedUser.PracticeId);

            if (icdCodes.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(ICDCode tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors = CheckForNull(tEntity, errors);

            var icdCodes = await this.Connection.SelectAsync<ICDCode>(i => i.Code.ToLower().Trim() == tEntity.Code.ToLower().Trim()
                                                                   && i.PracticeId == LoggedUser.PracticeId
                                                                   && i.ID != tEntity.ID);

            if (icdCodes.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private List<IValidationResult> CheckForNull(ICDCode tEntity, List<IValidationResult> errors)
        {
            if (string.IsNullOrEmpty(tEntity.Code))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeCannotBeNullOrEmpty]));

            if (string.IsNullOrEmpty(tEntity.Description))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DescriptionCannotBeNullOrEmpty]));
            return errors;
        }
    }
}

