using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PractiZing.Api.Common;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.DenialService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.PatientService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.MasterServcie.Objects;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Object;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.DataAccess.ReportService.Tables;
using PractiZing.Sftp;
using RestSharp;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using ServiceStack.OrmLite.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargesRepository : ModuleBaseRepository<Charges>, IChargesRepository
    {
        private readonly AutoMapper.IMapper _mapper;
        private IEnumerable<IInsurancePolicy> _insurancePolicies;
        private IInvoiceRepository _invoiceRepository;
        private IInsurancePolicyRepository _insurancePolicyRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IPatientCaseRepository _patientCaseRepository;
        private IHL7RuleStatementsRepository _hL7RuleStatementsRepository;
        private IInvDiagnosisRepository _invDiagnosisRepository;
        private IChargeScrubRepository _chargeScrubRepository;
        private readonly IPracticeRepository _practiceRepository;
        private IReportRepository _reportRepository;
        private string scrubURL;
        private IFacilityRepository _facilityRepository;
        private IProviderRepository _providerRepository;
        private IAppSettingRepository _appSettingRepository;
        IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        private string _catalystSftpForExcel;
        private string _relativePath;
        public ChargesRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 ITransactionProvider transactionProvider,
                                 IInvoiceRepository invoiceRepository,
                                 IInsurancePolicyRepository insurancePolicyRepository,
                                 IInsuranceCompanyRepository insuranceCompanyRepository,
                                 IMapper mapper,
                                 IPatientCaseRepository patientCaseRepository,
                                 IHL7RuleStatementsRepository hL7RuleStatementsRepository,
                                 IInvDiagnosisRepository invDiagnosisRepository,
                                 IPracticeRepository practiceRepository,
                                 IChargeScrubRepository chargeScrubRepository,
                                 IConfiguration configuration,
                                 IReportRepository reportRepository,
                                 IProviderRepository providerRepository,
                                 IFacilityRepository facilityRepository,
                                 IAppSettingRepository appSettingRepository,
                                 IHostingEnvironment hostingEnvironment
                                 ) : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
            this._providerRepository = providerRepository;
            this._facilityRepository = facilityRepository;
            this._reportRepository = reportRepository;
            this._hL7RuleStatementsRepository = hL7RuleStatementsRepository;
            this._invoiceRepository = invoiceRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._invDiagnosisRepository = invDiagnosisRepository;
            this._practiceRepository = practiceRepository;
            scrubURL = configuration["ScrubServiceURL"];
            this._chargeScrubRepository = chargeScrubRepository;
            this._appSettingRepository = appSettingRepository;
            this._hostingEnvironment = hostingEnvironment;
            this._configuration = configuration;
            this._catalystSftpForExcel = this._configuration["CatalystSftpForExcel"];
            this._relativePath = this._configuration["AttachmentFolder"];
        }

        public async Task<ICharges> AddNew(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                var tEntity = _mapper.Map<Charges>(entity);
                if (tEntity.IsChargeDeleted || tEntity.IsDeleted)
                    return tEntity;

                if (tEntity.IsDuplicate.HasValue)
                    if (tEntity.IsDuplicate.Value)
                        tEntity.IsDeleted = true;

                        _insurancePolicies = insurancePolicies;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                /*Set DuebyflagCD column to know charge is for insurance or Patient*/
                if (tEntity.BillToInsurance)
                    tEntity.DueByFlagCD = "PRIMARY";
                else if (tEntity.BillToPatient)
                    tEntity.DueByFlagCD = "PATIENT";

                /*Fetch maximum chargeNo from Charge table and increment by 1*/
                tEntity.ChargeNo = (await this.GetMaxChargeNo()) + 1;
                tEntity.Id = 0;
                /*Set below fields empty, if these are null for UI persective*/
                tEntity.Mod1 = tEntity.Mod1 ?? string.Empty;
                tEntity.Mod2 = tEntity.Mod2 ?? string.Empty;
                tEntity.Mod3 = tEntity.Mod3 ?? string.Empty;
                tEntity.Mod4 = tEntity.Mod4 ?? string.Empty;
                tEntity.ICD2 = tEntity.ICD2 ?? string.Empty;
                tEntity.ICD3 = tEntity.ICD3 ?? string.Empty;
                tEntity.ICD4 = tEntity.ICD4 ?? string.Empty;
                tEntity.NDCCode = tEntity.NDCCode ?? string.Empty;
                tEntity.Comments = tEntity.Comments ?? string.Empty;
                tEntity.Message1 = tEntity.Message1 ?? string.Empty;
                tEntity.Message2 = tEntity.Message2 ?? string.Empty;

                /*Insert single entity of Charge*/
                var chargeEntity = await base.AddNewAsync(tEntity);

                await _hL7RuleStatementsRepository.RunChargePostIdHl7Scripts(chargeEntity.Id);
                return chargeEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IChargeBatchTabsCount> GetAll(IChargeDashboardBatchFilter filter)
        {

            if (filter.InsuranceCompanyUId != null && filter.InsuranceCompanyUId != "undefined")
            {
                var _insuranceCompany = await this._insuranceCompanyRepository.GetByUId(new Guid(filter.InsuranceCompanyUId));
                filter.InsuranceCompanyId = _insuranceCompany == null ? 0 : _insuranceCompany.Id;
            }

            filter.FromDate = Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
            filter.ToDate = Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

            var queryCharges = await this.Get(filter);
            var queryResult = await this.Connection.SelectAsync<dynamic>(queryCharges);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();
            List<int> patientCaseIds = new List<int>();

            if (resultCharges != null && resultCharges.Count() > 0)
            {
                patientCaseIds = resultCharges.Select(i => i.PatientCaseId).Distinct().ToList();
            }

            var resultInsPolicies = await this._insurancePolicyRepository.GetActivePolicies(patientCaseIds);

            int[] chargeIds = resultCharges.Where(i => i.ScrubError == true).Select(i => i.Id).ToArray();
            var chargeScrubData = await this._chargeScrubRepository.GetByChargeIds(chargeIds);

            resultCharges.ForEach(i =>
            {
                i.ChargeScrubs = chargeScrubData.FirstOrDefault(x => x.ChargeId == i.Id);
                var activePolicy = resultInsPolicies.Where(policy => policy.PatientCaseId == i.PatientCaseId
                            && (policy.PlanEffectiveDate.HasValue
                           && policy.PlanEffectiveDate.Value.Date <= i.BillFromDate.Date)
                           && ((policy.PlanExpirationDate == null)
                           || (policy.PlanExpirationDate.HasValue
                           && policy.PlanExpirationDate.Value.Date >= i.BillFromDate.Date))).FirstOrDefault();
                if (activePolicy != null)
                {
                    i.InsuranceCompanyName = activePolicy.InsuranceCompanyName;
                    i.InsuranceCompanyCode= activePolicy.InsuranceCompanyCode;
                }
                    
                i.BillFromDate = Convert.ToDateTime(i.BillFromDate.ToShortDateString());
                i.ReviewComments = (!string.IsNullOrWhiteSpace(i.ReviewComments) ? i.ReviewComments : "");
                if(!string.IsNullOrWhiteSpace(  i.NonBillableComments ))
                {
                    i.ReviewComments +=" NonBillable Comments: " +(!string.IsNullOrWhiteSpace(i.NonBillableComments) ? i.NonBillableComments : "");
                }                
            });

            ChargeBatchTabsCount batchTabsCount = new ChargeBatchTabsCount();
            batchTabsCount = await this.GetTabsCount(resultCharges.ToList());

            batchTabsCount.Charge = resultCharges.ToList();

            var querySecondaryCharges = await this.GetFor_SecondaryClaims();
            var querySecondaryResult = await this.Connection.SelectAsync<dynamic>(querySecondaryCharges);
            var resultSecondaryCharges = (Mapper<Charges>.MapList(querySecondaryResult)).ToList();
            batchTabsCount.SecondaryCharge = resultSecondaryCharges;

            var resultSecondaryInsPolicies = await this._insurancePolicyRepository.GetActivePolicies_Secondary(resultSecondaryCharges.Select(i => i.PatientCaseId).Distinct().ToList());

            resultSecondaryCharges.ForEach(i =>
            {
                
                var activePolicy = resultSecondaryInsPolicies.Where(policy => policy.PatientCaseId == i.PatientCaseId
                            && (policy.PlanEffectiveDate.HasValue
                           && policy.PlanEffectiveDate.Value.Date <= i.BillFromDate.Date)
                           && ((policy.PlanExpirationDate == null)
                           || (policy.PlanExpirationDate.HasValue
                           && policy.PlanExpirationDate.Value.Date >= i.BillFromDate.Date))).FirstOrDefault();
                if (activePolicy != null)
                {
                    i.InsuranceCompanyName = activePolicy.InsuranceCompanyName;
                    i.InsuranceCompanyCode = activePolicy.InsuranceCompanyCode;
                }
            });

            batchTabsCount.SecondaryChargeCount = resultSecondaryCharges.Count();
            batchTabsCount.SecondaryChargePatientCount = resultSecondaryCharges.Select(i => i.PatientUId).Distinct().Count();

            return batchTabsCount;

        }

        public async Task<IEnumerable<ICharges>> GetAllForMakeClaims()
        {
            
            var queryCharges = await this.GetForMakeClaims();
            var sql = queryCharges.ToSelectStatement();
            var queryResult = await this.Connection.SelectAsync<dynamic>(queryCharges);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();
            List<int> patientCaseIds = new List<int>();

            if (resultCharges != null && resultCharges.Count() > 0)
            {
                patientCaseIds = resultCharges.Select(i => i.PatientCaseId).Distinct().ToList();
            }

            var resultInsPolicies = await this._insurancePolicyRepository.GetActivePolicies(patientCaseIds);

            int[] chargeIds = resultCharges.Where(i => i.ScrubError == true).Select(i => i.Id).ToArray();
            var chargeScrubData = await this._chargeScrubRepository.GetByChargeIds(chargeIds);

            resultCharges.ForEach(i =>
            {                
                var activePolicy = resultInsPolicies.Where(policy => policy.PatientCaseId == i.PatientCaseId
                            && (policy.PlanEffectiveDate.HasValue
                           && policy.PlanEffectiveDate.Value.Date <= i.BillFromDate.Date)
                           && ((policy.PlanExpirationDate == null)
                           || (policy.PlanExpirationDate.HasValue
                           && policy.PlanExpirationDate.Value.Date >= i.BillFromDate.Date))).FirstOrDefault();
                if (activePolicy != null)
                {
                    i.InsuranceCompanyName = activePolicy.InsuranceCompanyName;
                    i.InsuranceCompanyCode = activePolicy.InsuranceCompanyCode;
                }

                i.BillFromDate = Convert.ToDateTime(i.BillFromDate.ToShortDateString());
                i.ReviewComments = (!string.IsNullOrWhiteSpace(i.ReviewComments) ? i.ReviewComments : "");                
            });

            resultCharges = resultCharges.Where(i => i.ClaimId == null && i.ScrubError == false && i.IsAROldCharges == false && i.ReviewNeeded == false && i.IsLocked == false
              && i.DueAmount == i.Amount && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true) && i.InsuranceCompanyCode != "SelfP" && i.DueByFlagCD.ToLower() == "primary").ToList();

            return resultCharges;

        }

        public async Task<IEnumerable<IInvoiceDTO>> GetInvoicesFromCharges(IChargeDashboardBatchFilter filter)
        {
            var result = await this.GetAll(filter);
            //  result.Charge = await this.GetFilter(result.Charge, filter.SelectedType);

            var resultInvoices = result.Charge.Where(i=>i.IsDeleted==false).GroupBy(d => d.AccessionNumber).Select(g => new InvoiceDTO
            {
                InvoiceId = g.FirstOrDefault().InvoiceId,
                BatchNo = g.FirstOrDefault().BatchNo,
                AccessionNumber = g.FirstOrDefault().AccessionNumber,
                DOS = g.FirstOrDefault().BillFromDate.Date.ToString("MM-dd-yyyy"),
                PatientName = $"{g.FirstOrDefault().FirstName}  {g.FirstOrDefault().LastName}",
                InsuranceCompanyName = g.FirstOrDefault().InsuranceCompanyName,
                OrderingPhysician = $"{g.FirstOrDefault().OrderingPhysicianFirstName}  {g.FirstOrDefault().OrderingPhysicianLastName}",
                PostDate = g.FirstOrDefault().CreatedDate.Date.ToString("MM-dd-yyyy"),
                ChargeAmount = System.Math.Round(g.Select(i => i.Amount).Sum(), 2),
                Interest = System.Math.Round(g.Select(i => i.BonusAmount.GetValueOrDefault()).Sum(), 2),
                Balance = System.Math.Round(g.Select(i => i.DueAmount).Sum(), 2),
                ChargeType = (g.FirstOrDefault().ClaimId != null && g.FirstOrDefault().SentDate != null) ? "ClaimSent" :
                (g.FirstOrDefault().ClaimId != null && g.FirstOrDefault().SentDate == null) ? "ClaimNotSent" :
                g.FirstOrDefault().ClaimId == null ? "ClaimNotMade" : "All"
            });

            IEnumerable<int> invoiceIds = resultInvoices.Select(i => i.InvoiceId).ToArray().Distinct();
            var invDiagnosis = await this._invDiagnosisRepository.GetByInvoiceId(invoiceIds);
            resultInvoices = resultInvoices.ToList();

            foreach (var res in resultInvoices.ToList())
            {
                IEnumerable<string> IcdCodes = invDiagnosis.Where(i => i.InvoiceId == res.InvoiceId).Select(i => i.ICDCode);
                res.ICDCodes = string.Join(',', IcdCodes);
            }

            return resultInvoices;

        }


        public async Task<IEnumerable<IInvoiceDTO>> GetInvoicesFromChargesByInvoiceUids(List<Guid> invoiceUids)
        {
            var query = await this.GetChargesByInvoiceGUIds(invoiceUids);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();
            //  result.Charge = await this.GetFilter(result.Charge, filter.SelectedType);

            var resultInvoices = resultCharges.GroupBy(d => d.AccessionNumber).Select(g => new InvoiceDTO
            {
                InvoiceId = g.FirstOrDefault().InvoiceId,
                BatchNo = g.FirstOrDefault().BatchNo,
                AccessionNumber = g.FirstOrDefault().AccessionNumber,
                DOS = g.FirstOrDefault().BillFromDate.Date.ToString("MM-dd-yyyy"),
                PatientName = $"{g.FirstOrDefault().FirstName}  {g.FirstOrDefault().LastName}",
                InsuranceCompanyName = g.FirstOrDefault().InsuranceCompanyName,
                OrderingPhysician = $"{g.FirstOrDefault().OrderingPhysicianFirstName}  {g.FirstOrDefault().OrderingPhysicianLastName}",
                PostDate = g.FirstOrDefault().CreatedDate.Date.ToString("MM-dd-yyyy"),
                ChargeAmount = System.Math.Round(g.Select(i => i.Amount).Sum(), 2),
                Interest = System.Math.Round(g.Select(i => i.BonusAmount.GetValueOrDefault()).Sum(), 2),
                Balance = System.Math.Round(g.Select(i => i.DueAmount).Sum(), 2),
                ChargeType = (g.FirstOrDefault().ClaimId != null && g.FirstOrDefault().SentDate != null) ? "ClaimSent" :
                (g.FirstOrDefault().ClaimId != null && g.FirstOrDefault().SentDate == null) ? "ClaimNotSent" :
                g.FirstOrDefault().ClaimId == null ? "ClaimNotMade" : "All"
            });

            IEnumerable<int> invoiceIds = resultInvoices.Select(i => i.InvoiceId).ToArray().Distinct();
            var invDiagnosis = await this._invDiagnosisRepository.GetByInvoiceId(invoiceIds);
            resultInvoices = resultInvoices.ToList();

            foreach (var res in resultInvoices.ToList())
            {
                IEnumerable<string> IcdCodes = invDiagnosis.Where(i => i.InvoiceId == res.InvoiceId).Select(i => i.ICDCode);
                res.ICDCodes = string.Join(',', IcdCodes);
            }

            return resultInvoices;

        }

        //private async Task<SqlExpression<Charges>> Get(IClaimBatchFilter filter)
        //{
        //    // this is a query which is used to find charges for claim screen.
        //    var query = this.Connection.From<Charges>()
        //                 .Join<Charges, ChargeViewDTO>((c, i) => c.Id == i.Id, NoLockTableHint.NoLock)
        //                 .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)
        //                 .Join<Invoice, ChargeBatch>((cv, cb) => cv.ChargeBatchId == cb.Id, NoLockTableHint.NoLock)
        //                 .Join<Charges, PatientCase>((c, p) => c.PatientCaseId == p.Id, NoLockTableHint.NoLock)
        //                 .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id, NoLockTableHint.NoLock)
        //                 .LeftJoin<Patient, InsurancePolicy, Charges>((c, ip, i) => c.DefaultCaseId == ip.PatientCaseId && ((ip.InsuranceLevel == 1 && i.DueByFlagCD == "PRIMARY") || (ip.InsuranceLevel == 2 && i.DueByFlagCD == "SECONDARY")
        //                 || (ip.InsuranceLevel == 3 && i.DueByFlagCD == "TERNARY")))
        //                 .LeftJoin<InsurancePolicy, InsuranceCompany>((inp, inc) => inp.InsuranceCompanyID == inc.Id, NoLockTableHint.NoLock)
        //                 .LeftJoin<Charges, Provider>((c, p) => c.PerformingProviderId == p.Id, NoLockTableHint.NoLock)
        //                 .LeftJoin<Invoice, ReferringDoctor>((c, p) => c.RefDoctorId == p.Id, NoLockTableHint.NoLock)
        //                 .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id, NoLockTableHint.NoLock)
        //                 .SelectDistinct<Charges, Patient, InsurancePolicy, ChargeBatch, InsuranceCompany, Provider, Invoice>((c, p, ip, cb, ic, pr, inv) => new
        //                 {
        //                     c,
        //                     FirstName = p.FirstName,
        //                     LastName = p.LastName,
        //                     InsuranceCompanyId = ip.InsuranceCompanyID,
        //                     InsuranceCompanyName = ic.CompanyName,
        //                     IsActive = cb.IsActive,
        //                     AccessionNumber = inv.AccessionNumber,
        //                     PlanEffectiveDate = ip.PlanEffectiveDate,
        //                     BatchAmount = cb.Amount,
        //                     ClaimId = inv.ClaimId,
        //                     DOS = inv.DateOfSign,
        //                     cb.BatchNo,
        //                     ProviderId = p.ProviderId,
        //                     PatientDOB = p.DOB,
        //                     PatientSigned = p.PatientSigned,
        //                     PaymentUId = inv.UId,
        //                     PatientUId = p.UId,
        //                     BillingID = p.BillingID,
        //                     PerformingProviderUId = pr.UId,

        //                 })
        //                 .Where(c => c.PracticeId == LoggedUser.PracticeId && c.IsDeleted == false)
        //                 .OrderBy(x => x.InvoiceId);

        //    if (filter != null && filter.InsuranceCompanyId != null)
        //        query.Where<InsurancePolicy>(i => i.InsuranceCompanyID == filter.InsuranceCompanyId.Value);

        //    if (filter != null && filter.BillTo != null)
        //    {
        //        if (filter.BillTo == 0)
        //            query.Where<Charges>(i => i.DueByFlagCD.ToLower() != "patient" && i.DueByFlagCD.ToLower() != "");
        //        else
        //            query.Where<Charges>(i => i.DueByFlagCD.ToLower() == "patient" && i.DueByFlagCD.ToLower() != "");
        //    }

        //    var selectExpression = query.SelectExpression;
        //    // this is because select can only take 7 parameter at a time so, we are again adding select linq query.
        //    query.Select<PatientCase, Claim, ChargeViewDTO, ReferringDoctor>((s, c, cvd, rd) => new
        //    {
        //        PatientCaseNumber = s.CaseIdNumber,
        //        SentDate = c.SentDate,
        //        PatientCaseUId = s.UId,
        //        DueAmount = cvd.DueAmount,
        //        OrderingPhysicianFirstName = rd.FirstName,
        //        OrderingPhysicianLastName = rd.LastName
        //    });

        //    query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");
        //    string countExpression = query.ToCountStatement();

        //    string whereExpression = await WhereClauseProvider<IClaimBatchFilter>.GetWhereClause(filter);
        //    query.WhereExpression = query.WhereExpression + " AND " + whereExpression;
        //    return query;

        //    //}
        //    //}
        //}

        //private async Task<IEnumerable<ICharges>> GetFilter(IEnumerable<ICharges> chargeList, int? selectedType)
        //{
        //    try
        //    {
        //        if (selectedType != null)
        //        {
        //            switch (selectedType)
        //            {
        //                //case (int)ChargeEnum.All:
        //                //    {
        //                //        chargeList = chargeList;
        //                //        break;
        //                //    }
        //                case (int)ChargeEnum.ClaimNotMade:
        //                    {
        //                        chargeList = chargeList.Where(item => item.ClaimId == null);
        //                        break;
        //                    }
        //                case (int)ChargeEnum.ClaimNotSent:
        //                    {
        //                        chargeList = chargeList.Where(item => item.SentDate == null && item.ClaimId != null);
        //                        break;
        //                    }
        //                case (int)ChargeEnum.ClaimSent:
        //                    {
        //                        chargeList = chargeList.Where(item => item.SentDate != null && item.ClaimId != null);
        //                        break;
        //                    }
        //                default:
        //                    {
        //                        break;
        //                    }
        //            }
        //        }

        //        return chargeList;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        private async Task<SqlExpression<ChargeViewDTO>> Get(IChargeDashboardBatchFilter filter)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                         //.Join<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id, NoLockTableHint.NoLock)
                         //.Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id, NoLockTableHint.NoLock)
                         //.Join<ChargeViewDTO, PatientCase>((cv, pc) => cv.PatientCaseId == pc.Id, NoLockTableHint.NoLock)
                         .Join<ChargeViewDTO, Patient>((pc, p) => pc.PatientCaseId== p.DefaultCaseId, NoLockTableHint.NoLock)                         
                         .LeftJoin<ChargeViewDTO, Provider>((cv, pr) => cv.PerformingProviderId == pr.Id, this.Connection.JoinAlias("Provider"))
                         //.LeftJoin<Invoice, ChargeBatch>((i, cb) => i.ChargeBatchId == cb.Id, NoLockTableHint.NoLock)
                         //.LeftJoin<ChargeViewDTO, Claim>((i, cl) => i.ClaimId == cl.Id, NoLockTableHint.NoLock)
                         //.LeftJoin<Provider, ConfigPractitionerService>((i, cl) => i.PractitionerServiceId == cl.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.PractitionerServiceId == i.Id, this.Connection.JoinAlias("MHQual"))
                         .LeftJoin<Provider, ConfigPractitionerService>((c, i) => c.SUDPractitionerServiceId == i.Id, this.Connection.JoinAlias("SUDQual"))
                         //.LeftJoin<Invoice, Provider>((iv, pr) => iv.BillProviderId== pr.Id, this.Connection.JoinAlias("BillingProvider"))                         
                         .SelectDistinct<ChargeViewDTO, Patient,  Provider,  ConfigPractitionerService>((cv, p, pd, x) => new
                         {
                             //cb.BatchNo,
                             cv.AccessionNumber,
                             cv.BillFromDate,
                             p.FirstName,
                             p.LastName,
                             PerformingPhysicianFirstName = Sql.JoinAlias(pd.FirstName, "Provider"),
                             PerformingPhysicianLastName = Sql.JoinAlias(pd.LastName, "Provider"),
                             ProfessionalAbbreviation= Sql.JoinAlias(x.ProfessionalAbbreviation, "MHQual"),
                             SUDProfessionalAbbreviation = Sql.JoinAlias(x.ProfessionalAbbreviation, "SUDQual"),
                             cv.CPTCode,
                             cv.ICD1,
                             cv.ICD2,
                             cv.ICD3,
                             cv.ICD4,
                             cv.CreatedDate,
                             cv.Amount,
                             cv.BonusAmount,
                             cv.DueAmount,
                             cv.DueByFlagCD,
                             cv.InvoiceId,
                             cv.UId,
                             cv.Id,
                             cv.InvoiceUId, 
                             cv.ClaimId,
                             PatientUId = p.UId,
                             //cb.IsActive,
                             cv.SentDate,
                             cv.ScrubError,
                             PatientDOB = p.DOB,
                             BillingID = p.BillingID,
                             cv.IsAROldCharges,
                             cv.InvoiceType,
                             cv.ReviewNeeded,
                             cv.ReviewComments,
                             cv.IsBillable,
                             cv.Mod1,
                             cv.Mod2,
                             cv.Mod3,
                             cv.Mod4,
                             cv.IsLocked,
                             cv.IsDeleted,
                             cv.NonBillableComments,
                             cv.IsRejected,
                             cv.StatuCodeDescription,
                             cv.ErrorMessage,
                             PerformingProviderUId=pd.UId,
                             cv.PatientCaseId,
                             cv.PatientCaseUId
                         })
                         .Where(c => c.PracticeId == LoggedUser.PracticeId).OrderBy(x => x.InvoiceId);


            if (filter != null && filter.InsuranceCompanyId != null)
                query.Where<InsurancePolicy>(i => i.InsuranceCompanyID == filter.InsuranceCompanyId.Value);

            if (filter != null && filter.BillTo != null)
            {
                if (filter.BillTo == 0)
                    query.Where<ChargeViewDTO>(i => i.DueByFlagCD.ToLower() != "patient" && i.DueByFlagCD.ToLower() != "");
                else
                    query.Where<ChargeViewDTO>(i => i.DueByFlagCD.ToLower() == "patient" && i.DueByFlagCD.ToLower() != "");
            }

            var selectExpression = query.SelectExpression;
            // this is because select can only take 7 parameter at a time so, we are again adding select linq query.
            //query.Select<Provider, PatientCase, ConfigPractitionerService>((pr, pc,ps) => new
            //{
            //    PerformingProviderUId = pr.UId,
            //    PatientCaseUId = pc.UId,
            //    PatientCaseId = pc.Id,
            //    ProfessionalAbbreviation = ps.ProfessionalAbbreviation
            //});

            //query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");

            string whereExpression = await WhereClauseProvider<IChargeDashboardBatchFilter>.GetWhereClause(filter);
            query.WhereExpression = query.WhereExpression + " AND " + whereExpression;
            return query;
        }

        private async Task<SqlExpression<ChargeViewDTO>> GetForMakeClaims()
        {
            var query = this.Connection.From<ChargeViewDTO>()

                         .Join<ChargeViewDTO, Patient>((pc, p) => pc.PatientCaseId == p.DefaultCaseId, NoLockTableHint.NoLock)
                         .SelectDistinct<ChargeViewDTO, Patient>((cv, p) => new
                         {
                             cv.BillFromDate,
                             p.FirstName,
                             cv.CreatedDate,
                             cv.Amount,
                             cv.DueAmount,
                             cv.DueByFlagCD,
                             cv.InvoiceId,
                             cv.InvoiceUId,
                             cv.ClaimId,
                             PatientUId = p.UId,
                             cv.ScrubError,
                             cv.IsAROldCharges,
                             cv.ReviewNeeded,
                             cv.IsLocked,
                             cv.IsDeleted,
                             cv.ErrorMessage,
                             cv.PatientCaseId,
                             cv.PatientCaseUId,
                             cv.IsBillable
                         })
                          .Where(i => i.ClaimId == null && i.ScrubError == false && i.IsAROldCharges == false && i.ReviewNeeded == false && i.IsLocked == false
           && i.DueAmount == i.Amount && i.IsDeleted == false && i.IsBillable == true && i.DueByFlagCD.ToLower() == "primary" && i.BillFromDate>DateTime.Now.AddYears(-1));






            return query;
        }

        private async Task<SqlExpression<Charges>> GetFor_SecondaryClaims()
        {

            IEnumerable<IInvoice> guids = await this.GetDataForSecondaryClaims();
            var list = guids.Select(i => i.InvoiceUId).Distinct();

            var query = this.Connection.From<Charges>()
                         .Join<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id, NoLockTableHint.NoLock)
                         .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id, NoLockTableHint.NoLock)
                         .Join<ChargeViewDTO, PatientCase>((cv, pc) => cv.PatientCaseId == pc.Id, NoLockTableHint.NoLock)
                         .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id, NoLockTableHint.NoLock)
                         .LeftJoin<ChargeViewDTO, Provider>((cv, pr) => cv.PerformingProviderId == pr.Id, this.Connection.JoinAlias("Provider"))
                         .LeftJoin<Invoice, ChargeBatch>((i, cb) => i.ChargeBatchId == cb.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Invoice, Claim>((i, cl) => i.ClaimId == cl.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Invoice, Provider>((iv, pr) => iv.BillProviderId == pr.Id, this.Connection.JoinAlias("BillingProvider"))
                         .SelectDistinct<Charges, ChargeViewDTO, Patient, Invoice, Provider, ChargeBatch, Claim>((c, cv, p, inv, pd, cb, cl) => new
                         {
                             cb.BatchNo,
                             inv.AccessionNumber,
                             cv.BillFromDate,
                             p.FirstName,
                             p.LastName,
                             PerformingPhysicianFirstName = Sql.JoinAlias(pd.FirstName, "Provider"),
                             PerformingPhysicianLastName = Sql.JoinAlias(pd.LastName, "Provider"),
                             BillingPhysicianFirstName = Sql.JoinAlias(pd.FirstName, "BillingProvider"),
                             BillingPhysicianLastName = Sql.JoinAlias(pd.LastName, "BillingProvider"),
                             cv.CPTCode,
                             cv.ICD1,
                             cv.ICD2,
                             cv.ICD3,
                             cv.ICD4,
                             cv.CreatedDate,
                             cv.Amount,
                             cv.BonusAmount,
                             cv.DueAmount,
                             cv.DueByFlagCD,
                             c.InvoiceId,
                             c.UId,
                             c.Id,
                             InvoiceUId = inv.UId,
                             inv.ClaimId,
                             PatientUId = p.UId,
                             cb.IsActive,
                             cl.SentDate,
                             c.ScrubError,
                             PatientDOB = p.DOB,
                             BillingID = p.BillingID,
                             IsAROldCharges = inv.IsAROldCharges,
                             inv.InvoiceType,
                             inv.ReviewNeeded,
                             inv.ReviewComments,
                             inv.IsBillable,
                             cv.Mod1,
                             cv.Mod2,
                             cv.Mod3,
                             cv.Mod4,
                             c.IsLocked,
                             c.IsDeleted,
                             inv.NonBillableComments,
                             c.IsRejected,
                             cv.StatuCodeDescription,
                             cv.ErrorMessage
                         })
                         .Where<Charges, Invoice, ChargeViewDTO>((c, j, cv) => c.PracticeId == LoggedUser.PracticeId && cv.DueAmount > 0 && c.IsDeleted == false && list.Contains(j.UId)).OrderBy(x => x.InvoiceId);


            var selectExpression = query.SelectExpression;
            // this is because select can only take 7 parameter at a time so, we are again adding select linq query.
            query.Select<Provider, PatientCase>((pr, pc) => new
            {
                PerformingProviderUId = pr.UId,
                PatientCaseUId = pc.UId,
                PatientCaseId = pc.Id,
            });

            query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");


            return query;
        }


        private async Task<SqlExpression<Charges>> GetChargesByInvoiceGUIds(List<Guid> invoiceUids)
        {            

            var query = this.Connection.From<Charges>()
                         .Join<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id, NoLockTableHint.NoLock)
                         .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)
                         .Join<ChargeViewDTO, PatientCase>((cv, pc) => cv.PatientCaseId == pc.Id, NoLockTableHint.NoLock)
                         .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Invoice, ReferringDoctor>((i, rd) => i.RefDoctorId == rd.Id, NoLockTableHint.NoLock)
                         .LeftJoin<ChargeViewDTO, Provider>((cv, pr) => cv.PerformingProviderId == pr.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Invoice, ChargeBatch>((i, cb) => i.ChargeBatchId == cb.Id, NoLockTableHint.NoLock)
                         .LeftJoin<Invoice, Claim>((i, cl) => i.ClaimId == cl.Id, NoLockTableHint.NoLock)
                         .SelectDistinct<Charges, ChargeViewDTO, Patient, Invoice, ReferringDoctor, ChargeBatch, Claim>((c, cv, p, inv, rd, cb, cl) => new
                         {
                             cb.BatchNo,
                             inv.AccessionNumber,
                             cv.BillFromDate,
                             p.FirstName,
                             p.LastName,
                             OrderingPhysicianFirstName = rd.FirstName,
                             OrderingPhysicianLastName = rd.LastName,
                             cv.CPTCode,
                             cv.ICD1,
                             cv.ICD2,
                             cv.ICD3,
                             cv.ICD4,
                             cv.CreatedDate,
                             cv.Amount,
                             cv.BonusAmount,
                             cv.DueAmount,
                             cv.DueByFlagCD,
                             c.InvoiceId,
                             c.UId,
                             InvoiceUId = inv.UId,
                             inv.ClaimId,
                             PatientUId = p.UId,
                             cb.IsActive,
                             cl.SentDate,
                             cv.ChargeNo,
                             cv.Id
                         })
                         .Where(c => c.PracticeId == LoggedUser.PracticeId && c.IsDeleted == false).OrderBy(x => x.InvoiceId);




            var selectExpression = query.SelectExpression;
            // this is because select can only take 7 parameter at a time so, we are again adding select linq query.
            query.Select<Provider, PatientCase>((pr, pc) => new
            {
                PerformingProviderUId = pr.UId,
                PatientCaseUId = pc.UId,
                PatientCaseId = pc.Id,
            });

            invoiceUids = invoiceUids.Distinct().ToList();

            query.Where<Invoice>(i => invoiceUids.Contains(i.UId));

            query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");

            //string whereExpression = await WhereClauseProvider<IClaimBatchFilter>.GetWhereClause(filter);
            //query.WhereExpression = query.WhereExpression + " AND " + whereExpression;
            return query;
        }

        private async Task<SqlExpression<Charges>> GetChargesByInvoiceGUIdsForBulkAdjustment(List<Guid> invoiceUids)
        {

            var query = this.Connection.From<Charges>()
                .Join<Charges, ChargeViewDTO> ((cv, i) => cv.Id == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)                
                        .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)
                         .Select<ChargeViewDTO,Invoice>((cv,inv) => new
                         {   
                             cv.CPTCode,                          
                             cv.DueAmount,   
                             cv.Amount,
                             InvoiceId=inv.Id,
                             cv.UId,
                             InvoiceUId = inv.UId,                             
                             cv.Id
                         })
                         .Where<ChargeViewDTO, Invoice>((c,i) => c.PracticeId == LoggedUser.PracticeId && c.DueAmount>0
                         && c.IsDeleted == false && invoiceUids.Contains(i.UId)).OrderBy(x => x.InvoiceId);


            var selectExpression = query.SelectExpression;
            // this is because select can only take 7 parameter at a time so, we are again adding select linq query.
           
            invoiceUids = invoiceUids.Distinct().ToList();

            //query.Where<Invoice>(i => invoiceUids.Contains(i.UId));

            query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");

            //string whereExpression = await WhereClauseProvider<IClaimBatchFilter>.GetWhereClause(filter);
            //query.WhereExpression = query.WhereExpression + " AND " + whereExpression;
            return query;
        }

        private async Task<SqlExpression<Charges>> GetChargesByChargeIds(List<int> chargesIds)
        {
            var query = this.Connection.From<Charges>()
                .Join<Charges, ChargeViewDTO>((cv, i) => cv.Id == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)
                        .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id && i.IsDeleted == false, NoLockTableHint.NoLock)
                         .Select<ChargeViewDTO, Invoice>((cv, inv) => new
                         {
                             cv.CPTCode,
                             cv.DueAmount,
                             cv.Amount,
                             InvoiceId = inv.Id,
                             cv.UId,
                             InvoiceUId = inv.UId,
                             cv.Id
                         })
                         .Where<ChargeViewDTO, Invoice>((c, i) => c.PracticeId == LoggedUser.PracticeId && c.DueAmount > 0
                         && c.IsDeleted == false && chargesIds.Contains(i.Id)).OrderBy(x => x.InvoiceId);


            var selectExpression = query.SelectExpression;
            query.SelectExpression = selectExpression + "," + query.SelectExpression.Replace("SELECT", "");
            return query;
        }

        private async Task<ChargeBatchTabsCount> GetTabsCount(List<Charges> charge)
        {
            // this is a method to find total counts of claims for every tabs.
            ChargeBatchTabsCount count = new ChargeBatchTabsCount();
            /*Fetch all charges count*/
            count.AllCount = charge.Where(i=>i.IsDeleted==false).Count();
            count.AllPatientCount = charge.Where(i=>i.IsDeleted==false).Select(i => i.PatientUId).Distinct().Count();
            /*charges count in which claim is not made*/
            count.ClaimNotMadeCount = charge.Where(i => i.ClaimId == null && i.ScrubError == false && i.IsAROldCharges==false && i.ReviewNeeded == false && i.IsLocked==false
           && i.DueAmount == i.Amount && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true) && i.InsuranceCompanyCode!= "SelfP" && i.DueByFlagCD.ToLower()=="primary").Count();

            count.ClaimNotMadePatientCount = charge.Where(i => i.ClaimId == null && i.ScrubError == false && i.IsAROldCharges == false && i.ReviewNeeded == false && i.IsLocked == false
           && i.DueAmount == i.Amount && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true) && i.InsuranceCompanyCode != "SelfP" && i.DueByFlagCD.ToLower() == "primary").Select(i => i.PatientUId).Distinct().Count();

            /*charges count in which claim is not sent*/
            count.ClaimNotSentCount = charge.Where(i => i.ClaimId != null && i.SentDate == null && i.ScrubError == false && i.IsLocked == false
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true)).Count();

            count.ClaimNotSentPatientCount = charge.Where(i => i.ClaimId != null && i.SentDate == null && i.ScrubError == false && i.IsLocked == false
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true)).Select(i => i.PatientUId).Distinct().Count();

            /*charges count in which claim is sent*/
            count.ClaimSentCount = charge.Where(i => i.ClaimId != null && i.SentDate != null && i.ScrubError == false && i.IsLocked == false
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true)).Count();
            count.ClaimSentPatientCount = charge.Where(i => i.ClaimId != null && i.SentDate != null && i.ScrubError == false && i.IsLocked == false
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true)).Select(i => i.PatientUId).Distinct().Count();

            count.ChargeHasErrorCount = charge.Where(i => i.ScrubError == true || i.ReviewNeeded==true && i.IsLocked == false && i.IsDeleted == false && i.DueAmount>0 && (i.IsBillable.HasValue && i.IsBillable == true)).Count();

            count.ChargeHasErrorPatientCount = charge.Where(i => i.ScrubError == true || i.ReviewNeeded == true && i.DueAmount > 0 && i.IsLocked == false && i.DueAmount > 0
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true)).Select(i => i.PatientUId).Distinct().Count();

            count.ChargeBillableCount = charge.Where(i => i.IsLocked == false && i.DueAmount > 0 && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == false)).Count();
            count.ChargeBillablePatientCount = charge.Where(i => i.IsLocked == false && i.DueAmount > 0 && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == false)).Select(i => i.PatientUId).Distinct().Count();

            count.ChargeRolledUpCount = charge.Where(i => i.IsLocked == true && i.IsDeleted==true).Count();
            count.ChargeRolledUpPatientCount = charge.Where(i => i.IsLocked == true && i.IsDeleted == true).Select(i => i.PatientUId).Distinct().Count();

            count.ChargeRejctedCount = charge.Where(i => i.IsRejected == true && i.IsDeleted == true).Count();
            count.ChargeRejctedPatientCount = charge.Where(i => i.IsRejected == true && i.IsDeleted == true).Select(i => i.PatientUId).Distinct().Count();

            count.ChargeSelfPayCount = charge.Where(i => i.ReviewNeeded == false && i.DueAmount > 0 && i.IsLocked == false && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true) && i.InsuranceCompanyCode == "SelfP").Count();

            count.ChargeSelfPayPatientCount = charge.Where(i => i.ReviewNeeded == false && i.IsLocked == false && i.DueAmount > 0
            && i.IsDeleted == false && (i.IsBillable.HasValue && i.IsBillable == true) && i.InsuranceCompanyCode == "SelfP").Select(i => i.PatientUId).Distinct().Count();


            count.ClaimErrorCount = charge.Where(i => i.IsDeleted == false && i.DueAmount > 0 && !string.IsNullOrWhiteSpace(i.ErrorMessage) && i.DueByFlagCD.ToLower() != "patient").Count();
            count.ClaimErrorPatientCount = charge.Where(i => i.IsDeleted == false && i.DueAmount > 0 && !string.IsNullOrWhiteSpace(i.ErrorMessage) && i.DueByFlagCD.ToLower() != "patient").Select(i => i.PatientUId).Distinct().Count();

            return count;
        }

        public async Task<ICharges> Get(int chargeNo, decimal amount)
        {
            return await this.Connection.SingleAsync<Charges>(i => i.ChargeNo == chargeNo && i.IsDeleted == false && i.Amount == amount && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable< ICharges>> GetByInvoiceId(Guid invoiceUId)
        {
            var query = this.Connection.From<Charges>()
                        .LeftJoin<Charges, Invoice>((c, f) => c.InvoiceId== f.Id)
                        .Select<Charges,Invoice>((c,i) => new
                        {
                            c,
                            AccessionNumber=i.AccessionNumber,
                            FeeAmount=i.FeeAmount
                            
                        })
                        .Where<Invoice>(i => i.UId==invoiceUId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            // return await this.Connection.SelectAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && !i.IsDeleted);
            return result;
        }

        private async Task<int> GetMaxChargeNo()
        {
            int maxChargeNo = 1;
            var query = this.Connection.From<Charges>()
                        .Select<Charges>(i => new
                        {
                            ChargeNo = Sql.Max(i.ChargeNo)
                        })
                        .Where<Charges>(i => i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.Map(queryResult);

            maxChargeNo = result.ChargeNo;
            return maxChargeNo;
        }

        /// <summary>
        /// Insert multiple Charges for particular Invoice
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="invoiceId"></param>
        /// <param name="insurancePolicies"></param>
        /// <returns></returns>
        public async Task<bool> AddNewEntities(IEnumerable<ICharges> entities, int invoiceId, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                _insurancePolicies = insurancePolicies;
                /*iterate charges for particular invoice*/
                foreach (var item in entities)
                {
                    item.InvoiceId = invoiceId;
                    await this.AddNew(item, _insurancePolicies);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByInvoiceNo(int invoiceId)
        {
            try
            {
                return await this.Connection.DeleteAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteCharge(int invoiceId, int chargeId)
        {
            try
            {
                /*Fetch Charge for given invoiceId and chargeId*/
                var deletedCharge = await this.Connection.SingleAsync<Charges>(i => i.InvoiceId == invoiceId && i.Id == chargeId
                                    && i.PracticeId == LoggedUser.PracticeId);

                if (deletedCharge != null)
                {
                    deletedCharge.IsDeleted = true;
                    /*on delete request of charge, it doesn't delete permanantely from table.
                    * only IsDeleted flag become true.
                    */
                    return await this.Update(deletedCharge);
                }

                return chargeId;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByChargeId(int invoiceId, int chargeId)
        {
            try
            {
                /*Fetch Charge for given invoiceId and chargeId*/
                var deletedCharge = await this.Connection.DeleteAsync<Charges>(i => i.InvoiceId == invoiceId && i.Id == chargeId && i.PracticeId == LoggedUser.PracticeId);
                return deletedCharge;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid chargeUId)
        {
            try
            {
                /*Fetch Charge for given chargeUId*/
                var deletedCharge = await this.Connection.SingleAsync<Charges>(i => i.UId == chargeUId && i.PracticeId == LoggedUser.PracticeId);
                deletedCharge.IsDeleted = true;

                /*on delete request of charge, it doesn't delete permanantely from table.
                 * only IsDeleted flag become true.
                 */
                return await this.Update(deletedCharge);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateDueBy(IEnumerable<int> chargeIds, bool isAmountDue = false)
        {
            var getChargesData = await this.GetCharges(chargeIds);

            if (isAmountDue)
            {
                foreach (var item in getChargesData)
                {
                    var charges = getChargesData.Where(i => i.Id == item.Id).FirstOrDefault();
                    charges.DueByFlagCD = "Patient";
                    charges.BillToPatient = true;
                    charges.BillToInsurance = false;
                    await this.Update(charges);
                }
            }
            else
            {
                foreach (var item in getChargesData)
                {
                    var charges = getChargesData.Where(i => i.Id == item.Id).FirstOrDefault();
                    charges.DueByFlagCD = "";
                    await this.Update(charges);
                }
            }
        }

        private async Task UpdateDueBy(int chargeId, decimal amount)
        {
            var getChargesData = await this.Connection.SingleAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == chargeId);
            getChargesData.DueByFlagCD = amount > 0 ? "Patient" : "";

            await this.Update(getChargesData);
        }

        public async Task<int> DeleteGcCodeEntry(int invoiceId)
        {
            try
            {
                return await this.Connection.DeleteAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.CPTCode.Contains("90853"));
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICharges> GetGcCodeEntry(int invoiceId)
        {
            try
            {
                string[] cptCodes = { "S9480", "90853" };

                return await this.Connection.SingleAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && cptCodes.Contains(i.CPTCode) && !i.IsDeleted);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                var tEntity = _mapper.Map<Charges>(entity);
                _insurancePolicies = insurancePolicies;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                if (tEntity.BillToPatient)
                    tEntity.DueByFlagCD = "Patient";
                else
                {
                    
                    if(tEntity.DueByFlagCD.ToLower()== "patient")
                    {
                        tEntity.DueByFlagCD = "Primary";
                    }
                }

                var updateOnlyFields = this.Connection
                                         .From<Charges>()
                                         .Update(x => new
                                         {
                                             x.ICD1,
                                             x.ICD2,
                                             x.ICD3,
                                             x.ICD4,
                                             x.IsDeleted,
                                             x.IsLocked,
                                             x.IsTaxable,
                                             x.Message1,
                                             x.Message2,
                                             x.Mod1,
                                             x.Mod2,
                                             x.Mod3,
                                             x.Mod4,
                                             x.MultiplyQty,
                                             x.NDCCode,
                                             x.NDCFormat,
                                             x.OrderingProviderId,
                                             x.PatientCaseId,
                                             x.PerformingFacilityId,
                                             x.PerformingProviderId,
                                             x.POSId,
                                             x.Qty,
                                             x.RefNumber,
                                             x.Tax,
                                             x.TOSId,
                                             x.UnitOfMeasure,
                                             x.EntryDate,
                                             x.DueByFlagCD,
                                             x.DrugQty,
                                             x.Discount,
                                             x.Description,
                                             x.CPTCode,
                                             x.Comments,
                                             x.ChargeNo,
                                             x.BillToPatient,
                                             x.BillToInsurance,
                                             x.BillToDate,
                                             x.BillToClinic,
                                             x.BillFromDate,
                                             x.Amount,
                                             x.ModifiedBy,
                                             x.ModifiedDate,
                                             x.IsRejected
                                         })
                                         .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;

                if (tEntity.AllowedAmount.HasValue && tEntity.AllowedAmount.Value > 0)
                {

                }
                else
                {
                    var getChargeData = await this.Connection.SingleAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == tEntity.Id);
                    tEntity.AllowedAmount = getChargeData.AllowedAmount;
                }

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.DueByFlagCD,
                                               x.CoIns,
                                               x.CoPay,
                                               x.Deductible,
                                               x.AllowedAmount,
                                               x.IsDeleted,
                                               x.BillToInsurance,
                                               x.BillToPatient,
                                               x.BonusAmount,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateIsDeleted(int chargeId)
        {
            try
            {
                Charges tEntity = await this.Connection.SingleAsync<Charges>(i => i.Id == chargeId && i.PracticeId == LoggedUser.PracticeId);
                tEntity.IsDeleted = false;

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.IsDeleted,
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

        public async Task<int> MarkAsRejected(int chargeId)
        {
            try
            {
                Charges tEntity = await this.Connection.SingleAsync<Charges>(i => i.Id == chargeId && i.PracticeId == LoggedUser.PracticeId);
                tEntity.IsDeleted = true;
                tEntity.IsRejected = true;

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.IsDeleted,
                                               x.IsRejected,
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

        public async Task<int> UpdateQuantityAndAmount(ICharges entity,bool isQtyUpdate=false)
        {
            try
            {
                Charges tEntity = entity as Charges;
                //Charges tEntity = await this.Connection.SingleAsync<Charges>(i => i.Id == chargeId && i.PracticeId == LoggedUser.PracticeId);
                //tEntity.IsDeleted = false;

                if(isQtyUpdate)
                {
                    var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.Qty,
                                               x.Amount,
                                               x.RefChargeId,
                                               x.RefChargeComment,
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.IsDeleted
                                           })
                                           .Where(i => i.Id == tEntity.Id && i.PracticeId == LoggedUser.PracticeId);

                    return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }
                else
                {
                    var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.RefChargeComment,
                                               x.IsLocked,
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.RefChargeId,
                                               x.IsDeleted
                                           })
                                           .Where(i => i.Id == tEntity.Id && i.PracticeId == LoggedUser.PracticeId);

                    return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }
                
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateEntities(IEnumerable<ICharges> entities, int invoiceId, IEnumerable<IInsurancePolicy> insurancePolicies)
        {
            try
            {
                _insurancePolicies = insurancePolicies;
                foreach (var item in entities)
                {
                    item.InvoiceId = invoiceId;
                    if (item.Id != 0 && !item.IsChargeDeleted)
                        await this.Update(item, _insurancePolicies);
                    else if (item.Id == 0 && !item.IsChargeDeleted)
                        await this.AddNew(item, _insurancePolicies);
                    else
                        await this.DeleteCharge((int)item.InvoiceId, item.Id);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ICharges> GetById(int Id)
        {
            var query = this.Connection.From<Charges>()
                             .LeftJoin<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id)
                             .SelectDistinct<Charges, ChargeViewDTO>((c, cv) => new
                             {
                                 c,
                                 DueAmount = cv.DueAmount
                             })
                             .Where(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.Map(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetCharges(IEnumerable<int> Ids)
        {
            var query = this.Connection.From<Charges>()
                             .LeftJoin<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id)
                             .SelectDistinct<Charges, ChargeViewDTO>((c, cv) => new
                             {
                                 c,
                                 DueAmount = cv.DueAmount
                             });
            //.Where(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            query.WhereExpression = query.FromExpression + "Where (Charge.PracticeId = " + LoggedUser.PracticeId + " and Charge.IsDeleted=0 and Charge.Id In (" + string.Join(',', Ids) + "))";

            var result = await this.Connection.QueryAsync<ChargeViewDTO>(query.SelectExpression + query.WhereExpression);
            //var result = Mapper<Charges>.Map(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetById(int invoiceId, int patientCaseId)
        {
            var query = this.Connection.From<Charges>()
                        .LeftJoin<Charges, Facility>((c, f) => c.PerformingFacilityId == f.Id)
                        .LeftJoin<Charges, Provider>((c, p) => c.PerformingProviderId == p.Id)
                        .Join<Charges, CPTCodes>((c, cpt) => c.CPTCode == cpt.CPTCode)
                        .LeftJoin<Charges, ICDCode>((c, p) => c.ICD1 == p.Code)
                        .SelectDistinct<Charges, Facility, Provider, CPTCodes,ICDCode>((c, f, p, cpt,icd) => new
                        {
                            c,
                            PerformingFacilityUId = f.UId,
                            PerformingProviderUId = p.UId,
                            cpt.IsSameAsDefault,
                            Icd1Type= icd.IcdType
                        })
                        .Where(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && !i.IsDeleted);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            // return await this.Connection.SelectAsync<Charges>(i => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && !i.IsDeleted);
            return result;
        }

        public async Task<IEnumerable<ICharges>> GetBalance(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                // get charges for invoice data
                var query = this.Connection.From<Charges>()
                            .Join<Charges, ChargeViewDTO>((c, cv) => c.Id == cv.Id && c.IsDeleted == false)
                            .SelectDistinct<Charges, ChargeViewDTO>((c, cv) => new
                            {
                                cv,
                                DueAmount = cv.DueAmount,
                                BillToInsurance = cv.BillToInsurance,
                                BillToPatient = cv.BillToPatient
                            })
                            .Where<ChargeViewDTO>(i => i.PracticeId == LoggedUser.PracticeId);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// method to get charges for bulk payment screen 
        /// IsShowOnlyClaimed- it is a flag to show only those charges on which any claim exists. 
        /// </summary>
        /// <param name="invoiceId"></param>
        /// <param name="patientCaseId"></param>
        /// <param name="IsShowOnlyClaimed"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ICharges>> GetView(IEnumerable<int> invoiceId, IEnumerable<int> patientCaseId, bool IsShowOnlyClaimed)
        {
            if (IsShowOnlyClaimed)
            {
                var query = this.Connection.From<Charges>()
                            .Join<ChargeViewDTO, ClaimCharge>((c, cc) => c.Id == cc.ChargeId)
                            .SelectDistinct<ChargeViewDTO, ClaimCharge>((c, cc) => new
                            {
                                c
                            })
                            .Where<ChargeViewDTO>(i => invoiceId.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && patientCaseId.Contains(i.PatientCaseId) && i.IsDeleted == false);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<ChargeViewDTO>.MapList(queryResult);
            }

            return await this.Connection.SelectAsync<ChargeViewDTO>(i => invoiceId.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && patientCaseId.Contains(i.PatientCaseId) && i.IsDeleted == false && i.DueAmount > 0);
        }

        public async Task<IEnumerable<ICharges>> GetById(IEnumerable<int> invoiceId, IEnumerable<int> patientCaseId, IPaymentFilterDTO filter)
        {
            try
            {
                if (filter.IsShowOnlyClaimed)
                {
                    var query = this.Connection.From<Charges>()
                                .Join<Charges, ClaimCharge>((c, cc) => c.Id == cc.ChargeId, NoLockTableHint.NoLock)
                                .SelectDistinct<Charges, ClaimCharge>((c, cc) => new
                                {
                                    c
                                })
                                .Where(i => invoiceId.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && patientCaseId.Contains(i.PatientCaseId));

                    var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                    return Mapper<Charges>.MapList(queryResult);
                }
                else if (filter.IsShowAllPendingPayment)
                {
                    return await this.Connection.SelectAsync<ChargeViewDTO>(i => invoiceId.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && patientCaseId.Contains(i.PatientCaseId) && i.IsDeleted == false && i.DueAmount > 0);
                }
                else
                    return await this.Connection.SelectAsync<Charges>(i => invoiceId.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && !i.IsDeleted && patientCaseId.Contains(i.PatientCaseId));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteChargeValidation()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ChargeIsInUse]));

        }

        public async Task<ICharges> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<Charges>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId && !i.IsDeleted);
        }

        public async Task<IEnumerable<int>> GetByUIds(IEnumerable<string> UIds)
        {
            var query = this.Connection.From<Charges>().Select<Charges>(i => new
            {
                i.Id
            })
            .Where(i => UIds.Contains(i.UId.ToString()) && i.PracticeId == LoggedUser.PracticeId);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            return dynamics.Select(i => (int)i.Id);
        }

        private void ICDandModifierValidation(Charges tEntity, ref List<IValidationResult> errors)
        {
            /*Check Diagnosis Code should not duplicate for a single CPT Code on Charge Screen. 
             if duplicate diagnosis exist then give exception Diagnosis Code already exist for specific CPT*/
            var _icdDuplicacyCondition = ((!string.IsNullOrEmpty(tEntity.ICD2) ? tEntity.ICD2 == tEntity.ICD1 : false)
                                      || ((!string.IsNullOrEmpty(tEntity.ICD3) && !string.IsNullOrEmpty(tEntity.ICD2)) ? tEntity.ICD3 == tEntity.ICD2 : false)
                                      || ((!string.IsNullOrEmpty(tEntity.ICD3) ? tEntity.ICD3 == tEntity.ICD1 : false))
                                      || ((!string.IsNullOrEmpty(tEntity.ICD4) && !string.IsNullOrEmpty(tEntity.ICD3)) ? tEntity.ICD4 == tEntity.ICD3 : false)
                                      || ((!string.IsNullOrEmpty(tEntity.ICD4) && !string.IsNullOrEmpty(tEntity.ICD2)) ? tEntity.ICD4 == tEntity.ICD2 : false)
                                      || (!string.IsNullOrEmpty(tEntity.ICD4) ? tEntity.ICD4 == tEntity.ICD1 : false));

            if (_icdDuplicacyCondition)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.DiagnosisCodeAlreadyUsedForThisCPT]));

            /*Check modifier should not duplicate for a single CPT Code on Charge Screen. 
             if duplicate modifier exist then give exception Modifier already exist for specific CPT*/
            var _modifiersDuplicacyCondition = ((!string.IsNullOrEmpty(tEntity.Mod2) && (!string.IsNullOrEmpty(tEntity.Mod1))) ? tEntity.Mod2 == tEntity.Mod1 : false
                || ((!string.IsNullOrEmpty(tEntity.Mod3) && (!string.IsNullOrEmpty(tEntity.Mod2))) ? tEntity.Mod3 == tEntity.Mod2 : false)
                || ((!string.IsNullOrEmpty(tEntity.Mod3) && (!string.IsNullOrEmpty(tEntity.Mod1))) ? tEntity.Mod3 == tEntity.Mod1 : false)
                || ((!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod3)) ? tEntity.Mod4 == tEntity.Mod3 : false)
                || (!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod2) ? tEntity.Mod4 == tEntity.Mod2 : false)
                || (!string.IsNullOrEmpty(tEntity.Mod4) && !string.IsNullOrEmpty(tEntity.Mod1) ? tEntity.Mod4 == tEntity.Mod1 : false));

            if (_modifiersDuplicacyCondition)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ModifierAlreadyExistForThisCPT]));
        }

        private async Task<List<IValidationResult>> ModifierValidation(Charges tEntity, List<IValidationResult> errors)
        {
            /*Check modifier should not duplicate for a single CPT Code on Charge Screen. 
             if duplicate modifier exist then give exception Modifier should be unique for specific CPT*/
            var codes = await this.Connection.SelectAsync<Charges>(i => i.CPTCode == tEntity.CPTCode &&
                i.InvoiceId == tEntity.InvoiceId && i.PracticeId == LoggedUser.PracticeId);

            codes = codes.Where(i => i.BillFromDate.Day == tEntity.BillFromDate.Day && i.BillFromDate.Month == tEntity.BillFromDate.Month && i.BillFromDate.Year == tEntity.BillFromDate.Year
            && i.Mod1==tEntity.Mod1
            && i.Mod2 == tEntity.Mod2
            && i.Mod3 == tEntity.Mod3
            && i.Mod4 == tEntity.Mod4).ToList();

            var _modifiers = codes.Where(i => (!string.IsNullOrEmpty(tEntity.Mod1) ? i.Mod1 == tEntity.Mod1 : false)
                                           || (!string.IsNullOrEmpty(tEntity.Mod2) ? i.Mod2 == tEntity.Mod2 : false)
                                           || (!string.IsNullOrEmpty(tEntity.Mod3) ? i.Mod3 == tEntity.Mod3 : false)
                                           || (!string.IsNullOrEmpty(tEntity.Mod4) ? i.Mod4 == tEntity.Mod4 : false));


            if (tEntity.Id > 0 && _modifiers.Count() > 0)
                _modifiers = _modifiers.Where(i => i.Id != tEntity.Id).ToList();

            if (_modifiers.Count() > 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ModifierShouldBeUniqueForSameCPTCodes]));

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(Charges tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            ICDandModifierValidation(tEntity, ref errors);
            errors = await ModifierValidation(tEntity, errors);


            if (tEntity.BillToInsurance && _insurancePolicies.Count() == 0 && !tEntity.IsChargeDeleted)
            {
                if(!tEntity.IsFromHL7)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesNotHaveInsurance]));
            }
                

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(Charges tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            ICDandModifierValidation(tEntity, ref errors);

            errors = await ModifierValidation(tEntity, errors);

            if (tEntity.BillToInsurance && _insurancePolicies.Count() == 0 && !tEntity.IsChargeDeleted)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientDoesNotHaveInsurance]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public async Task<IEnumerable<ICharges>> GetByIds(IEnumerable<IDenialManagementInsuranceTypeDTO> chargeData, bool isSelfPayment)
        {
            List<Charges> charges = new List<Charges>();
            int[] chargesIds = chargeData.Select(i => i.AccountCount).ToArray();

            var query = this.Connection.From<ChargeViewDTO>()
                         .Join<ChargeViewDTO, Charges>((cb, i) => cb.Id == i.Id)
                         .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                         .Join<Invoice, ChargeBatch>((cv, cb) => cv.ChargeBatchId == cb.Id)
                         .Join<Charges, PatientCase>((c, p) => c.PatientCaseId == p.Id)
                         .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id)
                         .SelectDistinct<ChargeViewDTO, Patient, ChargeBatch, Invoice>((x, c, cb, i) => new
                         {
                             x,
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             IsActive = cb.IsActive,
                             DOS = i.DateOfSign
                         })
                         .Where<ChargeViewDTO, Invoice, Charges>((i, inc, c) => i.PracticeId == LoggedUser.PracticeId && chargesIds.Contains(c.Id));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            result = isSelfPayment ? result.Where(i => i.DueByFlagCD.ToLower() == "patient") : result.Where(i => i.DueByFlagCD.ToLower() != "patient");

            result = await this.Get(chargeData, result);

            return result;
        }

        private async Task<List<Charges>> Get(IEnumerable<IDenialManagementInsuranceTypeDTO> chargeIds, IEnumerable<Charges> result)
        {
            int[] ids = chargeIds.Select(i => i.InsuranceCompanyId).ToArray();
            var insuranceIds = await this._insuranceCompanyRepository.GetById(ids);

            foreach (var item in result)
            {
                var CompanyId = chargeIds.Where(i => i.AccountCount == item.Id).Select(i => i.InsuranceCompanyId).FirstOrDefault();
                var getCompanyData = insuranceIds.Where(i => i.Id == CompanyId).FirstOrDefault();
                item.InsuranceCompanyId = getCompanyData.Id;
                item.InsuranceCompanyName = getCompanyData.CompanyName;
                var policyData = await this._insurancePolicyRepository.GetById(item.PatientCaseId, getCompanyData.Id);
                item.PlanEffectiveDate = policyData == null ? null : policyData.PlanEffectiveDate;
            }

            return result.ToList();
        }

        public async Task<IEnumerable<ICharges>> GetByIds(IEnumerable<int> chargeIds)
        {

            if (chargeIds.Count() > 2000)
            {
                //long chunkSize = 2000;
                //List<List<int>> retVal = new List<List<int>>();

                //List<int> newIds = new List<int>();
                //newIds.AddRange(chargeIds);

                //while (newIds.Count() > 0)
                //{
                //    long count = newIds.Count() > chunkSize ? chunkSize : newIds.Count();
                //    retVal.Add(newIds.GetRange(0, (int)count));
                //    newIds.RemoveRange(0, (int)count);
                //}

                //List<Charges> chargesList = new List<Charges>();

                //foreach (var item in retVal)
                //{
                //    var chunkQuery = this.CreateSQL(item);
                //    var chunkQueryResult = await this.Connection.SelectAsync<dynamic>(chunkQuery);
                //    var chunkResult = Mapper<Charges>.MapList(chunkQueryResult);

                //    chargesList.AddRange(chunkResult);
                //}

                //return chargesList;

                return await this.GetCharge(chargeIds);
            }

            List<Charges> charges = new List<Charges>();

            var query = this.CreateSQL(chargeIds);
            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public SqlExpression<ChargeViewDTO> CreateSQL(IEnumerable<int> chargeIds)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                         .Join<ChargeViewDTO, Charges>((cb, i) => cb.Id == i.Id)
                         .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                         .Join<Invoice, ChargeBatch>((cv, cb) => cv.ChargeBatchId == cb.Id)
                         .Join<Charges, PatientCase>((c, p) => c.PatientCaseId == p.Id)
                         .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id)
                         .SelectDistinct<ChargeViewDTO, Patient, ChargeBatch, Invoice>((x, c, cb, i) => new
                         {
                             x,
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             IsActive = cb.IsActive,
                             DOS = i.DateOfSign
                         })
                         .Where<ChargeViewDTO, Invoice, Charges>((i, inc, c) => i.PracticeId == LoggedUser.PracticeId && chargeIds.Contains(c.Id));

            return query;
        }

        public async Task<IEnumerable<ChargeViewDTO>> GetCharge(IEnumerable<int> chargeIds)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                         .Join<ChargeViewDTO, Charges>((cb, i) => cb.Id == i.Id)
                         .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                         .Join<Invoice, ChargeBatch>((cv, cb) => cv.ChargeBatchId == cb.Id)
                         .Join<Charges, PatientCase>((c, p) => c.PatientCaseId == p.Id)
                         .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id)
                         .SelectDistinct<ChargeViewDTO, Patient, ChargeBatch, Invoice>((x, c, cb, i) => new
                         {
                             x,
                             FirstName = c.FirstName,
                             LastName = c.LastName,
                             IsActive = cb.IsActive,
                             DOS = i.DateOfSign
                         });
            //.Where<ChargeViewDTO, Invoice, Charges>((i, inc, c) => i.PracticeId == LoggedUser.PracticeId);

            query.WhereExpression = query.FromExpression + "Where (Charge.PracticeId = " + LoggedUser.PracticeId + " and Charge.Id In (" + string.Join(',', chargeIds) + "))";
            // query.WhereExpression = query.WhereExpression.Replace("@0", LoggedUser.PracticeId.ToString());

            var result = await this.Connection.QueryAsync<ChargeViewDTO>(query.SelectExpression + query.WhereExpression);
            return result;
        }

        private async Task<IClaimChargesDTO> Get(IClaimChargesDTO claimChargesDTO, int? billTo)
        {
            if (billTo != null)
                switch (billTo)
                {
                    case 0:
                        claimChargesDTO.ChargesAll = claimChargesDTO.ChargesAll.Where(i => i.BillToInsurance == true);
                        claimChargesDTO.ChargesClaimNotMade = claimChargesDTO.ChargesClaimNotMade.Where(i => i.BillToInsurance == true);
                        claimChargesDTO.ChargesClaimNotSent = claimChargesDTO.ChargesClaimNotSent.Where(i => i.BillToInsurance == true);
                        claimChargesDTO.ChargesClaimSent = claimChargesDTO.ChargesClaimSent.Where(i => i.BillToInsurance == true);
                        break;

                    case 1:
                        claimChargesDTO.ChargesAll = claimChargesDTO.ChargesAll.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PRIMARY.ToString());
                        claimChargesDTO.ChargesClaimNotMade = claimChargesDTO.ChargesClaimNotMade.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PRIMARY.ToString());
                        claimChargesDTO.ChargesClaimNotSent = claimChargesDTO.ChargesClaimNotSent.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PRIMARY.ToString());
                        claimChargesDTO.ChargesClaimSent = claimChargesDTO.ChargesClaimSent.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PRIMARY.ToString());
                        break;

                    case 2:
                        claimChargesDTO.ChargesAll = claimChargesDTO.ChargesAll.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PATIENT.ToString());
                        claimChargesDTO.ChargesClaimNotMade = claimChargesDTO.ChargesClaimNotMade.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PATIENT.ToString());
                        claimChargesDTO.ChargesClaimNotSent = claimChargesDTO.ChargesClaimNotSent.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PATIENT.ToString());
                        claimChargesDTO.ChargesClaimSent = claimChargesDTO.ChargesClaimSent.Where(i => i.BillToPatient == true && i.DueByFlagCD == DrugFlagTypeEnum.PATIENT.ToString());
                        break;
                    case 3:
                        claimChargesDTO.ChargesAll = claimChargesDTO.ChargesAll.Where(i => i.BillToPatient == true);
                        claimChargesDTO.ChargesClaimNotMade = claimChargesDTO.ChargesClaimNotMade.Where(i => i.BillToPatient == true);
                        claimChargesDTO.ChargesClaimNotSent = claimChargesDTO.ChargesClaimNotSent.Where(i => i.BillToPatient == true);
                        claimChargesDTO.ChargesClaimSent = claimChargesDTO.ChargesClaimSent.Where(i => i.BillToPatient == true);
                        break;
                }

            return claimChargesDTO;
        }

        public async Task<IEnumerable<IPatientChargesStatementDTO>> GetStatement(IEnumerable<int> patientCaseId, DateTime fromDate, DateTime toDate)
        {
            IStatementDTO statementDTO = null;

            var fromFirstDate = Convert.ToDateTime(fromDate.ToString("yyyy-MM-dd 00:00:00"));
            var fromToDate = Convert.ToDateTime(toDate.ToString("yyyy-MM-dd 23:59:59"));

            var query = this.Connection.From<ChargeViewDTO>()
            .Join<ChargeViewDTO, Charges>((cb, i) => cb.Id == i.Id && (i.CreatedDate >= fromFirstDate && i.CreatedDate <= fromToDate) && cb.IsDeleted == false)
            .Join<Charges, PatientCase>((c, p) => c.PatientCaseId == p.Id && c.IsDeleted == false)
            .Join<PatientCase, Patient>((c, p) => c.PatientId == p.Id)
            .Join<PatientCase, InsurancePolicy, ChargeViewDTO>((c, ip, i) => c.Id == ip.PatientCaseId)
            //&& ((ip.InsuranceLevel == 1 && i.DueByFlagCD == "PRIMARY") || (ip.InsuranceLevel == 2 && i.DueByFlagCD == "SECONDARY")
            //|| (ip.InsuranceLevel == 3 && i.DueByFlagCD == "TERNARY"))
            .SelectDistinct<ChargeViewDTO, Patient>((x, c) => new
            {
                x,
                ChargeId = x.Id,
                ChargeDate = x.CreatedDate,
                ChargeDescription = x.Description,
                CPTCodes = x.CPTCode,
                ChargeAmount = x.Amount,
                PaidAmount = x.PaidAmount,
                AdjustmentAmount = x.TotalAdjustment,
                BalanceAmount = x.DueAmount,
                DueByFlagCD = x.DueByFlagCD
                //  PaymentId = x.PaymentId
            })
            .Where<ChargeViewDTO, Invoice, Charges, InsurancePolicy>((i, inc, c, ip) => i.PracticeId == LoggedUser.PracticeId
            && patientCaseId.Contains(c.PatientCaseId) && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var chargesDTO = Mapper<PatientChargesStatementDTO>.MapList(queryResult);

            return chargesDTO;
        }

        public async Task<IEnumerable<ICharges>> GetNumber(IEnumerable<int> chargeNos, IEnumerable<int> patientCaseIds)
        {
            chargeNos = chargeNos.Distinct();

            var query = this.Connection.From<ChargeViewDTO>()
                          .Select<ChargeViewDTO>(i => new
                          {
                              i
                          })
                          .Where(i => chargeNos.Contains(i.ChargeNo) && i.IsDeleted == false && i.PracticeId == LoggedUser.PracticeId && patientCaseIds.Contains(i.PatientCaseId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetCharges(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<ChargeViewDTO, Provider>((pc, p) => pc.PerformingProviderId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .LeftJoin<ChargeViewDTO,ChargeStat>((i, c) => i.Id == c.Id)
                            .SelectDistinct<ChargeViewDTO, Invoice, Patient, Claim, PatientCase,Provider, ChargeStat>((x, i, p, c, ptc,prd,cs) => new
                            {
                                DOS = x.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = x.BonusAmount,
                                ScrubError = x.ScrubError,
                                IsLocked=x.IsLocked,
                                ReviewComments=i.ReviewComments,
                                PerformingPhysicianFirstName=prd.FirstName,
                                PerformingPhysicianLastName=prd.LastName,
                                x.BillToInsurance,
                                x.BillToPatient,
                                IsDenial=cs.HasDenial

                            })
                 .Where<ChargeViewDTO>((i) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId && i.IsDeleted==false);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetChargesNew(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<ChargeViewDTO, Provider>((pc, p) => pc.PerformingProviderId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .LeftJoin<ChargeViewDTO, ChargeStat>((i, c) => i.Id == c.Id)
                            .SelectDistinct<ChargeViewDTO, Invoice, Patient, Claim, PatientCase, Provider, ChargeStat>((x, i, p, c, ptc, prd, cs) => new
                            {
                                DOS = x.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = x.BonusAmount,
                                ScrubError = x.ScrubError,
                                IsLocked = x.IsLocked,
                                ReviewComments = i.ReviewComments,
                                PerformingPhysicianFirstName = prd.FirstName,
                                PerformingPhysicianLastName = prd.LastName,
                                x.BillToInsurance,
                                x.BillToPatient,
                                IsDenial = cs.HasDenial,
                                i.IsRejected,
                                x.IsDuplicate,
                                x.IsDeleted
                            })
                 .Where<ChargeViewDTO>((i) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetRollUpCharges(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .SelectDistinct<ChargeViewDTO, PaymentCharge, Invoice, Patient, Claim, PatientCase>((x, pc, i, p, c, ptc) => new
                            {
                                DOS = x.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = x.BonusAmount,
                                ScrubError = x.ScrubError,
                                IsLocked = x.IsLocked,
                                ReviewComments = i.ReviewComments
                            })
                 .Where<ChargeViewDTO>((i) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId && i.IsLocked== true);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetRejectedCharges(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .SelectDistinct<ChargeViewDTO, PaymentCharge, Invoice, Patient, Claim, PatientCase>((x, pc, i, p, c, ptc) => new
                            {
                                DOS = x.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = x.BonusAmount,
                                ScrubError = x.ScrubError,
                                IsLocked = x.IsLocked,
                                ReviewComments = i.ReviewComments
                            })
                 .Where<ChargeViewDTO,Invoice>((i,j) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId && j.IsRejected == true);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> DuplicateCharges(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .SelectDistinct<ChargeViewDTO, PaymentCharge, Invoice, Patient, Claim, PatientCase>((x, pc, i, p, c, ptc) => new
                            {
                                DOS = x.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = x.BonusAmount,
                                ScrubError = x.ScrubError,
                                IsLocked = x.IsLocked,
                                ReviewComments = i.ReviewComments
                            })
                 .Where<ChargeViewDTO>((i) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId &&(i.IsDuplicate.HasValue && i.IsDuplicate == true));

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeViewAccessionWise>> GetChargesByAccessionNumberWise(string accessionNumber)
        {
            try
            {
                var result = await this.Connection.SelectAsync<ChargeViewAccessionWiseDTO>(i => i.AccessionNumber == accessionNumber);
                //result = result.GroupBy(d => new { d.AccessionNumber, d.ChargeAmount}).Select(g => new ChargeViewAccessionWiseDTO
                //{
                //    AccessionNumber = g.FirstOrDefault().AccessionNumber,                    
                //    ChargeAmount= g.FirstOrDefault().ChargeAmount,
                //    PatientPaid = System.Math.Round(g.Select(i => i.PatientPaid.Value).Sum(), 2),
                //    InsurancePaid = System.Math.Round(g.Select(i => i.InsurancePaid.Value).Sum(), 2),
                //    InsuranceAdjustment = System.Math.Round(g.Select(i => i.InsuranceAdjustment.Value).Sum(), 2),
                //    PatientAdjustment = System.Math.Round(g.Select(i => i.PatientAdjustment.Value).Sum(), 2)                    

                //}).ToList();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetChargesByPatientCaseId(IChargePaymentBillingHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Charges>((cv, c) => cv.Id == c.Id)
                            .Join<ChargeViewDTO, Invoice>((cv, i) => cv.InvoiceId == i.Id)
                            .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                            .SelectDistinct<ChargeViewDTO, PaymentCharge, Invoice, Patient, Claim, PatientCase, Charges>((x, pc, i, p, c, ptc, ch) => new
                            {
                                DOS = i.BillFromDate,
                                Mod1 = x.Mod1,
                                Mod2 = x.Mod2,
                                Mod3 = x.Mod3,
                                Mod4 = x.Mod4,
                                UId = x.UId,
                                BillFromDate = x.BillFromDate,
                                PatientCaseUId = ptc.UId,
                                Id = x.Id,
                                Amount = x.Amount,
                                TotalPaidAmount = x.PaidAmount,
                                CoPay = x.CoPay,
                                Deductible = x.Deductible,
                                CoIns = x.CoIns,
                                CPTCode = x.CPTCode,
                                TotalAdjustment = x.TotalAdjustment,
                                DueAmount = x.DueAmount,
                                InvoiceId = x.InvoiceId,
                                DueByFlagCD = x.DueByFlagCD,
                                AccessionNumber = i.AccessionNumber,
                                VoucherUId = i.UId,
                                PaymentUId = x.UId,
                                ClaimId = i.ClaimId,
                                BillingID = p.BillingID,
                                ClaimUId = c.UId,
                                SentDate = c.SentDate,
                                BonusAmount = ch.BonusAmount,
                                ScrubError = ch.ScrubError
                            })
                 .Where<ChargeViewDTO>((i) => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId && i.IsDeleted == false);

                //string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                //string whereExpression = await WhereClauseProvider<IChargePaymentBillingHistoryFilter>.GetWhereClause(filter);

                //query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IValidationResult>> ThrowErrors(IEnumerable<int> chargeNoGet, IEnumerable<int> chargeNoExists)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            IEnumerable<int> chargeNotExists = chargeNoGet.Except<int>(chargeNoExists);

            foreach (var item in chargeNotExists)
            {
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ChargeDoesNotExists, item]));
            }

            return errors;
        }

        public async Task<IEnumerable<ICharges>> Get(IEnumerable<int> invoiceIds)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber
                        })
                        .Where<Charges>((i) => invoiceIds.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetAccessionForEolledUpchild(Guid invoiceUId)
        {

            var query1 = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c                            
                        })
                        .Where<Invoice>((i) => i.UId== invoiceUId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult1 = await this.Connection.SelectAsync<dynamic>(query1);
            var result1 = Mapper<Charges>.MapList(queryResult1);


            var performingProviderId = result1.FirstOrDefault().PerformingProviderId;
            var cptCode = result1.FirstOrDefault().CPTCode;
            var dosDae = result1.FirstOrDefault().BillFromDate;
            var patientCaseId = result1.FirstOrDefault().PatientCaseId;


            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber,
                            InvoiceUId=i.UId
                        })
                        .Where<Charges,Invoice>((i,j) => j.UId!=invoiceUId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.PatientCaseId== patientCaseId
                        && i.IsLocked==false && i.CPTCode==cptCode && i.PerformingProviderId== performingProviderId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);
            result = result.Where(i => i.BillFromDate.Day == dosDae.Day && i.BillFromDate.Month == dosDae.Month && i.BillFromDate.Year == dosDae.Year);
            return result;
        }

        public async Task<IEnumerable<ICharges>> GetExistsCharge(int invoiceId,int patientCaseId,short performingProviderId,string cptCode)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false && i.IsBillable==true)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber,
                            FeeAmount=i.FeeAmount
                        })
                        .Where<Charges>((i) => i.InvoiceId<invoiceId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false
                        && i.PerformingProviderId==performingProviderId
                        && i.PatientCaseId==patientCaseId && i.CPTCode== cptCode).OrderByDescending(i=>i.BillFromDate).Take(5);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetExistsChargeForRollUp(int invoiceId, int patientCaseId, short performingProviderId, string cptCode)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false && i.IsBillable == true)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber
                        })
                        .Where<Charges>((i) => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false
                        && i.PerformingProviderId == performingProviderId
                        && i.PatientCaseId == patientCaseId && i.CPTCode == cptCode);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetChargeView(IEnumerable<int> invoiceIds)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, ChargeViewDTO>((c, i) => c.Id == i.Id && c.IsDeleted == false)
                        .Join<ChargeViewDTO, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, ChargeViewDTO>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber
                        })
                        .Where<ChargeViewDTO>((i) => invoiceIds.Contains(i.InvoiceId) && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ChargeViewDTO>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> Get(int invoiceId)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == true)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber
                        })
                        .Where<Charges>((i) => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == true);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetCahrges97201To05(int patientCaseId)
        {
            List<string> cptCodes = new List<string>() { "99201", "99202", "99203", "99204", "99205" };

            var result = await this.Connection.SelectAsync<Charges>(i => cptCodes.Contains(i.CPTCode) && i.PatientCaseId==patientCaseId);

            return result;

        }

        public async Task<IEnumerable<ICharges>> Validate90791(int patientCaseId)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c                            
                        })
                        .Where<Charges>((i) => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false                        
                        && i.PatientCaseId == patientCaseId && i.CPTCode == "90791").OrderByDescending(i => i.BillFromDate).Take(1);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);
            
            return result;
        }

        public async Task<IEnumerable<ICharges>> GetForChargeReference(int invoiceId)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id && c.IsDeleted == false)
                        .SelectDistinct<Invoice, Charges>((i, c) => new
                        {
                            c,
                            AccessionNumber = i.AccessionNumber,
                            FeeAmount=i.FeeAmount
                        })
                        .Where<Charges>((i) => i.InvoiceId == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<bool> ChangeDueBy(Guid invoiceUId, Guid chargeUId, string dueBy, Guid patientCaseUId, DateTime billFromDate)
        {
            try
            {
                int insuranceLevel = -1;

                if (dueBy.ToLower() == Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Primary).ToLower())
                {
                    insuranceLevel = 1;
                }
                else if (dueBy.ToLower() == Enum.GetName(typeof(InsuranceLevel), InsuranceLevel.Secondary).ToLower())
                {
                    insuranceLevel = 2;
                }

                int patientCaseId = 0;
                var patientCase = await this._patientCaseRepository.GetByUId(patientCaseUId);
                if (patientCase != null)
                {
                    patientCaseId = patientCase.Id;
                }
                var errors = await CheckPatientInsuranceExists(patientCaseId, billFromDate, insuranceLevel, dueBy);
                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }
                if (chargeUId != Guid.Empty)
                {
                    var getChargeData = await this.GetByUId(chargeUId);
                    if (getChargeData != null)
                    {
                        getChargeData.BillToInsurance = dueBy.ToUpper() != "PATIENT" ? true : false;
                        getChargeData.BillToPatient = dueBy.ToUpper() == "PATIENT" ? true : false;
                        getChargeData.DueByFlagCD = dueBy;
                        await this.Update(getChargeData);
                    }
                }
                else if (invoiceUId != Guid.Empty)
                {

                    List<Charges> lstCharges = new List<Charges>();
                    var charges = await GetChargesByInvoice(invoiceUId);
                    if (charges.Count() > 0)
                    {
                        foreach (var charge in charges)
                        {
                            Charges entity = (charge as Charges);
                            entity.DueByFlagCD = dueBy;
                            entity.BillToInsurance = dueBy.ToUpper() != "PATIENT" ? true : false;
                            entity.BillToPatient = dueBy.ToUpper() == "PATIENT" ? true : false;
                            lstCharges.Add(entity);
                        }
                        await this.Connection.UpdateAllAsync(lstCharges);
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IEnumerable<ICharges> entities)
        {
            try
            {
                List<Charges> tEntity = entities as List<Charges>;
                int[] ids = tEntity.Select(i => i.Id).ToArray();

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.DueByFlagCD
                                           })
                                           .Where(i => ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);

                return await this.Connection.UpdateAllAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IValidationResult>> CheckPatientInsuranceExists(int patientCaseId, DateTime dateOfService, int insuranceLevel, string dueBy)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            // apart from patient level
            if (insuranceLevel > 0)
            {
                bool insuranceExists = await _insurancePolicyRepository.CheckInsurancePolicyExists(patientCaseId, dateOfService, insuranceLevel);

                if (!insuranceExists)
                {
                    errors.Add(new ValidationCodeResult("Patient does not have " + dueBy.ToLower() + " insurance policy"));
                }
            }
            return errors;
        }

        private async Task<IEnumerable<ICharges>> GetChargesByInvoice(Guid invoiceUId)
        {
            int invoiceId = 0;
            var invoice = await this._invoiceRepository.GetByUId(invoiceUId);
            if (invoice != null)
            {
                invoiceId = invoice.Id;
            }
            return (await this.Connection.SelectAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.InvoiceId == invoiceId && !i.IsDeleted));
        }


        public async Task<bool> RunChargeScrub(int invoiceId)
        {
            try
            {
                await this.CallScrubEngine(invoiceId);

                var chargeScrubErrors = await this._chargeScrubRepository.GetAll();
                foreach (var item in chargeScrubErrors)
                {
                    var entity = await GetById(item.ChargeId);
                    entity.ScrubError = true;
                    // updating ScrubError status in charge entity
                    await UpdateScrubError(entity);
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> CallScrubEngine(int invoiceId)
        {
            try
            {
                var client = new RestClient();
                client.BaseUrl = new Uri(scrubURL + "api");
                var practiceData = await this._practiceRepository.Get();
                var request = new RestRequest($"Validate/runChargeScrub?invoiceId={invoiceId}&practiceCentralId={practiceData.PracticeCentralId}&practiceId={LoggedUser.PracticeId}");

                request.AddHeader("ContentType", "application/json");
                request.Method = Method.POST;

                request.AddJsonBody(invoiceId);

                var okResult = client.Execute(request);
                var response = new List<ScrubError>();

                if (okResult.StatusCode == HttpStatusCode.OK)
                {
                    response = JsonConvert.DeserializeObject<List<ScrubError>>(okResult.Content);
                    var result = response.Distinct();
                    await this._chargeScrubRepository.AddChargeScrubErrors(result);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private async Task<int> UpdateScrubError(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.ScrubError
                                           })
                                           .Where(i => i.Id == tEntity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePerformingProviderIdForNineSeries(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.PerformingProviderId,
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

        public async Task<DataTable> GetExcelForPatientDetailInsuranceAging(DateTime fromDate, Guid insCompanyUId)
        {
            try
            {
                int insCompanyId = -1;
                var insurance = await _insuranceCompanyRepository.GetByUId(insCompanyUId);
                if (insurance != null)
                {
                    insCompanyId = insurance.Id;
                }
                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "rpt_Aging_Patient_Detail_By_InsuranceCompany";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.AddParam("ToDate", fromDate, ParameterDirection.Input, DbType.DateTime);
                cmd.AddParam("InsuranceCompanyId", insCompanyId, ParameterDirection.Input, DbType.Int32);

                con.Open();
                var data = this.ExecuteDataSet(cmd);

                con.Close();
                cmd.Dispose();

                return data.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<DataTable> GetExcelForPostingPayments(IReportParameterDTO parameterObject)
        {
            try
            {   

                var parentData = await this._reportRepository.GetById(Convert.ToInt64(parameterObject.ReportId));

                List<Guid> guidIds = new List<Guid>();
                if (parameterObject.InsuranceCompanyId != null && parameterObject.InsuranceCompanyId != "")
                {
                    var getCompanyIds = parameterObject.InsuranceCompanyId.Split(',');
                    getCompanyIds.ToList().ForEach((res) =>
                    {
                        guidIds.Add(new Guid(res));
                    });

                    var companyData = await this._insuranceCompanyRepository.GetByUId(guidIds);
                    parameterObject.InsuranceCompanyId = string.Join(",", companyData.Select(i => i.Id));
                    parameterObject.CompanyName = companyData.Where(i => i.Id == companyData.FirstOrDefault().Id).FirstOrDefault().CompanyName;
                }
                if (parameterObject.FacilityUId != null && parameterObject.FacilityUId != "")
                {
                    var getFacilityIds = parameterObject.FacilityUId.Split(',');
                    getFacilityIds.ToList().ForEach((res) =>
                    {
                        guidIds.Add(new Guid(res));
                    });

                    var facilityData = await this._facilityRepository.GetByUId(guidIds);
                    parameterObject.FacilityId = facilityData.FirstOrDefault().Id; 
                }

                if (parameterObject.ProviderID != null && parameterObject.ProviderID != "")
                {
                    guidIds = new List<Guid>();

                    var getProviderIDs = parameterObject.ProviderID.Split(',');
                    getProviderIDs.ToList().ForEach((res) =>
                    {
                        guidIds.Add(new Guid(res));
                    });

                    var getProviderData = await this._providerRepository.GetByUId(guidIds);
                    parameterObject.ProviderID = string.Join(",", getProviderData.Select(i => i.Id));
                }


                string jsonString = JsonConvert.SerializeObject(parameterObject);
                var parameterData = ObjectConvertor<object>.JsonStringToDataTable(jsonString);

                var queryString = ParseParameter.ParseReport(parentData.Command, parameterData.Rows[0]);
                queryString = queryString.Replace("'null'", "null");
                queryString = queryString + ",1";
                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = queryString;
                con.Open();
                var data = this.ExecuteDataSet(cmd);

                con.Close();
                cmd.Dispose();

                return data.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (var sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(ds);
            }

            return ds;
        }

        public async Task<int> UpdateWithShiftDate(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;

                if (tEntity.AllowedAmount.HasValue && tEntity.AllowedAmount.Value > 0)
                {

                }
                else
                {
                    var getChargeData = await this.Connection.SingleAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.Id == tEntity.Id);
                    tEntity.AllowedAmount = getChargeData.AllowedAmount;
                }

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.DueByFlagCD,
                                               x.CoIns,
                                               x.CoPay,
                                               x.Deductible,
                                               x.AllowedAmount,
                                               x.IsDeleted,
                                               x.BillToInsurance,
                                               x.BillToPatient,
                                               x.BonusAmount,
                                               x.ModifiedDate,
                                               x.ModifiedBy,
                                               x.ShiftDate
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateAllowedAmount(ICharges entity)
        {
            try
            {

                Charges tEntity = entity as Charges;

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.AllowedAmount,
                                               x.ModifiedDate,
                                               x.ModifiedBy

                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInvoice>> GetDataForSecondaryClaims()
        {
            var query = this.Connection.From<ChargeViewDTO>()
                        .LeftJoin<ChargeViewDTO,Claim>((c, f) => c.ClaimId == f.Id)                        
                        .Select<ChargeViewDTO, Claim>((i, j) => new
                        {
                            UId = i.InvoiceUId,
                            Id = i.InvoiceId,
                            PatientCaseId = i.PatientCaseId,
                            BillFromDate = i.BillFromDate,
                            AccessionNumber = i.AccessionNumber,
                            i.InvoiceUId,
                            PrimaryPayerCode=j.InsuranceCompanyCode

                        })
                        .Where<ChargeViewDTO, Claim>((i, j) => i.DueByFlagCD.ToLower() == "secondary" 
                        && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false 
                        && i.DueAmount > 0 && j.InsLevel==1);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Invoice>.MapList(queryResult);

            return result;


            //var query = this.Connection.From<Claim>()
            //            .RightJoin<Claim, Invoice>((c, f) => c.InvoiceId == f.Id && c.InsLevel==2)
            //            .LeftJoin<Invoice, ChargeViewDTO>((i, c) => c.InvoiceId == i.Id)
            //            .Select<Invoice,Claim>((i,j) => new
            //            {
            //                UId=i.UId,
            //                Id=j.Id,
            //                PatientCaseId=i.PatientCaseId,
            //                BillFromDate=i.BillFromDate,
            //                AccessionNumber=i.AccessionNumber

            //            })
            //            .Where<ChargeViewDTO, Claim>((i,j) => i.DueByFlagCD== "Secondary" && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.DueAmount>0);

            //var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            //var result = Mapper<Invoice>.MapList(queryResult);

            //return result.Where(i => i.Id == 0);
            //List<Invoice> lst=new List<Invoice>();

            //foreach (var invoice in result.Where(i=>i.Id==0))
            //{
            //    var hasBalance = await this.GetInvoiceBalanceByUid(invoice.UId);
            //    if (!hasBalance)
            //    {
            //        continue;
            //    }
            //    var companyType = await this._insurancePolicyRepository.GetCompanyType(invoice.PatientCaseId, invoice.BillFromDate);
            //    if (companyType.ToLower() == "medicare")
            //    {
            //        continue;
            //    }

            //    lst.Add(invoice);
            //}

            //return lst;
        }

        public async Task<bool> GetInvoiceBalance(int invoiceId)
        {
            var result = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.InvoiceId == invoiceId && i.DueByFlagCD== "Secondary" && i.IsDeleted==false);
            if(result.Sum(i=>i.DueAmount)>0)
            {
                return true;
            }
            return false;
        }

        private async Task<bool> GetInvoiceBalanceByUid(Guid uid)
        {
            var invoice = await this.Connection.SingleAsync<Invoice>(i => i.UId==uid && i.IsDeleted == false);

            var result = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.InvoiceId == invoice.Id && i.DueByFlagCD == "Secondary" && i.IsDeleted == false);
            if (result.Sum(i => i.DueAmount) > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<ICharges>> GetChargesForBulkAdjustments(List<Guid> invoiceUids)
        {
            var query = await this.GetChargesByInvoiceGUIds(invoiceUids);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();

            return resultCharges;

        }

        public async Task<IEnumerable<ICharges>> GetChargesForBulkAdjustmentsByChargeIds(List<int> chargeIds)
        {
            var query = await this.GetChargesByChargeIds(chargeIds);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();

            return resultCharges;

        }

        public async Task<IEnumerable<ICharges>> GetChargesForBulkAdjustmentsNew(List<Guid> invoiceUids)
        {
            var query = await this.GetChargesByInvoiceGUIdsForBulkAdjustment(invoiceUids);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();

            return resultCharges;

        }

        public async Task<ICharges> GetChargeByDosAndCptCode(int patientCaseId,string cptcode, DateTime dosDate)
        {
            var charges = await this.Connection.SelectAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.CPTCode == cptcode && i.PatientCaseId == patientCaseId);
            var item = charges.FirstOrDefault(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.CPTCode == cptcode && i.PatientCaseId == patientCaseId && i.BillFromDate.Day == dosDate.Day && i.BillFromDate.Month == dosDate.Month && i.BillFromDate.Year == dosDate.Year);
            return item;

        }

        public async Task<ICharges> GetChargeByDosAndCptCodeAndProvider(int patientCaseId, string cptcode, DateTime dosDate,int performingProviderId)
        {
            var charges = await this.Connection.SelectAsync<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.PerformingProviderId== performingProviderId && i.IsDeleted == false && i.CPTCode == cptcode && i.PatientCaseId == patientCaseId);
            var item = charges.FirstOrDefault(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.CPTCode == cptcode && i.PatientCaseId == patientCaseId && i.BillFromDate.Day == dosDate.Day && i.BillFromDate.Month == dosDate.Month && i.BillFromDate.Year == dosDate.Year);
            return item;
        }

        public async Task<bool> UploadExcelForReportDataForCatalystAllChargesToSFTP()
        {
            try
            {
                //string folderPath = _configuration.GetValue<string>("tempFolder");
                var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _catalystSftpForExcel);
                if(! Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var dt = await this.GetExcelForReportDataForCatalystAllCharges();
                if (dt.Rows.Count > 0)
                {
                    var appSettings = await this._appSettingRepository.GetAppSettingServicesAuthenticationConfig();
                    if (appSettings.Count() > 0)
                    {
                        var talbotCatalystSFTPHost = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPHost");
                        var talbotCatalystSFTPUserName = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPUserName");
                        var talbotCatalystSFTPPassword = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPPassword");
                        var talbotCatalystSFTPFolderPath = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPFolderPath");
                        if (talbotCatalystSFTPHost != null && talbotCatalystSFTPUserName != null && talbotCatalystSFTPPassword != null)
                        {

                            var practiceData = await this._practiceRepository.Get();

                            byte[] fileBytes = ExcelExportHelper.DownloadExcel(dt, "Charges");
                            string fileName = practiceData.PracticeCodeCLM +"_Clinic_" + DateTime.Now.ToString("MMddyyyy") + ".xlsx";                            
                            await FileOperations.CreateFileFromBytes(fileBytes, folderPath, fileName);
                            var file = Path.Combine(folderPath, fileName);
                            using (SftpClient sftpClient = new SftpClient(new SftpConnection(talbotCatalystSFTPHost.SettingValue, 22, talbotCatalystSFTPUserName.SettingValue, talbotCatalystSFTPPassword.SettingValue)))
                            {
                                sftpClient.Connect();
                                using (FileStream fs = new FileStream(file, FileMode.Open))
                                {
                                    string filePath = talbotCatalystSFTPFolderPath.SettingValue + "\\"+Path.GetFileName(file);
                                    await sftpClient.UploadFileAsync(fs, filePath);
                                }
                                sftpClient.Dispose();
                            }
                            if (File.Exists(file))
                            {
                                File.Delete(file);
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UploadExcelForActionNoteDataDataForCatalystAllChargesToSFTP()
        {
            try
            {
                //string folderPath = _configuration.GetValue<string>("tempFolder");
                var folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _catalystSftpForExcel);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                var dt = await this.GetExcelForReportDataForCatalystAllNotes();
                if (dt.Rows.Count > 0)
                {
                    var appSettings = await this._appSettingRepository.GetAppSettingServicesAuthenticationConfig();
                    if (appSettings.Count() > 0)
                    {
                        var talbotCatalystSFTPHost = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPHost");
                        var talbotCatalystSFTPUserName = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPUserName");
                        var talbotCatalystSFTPPassword = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPPassword");
                        var talbotCatalystSFTPFolderPath = appSettings.FirstOrDefault(i => i.SettingCD == "TalbotCatalystSFTPFolderPath");
                        if (talbotCatalystSFTPHost != null && talbotCatalystSFTPUserName != null && talbotCatalystSFTPPassword != null)
                        {

                            var practiceData = await this._practiceRepository.Get();

                            byte[] fileBytes = ExcelExportHelper.DownloadExcel(dt, "Charges");
                            string fileName = "All_Practices_ChargeNotes" + DateTime.Now.ToString("MMddyyyy") + ".xlsx";
                            await FileOperations.CreateFileFromBytes(fileBytes, folderPath, fileName);
                            var file = Path.Combine(folderPath, fileName);
                            using (SftpClient sftpClient = new SftpClient(new SftpConnection(talbotCatalystSFTPHost.SettingValue, 22, talbotCatalystSFTPUserName.SettingValue, talbotCatalystSFTPPassword.SettingValue)))
                            {
                                sftpClient.Connect();
                                using (FileStream fs = new FileStream(file, FileMode.Open))
                                {
                                    string filePath = talbotCatalystSFTPFolderPath.SettingValue + "\\" + Path.GetFileName(file);
                                    await sftpClient.UploadFileAsync(fs, filePath);
                                }
                                sftpClient.Dispose();
                            }
                            if (File.Exists(file))
                            {
                                File.Delete(file);
                            }
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<DataTable> GetExcelForReportDataForCatalystAllCharges()
        {
            try
            {                
                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "USP_ReportDataForCatalystAllCharges";
                cmd.CommandType = CommandType.StoredProcedure;                

                con.Open();
                var data = this.ExecuteDataSet(cmd);

                con.Close();
                cmd.Dispose();

                return data.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<DataTable> GetExcelForReportDataForCatalystAllNotes()
        {
            try
            {
                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "usp_GetActionNotesForCatalyst";
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                var data = this.ExecuteDataSet(cmd);

                con.Close();
                cmd.Dispose();

                return data.Tables[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetChargesByPatientId(long patientId)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()                                                        
                            .LeftJoin<ChargeViewDTO, PatientCase>((x, pc) => x.PatientCaseId == pc.Id)
                            .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                            .LeftJoin<ChargeViewDTO, Provider>((cv, pr) => cv.PerformingProviderId == pr.Id)
                            .SelectDistinct<ChargeViewDTO, Patient, Provider>((x, p, pr) => new
                            {          
                                x.AccessionNumber,
                                x.BillFromDate,                                
                                x.Id,
                                x.Amount,                                
                                x.CPTCode,
                                p.FirstName,
                                p.LastName,
                                PerformingPhysicianFirstName = pr.FirstName,
                                PerformingPhysicianLastName = pr.LastName,
                                x.DueAmount                                ,
                                x.DueByFlagCD
                            })
                 .Where<ChargeViewDTO, PatientCase>((i, pc) => i.PracticeId == LoggedUser.PracticeId && pc.PatientId == patientId && i.IsDeleted == false);
                //.Where<ChargeViewDTO, PatientCase>((i, pc) => i.PracticeId == LoggedUser.PracticeId && pc.PatientId == patientId && i.IsDeleted == false && i.DueByFlagCD.ToLower() == "primary");                

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result.Where(i=>i.DueAmount>0).OrderByDescending(i=>i.BillFromDate);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IBalanceCharge>> GetChargesForAdjustment(int patientCaseId)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                            .Join<ChargeViewDTO, Invoice>((x, y) => x.InvoiceId == y.Id)                            
                            .SelectDistinct<ChargeViewDTO, Invoice>((x, y) => new
                            {
                                x.AccessionNumber,
                                x.BillFromDate,
                                x.Id,
                                x.Amount,
                                x.CPTCode,                                
                                x.DueAmount,
                                x.UId,
                                InvoiceUId = y.UId
                            })
                            .Where<ChargeViewDTO, Invoice>((i, j) => i.PatientCaseId == patientCaseId && i.IsDeleted == false && i.DueAmount > 0);
            //.Where<ChargeViewDTO,Invoice>((i,j) => i.PatientCaseId == patientCaseId && i.IsDeleted == false && j.IsBillable == true && i.DueAmount > 0);
            //.Where<ChargeViewDTO, PatientCase>((i, pc) => i.PracticeId == LoggedUser.PracticeId && pc.PatientId == patientId && i.IsDeleted == false && i.DueByFlagCD.ToLower() == "primary");                

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ChargeViewDTO>.MapList(queryResult);


            //var result = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.PatientCaseId == patientCaseId && i.IsDeleted == false && i.IsBillable == true && i.DueAmount > 0);
            List<BalanceCharge> balanceCharges = new List<BalanceCharge>();

            foreach (var item in result)
            {
                BalanceCharge balanceCharge = new BalanceCharge();
                balanceCharge.Id = item.Id;
                balanceCharge.AccessionNumber = item.AccessionNumber;
                balanceCharge.Amount = item.Amount;
                balanceCharge.CptCode = item.CPTCode;
                balanceCharge.Dos = item.BillFromDate;
                balanceCharge.DueAmount = item.DueAmount;
                balanceCharge.ChargeUId = item.UId.ToString();
                balanceCharge.InvoiceUId = item.InvoiceUId.ToString();
                balanceCharges.Add(balanceCharge);
            }

            return balanceCharges;
        }
        public async Task Throw90834ChargeError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.CPT90834Validation]));
        }

        public async Task ThrowJCodeError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.JCodeError]));
        }

        public async Task ThrowRecurringError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.RecurringError]));
        }

        public async Task<IChargesDueAmountForEMR> GetDueChargesForEMR(int patientCaseId,Guid patientCaseUId)
        {
            List<string> dueBy = new List<string>() { "", "patient" };

            var list = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.PatientCaseId == patientCaseId  && i.IsDeleted == false);

            ChargesDueAmountForEMR chargesDueAmountForEMR = new ChargesDueAmountForEMR();
            chargesDueAmountForEMR.DueByInsurance = list.Where(i => !dueBy.Contains(i.DueByFlagCD.ToLower())).Sum(i=>i.DueAmount);
            var dueByPatientList = list.Where(i => dueBy.Contains(i.DueByFlagCD.ToLower()));

            var policies = await this._insurancePolicyRepository.GetByPatientCaseUIds(patientCaseUId.ToString());
            List<ChargeViewDTO> nonMedicaidChargesList = new List<ChargeViewDTO>();
            List<ChargeViewDTO> medicaidChargesList = new List<ChargeViewDTO>();

            foreach (var item in dueByPatientList)
            {
                var findMedicaid = policies.FirstOrDefault(i => i.PlanEffectiveDate <= item.BillFromDate.Date && 
                ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= item.BillFromDate.Date))
                    && i.InsuranceCompanyTypeId == 4);

                if (findMedicaid != null)
                {
                    medicaidChargesList.Add(item);
                }
                else
                {
                    nonMedicaidChargesList.Add(item);
                }
            }

            chargesDueAmountForEMR.DueByPatient = nonMedicaidChargesList.Sum(i => i.DueAmount);
            chargesDueAmountForEMR.DueByMedicaidPatient = medicaidChargesList.Sum(i => i.DueAmount);

            return chargesDueAmountForEMR;

        }

        public async Task<IEnumerable<ICharges>> GetChargesForRefreshFeeAmountWhilePolicySyncing(int patientCaseId)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                .Join<ChargeViewDTO, Invoice>((c, inv) => c.InvoiceId== inv.Id, NoLockTableHint.NoLock)
                .Join<ChargeViewDTO, Provider>((c, pr) => c.PerformingProviderId == pr.Id, NoLockTableHint.NoLock)
                         .SelectDistinct<ChargeViewDTO, Provider>((cv, pr) => new
                         {        
                             cv.UId,
                             cv.BillFromDate,                             
                             cv.PatientCaseId,
                             cv.CPTCode,
                             cv.Mod1,
                             cv.Mod2,
                             cv.Mod3,
                             cv.Mod4,
                             PerformingProviderUId=pr.UId,
                             cv.Amount,
                             cv.Qty,
                             cv.InvoiceId,
                             cv.DueAmount,
                             cv.DueByFlagCD
                         })
                         .Where<ChargeViewDTO, Invoice>((c,inv) => c.PatientCaseId == patientCaseId && c.DueAmount==c.Amount && !inv.ClaimId.HasValue);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);
            return result;
        }


        public async Task<IEnumerable<ICharges>> GetChargesForUpdateFeeAmount(List<int> ids)
        {
            var query = this.Connection.From<ChargeViewDTO>()
                .Join<ChargeViewDTO, Invoice>((c, inv) => c.InvoiceId == inv.Id, NoLockTableHint.NoLock)
                .Join<ChargeViewDTO, Provider>((c, pr) => c.PerformingProviderId == pr.Id, NoLockTableHint.NoLock)
                         .SelectDistinct<ChargeViewDTO, Provider>((cv, pr) => new
                         {
                             cv.UId,
                             cv.BillFromDate,
                             cv.PatientCaseId,
                             cv.CPTCode,
                             cv.Mod1,
                             cv.Mod2,
                             cv.Mod3,
                             cv.Mod4,
                             PerformingProviderUId = pr.UId,
                             cv.Amount,
                             cv.Qty
                         })
                         .Where<ChargeViewDTO>(c=> ids.Contains(c.Id));


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);
            return result;
        }
        public async Task<int> UpdateAmountWhilePolicySyncing(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.Amount,
                                               x.ModifiedDate,
                                               x.ModifiedBy

                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdatePatientStatementCount(IEnumerable<ICharges> list)
        {

            foreach (var item in list)
            {
                Charges tEntity = item as Charges;
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.PatientStatementCount

                                           })
                                           .Where(i => i.Id == tEntity.Id );

                 await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }

            return true;
        }

        public async Task<bool> UpdateIsRolledUpNotifyToEMR(IEnumerable<IRolledUpEncounterDTO> list)
        {

            foreach (var item in list)
            {
                var query = this.Connection.From<Charges>()                         
                         .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id)                         
                         .Select<Charges>(c => new
                         {
                             c
                         })
                         .Where<Invoice>(i =>i.AccessionNumber==item.RolledUpEncounter);


                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<Charges>.MapList(queryResult);

                foreach (var item1 in result)
                {
                    Charges tEntity = item1 as Charges;
                    tEntity.IsRolledUpNotifyToEMR = true;
                    tEntity.RolledUpNotifyToEMRDateTime = DateTime.Now;
                    var updateOnlyFields = this.Connection
                                               .From<Charges>()
                                               .Update(x => new
                                               {
                                                   x.IsRolledUpNotifyToEMR,
                                                   x.RolledUpNotifyToEMRDateTime

                                               })
                                               .Where(i => i.Id == tEntity.Id);

                    await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }
            }

            return true;
        }

        public async Task<IEnumerable<IRolledUpEncounterDTO>> GetLockedCharges()
        {

            var query = this.Connection.From<ChargeViewDTO>()
                         .Join<ChargeViewDTO, Charges>((c, rc) => c.Id == rc.RefChargeId, NoLockTableHint.NoLock)
                         .LeftJoin<Charges, Invoice>((c, i) => c.InvoiceId == i.Id, this.Connection.JoinAlias("RolledUp"))
                         .LeftJoin<ChargeViewDTO, Invoice>((c, i) => c.InvoiceId == i.Id, this.Connection.JoinAlias("Actual"))
                         .SelectDistinct<ChargeViewDTO,Invoice>((c, inv) => new
                         {
                             RolledUpEncounter = Sql.JoinAlias(inv.AccessionNumber, "RolledUp"),
                             ActualEncounter = Sql.JoinAlias(inv.AccessionNumber, "Actual"),
                             
                         })
                         .Where<Charges>(c=> c.PracticeId == LoggedUser.PracticeId                         
                         && c.IsLocked==true && (c.IsRolledUpNotifyToEMR ==null || c.IsRolledUpNotifyToEMR==false)).Take(200);           


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<RolledUpEncounterDTO>.MapList(queryResult);
            return result;
        }

        public async Task<bool> Check7DayLogic(int invoiceId)
        {

            var charges = await this.GetByInvoiceIdFor7DayLogic(invoiceId);
            var dosDate = charges.FirstOrDefault().BillFromDate;

            dosDate = new DateTime(dosDate.Year, dosDate.Month, dosDate.Day);

            var sevendayBackDate = dosDate.AddDays(-6);
            int patientCaseId = charges.FirstOrDefault().PatientCaseId;
            
            foreach (var charge in charges)
            {
                List<Charges> lst = new List<Charges>();
                if (charge.CPTCode == "H0048")
                {
                    lst = await this.Connection.SelectAsync<Charges>(i => i.PatientCaseId == patientCaseId && i.IsDeleted == false
                             && i.CPTCode == charge.CPTCode && i.PracticeId == LoggedUser.PracticeId && i.Id != charge.Id);

                    var record = lst.OrderByDescending(i => i.BillFromDate).FirstOrDefault(i => i.BillFromDate.Date >= sevendayBackDate && i.BillFromDate.Date <= dosDate && i.Amount>0);
                    if (record != null && record.Amount > 0)
                    {
                        await this.UpdateIsRecurring(charge);
                    }
                }
            }
            return true;
        }

        public async Task<int> Check14CountLogicForH0015(int invoiceId)
        {

            var charges = await this.GetByInvoiceIdFor7DayLogic(invoiceId);
            int patientCaseId = charges.FirstOrDefault().PatientCaseId;

            List<Charges> lst = new List<Charges>();
            foreach (var charge in charges)
            {
                var dosDate = new DateTime(charge.BillFromDate.Year, charge.BillFromDate.Month, 1);

                if (charge.CPTCode == "H0015")
                {
                    lst = await this.Connection.SelectAsync<Charges>(i => i.PatientCaseId == patientCaseId && i.IsDeleted == false && 
                    (i.BillFromDate>= dosDate  && i.BillFromDate <= dosDate.AddMonths(1).AddDays(-1)) && i.CPTCode == charge.CPTCode && i.PracticeId == LoggedUser.PracticeId && i.Id != charge.Id);
                }
            }
            return lst.Count;
        }

        public async Task<IEnumerable<ICharges>> GetByInvoiceId(int invoiceId)
        {
            var query = this.Connection.From<Charges>()
                        .Select<Charges>((c) => new
                        {
                            c.Id,
                            c.BillToInsurance,
                            c.UId,
                            c.Amount,
                            c.CPTCode,
                            c.BillFromDate,
                            c.PatientCaseId,
                            c.IsRecurring
                        })
                        .Where<Charges>((i) => i.InvoiceId == invoiceId
                                        && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IEnumerable<ICharges>> GetByInvoiceIdFor7DayLogic(int invoiceId)
        {
            var query = this.Connection.From<Charges>()
                        .Select<Charges>((c) => new
                        {
                            c.Id,
                            c.BillToInsurance,
                            c.UId,
                            c.Amount,
                            c.CPTCode,
                            c.BillFromDate,
                            c.PatientCaseId,
                            c.IsRecurring
                        })
                        .Where<Charges>((i) => i.InvoiceId == invoiceId
                                        && i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        private async Task<int> UpdateIsRecurring(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;
                tEntity.IsRecurring = true;
                tEntity.Amount = 0;
                tEntity.Comments = "CPT code came again in between 7 days";
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.IsRecurring,
                                               x.Comments,
                                               x.Amount,
                                               x.ModifiedDate,
                                               x.ModifiedBy

                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateDueByWhilePolicySyncing(ICharges entity)
        {
            try
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedBy = this.LoggedUser.UserName;

                Charges tEntity = entity as Charges;
                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.DueByFlagCD,
                                               x.BillToInsurance,
                                               x.BillToPatient,
                                               x.ModifiedBy,
                                               x.ModifiedDate

                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDueByFromSelfRatherThan(int invoiceId)
        {
            var list = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.InvoiceId == invoiceId && i.IsDeleted == false && i.PaidAmount==0);
            foreach (var item in list)
            {
                Charges charge = new Charges();
                charge.UId = item.UId;
                charge.BillToInsurance = true;
                charge.BillToPatient = false;
                charge.DueByFlagCD = "Primary";
                await this.UpdateDueByWhilePolicySyncing(charge);
            }
        }

        public async Task UpdateDueByFromSelfRatherThan_UNDO(int invoiceId)
        {
            var list = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.InvoiceId == invoiceId && i.IsDeleted == false && i.PaidAmount == 0);
            foreach (var item in list)
            {
                Charges charge = new Charges();
                charge.BillToInsurance = false;
                charge.BillToPatient = true;
                charge.DueByFlagCD = "Patient";
                charge.UId = item.UId;
                await this.UpdateDueByWhilePolicySyncing(charge);
            }
        }

        public async Task<int> UpdateFromAI(ICharges entity)
        {
            try
            {
                Charges tEntity = entity as Charges;                

                var updateOnlyFields = this.Connection
                                           .From<Charges>()
                                           .Update(x => new
                                           {
                                               x.NDCCode,
                                               x.NDCFormat,
                                               x.ICD1,
                                               x.ICD2,
                                               x.ICD3,
                                               x.ICD4,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }
    }
}
