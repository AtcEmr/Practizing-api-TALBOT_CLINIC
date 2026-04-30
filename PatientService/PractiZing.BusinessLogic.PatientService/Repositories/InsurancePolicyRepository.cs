using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.PatientEnums;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X12EDI;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.Base.Object.PatientService;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class InsurancePolicyRepository : ModuleBaseRepository<InsurancePolicy>, IInsurancePolicyRepository
    {
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IInsurancePolicyHolderRepository _insurancePolicyHolderRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IConfigTrizettoPatientEligibilityRepository _configTrizettoPatientEligibilityRepository;
        private readonly IPatientEligibilityRepository _patientEligibilityRepository;
        private readonly IPatientEligibilityDetailRepository _patientEligibilityDetailRepository;
        private readonly IEDIEligibilityLogRepository _ediEligibilityLogRepository;
        private readonly RestApiCall _restApiCall;
        private readonly IPatientAuthorizationNumberRepository _patientAuthorizationNumberRepository;
        private readonly IInsurancePolicyExceptionRepository _insurancePolicyExceptionRepository;
        private readonly ILogger _logger;

        public InsurancePolicyRepository(ValidationErrorCodes errorCodes,
                                         DataBaseContext dbContext,
                                         ILoginUser loggedUser,
                                         ITransactionProvider transactionProvider,
                                         IInsuranceCompanyRepository insuranceCompanyRepository,
                                         IInsurancePolicyHolderRepository insurancePolicyHolderRepository,
                                         IPatientCaseRepository patientCaseRepository,
                                         IPatientRepository patientRepository,
                                         IConfigTrizettoPatientEligibilityRepository configTrizettoPatientEligibilityRepository,
                                         IPatientEligibilityRepository patientEligibilityRepository,
                                         IPatientEligibilityDetailRepository patientEligibilityDetailRepository,
                                         IEDIEligibilityLogRepository ediEligibilityLogRepository,
                                         IPatientAuthorizationNumberRepository patientAuthorizationNumberRepository,
                                         IInsurancePolicyExceptionRepository insurancePolicyExceptionRepository, ILoggerFactory loggerFactory) : base(errorCodes, dbContext, loggedUser)
        {
            this._insurancePolicyExceptionRepository = insurancePolicyExceptionRepository;
            this._patientAuthorizationNumberRepository = patientAuthorizationNumberRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._insurancePolicyHolderRepository = insurancePolicyHolderRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._patientRepository = patientRepository;
            this._configTrizettoPatientEligibilityRepository = configTrizettoPatientEligibilityRepository;
            this._patientEligibilityRepository = patientEligibilityRepository;
            this._patientEligibilityDetailRepository = patientEligibilityDetailRepository;
            this._ediEligibilityLogRepository = ediEligibilityLogRepository;
            _restApiCall = new RestApiCall();
            _logger = loggerFactory.CreateLogger<InsurancePolicyRepository>();
        }

        public async Task<IPaginationQuery<IInsuranceCompany>> GetList(SearchQuery<IInsuranceCompanyFilter> entity)
        {
            try
            {
                var query = this.Connection.From<InsuranceCompany>()
                            .LeftJoin<InsuranceCompany, InsurancePolicy>((inc, inp) => inc.Id == inp.InsuranceCompanyID)
                            .SelectDistinct<InsuranceCompany, InsurancePolicy>((nc, np) => new
                            {
                                nc
                            })
                              .OrderBy<InsuranceCompany>(i => i.CompanyName);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IInsuranceCompanyFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;

                string defaultExpression = $"{query.Where<InsuranceCompany>(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<InsuranceCompany, IInsuranceCompanyFilter>(entity, selectExpression, whereExpression, countExpression);
                return new PaginationQuery<IInsuranceCompany>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> Get(int insuranceCompanyId)
        {
            try
            {
                return await this.Connection.SelectAsync<InsurancePolicy>(i => i.InsuranceCompanyID == insuranceCompanyId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetPolicies(int patientCaseId, DateTime fromDate)
        {
            try
            {
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
                result = result.Where(i => i.InsuranceLevel == 1 && i.IsActive == true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue
                             && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                             i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

                //.AddSeconds(86400 - 1)
                // var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId
                // && i.PlanEffectiveDate.HasValue && i.PlanEffectiveDate <= fromDate.AddSeconds(86400 - 1) && i.InsuranceLevel == 1
                // && ((i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= fromDate.Date.AddSeconds(86400 - 1)) || true)
                //);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IInsurancePolicy> GetSecondayPolicy(int patientCaseId, DateTime fromDate)
        {
            try
            {
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
                result = result.Where(i => i.InsuranceLevel == 2 && i.IsActive == true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue
                             && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                             i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

                //.AddSeconds(86400 - 1)
                // var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId
                // && i.PlanEffectiveDate.HasValue && i.PlanEffectiveDate <= fromDate.AddSeconds(86400 - 1) && i.InsuranceLevel == 1
                // && ((i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= fromDate.Date.AddSeconds(86400 - 1)) || true)
                //);

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<IEnumerable<IInsurancePolicy>> GetPoliciesFromHL7(int patientCaseId, DateTime fromDate)
        {
            try
            {
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
                result = result.Where(i => i.InsuranceLevel == 1 && (i.PlanEffectiveDate.HasValue
                             && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                             i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

                //.AddSeconds(86400 - 1)
                // var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId
                // && i.PlanEffectiveDate.HasValue && i.PlanEffectiveDate <= fromDate.AddSeconds(86400 - 1) && i.InsuranceLevel == 1
                // && ((i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= fromDate.Date.AddSeconds(86400 - 1)) || true)
                //);

                return result;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<string> GetCompanyType(int patientCaseId, DateTime fromDate)
        {
            try
            {
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
                result = result.Where(i => i.InsuranceLevel == 1 && i.IsActive==true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue
                             && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                             i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

                

                if(result!=null)
                {
                    var query = this.Connection.From<ConfigInsuranceCompanyType>()
                        .LeftJoin<ConfigInsuranceCompanyType, InsuranceCompany>((c, f) => c.Id == f.CompanyTypeId)                        
                        .Select<ConfigInsuranceCompanyType>((i) => new
                        {
                            i
                        })
                        .Where<InsuranceCompany>((i) => i.Id== result.FirstOrDefault().InsuranceCompanyID);

                    var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                    var obj = Mapper<ConfigInsuranceCompanyType>.MapList(queryResult);

                    return obj.FirstOrDefault().CompanyType;
                }

                
                return "";
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<bool> CheckInsurancePolicyExists(int patientCaseId, DateTime fromDate, int insuranceLevel)
        {
            try
            {
                bool insurancePolicyExists = false;
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
                result = result.Where(i => i.InsuranceLevel == insuranceLevel && i.IsActive==true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue
                             && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                             i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();
                if (result != null && result.Count() > 0)
                {
                    insurancePolicyExists = true;
                }
                return insurancePolicyExists;
            }
            catch
            {
                throw;
            }
        }

        public async Task PolicyDoesNotExist()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyExpired]));
            await this.ThrowEntityException(errors);
        }

        public async Task ValidateMedicaidZEROInsurancePolicy()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.MedicaidZERO]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetActivePolicies(int patientCaseId, DateTime fromDate)
        {
            //var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);

            var query = this.Connection.From<InsurancePolicy>()
                .Join<InsurancePolicy, InsuranceCompany>((a, b) => a.InsuranceCompanyID == b.Id).
                Select<InsurancePolicy, InsuranceCompany>((a, b) => new 
                 {
                     a,
                     InsuranceCompanyCode= b.CompanyCode,
                     InsuranceCompanyName=b.CompanyName,
                    InsuranceCompanyTypeId=b.CompanyTypeId
                }).Where(i => i.PatientCaseId == patientCaseId);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicy>.MapList(queryResult)).ToList();



            result = result.Where(i => i.IsActive == true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue 
                            && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

            if (result.Count == 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyNotExist]));

            return result;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetActivePoliciesForAdjustClaims(int patientCaseId, DateTime fromDate)
        {
            //var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);

            var query = this.Connection.From<InsurancePolicy>()
                .Join<InsurancePolicy, InsuranceCompany>((a, b) => a.InsuranceCompanyID == b.Id).
                Select<InsurancePolicy, InsuranceCompany>((a, b) => new
                {
                    a,
                    InsuranceCompanyCode = b.CompanyCode,
                    InsuranceCompanyName = b.CompanyName,
                    InsuranceCompanyTypeId = b.CompanyTypeId
                }).Where(i => i.PatientCaseId == patientCaseId);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicy>.MapList(queryResult)).ToList();



            result = result.Where(i => i.IsActive == true && i.IsDeleted == false && (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();


            return result;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetActivePolicies_OldCharges(int patientCaseId, DateTime fromDate)
        {
            //var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);

            var query = this.Connection.From<InsurancePolicy>()
                .Join<InsurancePolicy, InsuranceCompany>((a, b) => a.InsuranceCompanyID == b.Id).
                Select<InsurancePolicy, InsuranceCompany>((a, b) => new
                {
                    a,
                    InsuranceCompanyCode = b.CompanyCode,
                    InsuranceCompanyName = b.CompanyName,
                    InsuranceCompanyTypeId = b.CompanyTypeId,
                    InsuranceCompanyUId = b.UId
                }).Where(i => i.PatientCaseId == patientCaseId);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicy>.MapList(queryResult)).ToList();



            result = result.Where(i => (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();
                        

            return result;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetPoliciesForClaim(int patientCaseId, DateTime fromDate)
        {
            //var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);

            var query = this.Connection.From<InsurancePolicy>()
                .Join<InsurancePolicy, InsuranceCompany>((a, b) => a.InsuranceCompanyID == b.Id).
                Select<InsurancePolicy, InsuranceCompany>((a, b) => new
                {
                    a,
                    InsuranceCompanyCode = b.CompanyCode,
                    InsuranceCompanyName = b.CompanyName,
                    InsuranceCompanyUId=b.UId,
                    IsGCodeAccepted=b.IsGCodeAccepted,
                    InsuranceCompanyTypeId=b.CompanyTypeId
                }).Where(i => i.PatientCaseId == patientCaseId);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicy>.MapList(queryResult)).ToList();



            result = result.Where(i => (i.PlanEffectiveDate.HasValue
                            && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
                            i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();

            if (result.Count == 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyNotExist]));

            return result.Where(i=>i.IsActive==true);
        }

        public async Task<IEnumerable<IInsurancePolicyDTO>> GetActivePolicies(IEnumerable<int> patientCaseIds)
        {
            var query = this.Connection.From<InsurancePolicy>()
                         .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id, NoLockTableHint.NoLock)                         
                         .Select<InsurancePolicy, InsuranceCompany>((ip, ic) => new
                         {
                             ip.PatientCaseId,
                             ip.InsuranceLevel,
                             ip.PlanEffectiveDate,
                             ip.PlanExpirationDate,
                             InsuranceCompanyName = ic.CompanyName,
                             InsuranceCompanyCode=ic.CompanyCode

                         }).Where(i => patientCaseIds.Contains(i.PatientCaseId) && i.InsuranceLevel==1 && i.IsActive==true && i.IsDeleted == false);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicyDTO>.MapList(queryResult)).ToList();

            //if (result.Count == 0)
            //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyNotExist]));

            return result;
        }

        public async Task<IEnumerable<IInsurancePolicyDTO>> GetActivePolicies_Secondary(IEnumerable<int> patientCaseIds)
        {
            var query = this.Connection.From<InsurancePolicy>()
                         .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id, NoLockTableHint.NoLock)
                         .Select<InsurancePolicy, InsuranceCompany>((ip, ic) => new
                         {
                             ip.PatientCaseId,
                             ip.InsuranceLevel,
                             ip.PlanEffectiveDate,
                             ip.PlanExpirationDate,
                             InsuranceCompanyName = ic.CompanyName,
                             InsuranceCompanyCode = ic.CompanyCode

                         }).Where(i => patientCaseIds.Contains(i.PatientCaseId) && i.InsuranceLevel == 2 && i.IsActive == true && i.IsDeleted == false);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = (Mapper<InsurancePolicyDTO>.MapList(queryResult)).ToList();

            //if (result.Count == 0)
            //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyNotExist]));

            return result;
        }

        public async Task<IInsurancePolicy> AddNew(IInsurancePolicy entity, bool isFromHL7 = false)
        {
            try
            {
                InsurancePolicy tEntity = entity as InsurancePolicy;
                if (!string.IsNullOrEmpty(tEntity.PolicyNumber))
                {
                    tEntity.PolicyNumber = tEntity.PolicyNumber.Replace("-", "");
                }
                var company = await this._insuranceCompanyRepository.GetByUId(entity.InsuranceCompanyUId);
                if (company == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyNOtExists]));

                if(company.CompanyTypeId==4)
                {
                    if(string.IsNullOrWhiteSpace(tEntity.MedicaidId))
                    {
                        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.MedicaidIdRequired]));
                    }
                }

                if (isFromHL7)
                {
                    tEntity.IsNotifyToEMR = true;


                    var getPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.EMRInsurancePolicyId == entity.EMRInsurancePolicyId);


                    if(getPolicyData.Count()==0)
                    {
                        //getPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == entity.PatientCaseId
                        //    && i.InsuranceCompanyID == entity.InsuranceCompanyID
                        //    && i.InsuranceLevel == entity.InsuranceLevel && i.PolicyNumber == entity.PolicyNumber);

                        //if (getPolicyData.Count > 0)
                        //{
                        //    var getPolicy = getPolicyData.OrderByDescending(i => i.Id).FirstOrDefault(i => i.PolicyNumber == entity.PolicyNumber);
                        //    if (getPolicy != null)
                        //    {
                        //        tEntity.Id = getPolicy.Id;
                        //        tEntity.UId = getPolicy.UId;
                        //        tEntity.IsActive = true;
                        //        await this.Update(tEntity);
                        //        return tEntity;
                        //    }
                        //    else
                        //    {
                        //        var getInsuranceCompany = getPolicyData.FirstOrDefault(i => i.InsuranceCompanyID == company.Id);
                        //        if (getInsuranceCompany != null)
                        //        {
                        //            tEntity.Id = getInsuranceCompany.Id;
                        //            tEntity.InsuranceCompany.UId = entity.InsuranceCompanyUId;
                        //            tEntity.InsurancePolicyHolder.Id = entity.PHID;
                        //            //tEntity.PolicyNumber = entity.PolicyNumber;
                        //            await this.Update(tEntity);
                        //            return tEntity;
                        //        }
                        //        else
                        //        {
                        //            return tEntity;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        tEntity.Id = getPolicyData.FirstOrDefault().Id;
                        tEntity.UId = getPolicyData.FirstOrDefault().UId;
                        tEntity.IsActive = true;

                        await this.Update(tEntity);
                        return tEntity;
                    }
                }
                else
                {
                    tEntity.IsNotifyToEMR = false;

                }
                //else
                //{
                //    var getPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == entity.PatientCaseId && i.InsuranceLevel == entity.InsuranceLevel && i.PolicyNumber == entity.PolicyNumber);
                //    if (getPolicyData.Count > 0)
                //    {
                //        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyAlreadyExists]));
                //    }
                //}

                tEntity.Id = 0;
                tEntity.MedicareSecondary = tEntity.MedicareSecondary == 0 ? null : tEntity.MedicareSecondary;
                tEntity.InsuranceCompany.UId = tEntity.InsuranceCompanyUId;
                tEntity.InsuranceCompanyID = company.Id;

                var patientCase = await this._patientCaseRepository.GetByUId(entity.PatientCaseUId);
                tEntity.PatientCaseId = tEntity.PatientCaseId == 0 ? patientCase.Id : tEntity.PatientCaseId;

                if (tEntity.InsuranceCompanyID == 0)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceComapnyIdMandatory]));

                if (tEntity.PolicyNumber == null || tEntity.InsuranceCompanyID == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyFieldRequired]));

                if (tEntity.PolicyNumber != null && tEntity.PolicyNumber.ToCharArray().Length > 20)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PolicyNumberLength]));

                

                if (tEntity.ModifiedBy == "SYSTEM" || tEntity.ModifiedBy == "HL7 SYSTEM")
                    tEntity.HL7UpdateFlag = true;



                var policyHolder = await this._insurancePolicyHolderRepository.GetByUId(entity.PHUId);
                tEntity.PHID = policyHolder == null ? tEntity.PHID : policyHolder.Id;

                //await SendAcktoEMRAfterAddOrUpdate(tEntity);
                //if (!isFromHL7)
                //{
                //    var emrAck = await this.SendAcktoEMRAfterAddOrUpdate(tEntity);
                //    if (emrAck != null)
                //    {
                //        if (!string.IsNullOrWhiteSpace(emrAck.Exception))
                //        {
                //            await this.ThrowErrorFromEMR("EMR Error: " + emrAck.Exception);
                //        }
                //    }

                //    tEntity.EMRInsurancePolicyId = emrAck.EMRPolicyId;
                //}
                    
                if(!entity.EMRInsurancePolicyId.HasValue)
                {
                    var errors = await this.ValidateEntityToAdd(tEntity);
                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);
                }
                
                //await InActivateAllPolicies(tEntity.PatientCaseId, tEntity.InsuranceLevel);

                tEntity.IsActive = true;
                tEntity.IsDeleted = false;


                return await base.AddNewAsync(tEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<int> InActivateAllPolicies(int patientCaseId,int level)
        {
            var getPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId && i.InsuranceLevel == level);
            foreach (var item in getPolicyData)
            {
                item.IsActive = false;

                var updateOnlyFields = this.Connection
                                           .From<InsurancePolicy>()
                                           .Update(x => new
                                           {                                               
                                               x.IsActive
                                           })
                                           .Where<InsurancePolicy>(i => i.UId == item.UId);

                var value = await base.UpdateOnlyAsync(item, updateOnlyFields);
            }

            return 0;
        }

        public async Task<int> Update(IInsurancePolicy entity, bool isConditionCheck = true,bool isfromUI=false)
        {
            try
            {
                InsurancePolicy tEntity = entity as InsurancePolicy;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;
                // tEntity.PlanExpirationDate = tEntity.PlanExpirationDate == string.Empty ? null : tEntity.PlanExpirationDate;
                if (isConditionCheck)
                {
                    var company = await this._insuranceCompanyRepository.GetByUId(entity.InsuranceCompany.Id>0 ?entity.InsuranceCompany.UId: tEntity.InsuranceCompanyUId);
                    tEntity.InsuranceCompanyID = company.Id;

                    //var patientCase = await this._patientCaseRepository.GetByUId(entity.PatientCaseUId);
                    //tEntity.PatientCaseId = patientCase.Id;

                    var policyHolder = await this._insurancePolicyHolderRepository.GetByUId(entity.InsurancePolicyHolder.UId);
                    tEntity.PHID = policyHolder == null ? tEntity.PHID : policyHolder.Id;
                }

                var insurancePolicy = await this.Connection.SingleAsync<InsurancePolicy>(i => i.Id == entity.Id);
                if (insurancePolicy == null)
                {
                    tEntity.Id = 0;
                    tEntity.InsuranceCompanyUId = tEntity.InsuranceCompany.UId;

                    await this.AddNew(tEntity);

                    return 1;
                }
                else
                {
                    entity.UId = insurancePolicy.UId;
                }

                var getCompany = await this._insuranceCompanyRepository.GetById(tEntity.InsuranceCompanyID);
                if (getCompany.CompanyTypeId == 4)
                {
                    if (string.IsNullOrWhiteSpace(tEntity.MedicaidId))
                    {
                        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.MedicaidIdRequired]));
                    }
                }

                if(!tEntity.IsFromIntegration.HasValue)
                {
                    tEntity.IsFromIntegration = false;
                }

                //if (isfromUI==true)
                //{
                //    var emrAck = await this.SendAcktoEMRAfterAddOrUpdate(tEntity);
                //    if (emrAck != null)
                //    {
                //        if (!string.IsNullOrWhiteSpace(emrAck.Exception))
                //        {
                //            await this.ThrowErrorFromEMR("EMR Error: "+emrAck.Exception);
                //        }
                //    }

                //    tEntity.EMRInsurancePolicyId = emrAck.EMRPolicyId;
                //}
                if(tEntity.IsActive.Value)
                {
                    if(!tEntity.EMRInsurancePolicyId.HasValue)
                    {
                        var errors = await this.ValidateEntityToUpdate(tEntity);
                        if (errors.Count() > 0)
                            await this.ThrowEntityException(errors);
                    }
                    
                }
                

                if(tEntity.IsActive.HasValue && tEntity.IsActive.Value)
                {
                   // await InActivateAllPolicies(tEntity.PatientCaseId, tEntity.InsuranceLevel);
                }

                if (!tEntity.IsDeleted.HasValue)
                    tEntity.IsDeleted = false;

                var updateOnlyFields = this.Connection
                                           .From<InsurancePolicy>()
                                           .Update(x => new
                                           {
                                               x.PolicyNumber,
                                               x.ContactPerson,
                                               x.GroupNumber,
                                               x.GroupName,
                                               x.PlanEffectiveDate,
                                               x.PlanExpirationDate,
                                               x.AuthorizationInformation,
                                               x.PHFirstName,
                                               x.PHLastName,
                                               x.PHRelationshipToPatient,
                                               x.PHDOB,
                                               x.PlanType,
                                               x.PolicyDeductible,
                                               x.InsuranceCompanyID,
                                               x.InsuranceLevel,
                                               x.Copay,
                                               x.PHSignatureOnFile,
                                               x.AcceptAssignment,
                                               x.HL7UpdateFlag,
                                               x.PHID,
                                               x.PatientCaseId,
                                               x.Eligible,
                                               x.Medigap,
                                               x.MedicareSecondary,
                                               x.MedicaidId,
                                               x.IsActive,
                                               x.ModifiedDate,
                                               x.ModifiedBy,
                                               x.EMRInsurancePolicyId,
                                               x.IsDeleted
                                           })
                                           .Where<InsurancePolicy>(i => i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<IValidationResult>> AddValidationError()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyLinkedWithAnyPolicy]));

            return errors;
        }

        public async Task ValidateInsurancePolicy()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsurancePolicyDoesNotExist]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task ValidateMedicaidInsurancePolicy()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceMedicaidIdNotMatched]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task ValidateSelfPInsurancePolicy()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SelfPValidation]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task ValidateInsuranceCompanyType()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceCompanyTypeValidation]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task ThrowErrorFromEMR(string errorMessage)
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(errorMessage));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }

        public async Task ValidateClaimConfig()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimConfig]));
        }

        public async Task ThrowError(IEnumerable<IValidationResult> errors)
        {
            await this.ThrowEntityException(errors);
        }

        public async Task<IInsurancePolicy> Get(int patientCaseId, int level)
        {
            return await this.Connection.SingleAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId && i.InsuranceLevel == level && i.HL7UpdateFlag == false);
        }

        public async Task<IInsurancePolicy> GetById(int patientCaseId, int insuranceId)
        {
            return await this.Connection.SingleAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId && i.InsuranceCompanyID == insuranceId && i.HL7UpdateFlag == false);
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetById(int patientCaseId)
        {
            return await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
        }

        public async Task CheckPoliciesCameOrNotFromEMR(List<int> policyIds,int patientCaseId)
        {
            var list=await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
            foreach (var item in list)
            {
                if(!policyIds.Contains((int)item.EMRInsurancePolicyId.Value))
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                    await this.Update(item,false);
                }
            }
        }

        public async Task<IInsurancePolicy> GetByPolicyId(int policyId)
        {
            return await this.Connection.SingleAsync<InsurancePolicy>(i => i.Id == policyId);
        }

        public async Task<IInsurancePolicy> GetByUId(Guid uid)
        {
            var query = this.Connection.From<InsurancePolicy>()
                             .LeftJoin<InsurancePolicy, InsuranceCompany>((p, c) => p.InsuranceCompanyID == c.Id)
                             .LeftJoin<InsurancePolicy, PatientCase>((p, c) => p.PatientCaseId == c.Id)
                             .LeftJoin<InsurancePolicy, InsurancePolicyHolder>((p, h) => p.PHID == h.Id)
                             .Select<InsurancePolicy, InsuranceCompany, PatientCase, InsurancePolicyHolder>((p, c, pc, h) => new
                             {
                                 p,
                                 InsuranceCompanyUId = c.UId,
                                 PatientCaseUId = pc.UId,
                                 PHUId = h.UId
                             })
                             .Where(i => i.UId == uid);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper<InsurancePolicy>.Map(dynamics);
        }

        public async Task<IInsurancePolicy> GetByPolicyNumber(string policyNumber, IEnumerable<int> patientCaseIds)
        {
            var query = this.Connection.From<InsurancePolicy>()
                        .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id)
                        .SelectDistinct<InsuranceCompany, InsurancePolicy>((ic, ip) => new
                        {
                            ip,
                            InsuranceCompanyName = ic.CompanyName,
                            InsuranceCompanyUId = ic.UId
                        })
                        .Where<InsurancePolicy>(i => i.PolicyNumber == policyNumber && patientCaseIds.Contains(i.PatientCaseId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<InsurancePolicy>.Map(queryResult);

            if (result == null)
            {
                var query1 = this.Connection.From<InsurancePolicy>()
                        .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id)
                        .SelectDistinct<InsuranceCompany, InsurancePolicy>((ic, ip) => new
                        {
                            ip,
                            InsuranceCompanyName = ic.CompanyName,
                            InsuranceCompanyUId = ic.UId
                        })
                        .Where<InsurancePolicy>(i => patientCaseIds.Contains(i.PatientCaseId));

                var queryResult1 = await this.Connection.SelectAsync<dynamic>(query1);
                var result1 = Mapper<InsurancePolicy>.MapList(queryResult1);

                if (result1.Count() > 0)
                {
                    result = result1.Where(i => i.PolicyNumber.Contains(policyNumber.Substring(4))).FirstOrDefault();
                    return result;
                }
                else return null;
            }

            return result;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetByPatientId(int patientCaseId)
        {
            try
            {
                var policyList = (await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId && i.IsDeleted==false)).OrderBy(i => i.InsuranceLevel).OrderByDescending(z => z.PlanEffectiveDate);

                foreach (var item in policyList)
                {
                    item.InsuranceCompany = await this._insuranceCompanyRepository.GetById(item.InsuranceCompanyID.Value);
                    item.InsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(item.PHID);
                }

                return policyList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetByPatientCaseUIds(string patientCaseUIds)
        {
            try
            {
                Guid[] patientCaseUId = Array.ConvertAll<string, Guid>(patientCaseUIds.Split(','), Guid.Parse);
                int[] patientCaseIds = (await this._patientCaseRepository.GetByUIds(patientCaseUId)).Select(i => i.Id).ToArray();

                /* patientCaseUIds.Split(',').ToArray();*/
                var policyList = await this.Connection.SelectAsync<InsurancePolicy>(i => patientCaseIds.Contains(i.PatientCaseId));
                var companyData = await this._insuranceCompanyRepository.GetById(policyList.Select(i => i.InsuranceCompanyID.Value));

                foreach (var item in policyList)
                {
                    item.InsuranceCompanyName = (companyData.Where(i => i.Id == item.InsuranceCompanyID)).FirstOrDefault().CompanyName;
                    item.InsuranceCompanyUId = (companyData.Where(i => i.Id == item.InsuranceCompanyID)).FirstOrDefault().UId;
                    item.InsuranceCompanyTypeId= (companyData.Where(i => i.Id == item.InsuranceCompanyID)).FirstOrDefault().CompanyTypeId;
                }

                return policyList.Where(i=>i.IsActive==true && i.IsDeleted == false);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Guid> GetByPatientCaseId(int patientCaseId)
        {
            var _result = (await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId)).Where(i => i.InsuranceLevel == 1 && i.IsActive==true && i.IsDeleted == false);
            Guid insuranceCompanyUId = new Guid();

            if (_result.Count() > 0)
            {
                insuranceCompanyUId = (await this._insuranceCompanyRepository.GetById(_result.FirstOrDefault().InsuranceCompanyID.Value)).UId;
            }

            return insuranceCompanyUId;
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetInsurancePolicies(string billingId)
        {
            try
            {
                var query = this.Connection.From<InsurancePolicy>()
                            .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id)
                            .Join<InsurancePolicy, PatientCase>((ip, pc) => ip.PatientCaseId == pc.Id)
                            .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .SelectDistinct<InsuranceCompany, InsurancePolicy, PatientCase>((ic, ip, pc) => new
                            {
                                ip,
                                InsuranceCompanyName = ic.CompanyName,
                                InsuranceCompanyCode = ic.CompanyCode,
                                PatientCaseUId = pc.UId,
                                InsuranceCompanyUId = ic.UId

                            })
                            .Where<Patient>(i => i.BillingID == billingId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var policyList = Mapper<InsurancePolicy>.MapList(queryResult);
                foreach (var item in policyList)
                {
                    item.InsuranceCompany.UId = item.InsuranceCompanyUId;
                    //item.InsurancePolicyHolder = await this._insurancePolicyHolderRepository.GetByUId(item.PHUId);
                    item.InsurancePolicyHolder = null;
                }


                return policyList.Where(i=>i.IsActive==true && i.IsDeleted == false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetByCaseId(IEnumerable<int> patientCaseId)
        {
            if (patientCaseId.Count() > 2000)
            {
                long chunkSize = 2000;
                List<List<int>> retVal = new List<List<int>>();

                List<int> newIds = new List<int>();
                newIds.AddRange(patientCaseId);

                while (newIds.Count() > 0)
                {
                    long count = newIds.Count() > chunkSize ? chunkSize : newIds.Count();
                    retVal.Add(newIds.GetRange(0, (int)count));
                    newIds.RemoveRange(0, (int)count);
                }

                List<InsurancePolicy> insurancePolicys = new List<InsurancePolicy>();

                foreach (var item in retVal)
                {
                    var insurancePolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => item.Contains(i.PatientCaseId));
                    insurancePolicys.AddRange(insurancePolicyData);
                }

                return insurancePolicys.Where(i=>i.IsActive==true && i.IsDeleted == false);
            }

            return (await this.Connection.SelectAsync<InsurancePolicy>(i => patientCaseId.Contains(i.PatientCaseId)));
        }

        public async Task<int> Delete(int policyId)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<InsurancePolicy>(i => i.Id == policyId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByUId(Guid uId)
        {
            var result = await this.Connection.DeleteAsync<InsurancePolicy>(i => i.UId == uId);
            return result;
        }

        //public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(InsurancePolicy tEntity)
        //{
        //    List<IValidationResult> errors = new List<IValidationResult>();

        //    if (tEntity.PlanEffectiveDate > tEntity.PlanExpirationDate)
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectiveExpirationDateValidation]));

        //    if (string.IsNullOrEmpty(tEntity.InsuranceLevel.ToString()))
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceLevelRequired]));
        //    //   date = result.Where(i=> i.PlanExpirationDate.Value.Date == (tEntity.PlanEffectiveDate.Value.Date+1))

        //    var entityErrors = await base.ValidateEntity(tEntity);
        //    errors.AddRange(entityErrors);

        //    return errors;
        //}

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(InsurancePolicy tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (tEntity.PlanEffectiveDate > tEntity.PlanExpirationDate)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectiveExpirationDateValidation]));

            string expiryDate = tEntity.PlanExpirationDate.HasValue ? tEntity.PlanExpirationDate.Value.ToString().Split(' ')[0] : "";
            string effectiveDate = tEntity.PlanEffectiveDate.HasValue ? tEntity.PlanEffectiveDate.Value.ToString().Split(' ')[0] : "";

            var allPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == tEntity.PatientCaseId && i.IsActive==true && i.IsDeleted == false);
            var result = allPolicyData.Where(i => i.InsuranceLevel == 1).ToList();
            var policyString = tEntity.InsuranceLevel == (int)InsuranceLevel.Primary ? "Primary" : tEntity.InsuranceLevel == (int)InsuranceLevel.Secondary ? "Secondary" : "Ternary";

            if (result.Count == 0)
            {
                if (tEntity.InsuranceLevel == 2)
                {
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                }
            }
            else
            {
                if (tEntity.InsuranceLevel == (int)InsuranceLevel.Primary)
                {
                    var policyLevelData = allPolicyData.Where(i => i.InsuranceLevel == tEntity.InsuranceLevel);

                    if (policyLevelData.Count(i => i.PlanExpirationDate.HasValue == false) == 0)
                    {
                        if (tEntity.PlanExpirationDate.HasValue)
                        {
                            var existingPolicy = policyLevelData.Count(i => tEntity.PlanEffectiveDate.Value.Date <= i.PlanEffectiveDate.Value.Date && tEntity.PlanExpirationDate.Value.Date >= i.PlanExpirationDate.Value.Date);
                            if (existingPolicy > 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            var dataEffePolicys = policyLevelData.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                            if (dataEffePolicys.Count() >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            var dataExpiryPolicys = policyLevelData.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                            if (dataExpiryPolicys.Count() >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        }
                        else
                        {
                            if (policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) > 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectivePolicyActive]));

                            var dataPolicys = policyLevelData.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                            if (dataPolicys.Count() >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        }
                    }
                    else
                    {
                        policyLevelData = policyLevelData.Where(i => i.PlanExpirationDate.HasValue == false).ToList();

                        var dataEffePolicys1 = policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date && !tEntity.PlanExpirationDate.HasValue);
                        if (dataEffePolicys1 >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));


                        policyLevelData.ToList().ForEach((res) =>
                        {
                            res.PlanExpirationDate = res.PlanEffectiveDate.Value.Date == tEntity.PlanEffectiveDate.Value.Date ? tEntity.PlanEffectiveDate.Value.Date : tEntity.PlanEffectiveDate.Value.Date.AddDays(-1);
                        });

                        foreach (var item in policyLevelData)
                        {
                            if (item.PlanEffectiveDate.Value.Date < item.PlanExpirationDate.Value.Date)
                                await this.Update(item, false);
                            else
                                item.PlanExpirationDate = null;
                        }

                        var dataEffePolicys = allPolicyData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue &&  i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                        if (dataEffePolicys >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                        var dataExpiryPolicys = allPolicyData.Count(i => tEntity.PlanExpirationDate.HasValue && i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.HasValue &&  i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                        if (dataExpiryPolicys >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                        //var lessExpiryPolicys = allPolicyData.Count(i => tEntity.PlanExpirationDate.HasValue && i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date);
                        //if (lessExpiryPolicys >= 1)
                        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                    }
                }

                if (tEntity.InsuranceLevel == 2)
                {
                    //if (result.Count(i => i.PlanExpirationDate.HasValue) > 1)
                    //    if (!tEntity.PlanExpirationDate.HasValue)
                    //        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyExpirationDate]));

                    var policyLevelData = allPolicyData.Where(i => i.InsuranceLevel == tEntity.InsuranceLevel);
                    var secondPolicyData = policyLevelData.Where(i => i.Id != tEntity.Id && !i.PlanExpirationDate.HasValue);

                    if (secondPolicyData.Count() > 0)
                    {
                        secondPolicyData.ToList().ForEach((res) =>
                        {
                            res.PlanExpirationDate = res.PlanEffectiveDate.Value.Date == tEntity.PlanEffectiveDate.Value.Date ? tEntity.PlanEffectiveDate.Value.Date : tEntity.PlanEffectiveDate.Value.Date.AddDays(-1);
                        });

                        foreach (var item in policyLevelData)
                        {
                            await this.Update(item, false);
                        }
                    }

                    //if (policyData.Count() <= 1)
                    //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));

                    if (!tEntity.PlanExpirationDate.HasValue)
                    {

                        if (policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) > 0)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectivePolicyActive]));

                        var dataPolicys = policyLevelData.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                        if (dataPolicys.Count() >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));


                        //var policyData = result.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && ((i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) || true));
                        //if (policyData.Count() == 0)
                        //{
                        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyExpirationDate]));
                        //}

                        //policyData = result.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && !i.PlanExpirationDate.HasValue);
                        //if (policyData.Count() == 0)
                        //{
                        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyExpirationDate]));
                        //}


                    }
                    else
                    {
                        var policyData = result.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                        if (policyData.Count() == 0)
                        {
                            policyData = result.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date);
                            if(policyData.Count()==0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                        }

                        //var policySecData = result.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && !i.PlanExpirationDate.HasValue);
                        //if (policySecData.Count() > 0)
                        //{
                        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                        //}

                        var dataEffePolicys = policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                        if (dataEffePolicys >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                        var dataExpiryPolicys = policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                        if (dataExpiryPolicys >= 1)
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                        //var dataEffePolicys = policyLevelData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                        //if (dataEffePolicys > 0)
                        //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, tEntity.PlanEffectiveDate, tEntity.PlanExpirationDate]));

                    }
                }
            }

            if (string.IsNullOrEmpty(tEntity.InsuranceLevel.ToString()))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceLevelRequired]));
            //   date = result.Where(i=> i.PlanExpirationDate.Value.Date == (tEntity.PlanEffectiveDate.Value.Date+1))

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        //public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(InsurancePolicy tEntity)
        //{
        //    List<IValidationResult> errors = new List<IValidationResult>();

        //    if (tEntity.PlanEffectiveDate > tEntity.PlanExpirationDate)
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectiveExpirationDateValidation]));

        //    if (string.IsNullOrEmpty(tEntity.InsuranceLevel.ToString()))
        //        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceLevelRequired]));
        //    //   date = result.Where(i=> i.PlanExpirationDate.Value.Date == (tEntity.PlanEffectiveDate.Value.Date+1))

        //    var entityErrors = await base.ValidateEntity(tEntity);
        //    errors.AddRange(entityErrors);

        //    return errors;
        //}


        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(InsurancePolicy tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            string expiryDate = tEntity.PlanExpirationDate.HasValue ? tEntity.PlanExpirationDate.Value.ToString().Split(' ')[0] : "";
            string effectiveDate = tEntity.PlanEffectiveDate.HasValue ? tEntity.PlanEffectiveDate.Value.ToString().Split(' ')[0] : "";

            var allPolicyData = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == tEntity.PatientCaseId && i.IsActive==true && i.IsDeleted == false);
            var secondaryPolicies = allPolicyData.Where(i => i.InsuranceLevel == (int)InsuranceLevel.Secondary).ToList();

            var policyString = tEntity.InsuranceLevel == (int)InsuranceLevel.Primary ? "Primary" : tEntity.InsuranceLevel == (int)InsuranceLevel.Secondary ? "Secondary" : "Ternary";

            if (allPolicyData.Count > 1)
            {
                if (tEntity.InsuranceLevel == (int)InsuranceLevel.Primary)
                {
                    var primaryPolicies = allPolicyData.Where(i => i.InsuranceLevel == (int)InsuranceLevel.Primary && i.Id != tEntity.Id).ToList();

                    if (primaryPolicies.Count > 0)
                    {
                        if (tEntity.PlanExpirationDate.HasValue)
                        {
                            var existingPolicy = primaryPolicies.Count(i => tEntity.PlanEffectiveDate.Value.Date <= i.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && tEntity.PlanExpirationDate.Value.Date >= i.PlanExpirationDate.Value.Date);
                            if (existingPolicy > 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        }

                        if (primaryPolicies.FirstOrDefault(i => !i.PlanExpirationDate.HasValue) == null)
                        {
                            if (tEntity.PlanExpirationDate.HasValue)
                            {
                                if (primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) > 0)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                                var dataEffePolicys = primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                                if (dataEffePolicys >= 1)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                                var dataExpiryPolicys = primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                                if (dataExpiryPolicys >= 1)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            }
                            else
                            {
                                var countPrimary = primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                                if (countPrimary > 0)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectivePolicyActive]));

                                var dataPolicys = primaryPolicies.Where(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                                if (dataPolicys.Count() >= 1)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            }
                        }
                        else
                        {

                            var dataEffePolicys = primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date &&(i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date));
                            if (dataEffePolicys >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            var dataExpiryPolicys = primaryPolicies.Count(i => i.PlanExpirationDate.HasValue &&  tEntity.PlanExpirationDate.HasValue && i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                            if (dataExpiryPolicys >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            //var lessExpiryPolicys = primaryPolicies.Count(i => tEntity.PlanExpirationDate.HasValue && i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date);
                            //if (lessExpiryPolicys >= 1)
                            //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            if (!tEntity.PlanExpirationDate.HasValue)
                            {
                                var existsAfterExpiryNull = primaryPolicies.Count(i => i.PlanEffectiveDate >= tEntity.PlanEffectiveDate);
                                if (existsAfterExpiryNull > 0)
                                {
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));                                    
                                }
                            }
                            //var maxPrimaryEffectiveDate = primaryPolicies.Min(i => i.PlanEffectiveDate);
                            //var maxPrimaryExpireDate = primaryPolicies.Where(i => !i.PlanExpirationDate.HasValue).Max(i => i.PlanEffectiveDate);

                            //if (!tEntity.PlanExpirationDate.HasValue)
                            //{
                            //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            //}
                            //else
                            //{
                            //    if (maxPrimaryEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date)
                            //        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            //}
                        }

                        //if (secondaryPolicies.Count > 0)
                        //{
                        //    if (secondaryPolicies.FirstOrDefault(i => !i.PlanExpirationDate.HasValue) == null)
                        //    {
                        //        var maxSecondaryExpireDate = secondaryPolicies.Max(i => i.PlanExpirationDate);
                        //        if (maxSecondaryExpireDate != null && tEntity.PlanExpirationDate.HasValue)
                        //            if (tEntity.PlanExpirationDate.Value.Date < maxSecondaryExpireDate.Value.Date)
                        //                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        //    }
                        //    else
                        //    {
                        //        var maxSecondaryEffectiveDate = secondaryPolicies.Max(i => i.PlanEffectiveDate);
                        //        if (maxSecondaryEffectiveDate != null)
                        //            if (tEntity.PlanExpirationDate.HasValue)
                        //                if (tEntity.PlanExpirationDate.Value.Date < maxSecondaryEffectiveDate.Value.Date)
                        //                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        //    }
                        //}
                    }
                    else
                    {
                        if (secondaryPolicies.Count > 0)
                        {
                            if (secondaryPolicies.FirstOrDefault(i => !i.PlanExpirationDate.HasValue) == null)
                            {
                                if (tEntity.PlanExpirationDate.HasValue)
                                {
                                    var maxSecondaryExpireDate = secondaryPolicies.Max(i => i.PlanExpirationDate);
                                    if (tEntity.PlanExpirationDate.Value.Date < maxSecondaryExpireDate.Value.Date)
                                        await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                                }
                            }
                        }
                    }
                }


                if (tEntity.InsuranceLevel == (int)InsuranceLevel.Secondary)
                {
                    var secondPlicy = secondaryPolicies.Where(i => i.Id != tEntity.Id);

                    var primaryPolicies = allPolicyData.Where(i => i.InsuranceLevel == (int)InsuranceLevel.Primary).ToList();
                    if (tEntity.PlanExpirationDate.HasValue)
                    {
                        if (primaryPolicies.Count(i => !i.PlanExpirationDate.HasValue) == 0)
                        {
                            if (primaryPolicies.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date) == 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                        }
                        else
                        {
                            var policyHasNOtData = primaryPolicies.Where(i => !i.PlanExpirationDate.HasValue);
                            var policyHasData = primaryPolicies.Where(i => i.PlanExpirationDate.HasValue);

                            if (policyHasNOtData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date) == 0 && policyHasData.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) == 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                        }
                    }
                    else
                    {
                        if (primaryPolicies.Count(i => !i.PlanExpirationDate.HasValue) == 0)
                        {
                            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EffectivePolicyActive]));
                        }
                        else
                        {
                            //commented on 07112024
                            //var policyHasNOtData = primaryPolicies.FirstOrDefault(i => !i.PlanExpirationDate.HasValue);
                            //if (policyHasNOtData.PlanEffectiveDate.Value.Date > tEntity.PlanEffectiveDate.Value.Date)
                            //    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
                        }
                    }

                    if (secondPlicy.Count() > 0)
                    {
                        if (tEntity.PlanExpirationDate.HasValue)
                        {
                            if (secondPlicy.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date) > 0)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            
                            var dataEffePolicys = secondPlicy.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date);
                            if (dataEffePolicys >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));

                            var dataExpiryPolicys = secondPlicy.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanExpirationDate.Value.Date && i.PlanExpirationDate.HasValue  && i.PlanExpirationDate.Value.Date >= tEntity.PlanExpirationDate.Value.Date);
                            if (dataExpiryPolicys >= 1)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                        }
                        else
                        {
                            if (secondPlicy.FirstOrDefault(i => !i.PlanExpirationDate.HasValue) != null)
                                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            else
                            {
                                if (secondPlicy.Count(i => i.PlanEffectiveDate.Value.Date <= tEntity.PlanEffectiveDate.Value.Date && i.PlanExpirationDate.HasValue && i.PlanExpirationDate.Value.Date >= tEntity.PlanEffectiveDate.Value.Date) > 0)
                                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PrimaryPolicyDateOverlap, policyString, effectiveDate, expiryDate]));
                            }
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(tEntity.InsuranceLevel.ToString()))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsuranceLevelRequired]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<IInsurancePolicy> GetByInsuranceCompanyId(int companyId)
        {
            try
            {
                var result = await this.Connection.SingleAsync<InsurancePolicy>(i => i.InsuranceCompanyID == companyId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetPoliciesByPatientCaseId(int patientCaseId)
        {
            try
            {
                var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId && i.InsuranceLevel == 2);
                return result;
            }
            catch
            {
                throw;
            }
        }

        //public async Task<IEnumerable<IInsurancePolicy>> GetPoliciesByPatientCaseUId(Guid patientCaseUId)
        //{
        //    try
        //    {
        //        var result =await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseUId == patientCaseUId && i.InsuranceLevel == 2);
        //        return result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public async Task ErrorDeletingInsurancePolicy()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ErrorDeletingInsurancePolicy]));
            // errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SecondaryPolicyEffectivePeriod]));
            await this.ThrowEntityException(errors);
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetByInsuranceCompanyId(IEnumerable<int> companyIds)
        {
            try
            {
                var query = this.Connection.From<InsurancePolicy>()
                        .Join<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id)
                        .SelectDistinct<InsuranceCompany, InsurancePolicy>((ic, ip) => new
                        {
                            ip,
                            InsuranceCompanyName = ic.CompanyName
                        })
                        .Where<InsuranceCompany>(i => companyIds.Contains(i.Id));

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<InsurancePolicy>.MapList(queryResult);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> DeleteByPatientCaseId(int patientCaseId)
        {
            try
            {
                return await this.Connection.DeleteAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowError(IInsurancePolicy policyData)
        {
            if (policyData == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.InsurancePolicyDoesNotExist]));
            }
        }

        public async Task<string> VerifyPatientEligibility(Guid patientUId, Guid policyUId, string serviceTypeCode)
        {
            try
            {
                var insPolicy = this.GetByUId(policyUId);
                // Create following tables for Patient Eligibility

                //  1. Patient_Eligibility
                // Add Following Columns.
                // ID, ENTRY_DATE, TRN, Eligibility_Date, Error_Message, PatientID, ProviderID, Insurance\Plan ID, Subscriber LN\FN\MI]DOB\Gender Provider LN\FN\NPI, Insurance Name, PAYER ID.
                // Status, AAA_Error
                var config = await this._configTrizettoPatientEligibilityRepository.GetAll();

                var patientData = await this._patientRepository.GetPatientInformation(patientUId, insPolicy.Id);
                // check patient data here


                //  2. Patient_Eligibility_Detail
                // Add Following Columns.
                // 
                // Coverage, CoverageLevel, ServiceTypes, PlanName, PlanDescription, TimePeriod, BenefitAmount, BenefitPercentage
                // Authorization, PlanNetwork, Messages, Other

                // 3. EDI_Eligibility_Log
                // ID, Eligibility_ID, Transaction_270, Transaction_271

                _270Header header = new _270Header();

                header.ISA01AuthQual = config.ISA01AuthQual;
                header.ISA02AuthInfo = ".";
                header.ISA03SecQual = config.ISA03SecQual;
                header.ISA04SecInfo = config.ISA04SecInfo;
                header.ISA06SenderID = config.ISA06SenderId;
                header.ISA08ReceiverID = config.ISA08ReceiverId;

                // Create a sequence of 9 digits, starting from 1111111111.
                // pick a number from sequence and use here and incriment it.
                // Make sure ISA13CntrlNumber for every request is unique.
                long isA13CntrlNumber;
                isA13CntrlNumber = Convert.ToInt64(config.ISA13CntrlNumber) + 1;
                header.ISA13CntrlNumber = isA13CntrlNumber.ToString();

                header.ISA15UsageIndi = config.ISA15UsageIndi;    // T for Testing , P for production
                header.GS02SenderID = config.GS02SenderId;
                header.GS03ReceiverID = config.GS03ReceiverId;

                // Payer\Insurance Information 
                header.PayerOrgName = patientData.InsuranceName;//"HEALTH ADMIN CENTER";                
                header.PayerID = patientData.TrizettoInsuranceCode;// "84146";


                _270Data patient = new _270Data();

                patient.ServiceTypeCode = serviceTypeCode;

                // Provider Inforamtion
                patient.ProvEntity = "2"; // 2 if it is organization, 1 if it is an individual with last name and first name
                patient.ProvLastName = patientData.ProviderLName;//"Access Hospital Dayton LLC";
                patient.ProvFirstName = patientData.ProviderFName;//"";
                patient.ProvMI = "";
                patient.ProvNPI = patientData.ProviderNPI; //"1063737765";

                // Subscriber Information
                patient.SBRLastName = patientData.LastName; //"Boroff";
                patient.SBRFirstName = patientData.FirstName; //"Alicia";
                patient.SBRMiddleInitial = patientData.MI; //"";
                patient.SBRID = patientData.PolicyNumber; //"W224472009";
                patient.SBRDob = Convert.ToDateTime(patientData.DOB); //new DateTime(1988, 4, 27);
                patient.SBRGender = patientData.Sex; //"F";

                // Eligibility Date For which Eligibility is being checked
                patient.EligiblityForDate = DateTime.Now;

                // Create a sequence of 10 digits, starting from 1111111111.
                // pick a number from sequence and use here and incriment it.
                // Make sure TRN01 for every request is unique.

                long tRN01;
                tRN01 = Convert.ToInt64(config.TRN01) + 1;

                patient.TRN01 = tRN01.ToString();
                patient.TRN02 = "V2X7      ";

                header.SBRData = patient;

                if (Convert.ToBoolean(patientData.PatientElig) == false)
                {
                    return "Payer [" + patientData.InsuranceName + "] is not regiested for patient eligibility with trizetto";
                }

                // Add or Update Trizetto Patient Eligibility
                PatientEligibility patientEligibility = new PatientEligibility();
                patientEligibility.PatientId = patientData.Id;
                patientEligibility.TRN = tRN01.ToString();
                var entity = await this._patientEligibilityRepository.AddNew(patientEligibility);

                Eligibility.Vendor clearingHouse = (Eligibility.Vendor)Enum.Parse(typeof(Eligibility.Vendor), patientData.Clearinghouse);

                // change clearing house
                Eligibility objStatus = new Eligibility("V2X7", "fjbkjsc1", clearingHouse);

                Output271 output = objStatus.SendRequest(header);

                ConfigTrizettoPatientEligibility configTrizettoPatientEligibility = new ConfigTrizettoPatientEligibility();
                configTrizettoPatientEligibility.ISA13CntrlNumber = isA13CntrlNumber;
                configTrizettoPatientEligibility.TRN01 = tRN01;
                await this._configTrizettoPatientEligibilityRepository.UpdateTransactionNumber(configTrizettoPatientEligibility);

                EDIEligibilityLog eDIEligibilityLog = new EDIEligibilityLog();
                eDIEligibilityLog.PatientEligibilityId = entity.Id;

                if (output.ErrorMessage == "Success")
                {
                    if (output.EligibilityData == null)
                    {
                        return "Eligibility Data did not return from Trizetto.";
                    }

                    foreach (_271Header hh in output.EligibilityData)
                    {
                        string AAA_Code = hh.SubscriberData.AAA03;
                        foreach (_271SBREligibilityInfo eligInfo in hh.SubscriberData.EligibilityData)
                        {
                            // Save Following Data into 2nd Table. 
                            string coverage = eligInfo.EB01CoverageTypeV;
                            string coverageLevel = eligInfo.EB02CoverageLevelV;
                            string services = eligInfo.EB03ServiceTypeCodeV;
                            string planName = eligInfo.EB04InsuranceTypeCodeV;
                            string planDesc = eligInfo.EB05PlanCoverageDescV;
                            string timePeriod = eligInfo.EB06TimePeriodV;
                            string BenefitAmount = eligInfo.EB07MonetoryAmount;
                            string BenefitPercentage = eligInfo.EB08BenefitPercent;
                            string QuantityQual = eligInfo.EB09QuanityQualifierV;
                            string QuantityValue = eligInfo.EB10BenenfitQuantity;
                            string Authorization = eligInfo.EB11AuthorizationIndicatorV;
                            string PlanNetwork = eligInfo.EB12PlanNetworkIndicatorV;

                            // Save all these messages as '=' seperated in one column.
                            string Messages = string.Empty;
                            if (eligInfo.Messages != null)
                                Messages = string.Join("=", eligInfo.Messages);



                            string ReferenceIds = string.Empty;
                            // These are the Reference IDs like Group Number etc
                            // Example:   Group Number: U324380
                            // Save All Refrence Ids into One column Or Save at least 5 occurence of Ref Ids into sepearate Column.

                            // Method 1: All in One Column Pattern
                            if (eligInfo.ListOfReferenceIds != null)
                            {
                                foreach (KeyValuePair<string, string> entry in eligInfo.ListOfReferenceIds)
                                {
                                    ReferenceIds += entry.Key + "," + entry.Value + "=";
                                }
                            }
                            // Method 2: Save atleast 5 occurrences
                            string ReferenceId1 = string.Empty, ReferenceValue1 = string.Empty;
                            string ReferenceId2 = string.Empty, ReferenceValue2 = string.Empty;
                            string ReferenceId3 = string.Empty, ReferenceValue3 = string.Empty;
                            string ReferenceId4 = string.Empty, ReferenceValue4 = string.Empty;
                            string ReferenceId5 = string.Empty, ReferenceValue5 = string.Empty;
                            int counter = 1;
                            if (eligInfo.ListOfReferenceIds != null)
                            {
                                foreach (KeyValuePair<string, string> entry in eligInfo.ListOfReferenceIds)
                                {
                                    if (counter == 1)
                                        ReferenceId1 = entry.Key; ReferenceValue1 = entry.Value;
                                    if (counter == 2)
                                        ReferenceId2 = entry.Key; ReferenceValue2 = entry.Value;
                                    if (counter == 3)
                                        ReferenceId3 = entry.Key; ReferenceValue3 = entry.Value;
                                    if (counter == 4)
                                        ReferenceId4 = entry.Key; ReferenceValue4 = entry.Value;
                                    if (counter == 5)
                                        ReferenceId5 = entry.Key; ReferenceValue5 = entry.Value;

                                    counter += 1;
                                }
                            }


                            string Dates = string.Empty;
                            // These are the Reference IDs like Group Number etc
                            // Example:   Group Number: U324380
                            // Save All Refrence Ids into One column Or Save at least 5 occurence of Ref Ids into sepearate Column.

                            // Method 1: All in One Column Pattern
                            if (eligInfo.ListOfDates != null)
                            {
                                foreach (KeyValuePair<string, DateTime> entry in eligInfo.ListOfDates)
                                {
                                    Dates += entry.Key + "," + entry.Value.ToString("MM/dd/yyyy") + "=";
                                }
                            }

                            // Method 2: Save atleast 5 occurrences
                            string DateId1 = string.Empty, DateValue1 = string.Empty;
                            string DateId2 = string.Empty, DateValue2 = string.Empty;
                            string DateId3 = string.Empty, DateValue3 = string.Empty;
                            string DateId4 = string.Empty, DateValue4 = string.Empty;
                            string DateId5 = string.Empty, DateValue5 = string.Empty;
                            counter = 1;
                            if (eligInfo.ListOfDates != null)
                            {
                                foreach (KeyValuePair<string, DateTime> entry in eligInfo.ListOfDates)
                                {
                                    if (counter == 1)
                                        DateId1 = entry.Key; DateValue1 = entry.Value.ToString("MM/dd/yyyy");
                                    if (counter == 2)
                                        DateId2 = entry.Key; DateValue2 = entry.Value.ToString("MM/dd/yyyy");
                                    if (counter == 3)
                                        DateId3 = entry.Key; DateValue3 = entry.Value.ToString("MM/dd/yyyy");
                                    if (counter == 4)
                                        DateId4 = entry.Key; DateValue4 = entry.Value.ToString("MM/dd/yyyy");
                                    if (counter == 5)
                                        DateId5 = entry.Key; DateValue5 = entry.Value.ToString("MM/dd/yyyy");

                                    counter += 1;
                                }
                            }

                            PatientEligibilityDetail patientEligibilityDetail = new PatientEligibilityDetail();
                            patientEligibilityDetail.PatientEligibilityId = entity.Id;
                            patientEligibilityDetail.Coverage = (coverage == null ? "" : coverage);
                            patientEligibilityDetail.CoverageLevel = (coverageLevel == null ? "" : coverageLevel);
                            patientEligibilityDetail.ServiceTypes = (services == null ? "" : services);
                            patientEligibilityDetail.PlanName = (planName == null ? "" : planName);
                            patientEligibilityDetail.PlanDescription = (planDesc == null ? "" : planDesc);
                            patientEligibilityDetail.TimePeriod = (timePeriod == null ? "" : timePeriod);
                            decimal benefitAmount = 0;
                            decimal.TryParse(BenefitAmount, out benefitAmount);
                            patientEligibilityDetail.BenefitAmount = benefitAmount;
                            decimal benefitPercentage = 0;
                            decimal.TryParse(BenefitPercentage, out benefitPercentage);
                            patientEligibilityDetail.BenefitPercentage = benefitPercentage;
                            patientEligibilityDetail.Authorization = (Authorization == null ? "" : Authorization);
                            patientEligibilityDetail.PlanNetwork = (PlanNetwork == null ? "" : PlanNetwork);
                            patientEligibilityDetail.Messages = (Messages == null ? "" : Messages);
                            patientEligibilityDetail.Other = "";
                            patientEligibilityDetail.ReferenceId1 = ReferenceId1;
                            patientEligibilityDetail.ReferenceValue1 = ReferenceValue1;
                            patientEligibilityDetail.ReferenceId2 = ReferenceId2;
                            patientEligibilityDetail.ReferenceValue2 = ReferenceValue2;
                            patientEligibilityDetail.ReferenceId3 = ReferenceId3;
                            patientEligibilityDetail.ReferenceValue3 = ReferenceValue3;
                            patientEligibilityDetail.ReferenceId4 = ReferenceId4;
                            patientEligibilityDetail.ReferenceValue4 = ReferenceValue4;
                            patientEligibilityDetail.ReferenceId5 = ReferenceId5;
                            patientEligibilityDetail.ReferenceValue5 = ReferenceValue5;
                            patientEligibilityDetail.DateId1 = DateId1;
                            patientEligibilityDetail.DateValue1 = DateValue1;
                            patientEligibilityDetail.DateId2 = DateId2;
                            patientEligibilityDetail.DateValue2 = DateValue2;
                            patientEligibilityDetail.DateId3 = DateId3;
                            patientEligibilityDetail.DateValue3 = DateValue3;
                            patientEligibilityDetail.DateId4 = DateId4;
                            patientEligibilityDetail.DateValue4 = DateValue4;
                            patientEligibilityDetail.DateId5 = DateId5;
                            patientEligibilityDetail.DateValue5 = DateValue5;
                            await this._patientEligibilityDetailRepository.AddNew(patientEligibilityDetail);

                        }
                    }

                    // Save following into EDI_Eligibility_Log.
                    string Transaction270 = output.Transaction270;
                    string Transaction271 = output.Transaction271;
                    string Transaction999 = output.Transaction999;


                    eDIEligibilityLog.Transaction270 = Transaction270;
                    eDIEligibilityLog.Transaction271 = Transaction271;
                    await this._ediEligibilityLogRepository.AddNew(eDIEligibilityLog);
                }
                else
                {
                    eDIEligibilityLog.Transaction270 = output.Transaction270;
                    eDIEligibilityLog.Transaction271 = output.Transaction271;
                    await this._patientEligibilityRepository.AddNew(patientEligibility);
                    await this._ediEligibilityLogRepository.AddNew(eDIEligibilityLog);
                }
                return "";
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> CheckPolicyHoderUsed(long policyId, int policyHolderId)
        {
            try
            {
                var item = await this.Connection.SingleAsync<InsurancePolicy>(i => i.PHID == policyHolderId && i.Id != policyId);
                return item == null ? false : true;
            }
            catch
            {
                throw;
            }
        }

        public async Task ValidateAnthemInsurancePolicy()
        {

            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AnthemPolicyNumberValidation]));

            if (errors.Count() > 0)
            {
                await this.ThrowEntityException(errors);
            }
        }



        //public async Task<bool> CheckInsurancePolicyExists(int patientCaseId, DateTime fromDate, int insuranceLevel)
        //{
        //    try
        //    {
        //        bool insurancePolicyExists = false;
        //        var result = await this.Connection.SelectAsync<InsurancePolicy>(i => i.PatientCaseId == patientCaseId);
        //        result = result.Where(i => i.InsuranceLevel == insuranceLevel && (i.PlanEffectiveDate.HasValue
        //                     && i.PlanEffectiveDate.Value.Date <= fromDate.Date) && ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue &&
        //                     i.PlanExpirationDate.Value.Date >= fromDate.Date))).ToList();
        //        if (result != null && result.Count() > 0)
        //        {
        //            insurancePolicyExists = true;
        //        }
        //        return insurancePolicyExists;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public async Task<IEnumerable<IInsurancePolicy>> GetListForEMR()
        //{
        //    try
        //    {
        //        return await this.Connection.SelectAsync<InsurancePolicy>(i => i.IsNotifyToEMR==false);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        public async Task<IEnumerable<IInsurancePolicy>>GetPolicyEMRExceptionList()
        {
            var query = this.Connection.From<InsurancePolicy>()
                            .LeftJoin<InsurancePolicy, InsuranceCompany>((p, c) => p.InsuranceCompanyID == c.Id)
                            .LeftJoin<InsurancePolicy, Patient>((p, c) => p.PatientCaseId == c.DefaultCaseId)
                             .Join<InsurancePolicy, InsurancePolicyException>((p, c) => p.Id == c.PolicyId)
                             .Select<InsurancePolicy, InsurancePolicyException, InsuranceCompany,Patient>((p, c,i,pt) => new
                             {
                                 p,
                                 InsuranceCompanyName = i.CompanyName,
                                 InsuranceCompanyCode = i.CompanyCode,
                                 BillinId = pt.BillingID,
                                 ErrorMessage = c.ErrorMessage,
                                 PatientUId=pt.UId
                             });
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var list = Mapper<InsurancePolicy>.MapList(dynamics);
            return list;
                             
        }

        public async Task<IPolicyException> SendAcktoEMRAfterAddOrUpdate(IInsurancePolicy insurancePolicy)
        {
            List<PolicyException> returnList = new List<PolicyException>();
            List<PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO> policyList = new List<DataAccess.PatientService.Model.InsurancePolicyDTO>();

            var patient= await this._patientRepository.GetByCaseId(insurancePolicy.PatientCaseId);

            int billingId = 0;
            int.TryParse(patient.BillingID, out billingId);

            if (billingId == 0)
            {            
                return null;
            }

            insurancePolicy.BillinId = patient.BillingID;

            var insurancePolicyHolder = await this._insurancePolicyHolderRepository.GetByUId(insurancePolicy.PHUId);
            if(insurancePolicyHolder==null)
            {
                insurancePolicyHolder = await this._insurancePolicyHolderRepository.GetById(insurancePolicy.PHID);
            }

            var authorizationList = await this._patientAuthorizationNumberRepository.GetAuthorization(insurancePolicy.Id);

            PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO insurancePolicyDTO = new PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO();
            insurancePolicyDTO.AcceptAssignment = insurancePolicy.AcceptAssignment;
            insurancePolicyDTO.ContactPerson = insurancePolicy.ContactPerson;
            insurancePolicyDTO.PlanEffectiveDate = insurancePolicy.PlanEffectiveDate.Value;
            insurancePolicyDTO.PlanExpirationDate = insurancePolicy.PlanExpirationDate;
            insurancePolicyDTO.GroupName = insurancePolicy.GroupName;
            insurancePolicyDTO.GroupNumber = insurancePolicy.GroupNumber;
            if (insurancePolicy.EMRInsurancePolicyId.HasValue)
                insurancePolicyDTO.Id = insurancePolicy.EMRInsurancePolicyId.Value;

            insurancePolicyDTO.InsurancePolicyHolder = new DataAccess.PatientService.Model.Insurancepolicyholder();

            insurancePolicyDTO.InsurancePolicyHolder.address1 = insurancePolicyHolder.Address1;
            insurancePolicyDTO.InsurancePolicyHolder.address2 = insurancePolicyHolder.Address2;
            insurancePolicyDTO.InsurancePolicyHolder.busPhone = insurancePolicyHolder.BusPhone;
            insurancePolicyDTO.InsurancePolicyHolder.city = insurancePolicyHolder.City;
            if (insurancePolicyHolder.DOB.HasValue)
                insurancePolicyDTO.InsurancePolicyHolder.dob = insurancePolicyHolder.DOB.Value;
            insurancePolicyDTO.InsurancePolicyHolder.employerAddress1 = insurancePolicyHolder.EmployerAddress1;
            insurancePolicyDTO.InsurancePolicyHolder.employerAddress2 = insurancePolicyHolder.EmployerAddress2;
            insurancePolicyDTO.InsurancePolicyHolder.employerCity = insurancePolicyHolder.EmployerCity;
            insurancePolicyDTO.InsurancePolicyHolder.employerPhone = insurancePolicyHolder.EmployerPhone;
            insurancePolicyDTO.InsurancePolicyHolder.employerState = insurancePolicyHolder.EmployerState;
            insurancePolicyDTO.InsurancePolicyHolder.employerZip = insurancePolicyHolder.EmployerZip;
            insurancePolicyDTO.InsurancePolicyHolder.firstName = insurancePolicyHolder.FirstName;
            insurancePolicyDTO.InsurancePolicyHolder.lastName = insurancePolicyHolder.LastName;
            int sex = 1;
            if (insurancePolicyHolder.Sex == "M") sex = 1; if (insurancePolicyHolder.Sex == "F") sex = 2;
            if (insurancePolicyHolder.Sex == "A") sex = 3; if (insurancePolicyHolder.Sex == "U") sex = 4;

            insurancePolicyDTO.InsurancePolicyHolder.genderId = sex;

            insurancePolicyDTO.InsurancePolicyHolder.employerCity = insurancePolicyHolder.EmployerCity;
            insurancePolicyDTO.InsurancePolicyHolder.employerPhone = insurancePolicyHolder.EmployerPhone;
            insurancePolicyDTO.InsurancePolicyHolder.employerState = insurancePolicyHolder.EmployerState;
            insurancePolicyDTO.InsurancePolicyHolder.employerZip = insurancePolicyHolder.EmployerZip;
            insurancePolicyDTO.InsurancePolicyHolder.homePhone = insurancePolicyHolder.HomePhone;
            if (insurancePolicyHolder.MaritalStatusId.HasValue)
            {
                int? martialStId = null;
                if (insurancePolicyHolder.MaritalStatusId.Value == 1) martialStId = 2;
                if (insurancePolicyHolder.MaritalStatusId.Value == 2) martialStId = 1;
                if (insurancePolicyHolder.MaritalStatusId.Value == 3) martialStId = 37;
                if (insurancePolicyHolder.MaritalStatusId.Value == 4) martialStId = 35;
                if (insurancePolicyHolder.MaritalStatusId.Value == 7) martialStId = 36;

                insurancePolicyDTO.InsurancePolicyHolder.maritalStatus = martialStId;
            }

            insurancePolicyDTO.InsurancePolicyHolder.organizationName = insurancePolicyHolder.OrganizationName;
            insurancePolicyDTO.InsurancePolicyHolder.state = insurancePolicyHolder.State;
            insurancePolicyDTO.InsurancePolicyHolder.student = insurancePolicyHolder.Student;
            insurancePolicyDTO.InsurancePolicyHolder.zip = insurancePolicyHolder.Zip;

            insurancePolicyDTO.InsurancePolicyHolder.PatientPolicyHolders = new List<DataAccess.PatientService.Model.PatientPolicyHolderDTO>();

            DataAccess.PatientService.Model.PatientPolicyHolderDTO patientPolicyHolderDTO = new DataAccess.PatientService.Model.PatientPolicyHolderDTO();
            patientPolicyHolderDTO.PatientID = Convert.ToInt32(insurancePolicy.BillinId);
            byte relationShipId = 3;
            if (insurancePolicy.PHRelationshipToPatient == "Self") relationShipId = 1;
            if (insurancePolicy.PHRelationshipToPatient == "Spouse") relationShipId = 2;
            if (insurancePolicy.PHRelationshipToPatient == "Other") relationShipId = 3;
            if (insurancePolicy.PHRelationshipToPatient == "Significant Other") relationShipId = 4;
            if (insurancePolicy.PHRelationshipToPatient == "Mother") relationShipId = 5;
            if (insurancePolicy.PHRelationshipToPatient == "Father") relationShipId = 6;
            if (insurancePolicy.PHRelationshipToPatient == "Child") relationShipId = 7;

            patientPolicyHolderDTO.PHRelationId = relationShipId;

            insurancePolicyDTO.InsurancePolicyHolder.PatientPolicyHolders.Add(patientPolicyHolderDTO);

            insurancePolicyDTO.PHSignatureOnFile = insurancePolicy.PHSignatureOnFile;
            insurancePolicyDTO.PolicyNumber = insurancePolicy.PolicyNumber;
            insurancePolicyDTO.MedicaidId = insurancePolicy.MedicaidId;
            insurancePolicyDTO.BillingPolicyId = insurancePolicy.Id.ToString();
            insurancePolicyDTO.PolicyDeductible = insurancePolicy.PolicyDeductible;

            PractiZing.DataAccess.PatientService.Model.Patientpolicy patientpolicy = new DataAccess.PatientService.Model.Patientpolicy();
            patientpolicy.isActive = insurancePolicy.IsActive.Value;
            patientpolicy.levelId = insurancePolicy.InsuranceLevel;
            patientpolicy.patientId = Convert.ToInt32(insurancePolicy.BillinId);

            insurancePolicyDTO.PatientPolicy = new List<DataAccess.PatientService.Model.Patientpolicy>();

            var insuranceCompany = await this._insuranceCompanyRepository.GetById(insurancePolicy.InsuranceCompanyID);

            patientpolicy.insuranceCompany = new DataAccess.PatientService.Model.Insurancecompany();
            patientpolicy.insuranceCompany.code = insuranceCompany.CompanyCode;
            patientpolicy.insuranceCompany.name = insuranceCompany.CompanyName;
            patientpolicy.insuranceCompany.typeId = insuranceCompany.CompanyTypeId;


            if (authorizationList.Count() > 0)
            {
                patientpolicy.PolicyAuthorizationNumber = new List<DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO>();

                foreach (var auth in authorizationList)
                {
                    DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO policyAuthorizationNumberDTO = new DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO();
                    policyAuthorizationNumberDTO.AuthorizationNumber = auth.AuthorizationNumber;
                    policyAuthorizationNumberDTO.AuthorizationTypeId = 1;
                    policyAuthorizationNumberDTO.EffectiveDate = auth.EffectiveDate;
                    policyAuthorizationNumberDTO.ExpirationDate = auth.ExpirationDate;
                    patientpolicy.PolicyAuthorizationNumber.Add(policyAuthorizationNumberDTO);
                }
            }

            insurancePolicyDTO.PatientPolicy.Add(patientpolicy);
            
            policyList.Add(insurancePolicyDTO);
            

            if (policyList.Count > 0)
                {
                    string token = await GetEMRToken();

                    string emrUrl = this.LoggedUser.EMRURL + "InsurancePolicy/AddOrUpdate";
                    string jsondata = JsonConvert.SerializeObject(policyList);
                    HttpResponseMessage response = await _restApiCall.PostAsync(jsondata, "", emrUrl, token);
                    if (response.IsSuccessStatusCode)
                    {

                        returnList = JsonConvert.DeserializeObject<List<PolicyException>>(await response.Content.ReadAsStringAsync());

                        //var exculdeList = returnList.Select(i => Convert.ToInt64(i.BillingPolicyId));

                        //foreach (var insPolicyId in ids)
                        //{
                        //    await this.UpdateEMRACK(insPolicyId);
                        //}

                        //if (returnList.Where(i => !string.IsNullOrWhiteSpace(i.Exception)).Count() > 0)
                        //{
                        //    await this.UpdateEMRException(returnList.Where(i => !string.IsNullOrWhiteSpace(i.Exception)).ToList());
                        //}

                        //if (returnList.Where(i => string.IsNullOrWhiteSpace(i.Exception)).Count() > 0)
                        //{
                        //    await this.UpdateEMRPolicyIdToBilling(returnList.Where(i => string.IsNullOrWhiteSpace(i.Exception)).ToList());
                        //}
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("EMR Response" + response.StatusCode);
                    }
                

            }

            return returnList.FirstOrDefault();
        }

        public async Task<IEnumerable<IInsurancePolicy>> GetListForEMR()
        {
            var query = this.Connection.From<InsurancePolicy>()
                             .LeftJoin<InsurancePolicy, InsuranceCompany>((p, c) => p.InsuranceCompanyID == c.Id)
                             .LeftJoin<InsurancePolicy, PatientCase>((p, c) => p.PatientCaseId == c.Id)
                             .LeftJoin<InsurancePolicy, Patient>((p, c) => p.PatientCaseId == c.DefaultCaseId)
                             .LeftJoin<InsurancePolicy, InsurancePolicyHolder>((p, h) => p.PHID == h.Id)
                             .Select<InsurancePolicy, InsuranceCompany, PatientCase, InsurancePolicyHolder,Patient>((p, c, pc, h,pt) => new
                             {
                                 p,
                                 InsuranceCompanyUId = c.UId,
                                 PatientCaseUId = pc.UId,
                                 PHUId = h.UId,
                                 InsuranceCompanyName=c.CompanyName,
                                 InsuranceCompanyCode=c.CompanyCode,
                                 BillinId=pt.BillingID,
                                 InsuranceCompanyTypeId=c.CompanyTypeId
                             })
                             .Where(i => i.IsNotifyToEMR==false).Take(50);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var list=Mapper<InsurancePolicy>.MapList(dynamics);

            if (list.Count() > 0)
            {
                List<long> ids = new List<long>();

                List<PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO> policyList = new List<DataAccess.PatientService.Model.InsurancePolicyDTO>();
                foreach (var item in list)
                {

                    int billingId = 0;
                    int.TryParse(item.BillinId, out billingId);
                    if(billingId==0)
                    {
                        ids.Add(item.Id);
                        continue;
                    }

                    var insurancePolicyHolder = await this._insurancePolicyHolderRepository.GetByUId(item.PHUId);

                    var authorizationList = await this._patientAuthorizationNumberRepository.GetAuthorization(item.Id);

                    PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO insurancePolicyDTO = new PractiZing.DataAccess.PatientService.Model.InsurancePolicyDTO();
                    insurancePolicyDTO.AcceptAssignment = item.AcceptAssignment;
                    insurancePolicyDTO.ContactPerson = item.ContactPerson;
                    insurancePolicyDTO.PlanEffectiveDate = item.PlanEffectiveDate.Value;
                    insurancePolicyDTO.PlanExpirationDate = item.PlanExpirationDate;
                    insurancePolicyDTO.GroupName = item.GroupName;
                    insurancePolicyDTO.GroupNumber = item.GroupNumber;
                    if (item.EMRInsurancePolicyId.HasValue)
                        insurancePolicyDTO.Id = item.EMRInsurancePolicyId.Value;

                    insurancePolicyDTO.InsurancePolicyHolder = new DataAccess.PatientService.Model.Insurancepolicyholder();

                    insurancePolicyDTO.InsurancePolicyHolder.address1 = insurancePolicyHolder.Address1;
                    insurancePolicyDTO.InsurancePolicyHolder.address2 = insurancePolicyHolder.Address2;
                    insurancePolicyDTO.InsurancePolicyHolder.busPhone = insurancePolicyHolder.BusPhone;
                    insurancePolicyDTO.InsurancePolicyHolder.city = insurancePolicyHolder.City;
                    if (insurancePolicyHolder.DOB.HasValue)
                        insurancePolicyDTO.InsurancePolicyHolder.dob = insurancePolicyHolder.DOB.Value;
                    insurancePolicyDTO.InsurancePolicyHolder.employerAddress1 = insurancePolicyHolder.EmployerAddress1;
                    insurancePolicyDTO.InsurancePolicyHolder.employerAddress2 = insurancePolicyHolder.EmployerAddress2;
                    insurancePolicyDTO.InsurancePolicyHolder.employerCity = insurancePolicyHolder.EmployerCity;
                    insurancePolicyDTO.InsurancePolicyHolder.employerPhone = insurancePolicyHolder.EmployerPhone;
                    insurancePolicyDTO.InsurancePolicyHolder.employerState = insurancePolicyHolder.EmployerState;
                    insurancePolicyDTO.InsurancePolicyHolder.employerZip = insurancePolicyHolder.EmployerZip;
                    insurancePolicyDTO.InsurancePolicyHolder.firstName = insurancePolicyHolder.FirstName;
                    insurancePolicyDTO.InsurancePolicyHolder.lastName = insurancePolicyHolder.LastName;
                    int sex = 1;
                    if (insurancePolicyHolder.Sex == "M") sex = 1; if (insurancePolicyHolder.Sex == "F") sex = 2;
                    if (insurancePolicyHolder.Sex == "A") sex = 3; if (insurancePolicyHolder.Sex == "U") sex = 4;

                    insurancePolicyDTO.InsurancePolicyHolder.genderId = sex;

                    insurancePolicyDTO.InsurancePolicyHolder.employerCity = insurancePolicyHolder.EmployerCity;
                    insurancePolicyDTO.InsurancePolicyHolder.employerPhone = insurancePolicyHolder.EmployerPhone;
                    insurancePolicyDTO.InsurancePolicyHolder.employerState = insurancePolicyHolder.EmployerState;
                    insurancePolicyDTO.InsurancePolicyHolder.employerZip = insurancePolicyHolder.EmployerZip;
                    insurancePolicyDTO.InsurancePolicyHolder.homePhone = insurancePolicyHolder.HomePhone;
                    if(insurancePolicyHolder.MaritalStatusId.HasValue)
                    {
                        int? martialStId = null;
                        if (insurancePolicyHolder.MaritalStatusId.Value == 1) martialStId = 2;
                        if (insurancePolicyHolder.MaritalStatusId.Value == 2) martialStId = 1;
                        if (insurancePolicyHolder.MaritalStatusId.Value == 3) martialStId = 37;
                        if (insurancePolicyHolder.MaritalStatusId.Value == 4) martialStId = 35;
                        if (insurancePolicyHolder.MaritalStatusId.Value == 7) martialStId = 36;

                        insurancePolicyDTO.InsurancePolicyHolder.maritalStatus = martialStId;
                    }
                    
                    insurancePolicyDTO.InsurancePolicyHolder.organizationName = insurancePolicyHolder.OrganizationName;
                    insurancePolicyDTO.InsurancePolicyHolder.state = insurancePolicyHolder.State;
                    insurancePolicyDTO.InsurancePolicyHolder.student = insurancePolicyHolder.Student;
                    insurancePolicyDTO.InsurancePolicyHolder.zip = insurancePolicyHolder.Zip;

                    insurancePolicyDTO.InsurancePolicyHolder.PatientPolicyHolders= new List<DataAccess.PatientService.Model.PatientPolicyHolderDTO>();

                    DataAccess.PatientService.Model.PatientPolicyHolderDTO patientPolicyHolderDTO = new DataAccess.PatientService.Model.PatientPolicyHolderDTO();
                    patientPolicyHolderDTO.PatientID= Convert.ToInt32(item.BillinId);
                    byte relationShipId=3;
                    if (item.PHRelationshipToPatient == "Self") relationShipId = 1;
                    if (item.PHRelationshipToPatient == "Spouse") relationShipId = 2;
                    if (item.PHRelationshipToPatient == "Other") relationShipId = 3;
                    if (item.PHRelationshipToPatient == "Significant Other") relationShipId = 4;
                    if (item.PHRelationshipToPatient == "Mother") relationShipId = 5;
                    if (item.PHRelationshipToPatient == "Father") relationShipId = 6;
                    if (item.PHRelationshipToPatient == "Child") relationShipId = 7;

                    patientPolicyHolderDTO.PHRelationId = relationShipId;

                    insurancePolicyDTO.InsurancePolicyHolder.PatientPolicyHolders.Add(patientPolicyHolderDTO);

                    insurancePolicyDTO.PHSignatureOnFile = item.PHSignatureOnFile;
                    insurancePolicyDTO.PolicyNumber = item.PolicyNumber;
                    insurancePolicyDTO.MedicaidId = item.MedicaidId;
                    insurancePolicyDTO.BillingPolicyId = item.Id.ToString();
                    insurancePolicyDTO.PolicyDeductible = item.PolicyDeductible;

                    PractiZing.DataAccess.PatientService.Model.Patientpolicy patientpolicy = new DataAccess.PatientService.Model.Patientpolicy();
                    patientpolicy.isActive = item.IsActive.Value;
                    patientpolicy.levelId = item.InsuranceLevel;
                    patientpolicy.patientId = Convert.ToInt32(item.BillinId);

                    insurancePolicyDTO.PatientPolicy = new List<DataAccess.PatientService.Model.Patientpolicy>();

                    patientpolicy.insuranceCompany = new DataAccess.PatientService.Model.Insurancecompany();
                    patientpolicy.insuranceCompany.code = item.InsuranceCompanyCode;
                    patientpolicy.insuranceCompany.name = item.InsuranceCompanyName;
                    patientpolicy.insuranceCompany.typeId = item.InsuranceCompanyTypeId;


                    if (authorizationList.Count() > 0)
                    {
                        patientpolicy.PolicyAuthorizationNumber = new List<DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO>();

                        foreach (var auth in authorizationList)
                        {
                            DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO policyAuthorizationNumberDTO = new DataAccess.PatientService.Model.PolicyAuthorizationNumberDTO();
                            policyAuthorizationNumberDTO.AuthorizationNumber = auth.AuthorizationNumber;
                            policyAuthorizationNumberDTO.AuthorizationTypeId = 1;
                            policyAuthorizationNumberDTO.EffectiveDate = auth.EffectiveDate;
                            policyAuthorizationNumberDTO.ExpirationDate = auth.ExpirationDate;
                            patientpolicy.PolicyAuthorizationNumber.Add(policyAuthorizationNumberDTO);
                        }
                    }

                    insurancePolicyDTO.PatientPolicy.Add(patientpolicy);

                    policyList.Add(insurancePolicyDTO);
                    ids.Add(item.Id);
                }

                if(policyList.Count>0)
                {
                    string token = await GetEMRToken();

                    string emrUrl = this.LoggedUser.EMRURL + "InsurancePolicy/AddOrUpdate";
                    string jsondata = JsonConvert.SerializeObject(policyList);
                    HttpResponseMessage response = await _restApiCall.PostAsync(jsondata, "", emrUrl, token);
                    if (response.IsSuccessStatusCode)
                    {

                        var returnList = JsonConvert.DeserializeObject<List<PolicyException>>(await response.Content.ReadAsStringAsync());

                        var exculdeList = returnList.Select(i => Convert.ToInt64(i.BillingPolicyId));

                        foreach (var insPolicyId in ids)
                        {
                            await this.UpdateEMRACK(insPolicyId);
                        }

                        if (returnList.Where(i=>!string.IsNullOrWhiteSpace(i.Exception)).Count()>0)
                        {
                            await this.UpdateEMRException(returnList.Where(i => !string.IsNullOrWhiteSpace(i.Exception)).ToList());
                        }

                        if (returnList.Where(i => string.IsNullOrWhiteSpace(i.Exception)).Count() > 0)
                        {
                            await this.UpdateEMRPolicyIdToBilling(returnList.Where(i => string.IsNullOrWhiteSpace(i.Exception)).ToList());
                        }
                    }
                    else
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("EMR Response" + response.StatusCode);
                    }
                }
                
            }

            return list;
        }


        private async Task<int> UpdateEMRACK(long id)
        {
            try
            {
                var insurancePolicy = await this.Connection.SingleAsync<InsurancePolicy>(i => i.Id == id);
                insurancePolicy.IsNotifyToEMR = true;
                var updateOnlyFields = this.Connection
                                           .From<InsurancePolicy>()
                                           .Update(x => new
                                           {
                                               x.IsNotifyToEMR
                                           })
                                           .Where<InsurancePolicy>(i => i.UId == insurancePolicy.UId);

                var value = await base.UpdateOnlyAsync(insurancePolicy, updateOnlyFields);
                return value;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<int> UpdateEMRPolicyIdToBilling(List<PolicyException> lst)
        {
            try
            {
                foreach (var item in lst)
                {
                    var insurancePolicy = await this.Connection.SingleAsync<InsurancePolicy>(i => i.Id == Convert.ToInt32(item.BillingPolicyId));
                    insurancePolicy.EMRInsurancePolicyId = item.EMRPolicyId;
                    var updateOnlyFields = this.Connection
                                               .From<InsurancePolicy>()
                                               .Update(x => new
                                               {
                                                   x.EMRInsurancePolicyId
                                               })
                                               .Where<InsurancePolicy>(i => i.UId == insurancePolicy.UId);

                    var value = await base.UpdateOnlyAsync(insurancePolicy, updateOnlyFields);
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<int> UpdateEMRException(List<PolicyException> lst)
        {
            try
            {
                List<InsurancePolicyException> exceptionList = new List<InsurancePolicyException>();
                foreach (var item in lst)
                {
                    InsurancePolicyException insuancePolicyException = new InsurancePolicyException();
                    insuancePolicyException.PolicyId = Convert.ToInt64(item.BillingPolicyId);
                    insuancePolicyException.ErrorMessage = item.Exception;
                    insuancePolicyException.CreatedDate = DateTime.Now;
                    exceptionList.Add(insuancePolicyException);
                    await this.UpdateEMRACK(insuancePolicyException.PolicyId);
                }
                await this._insurancePolicyExceptionRepository.AddAll(exceptionList);
                return 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<string> GetEMRToken()
        {
            string tokenValue = "";

            //string emrUrl = this.LoggedUser.EMRURL + "BillingAuth/GetToken";
            string emrUrl = this.LoggedUser.EMRURL + "BillingAuth";
            //string emrUrl = "https://atc-dev-api.atcemr.com/api/BillingAuth";

            string username = this.LoggedUser.EMRUserName;
            string password = this.LoggedUser.EMRPassword;
            var response = await _restApiCall.PostWithHeaderAsync(username, password, "", "", emrUrl, "");
            //var response = await _restApiCall.GetAsync("", emrUrl, "");

            if (response.IsSuccessStatusCode)
            {
                var token_get = response.Content.ReadAsStringAsync().Result;
                //this.token = token_get.Substring(1, token_get.Length - 2);
                tokenValue = token_get;
                _logger.LogInformation("EMR Token : " + token_get);
                return tokenValue;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();

            }

            return tokenValue;
        }


    }

    public class PolicyException: IPolicyException
    {
        public string BillingPolicyId { get; set; }
        public string Exception { get; set; }
        public long EMRPolicyId { get; set; }
    }
}
