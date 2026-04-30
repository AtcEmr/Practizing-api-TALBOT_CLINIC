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
    public class CPTCodeRepository : ModuleBaseRepository<CPTCodes>, ICPTCodeRepository
    {
        private readonly DefaultSettings _settings;
        private readonly ICPTCategoryRepository _cptCategoryRepository;
        public CPTCodeRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           MyConfiguration configuration,
                                           ICPTCategoryRepository cptCategoryRepository
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            this._settings = configuration.settings.DefaultSettings;
            this._cptCategoryRepository = cptCategoryRepository;
        }

        public async Task<IPaginationQuery<ICPTCode>> Get(SearchQuery<ICPTCodeFilter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<CPTCodes>()
                              .LeftJoin<CPTCodes, DrugClass>((c, d) => c.DrugClassId == d.Id)
                              .LeftJoin<CPTCodes, CPTCategory>((i, j) => i.CPTCategoryId == j.Id)
                              .Select<CPTCodes, DrugClass, CPTCategory>((i, j, k) => new
                              {
                                  i,
                                  DrugCode = j.DrugCode,
                                  CategoryName = k.CategoryName
                              })
                              .OrderBy(i => i.CPTCode);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                string whereExpression = await WhereClauseProvider<ICPTCodeFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;

                string defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<CPTCodes, ICPTCodeFilter>(entity, selectExpression, whereExpression, countExpression);

                return new PaginationQuery<ICPTCode>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICPTCode> GetById(int id)
        {
            return await this.Connection.SingleAsync<CPTCodes>(i => i.ID == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<ICPTCode>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<CPTCodes>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<ICPTCode> GetByUId(Guid uid)
        {
            var query = this.Connection
                        .From<CPTCodes>()
                        .LeftJoin<CPTCodes, CPTCategory>((code, cat) => code.CPTCategoryId == cat.Id)
                        .Select<CPTCodes, CPTCategory>((code, cat) => new
                        {
                            code,
                            CPTCategoryUId = cat.UId
                        })
                            .Where(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<CPTCodes>.Map(dynamics);
            return result;
        }

        public async Task<ICPTCode> GetCPTCode(string code)
        {
            return await this.Connection.SingleAsync<CPTCodes>(i => i.CPTCode == code && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<ICPTCode>> GetCPTCodes()
        {
            try
            {
                var query = this.Connection
                             .From<CPTCodes>()
                             .LeftJoin<CPTCodes, NDC>((i, j) => j.Code == i.ID)
                             .Select<CPTCodes, NDC>((i, j) => new
                             {
                                 i,
                                 NDCCode = j.UId.ToString()
                             })
                             .Where(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true)
                             .OrderBy(i => i.CPTCode);

                var list=await this.Connection.QueryAsync<CPTCodes, CPTCodes>(query, LoggedUser.PracticeId, "true");

                foreach (var item in list)
                {
                    if(!string.IsNullOrWhiteSpace(item.GTModPOS))
                    {
                        item.GTModPOSList = new List<string>();
                        foreach (var pos in item.GTModPOS.Split(","))
                        {
                            item.GTModPOSList.Add(pos);
                        }
                    }
                }

                return list;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICPTCode>> GetCPTCodeByDrugClassId(int drugClassId)
        {
            try
            {
                return await this.Connection.SelectAsync<CPTCodes>(i => i.DrugClassId == drugClassId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICPTCode> AddNew(ICPTCode entity)
        {
            try
            {
                CPTCodes tEntity = entity as CPTCodes;
                if (string.IsNullOrEmpty(tEntity.DefaultPOSId))
                    tEntity.DefaultPOSId = this._settings.POS;

                if (string.IsNullOrEmpty(tEntity.DefaultTOSId))
                    tEntity.DefaultTOSId = this._settings.TOS;

                tEntity.DrugClassId = tEntity.DrugClassId == 0 ? null : tEntity.DrugClassId;

                if (tEntity.DefaultQuantity == null || tEntity.DefaultQuantity == 0)
                    tEntity.DefaultQuantity = 1;

                ////var category  = (short)((await base.GetId<ICPTCategory>(tEntity.CPTCategoryUId, false)).Value);
                // tEntity.CPTCategoryId = category.id;

                var category = tEntity.CPTCategoryUId == Guid.Empty ? null : await this._cptCategoryRepository.GetByUId(entity.CPTCategoryUId);
                tEntity.CPTCategoryId = category == null ? (short?)0 : category.Id;

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

        public async Task<int> Update(ICPTCode entity)
        {
            try
            {
                CPTCodes tEntity = entity as CPTCodes;

                /*if cptcatgeoryUId is string of 0s, then CPTCategoryId will be 0, otherwise it will return CPTCategoryId of that CPTCategoryUId*/
                //tEntity.CPTCategoryId = tEntity.CPTCategoryUId == Guid.Empty ? Convert.ToInt16(0)
                //                       : (await this._cptCategoryRepository.GetByUId(tEntity.CPTCategoryUId)).Id;
                tEntity.CPTCategoryId = tEntity.CPTCategoryUId != Guid.Empty ? (short?)(await base.GetId<CPTCategory>(tEntity.CPTCategoryUId, false)).Value : null;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<CPTCodes>()
                                           .Update(x => new
                                           {
                                               x.VisitType,
                                               x.CPTCode,
                                               x.Description,
                                               x.IsCommon,
                                               x.Ultrasound,
                                               x.DefaultQuantity,
                                               x.SNOMEDCT,
                                               x.CPTCategoryId,
                                               x.DefaultPOSId,
                                               x.DefaultTOSId,
                                               x.IsTaxable,
                                               x.BillToInsurance,
                                               x.IsQtyUnits,
                                               x.OffCode,
                                               x.InactiveDate,
                                               x.IsCostOfGoods,
                                               x.Color,
                                               x.DrugClassId,
                                               x.IsActive,
                                               x.ModifiedDate,
                                               x.ModifiedBy,
                                               x.IsSameAsDefault,
                                               x.IsForMentalAct,
                                               x.COGs

                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uId)
        {
            try
            {
                return await this.Connection.DeleteAsync<CPTCodes>(i => i.UId == uId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(CPTCodes tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            CheckForNull(tEntity, ref errors);

            var cptCodes = await this.Connection.SelectAsync<CPTCodes>(i => i.CPTCode.ToLower().Trim() == tEntity.CPTCode.ToLower().Trim()
                                                                          && i.PracticeId == LoggedUser.PracticeId);
            if (cptCodes.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(CPTCodes tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            CheckForNull(tEntity, ref errors);


            var cptCodes = await this.Connection.SelectAsync<CPTCodes>(i => i.CPTCode.ToLower().Trim() == tEntity.CPTCode.ToLower().Trim()
                                                                         && i.PracticeId == LoggedUser.PracticeId
                                                                         && i.ID != tEntity.ID);

            if (cptCodes.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private void CheckForNull(CPTCodes tEntity, ref List<IValidationResult> errors)
        {
            if (string.IsNullOrEmpty(tEntity.CPTCode))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeCannotBeNullOrEmpty]));

            if (string.IsNullOrEmpty(tEntity.Description))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DescriptionCannotBeNullOrEmpty]));

            if (tEntity.DefaultQuantity == null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DefaultQuantityNull]));

            if (tEntity.DefaultQuantity < 1)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DefaultQuantityLessThanOne]));
        }
    }
}
