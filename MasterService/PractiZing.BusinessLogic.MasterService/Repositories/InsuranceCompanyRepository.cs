using Microsoft.Extensions.Logging;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Object.CommonEntites;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Models;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class InsuranceCompanyRepository : ModuleBaseRepository<InsuranceCompany>, IInsuranceCompanyRepository
    {
        private IClearingHouseRepository _clearingHouseRepository;
        private readonly ILogger _logger;
        public InsuranceCompanyRepository(ValidationErrorCodes errorCodes,
                                          DataBaseContext dbContext,
                                          ILoginUser loggedUser,
                                          IClearingHouseRepository clearingHouseRepository,
                                          ILoggerFactory loggerFactory
                                          ) : base(errorCodes, dbContext, loggedUser)
        {
            this._clearingHouseRepository = clearingHouseRepository;
            _logger = loggerFactory.CreateLogger<InsuranceCompanyRepository>();

        }

        /// <summary>
        /// save new Insurance Company
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IInsuranceCompany> AddNew(IInsuranceCompany entity)
        {
            try
            {
                InsuranceCompany tEntity = entity as InsuranceCompany;

                tEntity.PMS_ID = (await this.Connection.SelectAsync<InsuranceCompany>()).Max(i => i.PMS_ID) == null ? 1
                               : (await this.Connection.SelectAsync<InsuranceCompany>()).Max(i => i.PMS_ID) + 1;

                //var _clearingHouse = await this._clearingHouseRepository.GetByUId(entity.ClearingHouseUId);
                //entity.ClearingHouseId = _clearingHouse == null ? 0 : (short?)_clearingHouse.Id;

                tEntity.ClearingHouseId = (short)(await base.GetId<ClearingHouse>(tEntity.ClearingHouseUId, false)).Value;

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

        /// <summary>
        /// Update Insurance Company by UId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Update(IInsuranceCompany entity)
        {
            try
            {
                InsuranceCompany tEntity = entity as InsuranceCompany;

                /*Get insurance Company by uid and practiceId*/
                var insuranceCompany = await this.Connection.SingleAsync<InsuranceCompany>(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);
                if (insuranceCompany == null)
                {
                    tEntity.Id = 0;
                    await this.AddNew(tEntity);

                    return 1;
                }

                tEntity.ClearingHouseId = (short)((await base.GetId<ClearingHouse>(tEntity.ClearingHouseUId, false)).Value);

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<InsuranceCompany>()
                                           .Update(x => new
                                           {
                                               x.CompanyCode,
                                               x.CompanyName,
                                               x.CompanyAddress1,
                                               x.CompanyAddress2,
                                               x.CompanyCity,
                                               x.CompanyState,
                                               x.CompanyZip,
                                               x.PhoneNumber,
                                               x.PMS_ID,
                                               x.EXTERNAL_ID,
                                               x.Medigap,
                                               x.CompanyTypeId,
                                               x.FormTypeId,
                                               x.ClearingHouseId,
                                               x.TransmitClaims,
                                               x.SubmitterID,
                                               x.Color,
                                               x.IsInnetwork,
                                               x.IsGCodeAccepted,
                                               x.CrossWalkId,
                                               x.IsActive,
                                               x.ModifiedDate,
                                               x.ModifiedBy,
                                               x.IsLoop2420ARequired,
                                               x.TempCompanyCode,
                                               x.IsProviderTaxonomyNeeded
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<int> DeleteByUId(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsuranceCompany>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteById(int Id)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsuranceCompany>(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IInsuranceCompany> GetByState(string state)
        {
            return await this.Connection.SingleAsync<InsuranceCompany>(i => i.CompanyState.ToLower() == state.ToLower() && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IInsuranceCompany> GetSelfPayPayer()
        {
            return await this.Connection.SingleAsync<InsuranceCompany>(i => i.CompanyTypeId==18 && i.CompanyCode.ToLower()=="selfp" && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IDropDownDTO>> GetAll()
        {
            var companies = await this.Connection.SelectAsync<InsuranceCompany>(i => i.PracticeId == LoggedUser.PracticeId);
            var result = new List<DropDownDTO>();
            foreach (var item in companies)
            {
                var ddoItem = new DropDownDTO();
                ddoItem.label = item.CompanyName;
                ddoItem.value = item.UId;
                result.Add(ddoItem);
            }

            return result;
        }

        public async Task<IEnumerable<IInsuranceCompany>> GetById(IEnumerable<int> Ids)
        {
            var query = this.Connection
                          .From<InsuranceCompany>()
                          .Select<InsuranceCompany>((i) => new
                          {
                              i
                          })
                          .Where(i => Ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<InsuranceCompany>.MapList(dynamics);
            
            return result;
        }

        public async Task<IEnumerable<IInsuranceCompany>> GetByUId(IEnumerable<Guid> Ids)
        {
            return await this.Connection.SelectAsync<InsuranceCompany>(i => Ids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IInsuranceCompany> GetByUId(Guid uid)
        {
            var query = this.Connection
                            .From<InsuranceCompany>()
                            .Join<InsuranceCompany, ClearingHouse>((i, c) => i.ClearingHouseId == c.Id)
                            .Select<InsuranceCompany, ClearingHouse>((i, c) => new
                            {
                                i,
                                ClearingHouseUId = c.UId,
                                ClearingHouseName = c.Name
                            })
                            .Where(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<InsuranceCompany>.Map(dynamics);

            if (result != null)
                result.ClearingHouseId = 0;

            return result;
        }

        public async Task<IInsuranceCompany> GetById(int? Id)
        {
            var query = this.Connection.From<InsuranceCompany>()
                .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((i, j) => i.CompanyTypeId == j.Id)
                .Select<InsuranceCompany, ConfigInsuranceCompanyType>((i, j) => new
                {
                    i,
                    CompanyType = j.CompanyType
                }
                ).Where(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<InsuranceCompany>.Map(dynamics);

            //return await this.Connection.SingleAsync<InsuranceCompany>(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(IInsuranceCompany entity)
        {
            InsuranceCompany tEntity = entity as InsuranceCompany;
            List<IValidationResult> errors = new List<IValidationResult>();

            tEntity.CompanyCode = tEntity.CompanyCode ?? string.Empty;
            tEntity.CompanyName = tEntity.CompanyName ?? string.Empty;
            tEntity.CompanyCity = tEntity.CompanyCity ?? string.Empty;
            tEntity.CompanyState = tEntity.CompanyState ?? string.Empty;
            tEntity.CompanyZip = tEntity.CompanyZip ?? string.Empty;

            /*Check Insurance company code or company name is not empty. if these are empty then will throw an exception*/
            if (string.IsNullOrEmpty(tEntity.CompanyCode) || string.IsNullOrEmpty(tEntity.CompanyName))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyValidation]));

            var _code = await this.Connection.SingleAsync<InsuranceCompany>(i => i.CompanyCode.ToLower().Trim() == entity.CompanyCode.ToLower().Trim() && i.CompanyTypeId==entity.CompanyTypeId
                                                                                        && i.PracticeId == LoggedUser.PracticeId);

            if (_code != null)
            {
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateCompanyCode]));
            }
            //if (_code != null)
            //{
            //    _code.CompanyName = _code.CompanyName ?? string.Empty;
            //    _code.CompanyCity = _code.CompanyCity ?? string.Empty;
            //    _code.CompanyState = _code.CompanyState ?? string.Empty;
            //    _code.CompanyZip = _code.CompanyZip ?? string.Empty;

            //    /*Check insurance company is not already exist for given params*/
            //    if (_code.CompanyName.ToLower() == tEntity.CompanyName.ToLower() && _code.CompanyCity.ToLower() == tEntity.CompanyCity.ToLower()
            //     && _code.CompanyState.ToLower() == tEntity.CompanyState.ToLower() && _code.CompanyZip.ToLower() == tEntity.CompanyZip.ToLower())
            //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyExists]));

            //    //else
            //    //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DuplicateCompanyCode]));
            //}

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(IInsuranceCompany entity)
        {
            InsuranceCompany tEntity = entity as InsuranceCompany;
            List<IValidationResult> errors = new List<IValidationResult>();

            /*Company Code or Company Name should not be empty*/
            if (string.IsNullOrEmpty(tEntity.CompanyCode) || string.IsNullOrEmpty(tEntity.CompanyName))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyValidation]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        /// <summary>
        /// Get Insurance Company by search, search would be apply for insurance company name, company code,address, city, state, zip
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IInsuranceCompaniesDTO>> GetForPatient(string searchKey)
        {
            try
            {
                searchKey = searchKey ?? string.Empty;

                var query = this.Connection.From<InsuranceCompany>()
                            .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((ic, ict) => ic.CompanyTypeId == ict.Id)
                            .SelectDistinct<InsuranceCompany, ConfigInsuranceCompanyType>((ic, ict) => new
                            {
                                Id = ic.Id,
                                CompanyCode = ic.CompanyCode,
                                CompanyName = ic.CompanyName,
                                CompanyAddress1 = ic.CompanyAddress1,
                                CompanyAddress2 = ic.CompanyAddress2,
                                CompanyCity = ic.CompanyCity,
                                CompanyState = ic.CompanyState,
                                CompanyZip = ic.CompanyZip,
                                PhoneNumber = ic.PhoneNumber,
                                PMS_ID = ic.PMS_ID,
                                EXTERNAL_ID = ic.EXTERNAL_ID,
                                CompanyTypeId = ic.CompanyTypeId,
                                Medigap = ic.Medigap,
                                FormTypeId = ic.FormTypeId,
                                ClearingHouseId = ic.ClearingHouseId,
                                TransmitClaims = ic.TransmitClaims,
                                ConfigInsuranceCompanyTypeName = ict.CompanyType,
                                UId = ic.UId,
                                CompanyType=ict.CompanyType
                            })
                            .Where<InsuranceCompany>((i) => ((searchKey == "") || (i.CompanyName.Contains(searchKey) ||
                                                              i.CompanyCode.Contains(searchKey) ||
                                                              i.CompanyAddress1.Contains(searchKey) ||
                                                              i.CompanyAddress2.Contains(searchKey) ||
                                                              i.CompanyCity.Contains(searchKey) ||
                                                              i.CompanyState.Contains(searchKey) ||
                                                              i.CompanyZip.Contains(searchKey) ||
                                                              i.PhoneNumber.Contains(searchKey))) &&
                                                              i.PracticeId == LoggedUser.PracticeId &&
                                                              i.IsActive == true)
                                                              .OrderBy(i => i.CompanyName);

                var insuranceCompaniesData = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<InsuranceCompaniesDTO>.MapList(insuranceCompaniesData);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// get all insurance company with their clearinghouse , company type and form type
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IInsuranceCompany>> GetAll(string companyName)
        {
            try
            {
                companyName = companyName ?? string.Empty;

                var query = this.Connection.From<InsuranceCompany>()
                                           .Join<InsuranceCompany, ConfigInsuranceFormType>((i, f) => i.FormTypeId == f.Id)
                                           .Join<InsuranceCompany, ConfigInsuranceCompanyType>((i, c) => i.CompanyTypeId == c.Id)
                                           .Join<InsuranceCompany, ClearingHouse>((i, c) => i.ClearingHouseId == c.Id)
                                           .Select<InsuranceCompany, ConfigInsuranceFormType, ConfigInsuranceCompanyType, ClearingHouse>((i, f, c, ch) => new
                                           {
                                               i,
                                               FormType = f.FTName,
                                               CompanyType = c.CompanyType,
                                               ClearingHouseName = ch.Name
                                           })
                                           .Where<InsuranceCompany>(i => ((companyName == "") || (i.CompanyName.Contains(companyName) || i.CompanyCity.Contains(companyName) || i.PhoneNumber.Contains(companyName) || i.CompanyState.Contains(companyName) || i.CompanyZip.Contains(companyName) || i.CompanyAddress1.Contains(companyName))
                                           ) && i.PracticeId == LoggedUser.PracticeId && i.IsActive==true)
                                           .OrderBy<InsuranceCompany>(i => i.CompanyName);

                var insuranceCompaniesData = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<InsuranceCompany>.MapList(insuranceCompaniesData);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IInsuranceCompany> GetByUId(Guid? uid)
        {
            var query = this.Connection.From<InsuranceCompany>()
                            .LeftJoin<InsuranceCompany, ClearingHouse>((i, c) => i.ClearingHouseId == c.Id)
                            .Select<InsuranceCompany, ClearingHouse>((i, c) => new
                            {
                                i,
                                ClearingHouseUId = c.UId
                            }).Where(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper<InsuranceCompany>.Map(dynamics);
        }

        /*get claim configuration for specific insurance company or company type*/
        public async Task<IEnumerable<IInsuranceCompany>> Get()
        {
            var query = this.Connection.From<ClaimConfig>()
                        .Join<ClaimConfig, InsuranceCompany>((cc, ic) => cc.InsuranceCompanyTypeId == null && cc.IsDefault == false &&
                        cc.InsuranceCompanyId == ic.Id && ic.PracticeId == LoggedUser.PracticeId)
                        .SelectDistinct<InsuranceCompany, ClaimConfig>((ic, cc) => new
                        {
                            ic
                        })
                        .Where<ClaimConfig>(i => i.PracticeId == LoggedUser.PracticeId)
                        .OrderBy<InsuranceCompany>(i => i.CompanyName);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<InsuranceCompany>.MapList(queryResult);

            result.ToList().ForEach((res) =>
            {
                res.IsNew = false;
            });
            return result;
        }

        /*Get insurance company by code or name*/
        public async Task<IInsuranceCompany> GetInsuranceCompany(string code, string name)
        {
            
            code = code ?? string.Empty;
            var result = await this.Connection.SelectAsync<InsuranceCompany>(i => i.CompanyName.ToUpper() == name.ToUpper() && i.PracticeId == LoggedUser.PracticeId);
            var insuraceCompany = result.Where(i => i.CompanyCode == code).FirstOrDefault();
            return insuraceCompany;
        }

        /*Get insurance company by code or name*/
        public async Task<IInsuranceCompany> GetInsuranceCompanyForEMR(string code, string name,short? companyTypeId)
        {
            _logger.LogInformation($"{code}- Code Insurance Company!");
            if(companyTypeId==1)
            {
                companyTypeId = 0;
            }
            
            code = code ?? string.Empty;
            var result = await this.Connection.SelectAsync<InsuranceCompany>(i => i.CompanyCode.ToUpper() == code.ToUpper() && i.PracticeId == LoggedUser.PracticeId);

            InsuranceCompany insuranceCompany = null;
            //insuranceCompany = await this.Connection.SingleAsync<InsuranceCompany>(i => i.CompanyCode.ToUpper() == code.ToUpper() && i.CompanyTypeId==companyTypeId && i.PracticeId == LoggedUser.PracticeId);

            insuranceCompany = result.Where(i => i.CompanyCode == code && i.CompanyTypeId==companyTypeId && i.IsActive==true).FirstOrDefault();

            //if (insuranceCompany == null)
            //{
            //    try
            //    {
            //        var clearingHouse = await _clearingHouseRepository.GetById(1);
            //        InsuranceCompany insuranceCompanyRecord = new InsuranceCompany();
            //        insuranceCompanyRecord.CompanyTypeId = companyTypeId;
            //        insuranceCompanyRecord.CompanyName = name;
            //        insuranceCompanyRecord.ClearingHouseId = 1;
            //        insuranceCompanyRecord.ClearingHouseUId = clearingHouse.UId;
            //        insuranceCompanyRecord.CompanyCode = code;
            //        insuranceCompanyRecord.PMS_ID = null;
            //        insuranceCompanyRecord.Medigap = false;
            //        insuranceCompanyRecord.TransmitClaims = true;
            //        insuranceCompanyRecord.IsActive = true;
            //        insuranceCompanyRecord.FormTypeId = 10;
            //        return await this.AddNew(insuranceCompanyRecord);
            //    }
            //    catch (Exception ex)
            //    {

            //        throw;
            //    }

            //}
            return insuranceCompany;
        }

        public async Task InsuranceCompanyIsInUse()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyCannotBeDeleted]));
            await this.ThrowEntityException(errors);
        }

        public async Task ThrowError(IInsuranceCompany companyData)
        {
            if (companyData == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyDoesNotExists]));
            }
        }
    }
}
