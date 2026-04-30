using AutoMapper;
using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Model;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.PatientService.Tables;
//using PractiZing.DataAccess.SecurityService;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class PatientRepository : ModuleBaseRepository<Patient>, IPatientRepository
    {
        private readonly ITransactionProvider _transactionProvider;
        private readonly IMapper _mapper;
        private readonly RestApiCall _restApiCall;
        public PatientRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 ITransactionProvider transactionProvider,                                 
        IMapper mapper) : base(errorCodes, dbContext, loggedUser)
        {
            this._transactionProvider = transactionProvider;
            _mapper = mapper;
            _restApiCall = new RestApiCall();
        }

        private async Task<int> GetMaxBillingId()
        {
            var _patient = await this.Connection.SelectAsync<Patient>(i => i.PracticeId == LoggedUser.PracticeId);
            var result = _patient.Count() != 0 ? (_patient).Max(i => Convert.ToInt32(i.Id)) : 0;
            return result;
        }

        /// <summary>
        /// Get list of all patients
        /// </summary>
        /// <returns></returns>
        /// 
        public async Task<IPaginationQuery<IPatient>> GetAll(SearchQuery<IBaseSearchModel> entity, string searchKey, string sortOrder)
        {
            try
            {
                DateTime date;
                bool isDate = DateTime.TryParseExact(searchKey, "MM/dd/yyyy", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out date);

                var query = this.Connection
                              .From<Patient>()
                              .Join<Patient, Provider>((pt, pr) => pt.ProviderId == pr.Id)
                              .LeftJoin<Patient, ConfigPatientRace>((x, y) => x.RaceId == y.Id)
                              .SelectDistinct<Patient, Provider, ConfigPatientRace>((pt, pr,z) => new
                              {
                                  pt.Id,
                                  pt.UId,
                                  pt.BillingID,
                                  pt.FirstName,
                                  pt.LastName,
                                  pt.MI,
                                  pt.SSN,
                                  pt.DOB,
                                  pt.Email,
                                  pt.PhoneNumber,
                                  ProviderUId = pr.UId,
                                  Nickname_ac=pt.Nickname_ac,
                                  Race=z.Description

                              });

                entity.PageSize = 30;

                string selectExpresssion = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IBaseSearchModel>.GetWhereClause(entity.Filter);

                string defaultExpression = null;
                if (!isDate)
                {
                    if (!string.IsNullOrEmpty(searchKey))
                    {
                        query.Where(i => (i.FirstName.Contains(searchKey)
                                                      || i.LastName.Contains(searchKey)
                                                      || i.MI.Contains(searchKey)
                                                      || i.PhoneNumber.Contains(searchKey)
                                                      || i.Email.Contains(searchKey)
                                                      || i.DOB.ToString().Contains(searchKey)
                                                      || i.BillingID.ToString().Contains(searchKey)
                                                      || i.Id.ToString().Contains(searchKey)));

                        for (int i = query.Params.Count() - 1; i >= 0; i--)
                            query.WhereExpression = query.WhereExpression.Replace($"@{i}", $"{"'"}{query.Params[i].Value}{"'"}");

                        defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@8", $"{LoggedUser.PracticeId}")}"/*.Replace("WHERE", "")*/;
                    }
                    else
                        defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                }
                else
                {
                    query.Where(i => i.DOB == Convert.ToDateTime(searchKey));
                    for (int i = query.Params.Count() - 1; i >= 0; i--)
                        query.WhereExpression = query.WhereExpression.Replace($"@{i}", $"{"'"}{query.Params[i].Value}{"'"}");
                    query.WhereStatementWithoutWhereString = true;
                    defaultExpression = query.WhereExpression;
                    //defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");
                }
                //if (!string.IsNullOrEmpty(searchKey))
                //{
                //    query.Where(i => (i.FirstName.Contains(searchKey)
                //                                  || i.LastName.Contains(searchKey)
                //                                  || i.MI.Contains(searchKey)
                //                                  || i.PhoneNumber.Contains(searchKey)
                //                                  || i.Nickname_ac.Contains(searchKey)
                //                                  || i.Email.Contains(searchKey)
                //                                  || i.DOB.ToString().Contains(searchKey)
                //                                  || i.BillingID.ToString().Contains(searchKey)                                                  
                //                                  || i.Id.ToString().Contains(searchKey)                                                  
                //                                  ));

                //    for (int i = query.Params.Count() - 1; i >= 0; i--)
                //        query.WhereExpression = query.WhereExpression.Replace($"@{i}", $"{"'"}{query.Params[i].Value}{"'"}");

                //    defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@9", $"{LoggedUser.PracticeId}")}"/*.Replace("WHERE", "")*/;
                //}
                //else
                //    defaultExpression = $"{query.Where(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");

                whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

                var result = await this.Connection.QueryPagination<Patient, IBaseSearchModel>(entity, selectExpresssion, whereExpression, countExpression, sortOrder);
                return new PaginationQuery<IPatient>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// get details of patient by patient's Id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IPatient> GetById(int id)
        {
            var patient = await this.Connection.SingleAsync<Patient>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            return patient;
        }

        /// <summary>
        /// get details of patient by patient's Id
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public async Task<IPatient> GetByCaseId(int patientCaseId)
        {
            var patient = await this.Connection.SingleAsync<Patient>(i => i.DefaultCaseId == patientCaseId && i.PracticeId == LoggedUser.PracticeId);
            return patient;
        }

        /// <summary>
        /// get details of patient by patient's Ids
        /// </summary>
        /// <param name="patientIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IPatient>> GetByIds(IEnumerable<int> ids)
        {
            var patients = await this.Connection.SelectAsync<Patient>(i => ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);
            return patients;
        }

        public async Task<IEnumerable<int>> GetByUId(string uid)
        {
            Guid[] values = uid.Split(',').Select(s => Guid.Parse(s)).ToArray();
            var patient = await this.Connection.SelectAsync<Patient>(i => values.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
            return patient.Select(i => i.Id).ToArray();
        }

        public async Task<IEnumerable<IPatient>> GetByUId(IEnumerable<Guid> uids)
        {
            var patientData = await this.Connection.SelectAsync<Patient>(i => uids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
            return patientData;
        }

        public async Task<IPatient> GetByUId(Guid UId)
        {
            var query = this.Connection
                            .From<Patient>()
                            .Join<Patient, Provider>((pt, pr) => pt.ProviderId == pr.Id)
                            .LeftJoin<Patient, ICDCode>((pt, icd) => pt.DefaultICDCode == icd.Code)
                            .Select<Patient, Provider, ICDCode>((p, pr, icd) => new
                            {
                                p,
                                ProviderUId = pr.UId,
                                ICDDescription = icd.Description
                            })
                            .Where<Patient>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);
            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var patient = Mapper<Patient>.Map(dynamics);

            if (patient == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientUIdDoesnotExists]));
            }

            return patient;
        }

        public async Task<IPatient> Get(int patientId)
        {
            return await this.Connection.SingleAsync<Patient>(i => i.Id == patientId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IPatient> GetForDynmo(int patientId, string dob)
        {
            return await this.Connection.SingleAsync<Patient>(i => i.Id == patientId && i.PracticeId == LoggedUser.PracticeId && i.DOB == Convert.ToDateTime(dob));
        }

        public async Task<IPatient> GetForDynmoWithEmrPatientId(string patientId, string dob)
        {
            var patients= await this.Connection.SelectAsync<Patient>(i => i.BillingID == patientId.ToString() && i.PracticeId == LoggedUser.PracticeId);
            //&& 
            var patient = patients.FirstOrDefault(i => i.DOB.Date == Convert.ToDateTime(dob).Date);
            return patient;
        }

        public async Task<IPatient> Get(Guid UId)
        {
            var query = this.Connection
                            .From<Patient>()
                            .Select<Patient>((p) => new
                            {
                                p
                            })
                            .Where<Patient>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var patient = Mapper<Patient>.Map(dynamics);

            if (patient == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientUIdDoesnotExists]));
            }

            return patient;
        }

        public async Task<IEnumerable<IPatient>> GetAll(string patientName = "")
        {
            try
            {

                var query = this.Connection.From<Patient>()
                      .Select<Patient>((p) => new
                      {
                          p
                      })
                      .Where<Patient>(i => ((patientName == string.Empty) || (i.FirstName.Contains(patientName) || i.LastName.Contains(patientName) || i.PhoneNumber.Contains(patientName) || i.MobilePhoneNumber.Contains(patientName)))
                      && i.PracticeId == LoggedUser.PracticeId)
                      .OrderBy<Patient>(i => i.FirstName);

                var patientData = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<Patient>.MapList(patientData);
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPatient> GetByPatientUId(Guid patientUId)
        {
            try
            {
                var query = this.Connection.From<Patient>()
                                .LeftJoin<Patient, Provider>((i, j) => i.ProviderId == j.Id)
                                .Select<Patient, Provider>((p, r) => new
                                {
                                    BillType = p.BillType,
                                    PrimaryCareDoctor = p.PrimaryCareDoctor,
                                    ReferralSource = p.ReferralSource,
                                    PatientSigned = p.PatientSigned,
                                    Pharmacy = p.Pharmacy,
                                    ReferredBy = p.ReferredBy,
                                    Id = p.Id,
                                    GAddress1 = p.Address1,
                                    GAddress2 = p.Address2,
                                    GCity = p.City,
                                    GState = p.State,
                                    GZip = p.ZipCode,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName,
                                    Sex = p.Sex,
                                    DOB = p.DOB,
                                    PracticeId = p.PracticeId,
                                    UId = p.UId,
                                    PrefContact = p.PreferredPhoneNumber,
                                    MobilePhoneNumber = p.MobilePhoneNumber,
                                    WorkPhoneNumber = p.WorkPhoneNumber,
                                    PhoneNumber = p.PhoneNumber,
                                    ProviderId = p.ProviderId,
                                    ProviderUId = r.UId
                                })
                                 .Where<Patient>(i => i.UId == patientUId && i.PracticeId == LoggedUser.PracticeId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<Patient>.Map(queryResult);
            }
            catch
            {
                throw;
            }
        }

        /*Get Patient Statement*/
        public async Task<IStatementDTO> GetStatement(int patientId)
        {
            StatementDTO statementDTO = new StatementDTO();
            var query = this.Connection.From<Patient>()
                        .Join<Patient, Provider>((pt, pv) => pt.ProviderId == pv.Id)
                        .Join<Provider, Facility>((p, f) => p.FacilityId == f.Id)
                        .SelectDistinct<Patient, Facility>((p, f) => new
                        {
                            firstName = p.FirstName,
                            LastName = p.LastName,
                            PatientId = p.Id,
                            BillAddress1 = p.BillAddress1,
                            BillAddress2 = p.BillAddress2,
                            BillCity = p.BillCity,
                            BillState = p.BillState,
                            BillZip = p.BillZip,
                            FacilityName = f.Name,
                            FacilityAddress1 = f.Address1,
                            FacilityAddress2 = f.Address2,
                            FacilityCity = f.city,
                            FacilityZip = f.ZipCode,
                            FacilityState = f.state,
                            FacilityPhone = f.Phone,
                            PatientAddress1 = p.Address1,
                            PatientAddress2 = p.Address2,
                            PatientCity = p.City,
                            PatientState = p.State,
                            PatientZipCode = p.ZipCode
                        })
                        .Where<Patient>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == patientId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var headerResult = Mapper<PatientChargesStatementHeaderDTO>.Map(queryResult);
            var footerResult = Mapper<PatientChargesStatementFooterDTO>.Map(queryResult);

            headerResult.PracticeId = LoggedUser.PracticeId;
            headerResult.StatementDate = DateTime.Now;
            footerResult.StatementDate = DateTime.Now;

            statementDTO.PatientChargesStatementHeaderDTO = headerResult;
            statementDTO.PatientChargesStatementFooterDTO = footerResult;

            return statementDTO;
        }

        public async Task<IEnumerable<IPatientChargeDTO>> GetAllPatient(string patientName = "")
        {
            try
            {
                var query = this.Connection.From<Patient>()
                           .Select<Patient>((p) => new
                           {
                               Id = p.Id,
                               FirstName = p.FirstName,
                               GName = p.GName,
                               LastName = p.LastName,
                               WorkPhoneNumber = p.WorkPhoneNumber,
                               PhoneNumber = p.PhoneNumber,
                               MobilePhoneNumber = p.MobilePhoneNumber,
                               PatientUID = p.UId,
                               Dob=p.DOB
                           })
                           .Where<Patient>(i => ((patientName == string.Empty) || (i.FirstName.Contains(patientName) || i.LastName.Contains(patientName) || i.PhoneNumber.Contains(patientName) || i.MobilePhoneNumber.Contains(patientName) || i.Id.ToString().Contains(patientName)))
                           && i.PracticeId == LoggedUser.PracticeId)
                           .OrderBy<Patient>(i => i.FirstName);

                var patientData = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<PatientChargeDTO>.MapList(patientData);
                foreach (var item in result)
                {
                    item.tempDob = item.Dob.ToString("MM/dd/yyyy");
                }

                foreach (var item in result)
                    item.MobilePhoneNumber = !string.IsNullOrEmpty(item.MobilePhoneNumber) ? item.MobilePhoneNumber : (!string.IsNullOrEmpty(item.WorkPhoneNumber) ? item.WorkPhoneNumber : item.PhoneNumber);

                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// add new patient from user
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>added entity</returns>
        public async Task<IPatient> AddNew(IPatient entity)
        {
            try
            {
                Patient tEntity = entity as Patient;
                if(tEntity==null)
                {
                     tEntity = _mapper.Map<Patient>(entity);
                }
                if (!string.IsNullOrEmpty(tEntity.BillingID))
                {
                    var patient = await this.CheckPatientExist(tEntity.BillingID);
                    if (patient != null)
                    {
                        tEntity.Id = patient.Id;
                        tEntity.UId = patient.UId;
                        await this.UpdateEntity(tEntity);
                        return tEntity;
                    }
                }

                if (!string.IsNullOrEmpty(tEntity.BillingID))
                {
                    var errors = await this.ValidateEntityToAdd(tEntity);

                    if (errors.Count() > 0)
                        await this.ThrowEntityException(errors);
                }

                if (string.IsNullOrEmpty(tEntity.BillingID))
                {
                    int newId = (await this.GetMaxBillingId()) + 1;

                    tEntity.BillingID = string.IsNullOrEmpty(tEntity.BillingID) ? Convert.ToString("M"+newId) : tEntity.BillingID;
                }

                /*check if billing address is same as residence address*/
                if (entity.BillSameAsRes.HasValue && entity.BillSameAsRes.Value)
                {
                    tEntity.BillAddress1 = entity.Address1;
                    tEntity.BillAddress2 = entity.Address2;
                    tEntity.BillCity = entity.City;
                    tEntity.BillState = entity.State;
                    tEntity.BillZip = entity.ZipCode;
                }

                if (tEntity.DOB.Year < 1900)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDOBValidation, tEntity.DOB]));

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Patient Info
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateEntity(IPatient entity)
        {
            try
            {
                Patient tEntity = entity as Patient;
                if (tEntity == null)
                {
                    tEntity = _mapper.Map<Patient>(entity);
                }

                if (entity.BillSameAsRes.HasValue && entity.BillSameAsRes.Value)
                {
                    tEntity.BillAddress1 = entity.Address1;
                    tEntity.BillAddress2 = entity.Address2;
                    tEntity.BillCity = entity.City;
                    tEntity.BillState = entity.State;
                    tEntity.BillZip = entity.ZipCode;
                }

                tEntity.Email = string.IsNullOrEmpty(tEntity.Email) ? null : tEntity.Email;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                          .From<Patient>()
                                          .Update(x => new
                                          {
                                              x.LastName,
                                              x.FirstName,
                                              x.MI,
                                              x.DOB,
                                              x.Age,
                                              x.ProviderId,
                                              x.PrimaryCareDoctor,
                                              x.PhoneNumber,
                                              x.Pharmacy,
                                              x.DoctorUserId,
                                              x.SSN,
                                              x.Sex,
                                              x.Address1,
                                              x.Address2,
                                              x.City,
                                              x.State,
                                              x.ZipCode,
                                              x.ReferralSource,
                                              x.ReferredBy,
                                              x.Email,
                                              x.Picture,
                                              x.SpouseName,
                                              x.HistoryOfDrugAbuse,
                                              x.HistoryOfDrugAbuseComments,
                                              x.MobilePhoneNumber,
                                              x.WorkPhoneNumber,
                                              x.PreferredPhoneNumber,
                                              x.PatientHXExists,
                                              x.BillAddress1,
                                              x.BillAddress2,
                                              x.BillCity,
                                              x.BillState,
                                              x.BillZip,
                                              x.Resesitate,
                                              x.POAName,
                                              x.POAAddress1,
                                              x.POAAddress2,
                                              x.POACity,
                                              x.POAState,
                                              x.POAZip,
                                              x.GName,
                                              x.RaceId,
                                              x.GAddress1,
                                              x.GAddress2,
                                              x.GCity,
                                              x.GState,
                                              x.GZip,
                                              x.MedicalRelNames,
                                              x.HomeHealth,
                                              x.HomeHealthLoc,
                                              x.NursingHome,
                                              x.NursingHomeLoc,
                                              x.BillSameAsRes,
                                              x.Hospice,
                                              x.HospiceLoc,
                                              x.ResultsEmail,
                                              x.ResultsMail,
                                              x.ResultsPickup,
                                              x.ResultsPhone,
                                              x.ResultsFax,
                                              x.Locked,
                                              x.InCollections,
                                              x.InCollectionsComments,
                                              x.IDVerified,
                                              x.IDVerifiedBy,
                                              x.IDVerifiedDate,
                                              x.Alert,
                                              x.AlertText,
                                              x.BillType,
                                              x.CustomAlert1,
                                              x.CustomAlert2,
                                              x.TransferOfCare,
                                              x.Language,
                                              x.Ethnicity,
                                              x.ECFirstName,
                                              x.ECLastName,
                                              x.ECMiddleInitial,
                                              x.ECRelationship,
                                              x.ECPhoneNumber,
                                              x.ResultsEAccess,
                                              x.Nickname_ac,
                                              x.BillingSelection,
                                              x.PrefContact,
                                              x.Guardian1ID,
                                              x.Guardian2ID,
                                              x.LivesWith,
                                              x.PatientSigned,
                                              x.MaritalStatus,
                                              x.Religion,
                                              x.LivingWill,
                                              x.Impairment,
                                              x.ImpairmentLoc,
                                              x.MaidenName,
                                              x.ScheduleAlert,
                                              x.PublicityCode,
                                              x.PublicityEffDate,
                                              x.RegistryStatusCode,
                                              x.RegistryEffDate,
                                              x.ShareHealthData,
                                              x.ShareHealthDataEffDate,
                                              x.CustomAlert3,
                                              x.PortalOptedOut,
                                              x.DisallowScheduling,
                                              x.DefaultCaseId,
                                              x.DefaultICDCode
                                          })
                                          .Where<Patient>(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Update Patient Info
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IPatient> UpdatePatientFromInsurance(IPatient entity)
        {
            try
            {
                Patient tEntity = entity as Patient;

                //var errors = await this.ValidateEntityToUpdate(tEntity);
                //if (errors.Count() > 0)
                //    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                          .From<Patient>()
                                          .Update(x => new
                                          {
                                              x.PatientSigned,
                                              x.ReferredBy,
                                              x.ReferralSource,
                                              x.PrimaryCareDoctor,
                                              x.Pharmacy,
                                              x.BillType
                                          })
                                          .Where<Patient>(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);
                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);

                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatient> UpdatePatientByEmrSync(IPatient entity)
        {
            try
            {
                Patient tEntity = entity as Patient;

                //var errors = await this.ValidateEntityToUpdate(tEntity);
                //if (errors.Count() > 0)
                //    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                          .From<Patient>()
                                          .Update(x => new
                                          {
                                              x.DOB,
                                              x.FirstName,
                                              x.LastName,
                                              x.MI,
                                              x.MaidenName,
                                              x.PhoneNumber,
                                              x.MobilePhoneNumber,
                                              x.SSN,
                                              x.Address1,
                                              x.Address2,
                                              x.City,
                                              x.State,
                                              x.ZipCode,
                                              x.BillAddress1,
                                              x.BillAddress2,
                                              x.BillCity,
                                              x.BillState,
                                              x.BillZip,
                                              x.ModifiedBy,
                                              x.ModifiedDate
                                          })
                                          .Where<Patient>(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);
                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);

                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPatient> CheckPatientExist(string billingId)
        {
            var result = await this.Connection.SingleAsync<Patient>(i => i.BillingID == billingId && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<IPatient> PatientByBillingId(string billingId)
        {
            var query = this.Connection
                            .From<Patient>()                            
                            .Join<Patient, PatientCase>((pt, pc) => pt.Id == pc.PatientId)
                            .Select<Patient, PatientCase>
                            ((p, pc) => new
                            {
                                p,
                                PatientCaseUId=pc.UId

                            }).Where<Patient>(i => i.BillingID == billingId && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var patient = Mapper<Patient>.Map(dynamics);

            return patient;



            //var result = await this.Connection.SingleAsync<Patient>(i => i.BillingID == billingId && i.PracticeId == LoggedUser.PracticeId);
            //return result;
        }

        public async Task<IPatient> PatientByPatientIdWithCaseUid(int patientId)
        {
            var query = this.Connection
                            .From<Patient>()
                            .Join<Patient, PatientCase>((pt, pc) => pt.Id == pc.PatientId)
                            .Select<Patient, PatientCase>
                            ((p, pc) => new
                            {
                                p,
                                PatientCaseUId = pc.UId

                            }).Where<Patient>(i => i.Id == patientId && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var patient = Mapper<Patient>.Map(dynamics);

            return patient;



            //var result = await this.Connection.SingleAsync<Patient>(i => i.BillingID == billingId && i.PracticeId == LoggedUser.PracticeId);
            //return result;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<Patient>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
                return result;
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
                return await this.Connection.DeleteAsync<Patient>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(Patient tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors = await SSNAndDOBValidation(tEntity, errors);

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private async Task<List<IValidationResult>> SSNAndDOBValidation(Patient tEntity, List<IValidationResult> errors)
        {
            /*patient's DOB should be valid or not to be for future*/
            if (tEntity.DOB > DateTime.Now)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDOBValidation]));

            /*Accession No can't be empty*/
            if (!string.IsNullOrEmpty(tEntity.SSN))
            {
                var _patients = (await this.Connection.SelectAsync<Patient>(i => i.SSN.ToLower().Trim() == tEntity.SSN.ToLower().Trim()
                                                                         && i.PracticeId == LoggedUser.PracticeId));

                //check in update case
                if (tEntity.Id > 0 && _patients.Count() > 0)
                    _patients = _patients.Where<Patient>(i => i.Id != tEntity.Id).ToList();

                //if (_patients.Count() > 0)
                //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.SSNAlreadyExists]));
            }

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(Patient tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors = await SSNAndDOBValidation(tEntity, errors);

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task ThrowError(IPatient patientData)
        {
            if (patientData == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesnotExists]));
            }
        }

        public async Task<IEnumerable<IPatientStatementRDLCDTO>> Get()
        {
            try
            {
                var result = await base.ExecuteStoredProcedureAsync<dynamic>("usp_GetPatientAgingBalances");
                var results = _mapper.Map<List<PatientStatementRDLCDTO>>(result);

                return results;
            }

            catch
            {
                throw;
            }
        }

        public async Task<dynamic> RefreshPatientChargesReport_WareHouse(Guid UId)
        {
            try
            {
                try
                {
                    var patient = await this.GetByUId(UId);

                    string query = "usp_ImportChargesInDataWareHouseTable_PatientWise " + patient.Id;
                    var result = await base.ExecuteStoredProcedureAsync<dynamic>(query);
                    return result;
                }
                catch
                {
                    throw;
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task ValidatePatientAddress(string patientStreet, string patientState, string patientCity, string patientZip)
        {
            try
            {
                IList<ValidationResult> validations = new List<ValidationResult>();

                if (string.IsNullOrEmpty(patientStreet))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientStreetRequired]));
                }
                if (string.IsNullOrEmpty(patientState))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientStateRequired]));
                }
                if (string.IsNullOrEmpty(patientCity))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientCityRequired]));
                }
                if (string.IsNullOrEmpty(patientZip))
                {
                    validations.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientZipRequired]));
                }

                var errors = (from x in validations
                              select new ValidationCodeResult(x.ErrorMessage, x.MemberNames)).ToList<IValidationResult>();

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);
            }
            catch
            {
                throw;
            }
        }


        public async Task<IPatientDTO> GetPatientInformation(Guid patientUId, int policyId)
        {
            var query = this.Connection
                            .From<Patient>()
                            .Join<Patient, Provider>((pt, pr) => pt.ProviderId == pr.Id)
                            .Join<Patient, PatientCase>((pt, pc) => pt.Id == pc.PatientId)
                            .LeftJoin<PatientCase, InsurancePolicy>((pc, ip) => pc.Id == ip.PatientCaseId && ip.Id == policyId)
                            .LeftJoin<InsurancePolicy, InsuranceCompany>((ip, ic) => ip.InsuranceCompanyID == ic.Id)
                            // hcfa form join
                            .LeftJoin<Provider, Facility>((pr, fc) => pr.FacilityId == fc.Id)
                            .Join<InsuranceCompany, ClearingHouse>((ic, ch) => ic.ClearingHouseId == ch.Id)
                            .LeftJoin<Provider, ProviderIdentity>((pr, pi) => pr.Id == pi.ProviderId && pi.TypeId == 1)

                            .Select<Patient, InsurancePolicy, Provider, ProviderIdentity, InsuranceCompany, ClearingHouse>
                            ((p, ip, pr, pi, ic, ch) => new
                            {
                                p.Id,
                                p.LastName,
                                p.FirstName,
                                p.MI,
                                p.DOB,
                                p.Sex,
                                ip.PolicyNumber,
                                ProviderFName = pr.FirstName,
                                ProviderLName = pr.LastName,
                                ProviderNPI = pi.Identifier,
                                InsuranceName = ic.CompanyName,
                                PayorId = ic.CompanyCode,
                                TrizettoInsuranceCode = ic.CompanyCode,
                                ic.PatientElig,
                                Clearinghouse = ch.Name
                            }).Where<Patient>(i => i.UId == patientUId && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var patient = Mapper<PatientDTO>.Map(dynamics);

            if (patient == null)
            {
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesnotExists]));
            }

            return patient;
        }
        string token = "";
        public async Task<IEnumerable<IArPatient>> GetArPatientBillingData()
        {
            string val=await GetEMRToken();

            //this.token = "eyJraWQiOiJ0VzI1WWRia0dxd0pwNUdOVGpwQm1yYTllZXd0TW5mQ25Ta0MzK3JxY0M4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI4OWQyZGVhNy0wNzEzLTRiYjctOTcwMC0yNTYwMDZhYWExODEiLCJhdWQiOiJpZG5jN3RtNmduZDU0NXM0ZDhuOThwNWZyIiwiY29nbml0bzpncm91cHMiOlsiU0EiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImV2ZW50X2lkIjoiOTEzMjBlNjYtMzU0Ni00NDM2LTlkMzUtMTZhODFjMmM1MGIwIiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2MTU5MDA2NDgsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTIuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0yX2lEZ2E5cFRMViIsImNvZ25pdG86dXNlcm5hbWUiOiJhZG1pbl9teWFjY2Vzc29oLmNvbSIsImV4cCI6MTYxNTk3OTg2MSwiaWF0IjoxNjE1OTc2MjYxLCJlbWFpbCI6ImFkbWluQG15YWNjZXNzb2guY29tIn0.SPnjRPvJw1RByBCNkd4pCKJNx-zdTALkHEtX1pGo-eoDZXjeHkgPZ-cl_PFGRSyx8_P-qmjEuX1enUSdpK_Xg2jsMehX-tzXwNmhgfixAk6T7j9zhQSSLfKDL93_IQTwlQZdmpBce8Et_UvVejJ8zkUK7GKCacIhAkgg0FiGrKhGBExfqep7Tvq5Iw1M9v6jvyJN2323SroT0GAEGxIc0z16w34mRNF40IdRepzXmQxcw6F4gGXNxaeI9X3z5nev9SxMB0-7cSyfr4a5FqmvKQOmtdVw4Is_EzwW-Ar5P3mJsq6jakCW643inn01WbJ_2jI4ld7Ts4M4oqCC5JOrEg";

            //string emrUrl = this.LoggedUser.EMRURL+"PatientAdmissionBilling/SendResidentialsVisitsToBilling";
           string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeGetApi;

            IEnumerable<IArPatient> result = new List<IArPatient>();
            List<ArPatient> patientList=null;
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);  
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                
                patientList= JsonConvert.DeserializeObject<List<ArPatient>>(item);
            }
            else
            {
                var str = await response.Content.ReadAsStringAsync();
            }
                //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return (IEnumerable<IArPatient>)patientList;
        }

        public async Task<object> ImortPatientPoliciesFromEMR()
        {
            string val = await GetEMRToken();

            //this.token = "eyJraWQiOiJ0VzI1WWRia0dxd0pwNUdOVGpwQm1yYTllZXd0TW5mQ25Ta0MzK3JxY0M4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI4OWQyZGVhNy0wNzEzLTRiYjctOTcwMC0yNTYwMDZhYWExODEiLCJhdWQiOiJpZG5jN3RtNmduZDU0NXM0ZDhuOThwNWZyIiwiY29nbml0bzpncm91cHMiOlsiU0EiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImV2ZW50X2lkIjoiOTEzMjBlNjYtMzU0Ni00NDM2LTlkMzUtMTZhODFjMmM1MGIwIiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2MTU5MDA2NDgsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTIuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0yX2lEZ2E5cFRMViIsImNvZ25pdG86dXNlcm5hbWUiOiJhZG1pbl9teWFjY2Vzc29oLmNvbSIsImV4cCI6MTYxNTk3OTg2MSwiaWF0IjoxNjE1OTc2MjYxLCJlbWFpbCI6ImFkbWluQG15YWNjZXNzb2guY29tIn0.SPnjRPvJw1RByBCNkd4pCKJNx-zdTALkHEtX1pGo-eoDZXjeHkgPZ-cl_PFGRSyx8_P-qmjEuX1enUSdpK_Xg2jsMehX-tzXwNmhgfixAk6T7j9zhQSSLfKDL93_IQTwlQZdmpBce8Et_UvVejJ8zkUK7GKCacIhAkgg0FiGrKhGBExfqep7Tvq5Iw1M9v6jvyJN2323SroT0GAEGxIc0z16w34mRNF40IdRepzXmQxcw6F4gGXNxaeI9X3z5nev9SxMB0-7cSyfr4a5FqmvKQOmtdVw4Is_EzwW-Ar5P3mJsq6jakCW643inn01WbJ_2jI4ld7Ts4M4oqCC5JOrEg";

            string emrUrl = this.LoggedUser.EMRURL+ "BillingAndFinalize/GetAllActivePolicies";
            //string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeGetApi;

            IEnumerable<IArPatient> result = new List<IArPatient>();
            List<Patientpolicy> patientList = null;
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();

                patientList = JsonConvert.DeserializeObject<List<Patientpolicy>>(item);
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return patientList;
        }

        public async Task<object> EMRPolicySyncService(string emrtoken)
        {
            //string val = await GetEMRToken();

            //this.token = "eyJraWQiOiJ0VzI1WWRia0dxd0pwNUdOVGpwQm1yYTllZXd0TW5mQ25Ta0MzK3JxY0M4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI4OWQyZGVhNy0wNzEzLTRiYjctOTcwMC0yNTYwMDZhYWExODEiLCJhdWQiOiJpZG5jN3RtNmduZDU0NXM0ZDhuOThwNWZyIiwiY29nbml0bzpncm91cHMiOlsiU0EiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImV2ZW50X2lkIjoiOTEzMjBlNjYtMzU0Ni00NDM2LTlkMzUtMTZhODFjMmM1MGIwIiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2MTU5MDA2NDgsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTIuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0yX2lEZ2E5cFRMViIsImNvZ25pdG86dXNlcm5hbWUiOiJhZG1pbl9teWFjY2Vzc29oLmNvbSIsImV4cCI6MTYxNTk3OTg2MSwiaWF0IjoxNjE1OTc2MjYxLCJlbWFpbCI6ImFkbWluQG15YWNjZXNzb2guY29tIn0.SPnjRPvJw1RByBCNkd4pCKJNx-zdTALkHEtX1pGo-eoDZXjeHkgPZ-cl_PFGRSyx8_P-qmjEuX1enUSdpK_Xg2jsMehX-tzXwNmhgfixAk6T7j9zhQSSLfKDL93_IQTwlQZdmpBce8Et_UvVejJ8zkUK7GKCacIhAkgg0FiGrKhGBExfqep7Tvq5Iw1M9v6jvyJN2323SroT0GAEGxIc0z16w34mRNF40IdRepzXmQxcw6F4gGXNxaeI9X3z5nev9SxMB0-7cSyfr4a5FqmvKQOmtdVw4Is_EzwW-Ar5P3mJsq6jakCW643inn01WbJ_2jI4ld7Ts4M4oqCC5JOrEg";

            string emrUrl = this.LoggedUser.EMRURL + "InsurancePolicy/GetNotSyncedPolicy/Clinic";
            
            List<EMRPolicySync> patientList = null;
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, emrtoken);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();

                patientList = JsonConvert.DeserializeObject<List<EMRPolicySync>>(item);
            }
            return patientList;
        }

        public async Task<bool> EMRUpdatePolicySync(string emrToken)
        {
            //string val = await GetEMRToken();
            string emrUrl = this.LoggedUser.EMRURL + "InsurancePolicy/UpdateSyncFlag/Clinic";
            
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, emrToken);
            if (response.IsSuccessStatusCode)
            {   
                return true;
            }
            return false;
        }

        public async Task<bool> EMRUpdatePolicyWithIdsSync(string emrToken, List<int> insuranceIds)
        {
            //string val = await GetEMRToken();
            string emrUrl = this.LoggedUser.EMRURL + "InsurancePolicy/UpdateSyncFlagByIds/Clinic";
            string jsondata = JsonConvert.SerializeObject(insuranceIds);
            HttpResponseMessage response = await _restApiCall.PostAsync(jsondata,"", emrUrl, emrToken);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<object> SyncPoliciesFromEMR(string patientId, string emrToken = "")
        {
            if(string.IsNullOrWhiteSpace(emrToken))
            {
                emrToken = await GetEMRToken();
            }
            

            //this.token = "eyJraWQiOiJ0VzI1WWRia0dxd0pwNUdOVGpwQm1yYTllZXd0TW5mQ25Ta0MzK3JxY0M4PSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI4OWQyZGVhNy0wNzEzLTRiYjctOTcwMC0yNTYwMDZhYWExODEiLCJhdWQiOiJpZG5jN3RtNmduZDU0NXM0ZDhuOThwNWZyIiwiY29nbml0bzpncm91cHMiOlsiU0EiXSwiZW1haWxfdmVyaWZpZWQiOnRydWUsImV2ZW50X2lkIjoiOTEzMjBlNjYtMzU0Ni00NDM2LTlkMzUtMTZhODFjMmM1MGIwIiwidG9rZW5fdXNlIjoiaWQiLCJhdXRoX3RpbWUiOjE2MTU5MDA2NDgsImlzcyI6Imh0dHBzOlwvXC9jb2duaXRvLWlkcC51cy1lYXN0LTIuYW1hem9uYXdzLmNvbVwvdXMtZWFzdC0yX2lEZ2E5cFRMViIsImNvZ25pdG86dXNlcm5hbWUiOiJhZG1pbl9teWFjY2Vzc29oLmNvbSIsImV4cCI6MTYxNTk3OTg2MSwiaWF0IjoxNjE1OTc2MjYxLCJlbWFpbCI6ImFkbWluQG15YWNjZXNzb2guY29tIn0.SPnjRPvJw1RByBCNkd4pCKJNx-zdTALkHEtX1pGo-eoDZXjeHkgPZ-cl_PFGRSyx8_P-qmjEuX1enUSdpK_Xg2jsMehX-tzXwNmhgfixAk6T7j9zhQSSLfKDL93_IQTwlQZdmpBce8Et_UvVejJ8zkUK7GKCacIhAkgg0FiGrKhGBExfqep7Tvq5Iw1M9v6jvyJN2323SroT0GAEGxIc0z16w34mRNF40IdRepzXmQxcw6F4gGXNxaeI9X3z5nev9SxMB0-7cSyfr4a5FqmvKQOmtdVw4Is_EzwW-Ar5P3mJsq6jakCW643inn01WbJ_2jI4ld7Ts4M4oqCC5JOrEg";

            string emrUrl = this.LoggedUser.EMRURL + "BillingAndFinalize/GetAllActivePolicies/"+patientId;
            //string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeGetApi;

            IEnumerable<IArPatient> result = new List<IArPatient>();
            List<Patientpolicy> patientList = null;
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, emrToken);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();

                patientList = JsonConvert.DeserializeObject<List<Patientpolicy>>(item);
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return patientList;
        }


        public async Task<IEnumerable<IProviderEmrDTO>> GetEMRProviders()
        {
            string val = await GetEMRToken();

            //this.token = "eyJraWQiOiJPdldPeitYQzh3aENVKzMrQndMQW5pVmZRVnRRd2VWendLOHdnWmFWNHFNPSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI0ODE0ZWQyOC04MWQ3LTQ4NWItYmRlMi1iNjI4YTAwNDUwYzEiLCJhdWQiOiI3Y3Q3dmNwNzQ5b29rajFtMmRvOWVzdWJqZSIsImNvZ25pdG86Z3JvdXBzIjpbIlNBIl0sImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJldmVudF9pZCI6ImRlZmE0YTA0LTJlZDgtNDdiNy05MmM3LWU1ZjE5NzczYzNkNSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjM3MDUzMTU0LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl8yV0RNbU1INnIiLCJjb2duaXRvOnVzZXJuYW1lIjoiYWRtaW51c2VyIiwiZXhwIjoxNjM4MzY1MzYyLCJpYXQiOjE2MzgzNjE3NjIsImVtYWlsIjoiYWRtaW5AYXRjZW1yLmNvbSJ9.jR5HEaS5hkuir2046iBtjlfgE4_8Q1hm04kzAXcwuL_4VuSLzA7tcz0RagZ8TNkYmmw_v1ReqMKuaSs-wF6ExMaYVHAkj-L39ziJuR_Pr_vxJ-JTAyZP5hJOkBVOVjlFearGWVvjbr74o_sCBfxu1A3EwaRjj-Gb-spn245bjJMDN2GURjlZ8DlW04BjkxD4GJct7K9mdoVn-m9sMPRy2SZ4EMGh7X2cp7NP8QXgDKNiT4_QLklwEd65pYN97BiEDBIPaPJ7SVYL_A_sq9it1dKQbMtLjet2DLwZsADk7PtAfdhEXaoSo2pVNQD8Z48c0R_ZZqAznu411LdebjEt9Q";

            //string emrUrl = this.LoggedUser.EMRURL+"PatientAdmissionBilling/SendResidentialsVisitsToBilling";
            string emrUrl = this.LoggedUser.EMRURL + "BillingAndFinalize/ProviderListForBilling";
            //string emrUrl = "https://atc-dev-api.atcemr.com/api/BillingAndFinalize/ProviderListForBilling";
            
            List<ProviderEmrDTO> providerEmrs = null;
            
            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                providerEmrs= JsonConvert.DeserializeObject<List<ProviderEmrDTO>>(item);                
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return (IEnumerable<IProviderEmrDTO>)providerEmrs;
        }

        public async Task<IEnumerable<ISyncPatientDetailDTO>> GetPatientsForSync()
        {
            string val = await GetEMRToken();
            string emrUrl = this.LoggedUser.EMRURL + "Patient/V2/GetUpdatedClientDetailList/1";

            List<SyncPatientDetailDTO> patients = null;

            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                patients = JsonConvert.DeserializeObject<List<SyncPatientDetailDTO>>(item);
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return (IEnumerable<ISyncPatientDetailDTO>)patients;
        }

        public async Task<bool> SendPatientSyncAckToEMR(IEnumerable<int> patientIds)
        {
            string emrUrl = this.LoggedUser.EMRURL + "Patient/AddressUpdated";

            //string jsondata = "{" + "\"patientIds\"" + ": [";
            //jsondata += string.Join(",", patientIds);
            //jsondata += "]}";

            UpdateIsAddressUpdatedFlagRequest updateIsAddressUpdatedFlagRequest = new UpdateIsAddressUpdatedFlagRequest();
            updateIsAddressUpdatedFlagRequest.PatientIds = patientIds.ToArray();
            updateIsAddressUpdatedFlagRequest.IsClinicSynced = true;

            string jsondata = JsonConvert.SerializeObject(updateIsAddressUpdatedFlagRequest);

            HttpResponseMessage response = null;
            response = await _restApiCall.PutAsync(jsondata, "", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
            }

            return true;
        }

        public async Task<IEnumerable<IFacilityEMRDto>> GetEMRFacilities()
        {
            string val = await GetEMRToken();

            //this.token = "eyJraWQiOiJPdldPeitYQzh3aENVKzMrQndMQW5pVmZRVnRRd2VWendLOHdnWmFWNHFNPSIsImFsZyI6IlJTMjU2In0.eyJzdWIiOiI0ODE0ZWQyOC04MWQ3LTQ4NWItYmRlMi1iNjI4YTAwNDUwYzEiLCJhdWQiOiI3Y3Q3dmNwNzQ5b29rajFtMmRvOWVzdWJqZSIsImNvZ25pdG86Z3JvdXBzIjpbIlNBIl0sImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJldmVudF9pZCI6ImRlZmE0YTA0LTJlZDgtNDdiNy05MmM3LWU1ZjE5NzczYzNkNSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjM3MDUzMTU0LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl8yV0RNbU1INnIiLCJjb2duaXRvOnVzZXJuYW1lIjoiYWRtaW51c2VyIiwiZXhwIjoxNjM4MzY1MzYyLCJpYXQiOjE2MzgzNjE3NjIsImVtYWlsIjoiYWRtaW5AYXRjZW1yLmNvbSJ9.jR5HEaS5hkuir2046iBtjlfgE4_8Q1hm04kzAXcwuL_4VuSLzA7tcz0RagZ8TNkYmmw_v1ReqMKuaSs-wF6ExMaYVHAkj-L39ziJuR_Pr_vxJ-JTAyZP5hJOkBVOVjlFearGWVvjbr74o_sCBfxu1A3EwaRjj-Gb-spn245bjJMDN2GURjlZ8DlW04BjkxD4GJct7K9mdoVn-m9sMPRy2SZ4EMGh7X2cp7NP8QXgDKNiT4_QLklwEd65pYN97BiEDBIPaPJ7SVYL_A_sq9it1dKQbMtLjet2DLwZsADk7PtAfdhEXaoSo2pVNQD8Z48c0R_ZZqAznu411LdebjEt9Q";

            //string emrUrl = this.LoggedUser.EMRURL+"PatientAdmissionBilling/SendResidentialsVisitsToBilling";
            string emrUrl = this.LoggedUser.EMRURL + "BillingAndFinalize/FacilityListForBilling";
            //string emrUrl = "https://atc-dev-api.atcemr.com/api/BillingAndFinalize/ProviderListForBilling";

            List<FacilityEMRDto> providerEmrs = null;

            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                providerEmrs = JsonConvert.DeserializeObject<List<FacilityEMRDto>>(item);
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return (IEnumerable<IFacilityEMRDto>)providerEmrs;
        }

        public async Task<IEnumerable<IPractitionerModifiersDTO>> GetPractitionerModifierList()
        {
            string val = await GetEMRToken();
            string emrUrl = this.LoggedUser.EMRURL + "BillingAndFinalize/PractitionerModifiers";
            List<PractitionerModifiersDTO> providerEmrs = null;

            HttpResponseMessage response = await _restApiCall.GetAsync("", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var item = await response.Content.ReadAsStringAsync();
                providerEmrs = JsonConvert.DeserializeObject<List<PractitionerModifiersDTO>>(item);
            }
            //List<ArPatient> patientList = JsonConvert.DeserializeObject<List<ArPatient>>(await HttpRequestHelper.GetRequestAsync(!string.IsNullOrWhiteSpace(this.LoggedUser.EMRURL) ? this.LoggedUser.EMRURL : "https://ar-dev-api.myaccessoh.com/api/PatientAdmissionBilling/SendResidentialsVisitsToBilling"));
            //result = _mapper.Map<IEnumerable<IArPatient>>(patientList);
            return (IEnumerable<IPractitionerModifiersDTO>)providerEmrs;
        }


        public async Task<bool> SendAcknowledgementToEMR(int billingId, int chargeId, string errorMessage)
        {
            string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeUpdateApi; //"PatientAdmissionBilling/UpdateCharges";
            string str="charges";
            EMRChargeStatus obj = new EMRChargeStatus();
            obj.BillingId = billingId;
            obj.ChargeId = chargeId;
            obj.ReasonsFromBillingSytem = errorMessage;
            string jsondata = "{" + "\"charges\"" + ": [";
            jsondata += JsonConvert.SerializeObject(obj);
            jsondata += "]}";
            HttpResponseMessage response = null;
             response = await _restApiCall.PutAsync(jsondata, "", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
            }

            return true;
        }

        public async Task<bool> SendEncounterImportAcknowledgementToEMR(List<IEMRChargeStatus> lst)
        {
            string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeUpdateApi; //"PatientAdmissionBilling/UpdateCharges";
            if (string.IsNullOrWhiteSpace(this.token))
            {
                await GetEMRToken();
            }

            string jsondata = "{" + "\"charges\"" + ": ";
            jsondata += JsonConvert.SerializeObject(lst);
            jsondata += "}";
            HttpResponseMessage response = null;
            response = await _restApiCall.PutAsync(jsondata, "", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {

            }

            return true;
        }

        public async Task<bool> SendClaimSentAcknowledgementToEMR(List<IEMRChargeStatus> lst)
        {
            string emrUrl = this.LoggedUser.EMRURL + this.LoggedUser.EMRChargeUpdateApi; //"PatientAdmissionBilling/UpdateCharges";
            if(string.IsNullOrWhiteSpace(this.token))
            {
                await GetEMRToken();
            }
                        
            string jsondata = "{" + "\"charges\"" + ": ";
            jsondata += JsonConvert.SerializeObject(lst);
            jsondata += "}";
            HttpResponseMessage response = null;
            response = await _restApiCall.PutAsync(jsondata, "", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {

            }

            return true;
        }

        public async Task<bool> SendRolledUpChargesToEMR(List<IRolledUpEncounterDTO> lst)
        {
            //need api from nikunj
            string emrUrl = this.LoggedUser.EMRURL + "Encounters/UpdateRolledUpEncounter";
            if (string.IsNullOrWhiteSpace(this.token))
            {
                await GetEMRToken();
            }

            //string jsondata = "{" + "\"charges\"" + ": ";
            //jsondata += JsonConvert.SerializeObject(lst);
            //jsondata += "}";

            string jsondata = JsonConvert.SerializeObject(lst);
            
            HttpResponseMessage response = null;
            response = await _restApiCall.PostAsync(jsondata, "", emrUrl, this.token);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
            }

            return false;
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
                this.token = token_get;
                return this.token;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                
            }

            return string.Empty;
        }
    }

    public class UpdateIsAddressUpdatedFlagRequest
    {
        public int[] PatientIds { get; set; }

        public bool IsLabSynced { get; set; }
        public bool IsClinicSynced { get; set; }
        public bool IsResidentialSynced { get; set; }

        public bool IsLIMSSynced { get; set; }

    }
}
