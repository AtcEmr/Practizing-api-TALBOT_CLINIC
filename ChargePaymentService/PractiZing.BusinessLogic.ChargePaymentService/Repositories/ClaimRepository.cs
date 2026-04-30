using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using PractiZing.DataAccess.BatchPaymentService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Common;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.Base.Object.ClaimService;
using Microsoft.Extensions.Configuration;

using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ClaimRepository : ModuleBaseRepository<Claim>, IClaimRepository
    {
        private readonly string _lastName;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IChargesRepository _chargesRepository;
        private readonly IClaimChargeRepository _claimChargeRepository;
        private readonly IScrubErrorRepository _scrubErrorRepository;

        public ClaimRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                             IConfiguration configuration,
                                             IInvoiceRepository invoiceRepository,
                                             IActionNoteRepository actionNoteRepository,
                                             IChargesRepository chargesRepository,
                                             IClaimChargeRepository claimChargeRepository,
                                             IScrubErrorRepository scrubErrorRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _lastName = configuration["BillLast"];
            _invoiceRepository = invoiceRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._chargesRepository = chargesRepository;
            this._claimChargeRepository = claimChargeRepository;
            this._scrubErrorRepository = scrubErrorRepository;
        }

        public async Task<IEnumerable<IClaim>> Get()
        {
            return await this.Connection.SelectAsync<Claim>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClaim> AddNew(IClaim entity)
        {
            try
            {
                Claim tEntity = entity as Claim;
                int[] invoiceIds = { tEntity.InvoiceId };
                var invoiceData = await this._invoiceRepository.GetById(tEntity.InvoiceId);
                var chargeData = await this._chargesRepository.Get(invoiceIds);
                IEnumerable<int> chargeIds = (chargeData).Select(i => i.Id);

                tEntity.PracticeId = LoggedUser.PracticeId;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if (tEntity.Id > 0)
                {
                    //entity.Status = ClaimStatusEnum.UPDATED.ToString();
                    await this.UpdateEntity(entity);
                    tEntity.IsUpdated = true;
                    await this._actionNoteRepository.CreateObject(tEntity.PatientCaseId, chargeData, tEntity.Id, "Claim updated (# " + tEntity.Id + ") ");
                    return tEntity;
                }
                else if (tEntity.Id == 0)
                {
                    tEntity = await base.AddNewAsync(tEntity);
                    tEntity.IsUpdated = false;
                    await this._actionNoteRepository.CreateObject(tEntity.PatientCaseId, chargeData, tEntity.Id, "Claim created (#" + tEntity.Id + ") ");
                }

                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaim>> GetClaims(int claimBatchId)
        {
            var result = await this.Connection.SelectAsync<Claim>(i => i.ClaimBatchId == claimBatchId && i.PracticeId == LoggedUser.PracticeId);
            return result;
        }

        public async Task<IEnumerable<IClaim>> GetByBatchUId(Guid claimBatchUId)
        {
            var _batch = await this.Connection.SingleAsync<ClaimBatch>(i => i.UId == claimBatchUId);
            return await this.Connection.SelectAsync<Claim>(i => i.ClaimBatchId == _batch.Id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> UnBatchClaims(Guid claimBatchUId)
        {
            try
            {
                var _batch = await this.Connection.SingleAsync<ClaimBatch>(i => i.UId == claimBatchUId);
                var incorrectClaims = await this.Connection.SelectAsync<Claim>(i => i.ClaimBatchId == _batch.Id && i.ScrubStatus == (int)ScrubErrorEnum.Failed && i.PracticeId == LoggedUser.PracticeId);

                foreach (var entity in incorrectClaims)
                {
                    Claim tEntity = entity as Claim;
                    tEntity.ClaimBatchId = null;

                    await this.UpdateBatchId(tEntity);

                    int[] claimIds = { tEntity.Id };
                    IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);
                    // int[] claimCharges = claimCharges.Select(i => i.Id).ToArray();
                    await this._actionNoteRepository.CreateObject(tEntity.PatientCaseId, claimCharges, tEntity.Id, "Claim unbatch (#" + tEntity.Id + ") ");
                }


                return 1;
                //var unBatch = this.Connection.From<Claim>().Update(x => new
                //{
                //    x.ClaimBatchId
                //}).Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                //return await base.UpdateOnlyAsync(tEntity, unBatch);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaim>> GetClaims(IClaimFilter claimFilter)
        {
            try
            {
                var query = this.Connection.From<Claim>()
                                           .Join<Claim, ClearingHouse>((cl, ch) => cl.ClearingHouseId == ch.Id, NoLockTableHint.NoLock)
                                           .Join<Claim, Invoice>((c, i) => c.InvoiceId == i.Id, NoLockTableHint.NoLock)
                                           .Join<Claim, InsuranceCompany>((c, f) => c.InsuranceCompanyId == f.Id, NoLockTableHint.NoLock)
                                           .Join<Claim, ConfigInsuranceFormType>((c, i) => c.FormTypeId == i.Id, NoLockTableHint.NoLock)
                                           .Join<Invoice, PatientCase>((i, p) => i.PatientCaseId == p.Id, NoLockTableHint.NoLock)
                                           .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((i, c) => i.CompanyTypeId == c.Id, NoLockTableHint.NoLock)                                           
                                           .SelectDistinct<Claim, ClearingHouse, Invoice, InsuranceCompany, Patient, ConfigInsuranceCompanyType>((i, j, inv, ic, p, c) => new
                                           {
                                               i,
                                               ClearingHouse = j.Name,
                                               AccessionNumber = inv.AccessionNumber,
                                               Carrier = ic.CompanyName,
                                               CarrierType = c.CompanyType,
                                               BillingId = p.BillingID,
                                               DateOfService = inv.BillFromDate,
                                               PatientUId = p.UId
                                           })
                                            .Where(i => i.ClearingHouseId == claimFilter.ClearingHouseId && i.ClaimDate >= claimFilter.FromDate.Date
                                           && i.ClaimDate <= claimFilter.ToDate.Date && i.PracticeId == LoggedUser.PracticeId);




                //.Where(i => i.ClearingHouseId == claimFilter.ClearingHouseId && i.ClaimDate >= claimFilter.FromDate.Date
                //&& i.ClaimDate <= claimFilter.ToDate.Date && i.PracticeId == LoggedUser.PracticeId);

                //if (claimFilter.InsuranceCompanyId != null)
                //    query = query.Where(i => i.InsuranceCompanyId == claimFilter.InsuranceCompanyId);
                //if (claimFilter.CarrierTypeId != null)
                //    query = query.Where(i => i.CarrierTypeId == claimFilter.CarrierTypeId);
                //if (claimFilter.ClearingHouseId != null)
                //    query = query.Where(i => i.ClearingHouseId == claimFilter.ClearingHouseId);
                //if (claimFilter.CaseTypeId != null)
                //    query = query.Where(i => i.CaseTypeId == claimFilter.CaseTypeId);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<Claim>.MapList(dynamicResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaim>> GetClaims(/*IEnumerable<int?> claimBatchIds*/)
        {
            try
            {
                var query = this.Connection.From<Claim>()
                                           .LeftJoin<Claim, ClearingHouse>((cl, ch) => cl.ClearingHouseId == ch.Id)
                                           .LeftJoin<Claim, Invoice>((c, i) => c.InvoiceId == i.Id)
                                           .LeftJoin<Claim, InsuranceCompany>((c, f) => c.InsuranceCompanyId == f.Id)
                                           .LeftJoin<Claim, ConfigInsuranceFormType>((c, i) => c.FormTypeId == i.Id)
                                           .LeftJoin<Invoice, PatientCase>((i, p) => i.PatientCaseId == p.Id)
                                           .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                                           .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((i, c) => i.CompanyTypeId == c.Id)
                                           .SelectDistinct<Claim, ClearingHouse, Invoice, InsuranceCompany, Patient, ConfigInsuranceCompanyType>((i, j, inv, ic, p, c) => new
                                           {
                                               i,
                                               ClearingHouse = j.Name,
                                               AccessionNumber = inv.AccessionNumber,
                                               Carrier = ic.CompanyName,
                                               CarrierType = c.CompanyType,
                                               BillingId = p.BillingID,
                                               DateOfService = inv.BillFromDate,
                                               PatientUId = p.UId
                                           })
                                            .Where(i => i.PracticeId == LoggedUser.PracticeId);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<Claim>.MapList(dynamicResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaim>> GetByInvoiceId(Guid invoiceUid)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(invoiceUid);
                //var result = await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoice.Id && i.PracticeId == LoggedUser.PracticeId);

                var query = this.Connection.From<Claim>()                                          
                                          .LeftJoin<Claim, ConfigInsuranceCompanyType>((c, f) => c.CarrierTypeId == f.Id)                                          
                                          .SelectDistinct<Claim, ConfigInsuranceCompanyType>((i, j) => new
                                          {
                                              i,
                                              InsuranceCompanyType=j.CompanyType
                                          })
                                          .Where(i => i.PracticeId == LoggedUser.PracticeId && i.InvoiceId==invoice.Id);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                var result=Mapper<Claim>.MapList(dynamicResult);


                IEnumerable<int> claimIds = result.Select(i => i.Id);

                var scrubError = await this._scrubErrorRepository.GetByClaimId(claimIds);
                result.ToList().ForEach((res) =>
                {
                    res.ScrubErrors = scrubError.Where(i => i.ClaimId == res.Id);
                });

                return result.OrderBy(i=>i.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaim> GetByInvoiceId(int invoiceid)
        {
            try
            {
                return (await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceid && i.PracticeId == LoggedUser.PracticeId)).LastOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaim> GetByInvoiceIdForAdjustment(int invoiceid)
        {
            try
            {
                return (await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceid && i.PracticeId == LoggedUser.PracticeId && i.InsLevel==1)).LastOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaim> GetByInvoiceIdByINSLevel(int invoiceid,int insLevel)
        {
            try
            {
                return (await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceid && i.PracticeId == LoggedUser.PracticeId && i.InsLevel==insLevel)).LastOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaim> GetByInvoiceIdNoDeleteClaims(int invoiceid, int claimId)
        {
            try
            {
                return (await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceid && i.Id != claimId && i.PracticeId == LoggedUser.PracticeId)).LastOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowError(List<IValidationResult> validationResults)
        {
            string errorMsg = string.Empty;
            int count = 1;
            /*concat error msgs for multiple claims.. */
            foreach (var item in validationResults)
            {
                errorMsg += $"{count} . {item.ErrorMessage}";
                count++;
            }
            await this.ThrowEntityException(new ValidationCodeResult(errorMsg));

        }

        public async Task<int> UnBatchClaim(IClaim entity)
        {
            try
            {
                Claim tEntity = entity as Claim;
                tEntity.ClaimBatchId = null;

                await this.UpdateBatchId(tEntity);
                int[] claimIds = { tEntity.Id };

                IEnumerable<ICharges> claimCharges = await this._claimChargeRepository.GetByClaim(claimIds);
                await this._actionNoteRepository.CreateObject(tEntity.PatientCaseId, claimCharges, tEntity.Id, "Claim unbatch (#" + tEntity.Id + ") ");

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task Update(IEnumerable<IClaim> claims, int batchId)
        {
            try
            {
                foreach (var item in claims)
                {
                    item.ClaimBatchId = batchId;
                    await this.UpdateBatchId(item);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEntities(IEnumerable<IClaim> entities)
        {
            try
            {
                foreach (var item in entities)
                    await this.UpdateEntity(item);
                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> UpdateBatchId(IClaim entity)
        {
            try
            {
                Claim tEntity = entity as Claim;
                /*Update only claim batchId whenever unbatch claim or batch claim.*/
                var updateOnlyFields = this.Connection
                                           .From<Claim>()
                                           .Update(x => new
                                           {
                                               x.ClaimBatchId
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateClaimScrubStatus(IClaim entity)
        {
            try
            {
                Claim tEntity = entity as Claim;

                /*Update only claim scrub status.*/
                var updateOnlyFields = this.Connection
                                           .From<Claim>()
                                           .Update(x => new
                                           {
                                               x.ScrubStatus
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateEntity(IEnumerable<IClaim> claims)
        {
            foreach (var item in claims)
            {
                await this.UpdateEntity(item);
            }

            return 1;
        }

        public async Task<int> UpdateEntity(IClaim entity)
        {
            try
            {
                Claim tEntity = entity as Claim;               

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Claim>()
                                           .Update(x => new
                                           {
                                               x.AcceptAssignment,
                                               x.BillingDoctorAddressLine1,
                                               x.BillingDoctorAddressLine2,
                                               x.BillingDoctorCity,
                                               x.BillingDoctorIDPrefix,
                                               x.BillingDoctorName,
                                               x.BillingDoctorPhone,
                                               x.BillingDoctorState,
                                               x.BillingDoctorZip,
                                               x.BillingFacilityId,
                                               x.BillingFacilityIDQualifier,
                                               x.BillingFacilityNPI,
                                               x.Box10Value,
                                               x.CanBeSentElectronically,
                                               x.CarrierTypeId,
                                               x.CaseTypeId,
                                               x.ClaimBatchId,
                                               x.ClaimDate,
                                               x.ClaimToAddress1,
                                               x.ClaimToAddress2,
                                               x.ClaimToCity,
                                               x.ClaimToState,
                                               x.ClaimToZip,
                                               x.ClaimType,
                                               x.ClearingHouseId,
                                               x.FillingCode,
                                               x.FLAGS,
                                               x.FormTypeId,
                                               x.Frequency,
                                               x.FromDate,
                                               x.GRP,
                                               x.HasAnotherPlan,
                                               x.HoldBy,
                                               x.HoldDate,
                                               x.HoldComment,
                                               x.InsLevel,
                                               x.InsuranceCompanyId,
                                               x.InsuranceType,
                                               x.IsAuto,
                                               x.MaxServices,
                                               x.MedicaidResubmissionCode,
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.OriginalReferenceNumber,
                                               x.OtherInsCompanyId,
                                               x.OtherInsFillingCode,
                                               x.OtherInsType,
                                               x.PatientAccountNumber,
                                               x.TaxonomyCode,
                                               x.OtherPolicyHolderCity,
                                               x.OtherPolicyHolderDOB,
                                               x.OtherPolicyHolderEmpl,
                                               x.OtherPolicyHolderGroupNo,
                                               x.OtherPolicyHolderName,
                                               x.OtherPolicyHolderRelation,
                                               x.OtherPolicyHolderSex,
                                               x.OtherPolicyHolderState,
                                               x.OtherPolicyHolderStreet,
                                               x.OtherPolicyHolderZip,
                                               x.OtherPolicyInsurancePlanName,
                                               x.OtherPolicyNo,
                                               x.PatientCaseId,
                                               x.PatientCity,
                                               x.PatientDOB,
                                               x.PatientName,
                                               x.PatientPhone,
                                               x.PatientSignatureDate,
                                               x.PatientState,
                                               x.PatientStreet,
                                               x.PatientZip,
                                               x.PerformingDoctorAddressLine1,
                                               x.PerformingDoctorAddressLine2,
                                               x.PerformingDoctorCity,
                                               x.PerformingDoctorName,
                                               x.PerformingDoctorPhone,
                                               x.PerformingDoctorState,
                                               x.PerformingDoctorZip,
                                               x.PerformingFacilityIDQualifier,
                                               x.PerformingFacilityNPI,
                                               x.PhysicianIdOrAuthNo,
                                               x.PhysicianSignature,
                                               x.PolicyHolderCity,
                                               x.PolicyHolderDOB,
                                               x.PolicyHolderEmpl,
                                               x.PolicyHolderGroupNo,
                                               x.PolicyHolderName,
                                               x.PolicyHolderPhone,
                                               x.PolicyHolderRelation,
                                               x.PolicyHolderSex,
                                               x.PolicyHolderSignature,
                                               x.PolicyHolderState,
                                               x.PolicyHolderStreet,
                                               x.PolicyHolderZip,
                                               x.PolicyInsurancePlanName,
                                               x.PolicyNo,
                                               x.PriorAuthorizationNumber,
                                               x.ReferringPhyId,
                                               x.ReferringPhyName,
                                               x.ReferringPhysicianNpi,
                                               x.ReferringPhyFirstName,
                                               x.ReferringPhyLastName,
                                               x.ReferringPhyMI,
                                               x.ReleaseBy,
                                               x.ReleaseDate,
                                               x.ReleaseComment,
                                               x.RESERVED19,
                                               x.SentDate,
                                               x.ShouldBePrinted,
                                               x.ShowCPTDescripton,
                                               x.Status,
                                               x.SupervisingPhysID,
                                               x.ToDate,
                                               x.TotalBilled,
                                               x.VisitNo,
                                               x.PolicyHolderAddress1,
                                               x.PolicyHolderAddress2,
                                               x.InsuranceCompanyCode,
                                               x.IsCliaNumber,
                                               x.BillingDoctorFirstName,
                                               x.BillingDoctorMiddleName,
                                               x.BillingDoctorLastName,
                                               x.PerformingDoctorId,
                                               x.DiagnosisCodes,
                                               x.Box32FacilityId,
                                               x.Box32FacilityAddress1,
                                               x.Box32FacilityAddress2,
                                               x.Box32FacilityCity,
                                               x.Box32FacilityState,
                                               x.Box32FacilityZip,
                                               x.ReferringPhySuffix,
                                               x.IsLoop2420E,
                                               x.IsLoop2420DRequired,
                                               x.BillingProviderFacilityName,
                                               x.POSCode,
                                               x.CurrentIllnesDate,
                                               x.OtherIllnesDate,
                                               x.UnableToWorkFrom,
                                               x.UnableToWorkTo,
                                               x.HospitalizationFrom,
                                               x.HospitalizationTo,
                                               x.ReferCliaNumber,
                                               x.IsRefProviderAndRendProviderSame,
                                               x.OtherCompanyCode,
                                               x.SupervisionDoctorFirstName,
                                               x.SupervisionDoctorLastName,
                                               x.SupervisionDoctorMiddleName,
                                               x.SupervisionDoctorNPI,
                                               x.SupervisionDoctorPrefix,
                                               x.SupervisionDoctorSuffix,
                                               x.IsLoop2310DRequired,
                                               x.PerformingLocationName,
                                               x.PerformingLocationAddressLine1,
                                               x.PerformingLocationAddressLine2,
                                               x.PerformingLocationCity,
                                               x.PerformingLocationState,
                                               x.PerformingLocationZIP,
                                               x.PerformingLocationPhone,
                                               x.PerformingDoctorFirstName,
                                               x.PerformingDoctorLastName,
                                               x.PerformingDoctorMiddleName,
                                               x.PerformingDoctorNPI,x.GroupNPI,
                                               x.OrderingDoctorFirstName,
                                               x.OrderingDoctorLastName,
                                               x.OrderingDoctorMiddleName,
                                               x.OrderingDoctorNPI,
                                               x.OrderingDoctorPrefix,
                                               x.OrderingDoctorSuffix,
                                               x.OrderingProviderId,
                                               x.IsSendAck,
                                               x.IsLoop2420ARequired,
                                               x.PerformingProviderTaxonomy,
                                               x.MedicaidClearingHouseId,
                                               x.MedicaidPayerId,
                                               x.MedicaidPayerReceiverId
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaim> Get(int id)
        {
            return await this.Connection.SingleAsync<Claim>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IClaim> GetByPatientControlNumber(string patientControlNumber)
        {
            return await this.Connection.SingleAsync<Claim>(i => i.PatientControlNumber== patientControlNumber);
        }

        public async Task<IClaim> GetByUID(Guid uId)
        {
            return await this.Connection.SingleAsync<Claim>(i => i.UId == uId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IClaim>> GetByInvoice(int invoiceId, int level)
        {
            return await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceId && i.InsLevel == level && i.Status == ClaimStatusEnum.CREATED.ToString() && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IClaim>> Get(List<Guid> uids)
        {
            return await this.Connection.SelectAsync<Claim>(i => uids.Contains(i.UId) && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> GetClaimbyInvoice(string invoiceUId, short lvl)
        {
            try
            {
                var invoice = await this._invoiceRepository.GetByUId(Guid.Parse(invoiceUId));
                var invoiceId = invoice != null ? invoice.Id : 0;

                var query = this.Connection.From<Claim>()
                    .Join<Claim, ClaimBatch>((i, j) => i.ClaimBatchId == j.Id)
                    .Select<ClaimBatch>(i => new
                    {
                        BatchStatus = (i.BatchStatus == 2 ? 0 : 1)
                    })
                    .Where((i) => i.InvoiceId == invoiceId && i.InsLevel == lvl && i.PracticeId == LoggedUser.PracticeId)
                    .OrderBy(i => i.Id);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

                var result = Mapper<Claim>.Map(dynamicResult);

                return Convert.ToInt32(result);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> GetUnBatchClaimByInvoice(int invoiceId)
        {
            var result = await this.Connection.SelectAsync<Claim>(i => i.InvoiceId == invoiceId && i.ClaimBatchId == null && i.PracticeId == LoggedUser.PracticeId);
            return result.Count() > 0 ? true : false;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await base.DeleteByIdAsync<Claim>(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int[] claimIds)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<Claim>(i => claimIds.Contains(i.Id));
                return result;
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(Claim tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            //var claim = await this.Connection.SelectAsync<Claim>(i => i.InsLevel == tEntity.InsLevel
            //                                                        && i.InvoiceId == tEntity.InvoiceId
            //                                                        && i.SentDate != null
            //                                                        && i.Status != ClaimStatusEnum.CREATED.ToString()
            //                                                        && i.PracticeId == LoggedUser.PracticeId);
            //if (claim.Count() > 0)
            //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimAlreadyExist]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private async Task<IEnumerable<IValidationResult>> ValidateEntityToDelete()
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimCannotBeDeleted]));

            return errors;
        }

        //private async Task<List<IValidationResult>>  ValidateEntityToDelete(Claim tEntity, int? claimBatchId, List<IValidationResult> errors)
        //{
        //    //if (tEntity.ClaimBatchId > DateTime.Now)
        //    //    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDOBValidation]));

        //    if (tEntity.ClaimBatchId!=null)
        //    {
        //        var error = (await this.Connection.SelectAsync<Claim>(i => i.ClaimBatchId == claimBatchId
        //                                                            && i.PracticeId == LoggedUser.PracticeId));

        //        if (error.Count() > 0)
        //            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimCannotBeDeleted]));
        //    }

        //    return errors;
        //}


        //public async Task<IOrganizationSubmitter> OrganizationSubmitterAsync(string senderId)
        //{
        //    IOrganizationSubmitter submitter = new OrganizationSubmitter();
        //    submitter.Code = senderId;
        //    submitter.Name = _lastName;
        //    return submitter;
        //}

        public async Task ClaimIsInUse()
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimCannotBeDeleted]));
            await this.ThrowEntityException(errors);
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(Claim tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            if (!string.IsNullOrEmpty(tEntity.HoldBy) && string.IsNullOrEmpty(tEntity.HoldComment))
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.HoldCommentRequired]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<int> UpdateClaimAfterNotifyRevdx(long id)
        {
            try
            {
                Claim tEntity = await this.GetById(id);
                tEntity.IsSendAck = true;
                tEntity.SendAckDate = DateTime.Now;
                tEntity.ModifiedBy = this.LoggedUser.UserName;
                tEntity.ModifiedDate = DateTime.Now;
                /*Update only claim scrub status.*/
                var updateOnlyFields = this.Connection
                                           .From<Claim>()
                                           .Update(x => new
                                           {
                                               x.IsSendAck,
                                               x.SendAckDate,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where(i => i.Id == tEntity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaimAckDTO>> GetForACK()
        {
            //return await this.Connection.SelectAsync<Claim>(i => i.IsSendAck==false && i.PracticeId == LoggedUser.PracticeId);
            var query = this.Connection.From<Claim>()
                .Join<Claim, Patient>((cl, p) => cl.PatientCaseId == p.DefaultCaseId)
                .Join<Claim, Invoice>((cl, inv) => cl.InvoiceId == inv.Id)
                                           .Select<Claim, Patient, Invoice>((i, p, inv) => new
                                           {
                                               i.Id,
                                               i.AccessionNumber,
                                               i.TotalBilled,
                                               i.SentDate,
                                               i.InvoiceId
                                               //LabClientID = p.LabClientID,
                                               //CaseType = inv.CaseType
                                           })
                                           .Where(i => i.PracticeId == LoggedUser.PracticeId && i.IsSendAck == false && i.SentDate != null && i.AccessionNumber!=null).OrderBy(i=>i.Id).Take(200);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            return Mapper<ClaimAckDTO>.MapList(dynamicResult);
        }

        public async Task ThrowClaimBatchInsuranceCompany()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Please select one payer claims to create the batch."));
        }

        public async Task<short?> GetClaimLevel(string patientAccountNumber)
        {
            return (await this.Connection.SingleAsync<Claim>(i => i.PatientAccountNumber == patientAccountNumber && i.PracticeId == LoggedUser.PracticeId)).InsLevel;
        }

        public async Task<IClaim> GetClaimByPatientAccountNumber(string patientAccountNumber)
        {
            return await this.Connection.SingleAsync<Claim>(i => i.PatientAccountNumber == patientAccountNumber && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task ThrowDummyProviderError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Cannot create claim with Dummy Provider."));
        }

        public async Task ThrowMedicaidPolicyLengthError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Medicaid Policy Number should not be less than 12 characters"));
        }

        public async Task ThrowProviderQualificationError(string qualification)
        {
            await this.ThrowEntityException(new ValidationCodeResult("Provider Qualication ("+ qualification + ") does not match with [MD,CNP,LISW,PA,LICDC,LPCC] for none Medicaid claims."));
        }

        public async Task<IEnumerable<IClaimLevelDTO>> GetClaimsForReversePayment(IEnumerable<string> patientAccountNumbers)
        {
            var query = this.Connection.From<Claim>()
                                          .Select<Claim>((cl) => new
                                          {
                                              cl.PatientAccountNumber,
                                              cl.InsLevel
                                          })
                                          .Where(i => patientAccountNumbers.Contains(i.PatientAccountNumber));

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);

            return Mapper<ClaimLevelDTO>.MapList(dynamicResult);
        }

        public async Task ThrowNoPaymentErrorForSecondary()
        {
            await this.ThrowEntityException(new ValidationCodeResult("There is no primary payment for sending with Secondary."));
        }

        public async Task ThrowPrimaryPaymentPostedWithWrongPayer()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Primary payment posted with another payer please correct."));
        }

        public async Task<IEnumerable<IClaim>> GetClaimsForAutomation(int clearingHouseId)
        {
            try
            {
                var query = this.Connection.From<Claim>()
                                           .LeftJoin<Claim, ClearingHouse>((cl, ch) => cl.ClearingHouseId == ch.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<Claim, Invoice>((c, i) => c.InvoiceId == i.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<Claim, InsuranceCompany>((c, f) => c.InsuranceCompanyId == f.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<Claim, ConfigInsuranceFormType>((c, i) => c.FormTypeId == i.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<Invoice, PatientCase>((i, p) => i.PatientCaseId == p.Id, NoLockTableHint.NoLock)
                                           .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id, NoLockTableHint.NoLock)
                                           .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((i, c) => i.CompanyTypeId == c.Id, NoLockTableHint.NoLock)
                                           .SelectDistinct<Claim, ClearingHouse, Invoice, InsuranceCompany, Patient, ConfigInsuranceCompanyType>((i, j, inv, ic, p, c) => new
                                           {
                                               i,
                                               ClearingHouse = j.Name,
                                               AccessionNumber = inv.AccessionNumber,
                                               Carrier = ic.CompanyName,
                                               CarrierType = c.CompanyType,
                                               BillingId = p.BillingID,
                                               DateOfService = inv.BillFromDate,
                                               PatientUId = p.UId
                                           })
                                            .Where(i => i.ClearingHouseId == clearingHouseId && i.ClaimBatchId == null && i.PracticeId == LoggedUser.PracticeId);

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<Claim>.MapList(dynamicResult);
            }
            catch
            {
                throw;
            }
        }
    }
}