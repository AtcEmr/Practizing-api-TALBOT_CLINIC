using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using System.Text.RegularExpressions;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ReferringDoctorRepository : ModuleBaseRepository<ReferringDoctor>, IReferringDoctorRepository
    {
        private readonly IMapper _mapper;

        public ReferringDoctorRepository(ValidationErrorCodes errorCodes,
                                         DataBaseContext dbContext,
                                         ILoginUser loggedUser, IMapper mapper)
                                       : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<IReferringDoctor>> GetAll(IReferringDoctorFilter entity)
        {
            try
            {
                var query = this.Connection
                              .From<ReferringDoctor>()
                              .Select<ReferringDoctor>((r) => new
                              {
                                  r,
                              })
                              .Where<ReferringDoctor>((i) => i.PracticeId == LoggedUser.PracticeId)
                              .OrderBy(i => i.FirstName).ThenBy(i => i.LastName);


                string whereExpression = await WhereClauseProvider<IReferringDoctorFilter>.GetWhereClause(entity);
                query.WhereExpression = string.IsNullOrEmpty(query.WhereExpression) ? whereExpression : query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ReferringDoctor>.MapList(queryResult);

                //var query = this.Connection
                //              .From<ReferringDoctor>()
                //              .Select<ReferringDoctor>((p) => new
                //              {
                //                  p
                //              }).Where<ReferringDoctor>(i => i.PracticeId == LoggedUser.PracticeId)
                //              .OrderBy(i => i.LastName).ThenBy(i => i.FirstName);

                //string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                //string countExpression = query.ToCountStatement();
                //query.Where(i => i.PracticeId == LoggedUser.PracticeId);
                //string whereExpression = await WhereClauseProvider<IReferringDoctorFilter>.GetWhereClause(entity.Filter);
                //entity.SortExpression = query.OrderByExpression;
                //var result = await this.Connection.QueryPagination<ReferringDoctor, IReferringDoctorFilter>(entity, selectExpression, whereExpression, countExpression);
                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<IReferringDoctor> GetById(Int16 id)
        {
            return await this.Connection.SingleAsync<ReferringDoctor>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IReferringDoctor> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<ReferringDoctor>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IReferringDoctor>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<ReferringDoctor>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IReferringDoctor> GetByNPI(string npi)
        {
            return await this.Connection.SingleAsync<ReferringDoctor>(i => i.NPI == npi && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IReferringDoctor> GetByNPI(IReferringDoctor entity)
        {
            var result = await this.GetByNPI(entity.NPI);
            if (result == null)
            {
                if (string.IsNullOrEmpty(entity.City) || string.IsNullOrEmpty(entity.State))
                {
                    result = null;
                }
                else
                    result = await this.AddNew(entity);
            }

            return result;
        }

        public async Task<IEnumerable<IReferringDoctor>> GetReferringDoctors()
        {
            return (await this.Connection.SelectAsync<ReferringDoctor>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true)).OrderBy(i => i.FirstName);
        }

        public async Task<IEnumerable<IReferringDoctorDTO>> GetReferringDoctorDTO()
        {
            try
            {
                var res = await this.Connection.SelectAsync<ReferringDoctor>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true);

                var result = (_mapper.Map<List<ReferringDoctorDTO>>(res)).OrderBy(i => i.FullName);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IReferringDoctor> AddNew(IReferringDoctor entity)
        {
            try
            {
                ReferringDoctor tEntity = entity as ReferringDoctor;
                tEntity.Email = string.IsNullOrEmpty(tEntity.Email) ? null : tEntity.Email;
                tEntity.State = tEntity.State ?? "";

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

        public async Task<int> Update(IReferringDoctor entity)
        {
            try
            {
                ReferringDoctor tEntity = entity as ReferringDoctor;

                tEntity.Email = string.IsNullOrEmpty(tEntity.Email) ? null : tEntity.Email;
                tEntity.State = tEntity.State ?? "";

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<ReferringDoctor>()
                                           .Update(x => new
                                           {
                                               x.Prefix,
                                               x.FirstName,
                                               x.Middle,
                                               x.LastName,
                                               x.Suffix,
                                               x.Address,
                                               x.Address2,
                                               x.City,
                                               x.State,
                                               x.Zip,
                                               x.Phone,
                                               x.Fax,
                                               x.Email,
                                               x.PracticeName,
                                               x.Degree,
                                               x.NPI,
                                               x.Comments,
                                               x.PM_Person_NO,
                                               x.DirectEmailID,
                                               x.IsActive,
                                               x.ModifiedDate,
                                               x.ModifiedBy
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
                return await this.Connection.DeleteAsync<ReferringDoctor>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> IsValidEmail(string email)
        {
            bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(IReferringDoctor entity)
        {
            ReferringDoctor tEntity = entity as ReferringDoctor;
            List<IValidationResult> errors = new List<IValidationResult>();

            var _npi = await this.Connection.SingleAsync<ReferringDoctor>(i => i.NPI == entity.NPI && i.PracticeId == LoggedUser.PracticeId);
            if (_npi != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SameNPIAlreadyExists]));

            if (!string.IsNullOrEmpty(tEntity.Email) && !await this.IsValidEmail(tEntity.Email))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InvalidEmailFormat]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);
            return errors;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(IReferringDoctor entity)
        {
            ReferringDoctor tEntity = entity as ReferringDoctor;
            List<IValidationResult> errors = new List<IValidationResult>();

            var _npi = await this.Connection.SingleAsync<ReferringDoctor>(i => i.NPI == entity.NPI && i.Id != tEntity.Id && i.PracticeId == LoggedUser.PracticeId);
            if (_npi != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SameNPIAlreadyExists]));

            if (!string.IsNullOrEmpty(tEntity.Email) && !await this.IsValidEmail(tEntity.Email))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InvalidEmailFormat]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);
            return errors;
        }
    }
}
