using PractiZing.Base.Common;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using PractiZing.DataAccess.SecurityService.View;
using ServiceStack.OrmLite.Dapper;
using AutoMapper;
using System;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class UserRepository : ModuleBaseRepository<User>, IUserRepository
    {
        private IFacilityRepository _facilityRepository;
        public UserRepository(ValidationErrorCodes validationErrorCodes,
                              DataBaseContext dbContext,
                              ILoginUser loggedUser,
                              IFacilityRepository facilityRepository) : base(validationErrorCodes, dbContext, loggedUser)
        {
            this._facilityRepository = facilityRepository;
        }

        /*Login with user name and password*/
        public async Task<ILoginUser> Login(string userName, string password)
        {
            try
            {
                var query = this.Connection
                               .From<User>()
                               .Join<User, Practice>((i, j) => i.PracticeId == j.Id)
                               .LeftJoin<User, ConfigPosition>((i, j) => i.PositionId == j.Id)
                               .Select<User, Practice, ConfigPosition>((u, p,cp) => new
                               {
                                   u,
                                   PracticeName = p.PracticeName,
                                   PracticeCode = p.PracticeCode,
                                   EMRURL=p.EMRURL,
                                   EMRUserName=p.EMRUserName,
                                   EMRPassword=p.EMRPassword,
                                   p.LogoName,
                                   p.EMRChargeGetApi,
                                   p.EMRChargeUpdateApi,
                                   p.IsMentalACT,
                                   p.FavIcon,
                                   p.OnlinePaymentURL,
                                   Position=cp.PositionName,
                                   IsRequiredInsuranceAddEdit = p.IsRequiredInsuranceAddEdit
                               })
                               .Where<User>(u => u.UserName == userName);
                var result = await this.Connection.QueryAsync<User, User>(query, userName);
                var user = result.FirstOrDefault(i=>i.Active==true);
                if (user == null)
                    return null;

                var existingPwd = System.Text.Encoding.UTF8.GetString(user.UserPassword);
                if (existingPwd == password)
                    return Mapper.Map<User, LoginView>(user);

                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                
            }
        }

        /*Login with user name and password*/
        public async Task<ILoginUser> LoginAzure(string userName, string password)
        {
            try
            {
                var query = this.Connection
                               .From<User>()
                               .Join<User, Practice>((i, j) => i.PracticeId == j.Id)
                               .Select<User, Practice>((u, p) => new
                               {
                                   u,
                                   PracticeName = p.PracticeName,
                                   PracticeCode = p.PracticeCode,
                                   EMRURL = p.EMRURL,
                                   EMRUserName = p.EMRUserName,
                                   EMRPassword = p.EMRPassword,
                                   p.LogoName,
                                   p.EMRChargeGetApi,
                                   p.EMRChargeUpdateApi,
                                   p.IsMentalACT,
                                   p.FavIcon
                               })
                               .Where<User>(u => u.UserName == userName);
                var result = await this.Connection.QueryAsync<User, User>(query, userName);
                var user = result.FirstOrDefault();
                if (user == null)
                    return null;

                return Mapper.Map<User, LoginView>(user);

                //return null;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }


        /// <summary>
        /// Get all users by practice and their FacilityName
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IUser>> GetAll()
        {
            var query = this.Connection
                                .From<User>()
                                .LeftJoin<User, ConfigPosition>((i, j) => i.PositionId == j.Id)
                                .LeftJoin<User, Facility>((u, f) => u.DefaultBillFacilityId == f.Id, this.Connection.JoinAlias("BillFacility"))
                                .LeftJoin<User, Facility>((u, f) => u.DefaultPrefFacilityId == f.Id, this.Connection.JoinAlias("PerfFacility"))
                                .LeftJoin<User, Practice>((u, p) => u.PracticeId == p.Id)
                                .Select<User, ConfigPosition, Facility, Practice>((u, c, f, p) => new
                                {
                                    u,
                                    PositionName = c.PositionName,
                                    BillFacility = Sql.JoinAlias(f.Name, "BillFacility"),
                                    PerfFacility = Sql.JoinAlias(f.Name, "PerfFacility"),
                                    PracticeName = p.PracticeName
                                })
                                .Where(u => u.PracticeId == LoggedUser.PracticeId && u.IsHide == false);

            var result = await this.Connection.QueryAsync<User, User>(query, LoggedUser.PracticeId, 0);
            return result.Where(i=>i.Active==true).OrderBy(i => i.LastName);
        }



        public async Task<IUser> AddNew(IUser entity)
        {
            try
            {
                User tEntity = entity as User;
                tEntity.IsHide = false;
                tEntity.DefaultBillFacilityId = tEntity.DefaultBillFacilityUId == null ? null : (short?)(await this._facilityRepository.GetByUId(entity.DefaultBillFacilityUId.Value)).Id;
                tEntity.DefaultPrefFacilityId = tEntity.DefaultPrefFacilityUId == null ? null : (short?)(await this._facilityRepository.GetByUId(entity.DefaultPrefFacilityUId.Value)).Id;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                tEntity.UserPassword = (UTF8Encoding.UTF8.GetBytes(tEntity.Password));
                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update User Info
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(IUser entity)
        {
            try
            {
                User tEntity = entity as User;
                tEntity.DefaultBillFacilityId = tEntity.DefaultBillFacilityUId == null ? null : (short?)(await this._facilityRepository.GetByUId(entity.DefaultBillFacilityUId.Value)).Id;
                tEntity.DefaultPrefFacilityId = tEntity.DefaultPrefFacilityUId == null ? null : (short?)(await this._facilityRepository.GetByUId(entity.DefaultPrefFacilityUId.Value)).Id;
                // tEntity.DefaultBillFacilityId = billFacility?.Id;
                //var preferFacility = await this._facilityRepository.GetByUId(entity.DefaultPrefFacilityUId);
                //tEntity.DefaultPrefFacilityId = preferFacility?.Id;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                tEntity.UserPassword = !string.IsNullOrEmpty(tEntity.Password) ? (UTF8Encoding.UTF8.GetBytes(tEntity.Password)) : tEntity.UserPassword;
                var updateOnlyFields = this.Connection
                                          .From<User>()
                                          .Update(x => new
                                          {
                                              x.LastName,
                                              x.FirstName,
                                              x.PositionId,
                                              x.Active,
                                              x.CanBill,
                                              x.DefaultBillFacilityId,
                                              x.DefaultPrefFacilityId,
                                              x.IsClinicUser,
                                              x.UserName,
                                              x.UserPassword,
                                              x.PIN
                                          })
                                          .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
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
                return await this.Connection.DeleteAsync<User>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(User tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Check username is already exist or not, if user name is already exist then throw an exception.*/
            var user = await this.Connection.SingleAsync<User>(i => i.UserName.ToLower().Trim() == tEntity.UserName.ToLower().Trim());
            if (user != null)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserNameAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(User tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Check username is already exist or not, if user name is already exist then throw an exception.*/
            var user = await this.Connection.SelectAsync<User>(i => i.UserName.ToLower().Trim() == tEntity.UserName.ToLower().Trim()
                                                                 && i.Id != tEntity.Id);

            if (user.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserNameAlreadyExists]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        /*Get User Details with their Facility and positions*/
        public async Task<IUser> GetByUId(Guid UId)
        {
            try
            {
                var query = this.Connection
                                .From<User>()
                                .LeftJoin<User, ConfigPosition>((i, j) => i.PositionId == j.Id)
                                .LeftJoin<User, Facility>((u, f) => u.DefaultBillFacilityId == f.Id, this.Connection.JoinAlias("BillFacility"))
                                .LeftJoin<User, Facility>((u, f) => u.DefaultPrefFacilityId == f.Id, this.Connection.JoinAlias("PerfFacility"))
                                .LeftJoin<User, Practice>((u, p) => u.PracticeId == p.Id)
                                .Select<User, ConfigPosition, Facility, Practice>((u, c, f, p) => new
                                {
                                    u,
                                    PositionName = c.PositionName,
                                    BillFacility = Sql.JoinAlias(f.Name, "BillFacility"),
                                    PerfFacility = Sql.JoinAlias(f.Name, "PerfFacility"),
                                    DefaultBillFacilityUId = Sql.JoinAlias(f.UId, "BillFacility"),
                                    DefaultPrefFacilityUId = Sql.JoinAlias(f.UId, "PerfFacility"),
                                    PracticeName = p.PracticeName
                                }).Where(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<User>.Map(dynamicResult);
                return result;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<IUser>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<User>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IUser> GetCurrentUser()
        {
            return await this.Connection.SingleAsync<User>(i => i.Id== this.LoggedUser.Id);
        }

        public async Task ThrowPinEmptyError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserPINEmpty]));
        }

        public async Task ThrowPinNotMatchedError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.UserPINNotMatched]));
        }
    }
}