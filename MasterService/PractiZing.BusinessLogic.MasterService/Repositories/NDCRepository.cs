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
using PractiZing.Base.Object.MasterServcie;
using PractiZing.BusinessLogic.Common;
using ServiceStack.OrmLite.Dapper;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class NDCRepository : ModuleBaseRepository<NDC>, INDCRepository

    {
        private ICPTCodeRepository _cptCodeRepository;
        public NDCRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser,
                                           ICPTCodeRepository cptCodeRepository
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            this._cptCodeRepository = cptCodeRepository;
        }

        public async Task<IPaginationQuery<INDC>> GetAll(SearchQuery<INDCFilter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<NDC>()
                              .LeftJoin<NDC, ConfigNDCUOM>((n, u) => n.UoM == u.Id)
                              .Join<NDC, CPTCodes>((n, c) => n.Code == c.ID)
                              .Select<NDC, ConfigNDCUOM, CPTCodes>((p, u, c) => new
                              {
                                  p,
                                  UoMDesc = u.Description,
                                  CPTCode = c.CPTCode
                              })
                               .OrderBy(i => i.NDCCode);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                string whereExpression = await WhereClauseProvider<INDCFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;

                string defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<NDC, INDCFilter>(entity, selectExpression, whereExpression, countExpression);
                return new PaginationQuery<INDC>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<INDC> GetByCode(string code)
        {
            return await this.Connection.SingleAsync<NDC>(i => i.NDCCode == code && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<INDC> GetByCptCode(string code)
        {
            return await this.Connection.SingleAsync<NDC>(i => i.CptCode == code && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<INDC> GetByUId(Guid uid)
        {
            var query = this.Connection.From<NDC>()
                            .LeftJoin<NDC, CPTCodes>((n, c) => n.Code == c.ID)
                            .Select<NDC, CPTCodes>((n, c) => new
                            {
                                n,
                                CPTCodeUId = c.UId
                            })
                            .Where(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper<NDC>.Map(dynamics);
        }

        public async Task<IEnumerable<INDC>> GetNDCCodes()
        {
            return (await this.Connection.SelectAsync<NDC>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.NDCCode);
        }

        public async Task<INDC> AddNew(INDC entity)
        {
            try
            {
                NDC tEntity = entity as NDC;

                var cptcode = await this._cptCodeRepository.GetByUId(entity.CPTCodeUId);
                entity.Code = Convert.ToInt16(cptcode.ID);
                entity.CptCode = cptcode.CPTCode;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewEntity(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(INDC entity)
        {
            try
            {
                NDC tEntity = entity as NDC;

                var cptcode = await this._cptCodeRepository.GetByUId(entity.CPTCodeUId);
                entity.Code = Convert.ToInt16(cptcode.ID);
                entity.CptCode = cptcode.CPTCode;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                                           .From<NDC>()
                                                           .Update(x => new
                                                           {
                                                               x.Code,
                                                               x.NDCCode,
                                                               x.Format,
                                                               x.UoM,
                                                               x.DrugQty,
                                                               x.Description,
                                                               x.IsActive,
                                                               x.CptCode
                                                           }).Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Int16 code)
        {
            try
            {
                return await this.Connection.DeleteAsync<NDC>(i => i.Code == code && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(NDC tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            CheckForNull(tEntity, ref errors);

            var NDC = await this.Connection.SelectAsync<NDC>(i => (i.NDCCode.ToLower().Trim() == tEntity.NDCCode.ToLower().Trim()
                                                                || i.Code == tEntity.Code)
                                                                && i.PracticeId == LoggedUser.PracticeId);

            var cptcode = NDC.FirstOrDefault(i => i.Code == tEntity.Code);
            if (cptcode != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeAlreadyChoosen]));

            else
            {
                var code = NDC.Where(i => i.NDCCode.ToLower().Trim() == tEntity.NDCCode.ToLower().Trim());
                if (code.Count() > 0)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.NDCCodeAlreadyExists]));
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(NDC tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            CheckForNull(tEntity, ref errors);

            var _ndc = await this.Connection.SelectAsync<NDC>(i => i.NDCCode.ToLower().Trim() == tEntity.NDCCode.ToLower().Trim()
                                                                && i.UId != tEntity.UId);

            if (_ndc.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.NDCCodeAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private void CheckForNull(NDC tEntity, ref List<IValidationResult> errors)
        {
            if (string.IsNullOrEmpty(tEntity.NDCCode))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CodeCannotBeNullOrEmpty]));

            if (string.IsNullOrEmpty(tEntity.Description))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DescriptionCannotBeNullOrEmpty]));
        }
    }
}
