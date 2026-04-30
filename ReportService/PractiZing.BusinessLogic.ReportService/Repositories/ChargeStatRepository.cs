using AutoMapper;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.DataAccess.ReportService;
using PractiZing.DataAccess.ReportService.Objects;
using PractiZing.DataAccess.ReportService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class ChargeStatRepository : ModuleBaseRepository<ChargeStat>, IChargeStatRepository
    {
        private readonly IMapper _mapper;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IConfigInsuranceCompanyTypeRepository _insuranceCompanyTypeRepository;
        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IPaymentChargeRepository _paymentChargeRepository;
        private IDenialQueueRepository _denialQueueRepository;
        private IVoucherRepository _voucherRepository;
        private IActionNoteRepository _actionNoteRepository;
        private IInsurancePolicyRepository _insurancePolicyRepository;
        public ChargeStatRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser, IMapper mapper,
                                           IConfigInsuranceCompanyTypeRepository insuranceCompanyTypeRepository,
                                           IInsuranceCompanyRepository insuranceCompanyRepository,
                                           IDenialQueueRepository denialQueueRepository,
                                           IVoucherRepository voucherRepository,
                                           IPaymentChargeRepository paymentChargeRepository,
                                           IActionNoteRepository actionNoteRepository,
                                           IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                           IInsurancePolicyRepository insurancePolicyRepository
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
            _mapper = mapper;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._insuranceCompanyTypeRepository = insuranceCompanyTypeRepository;
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._denialQueueRepository = denialQueueRepository;
            this._voucherRepository = voucherRepository;
            this._paymentChargeRepository = paymentChargeRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
        }

        public async Task<IDenialDashboardDTO> GetDenialDashboardData(bool? hasDenial, bool isBaseStatsRequired)
        {
            DenialDashboardDTO denialDashboardDTO = new DenialDashboardDTO();

            denialDashboardDTO.ARAging = await this.GetAgingByCharge(hasDenial);
            denialDashboardDTO.TopFollowingCategories = await this.ChargeStatByActionCategory(hasDenial);
            denialDashboardDTO.InsuranceCompanies = await this.ChargeStatByInsuranceCompany(hasDenial);
            denialDashboardDTO.TopDenialReasons = await this.ChargeStatByReasonCode(hasDenial);
            denialDashboardDTO.CarrerTypes = await this.ChargeStatByInsuranceType(hasDenial);
            if (isBaseStatsRequired)
            {
                denialDashboardDTO.DenialBaseStatistics = await this.DenialDashboardBaseStatistics(true);
            }

            return denialDashboardDTO;
        }

        public async Task<IDenialQueueDTO> GetDenialData(IChargeStatFilter chargeStatFilter)
        {
            IDenialQueueDTO denialQueueDTO = new DenialQueueDTO();
            denialQueueDTO.DenialStatDTO = await this.GetDenialDataForFilters(chargeStatFilter);
            var chargeIds = denialQueueDTO.DenialStatDTO.Select(i => i.ChargeId).ToList();
            denialQueueDTO.AssignedFollowUpDTO = await _denialQueueRepository.GetAssignedFollowUpCount(chargeIds);
            return denialQueueDTO;
        }

        public async Task<IEnumerable<IDenialStatDTO>> GetDenialDataForFilters(IChargeStatFilter chargeStatFilter)
        {
            try
            {
                var query = await Query();

                string whereQuery = "";

                if (!string.IsNullOrEmpty(chargeStatFilter.ReasonCodes))
                {
                    var chargeIds = await this._paymentChargeRepository.GetChargeIdsByReasonCodes(chargeStatFilter.ReasonCodes);
                    //query = query.Where(i => chargeIds.Contains(i.Id));
                    if (chargeIds.Count() > 0)
                        whereQuery += " AND vw_GetChargeForPendingPayment.Id  In (" + string.Join(',', chargeIds) + ")";
                }

                if (!string.IsNullOrEmpty(chargeStatFilter.FollowCategoryUIds))
                {
                    var chargeIds = await this._actionNoteRepository.GetByCategoryUIds(chargeStatFilter.FollowCategoryUIds);
                    //query = query.Where(i => chargeIds.Contains(i.Id));
                    if (chargeIds.Count() > 0)
                    {
                        whereQuery += " AND vw_GetChargeForPendingPayment.Id  In (" + string.Join(',', chargeIds) + ")";
                    }
                }

                /*for all charges, hasDenial = null*/
                /*for insurance denials, hasDenial = true*/
                /*for patient overdue, hasDenial = false*/
                if (chargeStatFilter.HasDenial != null)
                {
                    //query = query.Where(i => i.HasDenial == chargeStatFilter.HasDenial);
                    whereQuery += " AND HasDenial  ='" + chargeStatFilter.HasDenial + "'";
                }

                query.WhereExpression = query.WhereExpression + whereQuery;
                //query.SelectExpression = query.SelectExpression + query.FromExpression + query.WhereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var tempChargeStats = Mapper<DenialStatDTO>.MapList(queryResult);
                tempChargeStats = tempChargeStats.Where(i => i.Balance > 0);
                //if (chargeStatFilter.HasDenial == false)
                //    tempChargeStats = tempChargeStats.Where(c => c.DueByFlagCD.ToLower() == "patient");

                //if (chargeStatFilter.HasDenial == true)
                //    tempChargeStats = tempChargeStats.Where(c => c.DueByFlagCD.ToLower() != "patient");

                /*filtering is according to the selected InsuranceCompanyUIds*/
                if (!string.IsNullOrEmpty(chargeStatFilter.InsuranceCompanyUIds))
                {
                    string[] splitValue = chargeStatFilter.InsuranceCompanyUIds.Split(",");
                    tempChargeStats = tempChargeStats.Where(i => splitValue.Contains(i.InsuranceCompanyUId.ToString()));
                }



                /*filtering is according to the selected InsuranceCompanyTypeIds*/
                if (!string.IsNullOrEmpty(chargeStatFilter.InsuranceCompanyTypeIds))
                {
                    string[] splitValue = chargeStatFilter.InsuranceCompanyTypeIds.Split(",");
                    tempChargeStats = tempChargeStats.Where(i => splitValue.Contains(i.InsuranceCompanyTypeId.ToString())
                                                && i.InsuranceCompanyTypeId != null /*&& i.DueByFlagCD.ToLower() != "patient"*/);
                }


                /*filtering is according to the selected date ranges and the number of times the statement has been sent to the patient*/
                if (chargeStatFilter.PatientStatementCount > 0/* && chargeStatFilter.StatNames.Count() > 0*/)
                    tempChargeStats = tempChargeStats.Where(i => i.PatientStatementSentCount >= chargeStatFilter.PatientStatementCount && i.StatName == chargeStatFilter.StatNames);// && i.DueByFlagCD.ToLower() == "patient"*/);

                var chargeStats = await this.GetStatName(tempChargeStats);

                /*filtering is according to the selected date ranges*/
                if (!(string.IsNullOrEmpty(chargeStatFilter.StatNames)))
                    chargeStats = chargeStats.Where(i => chargeStatFilter.StatNames == i.StatName /*&& i.DueByFlagCD.ToLower() != "patient"*/);

                /*for filteration according to date range*/
                if (!string.IsNullOrEmpty(chargeStatFilter.FromDate.ToString()))
                {
                    var insuranceCompanyIds = chargeStats.Where(i => i.InsuranceCompanyId != null).Select(i => i.InsuranceCompanyId.Value).Distinct().ToList();

                    var patientIds = chargeStats.Select(i => i.PatientId).Distinct().ToList();
                    var effChargeStats = await this._voucherRepository.Get(insuranceCompanyIds, patientIds);

                    chargeStatFilter.FromDate = chargeStatFilter.FromDate == null ? null : chargeStatFilter.FromDate;
                    chargeStatFilter.ToDate = chargeStatFilter.ToDate == null ? DateTime.Now : chargeStatFilter.ToDate.Value;

                    if (effChargeStats.Count() > 0)
                    {
                        effChargeStats = effChargeStats.Where(i => (i.EffectiveDate >= chargeStatFilter.FromDate.Value.Date) &&
                                                 (i.EffectiveDate < chargeStatFilter.ToDate.Value.AddDays(1).Date)).ToList();

                        var effPatientIds = effChargeStats.Count() == 0 ? null : effChargeStats.Where(i => i.PatientId != null).Select(i => i.PatientId.Value);
                        var effCompanyIds = effChargeStats.Count() == 0 ? null : effChargeStats.Where(i => i.InsuranceCompanyId != null).Select(i => i.InsuranceCompanyId.Value);

                        if (effCompanyIds != null && effPatientIds != null)
                            chargeStats = chargeStats.Where(i => (effPatientIds.Contains(i.PatientId)) || (effCompanyIds.Contains(i.InsuranceCompanyId.Value)));
                        else
                            return
                                chargeStats = new List<DenialStatDTO>();
                    }
                }


                chargeStats = chargeStats.Where(i => i.Balance > 0).OrderBy(i => i.LastName).ThenBy(i => i.CPTCode);
                return chargeStats;
            }
            catch
            {
                throw;
            }
        }

        private async Task<SqlExpression<ChargeStat>> Query()
        {
            var query = this.Connection.From<ChargeStat>()
                            .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id, NoLockTableHint.NoLock)
                            .Join<ChargeViewDTO, Invoice>((c, i) => c.InvoiceId == i.Id, NoLockTableHint.NoLock)
                            .LeftJoin<ChargeStat, ActionNote>((cs, a) => cs.Id == a.ChargeId && a.IsNote == true, NoLockTableHint.NoLock)
                            .LeftJoin<ActionNote, ActionCategory>((a, ac) => a.ActionCategoryId == ac.Id, NoLockTableHint.NoLock)
                            .LeftJoin<ChargeViewDTO, DenialQueue>((c, d) => c.Id == d.ChargeId, NoLockTableHint.NoLock)
                            .LeftJoin<ChargeViewDTO, PaymentCharge>((c, p) => c.Id == p.ChargeId, NoLockTableHint.NoLock)
                            .LeftJoin<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId, NoLockTableHint.NoLock)
                            .LeftJoin<ChargeStat, InsuranceCompany>((cs, i) => cs.InsuranceCompanyId == i.Id/* && cs.InsuranceCompanyId != null*/ , NoLockTableHint.NoLock)
                            .LeftJoin<InsuranceCompany, ConfigInsuranceCompanyType>((cs, ci) => cs.CompanyTypeId == ci.Id, NoLockTableHint.NoLock)
                            //.LeftJoin<InsuranceCompany, Voucher>((ic, v) => ic.Id == v.InsuranceCompanyId)
                            .Join<ChargeViewDTO, PatientCase>((c, pc) => c.PatientCaseId == pc.Id, NoLockTableHint.NoLock)
                            .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id, NoLockTableHint.NoLock)
                            //.LeftJoin<Patient, Voucher>((p, v) => v.PatientId == p.Id)
                            .LeftJoin<Invoice, ReferringDoctor>((c, p) => c.RefDoctorId == p.Id, NoLockTableHint.NoLock)
                            .LeftJoin<ChargeViewDTO, Provider>((cv, pr) => cv.PerformingProviderId == pr.Id, NoLockTableHint.NoLock)
                            .SelectDistinct<ChargeStat, ChargeViewDTO, Patient, ConfigInsuranceCompanyType, Invoice, /*PaymentAdjustment,*/ InsuranceCompany>((cs, c, p, ict, i, /*pa,*/ ic) => new
                            {

                                ChargeId = cs.Id,
                                //Modifier = c.Mod1 + c.Mod2 + c.Mod3 + c.Mod4,
                                p.FirstName,
                                p.LastName,
                                ChargeUId = c.UId,
                                AccessionNumber = i.AccessionNumber,
                                DOS = c.BillFromDate,
                                CPTCode = c.CPTCode,
                                Mod1 = c.Mod1,
                                Mod2 = c.Mod2,
                                Mod3 = c.Mod3,
                                Mod4 = c.Mod4,
                                DueByFlagCD = c.DueByFlagCD,
                                PatientCaseId = c.PatientCaseId,
                                CoPay = c.CoPay,
                                Deductible = c.Deductible,
                                TotalPaidAmount = c.TotalPaidAmount,//cs.Payments,
                                TotalAdjustment = c.TotalAdjustment,//cs.Adjustments,
                                PatientOverDue = c.CoPay + c.Deductible,
                                InsuranceCompanyName = ic.CompanyName,
                                InsuranceCompanyTypeId = ic.CompanyTypeId,
                                InsuranceCompanyId = ic.Id,
                                InsuranceCompanyUId = ic.UId,
                                InsuranceCompanyType = ict.CompanyType,
                                //ReasonCodes = pa.ReasonCode,
                                EntryDate = c.EntryDate,
                                PatientStatementSentCount = c.PatientStatementCount,
                                Charge = c.Amount,
                                Balance = Sql.As((c.Amount- ((cs.Payments ?? 0) + (cs.Adjustments ?? 0))), "Balance"),
                                PatientUId = p.UId,
                                PatientId = p.Id,
                                InvoiceId = i.Id,
                                PatientDOB = p.DOB,
                                InvoiceUId = i.UId,
                            })
                            .Where<ChargeViewDTO>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted==false);

            var selectExpression = query.SelectExpression;
            query.Select<ReferringDoctor, DenialQueue, Provider, PatientCase>((rd, dq, pr, pc) => new
            {
                // EffectiveDate = v.EffectiveDate,
                OrderingPhysicianFirstName = rd.FirstName,
                OrderingPhysicianLastName = rd.LastName,
                AssignedTo = dq.AssignedTo,
                FollowUpDate = dq.FollowUpDate,
                PerformingProviderUId = pr.UId,
                PatientCaseUId = pc.UId,
            });
            query.SelectExpression = selectExpression + " AND " + query.SelectExpression;
            query.SelectExpression = query.SelectExpression.Replace("AND SELECT", ", ");
            return query;
        }

        private async Task<IEnumerable<IDenialStatDTO>> GetStatName(IEnumerable<IDenialStatDTO> tempChargeStats)
        {
            try
            {
                var aging0_30Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays < 30);
                var aging30_60Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 30 && (DateTime.Now - i.EntryDate)?.TotalDays < 60);
                var aging60_90Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 60 && (DateTime.Now - i.EntryDate)?.TotalDays < 90);
                var aging90_120Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 90 && (DateTime.Now - i.EntryDate)?.TotalDays < 120);
                var aging120_above = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 120);

                List<IDenialStatDTO> chargeStats = new List<IDenialStatDTO>();
                aging0_30Days.ToList().ForEach(cc => cc.StatName = "0-30 Days");
                aging30_60Days.ToList().ForEach(cc => cc.StatName = "30-60 Days");
                aging60_90Days.ToList().ForEach(cc => cc.StatName = "60-90 Days");
                aging90_120Days.ToList().ForEach(cc => cc.StatName = "90-120 Days");
                aging120_above.ToList().ForEach(cc => cc.StatName = "120-above");

                chargeStats.AddRange(aging0_30Days);
                chargeStats.AddRange(aging30_60Days);
                chargeStats.AddRange(aging60_90Days);
                chargeStats.AddRange(aging90_120Days);
                chargeStats.AddRange(aging120_above);

                return chargeStats;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeStatDTO>> GetAgingByCharge(bool? hasDenial)
        {
            var query = this.Connection.From<ChargeStat>()
                                .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                .SelectDistinct<ChargeStat, ChargeViewDTO>((cs, c) => new
                                {
                                    cs,
                                    EntryDate = c.EntryDate,
                                    Amount = c.DueAmount //Sql.As((cs.Charges - ((cs.Payments ?? 0) + (cs.Adjustments ?? 0))), "Amount")
                                }).Where<ChargeViewDTO>(i => i.IsDeleted == false && i.DueAmount > 0);

            if (hasDenial.HasValue)
                query = query.Where(i => i.HasDenial == hasDenial);


            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var tempChargeStats = Mapper<ChargeStat>.MapList(queryResult);

            //tempChargeStats = tempChargeStats.Where(i => i.Amount > 0);


            //var tempChargeStats = await this.Connection.SelectAsync<ChargeViewDTO>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.DueAmount>0);


            var aging0_30Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays < 30);
            var aging30_60Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 30 && (DateTime.Now - i.EntryDate)?.TotalDays < 60);
            var aging60_90Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 60 && (DateTime.Now - i.EntryDate)?.TotalDays < 90);
            var aging90_120Days = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 90 && (DateTime.Now - i.EntryDate)?.TotalDays < 120);
            var aging120_above = tempChargeStats.Where(i => (DateTime.Now - i.EntryDate)?.TotalDays >= 120);
            List<ChargeStat> chargeStats = new List<ChargeStat>();

            aging0_30Days.ToList().ForEach(cc => cc.StatName = "0-30 Days");
            aging30_60Days.ToList().ForEach(cc => cc.StatName = "30-60 Days");
            aging60_90Days.ToList().ForEach(cc => cc.StatName = "60-90 Days");
            aging90_120Days.ToList().ForEach(cc => cc.StatName = "90-120 Days");
            aging120_above.ToList().ForEach(cc => cc.StatName = "120-above");

            chargeStats.AddRange(aging0_30Days);
            chargeStats.AddRange(aging30_60Days);
            chargeStats.AddRange(aging60_90Days);
            chargeStats.AddRange(aging90_120Days);
            chargeStats.AddRange(aging120_above);

            var result = chargeStats.GroupBy(d => d.StatName).Select(g => new ChargeStatDTO
            {
                Amount = g.Sum(s => (s.Amount)),
                StatName = g.FirstOrDefault().StatName,
                StatUId = g.FirstOrDefault().StatName,
                Count = g.Count()
            });

            List<ChargeStatDTO> chargeStatDTOs = new List<ChargeStatDTO>();
            chargeStatDTOs.AddRange(result.ToList());
            ChargeStatDTO chargeStatDTO = new ChargeStatDTO();
            chargeStatDTO.StatName = string.Empty;
            chargeStatDTO.Count = 0;
            chargeStatDTO.Amount = 0;
            chargeStatDTO.StatUId = string.Empty;
            chargeStatDTO = AddAgingInfo(result, chargeStatDTOs, chargeStatDTO);

            return chargeStatDTOs;
        }

        private static ChargeStatDTO AddAgingInfo(IEnumerable<ChargeStatDTO> result, List<ChargeStatDTO> chargeStatDTOs, ChargeStatDTO chargeStatDTO)
        {
            if (result.FirstOrDefault(i => i.StatName == "0-30 Days") == null)
            {
                chargeStatDTO = new ChargeStatDTO();
                chargeStatDTO.StatName = "0-30 Days";
                chargeStatDTO.StatUId = chargeStatDTO.StatName;
                chargeStatDTOs.Add(chargeStatDTO);
            }
            if (result.FirstOrDefault(i => i.StatName == "30-60 Days") == null)
            {
                chargeStatDTO = new ChargeStatDTO();
                chargeStatDTO.StatName = "30-60 Days";
                chargeStatDTO.StatUId = chargeStatDTO.StatName;
                chargeStatDTOs.Add(chargeStatDTO);
            }
            if (result.FirstOrDefault(i => i.StatName == "60-90 Days") == null)
            {
                chargeStatDTO = new ChargeStatDTO();
                chargeStatDTO.StatName = "60-90 Days";
                chargeStatDTO.StatUId = chargeStatDTO.StatName;
                chargeStatDTOs.Add(chargeStatDTO);
            }
            if (result.FirstOrDefault(i => i.StatName == "90-120 Days") == null)
            {
                chargeStatDTO = new ChargeStatDTO();
                chargeStatDTO.StatName = "90-120 Days";
                chargeStatDTO.StatUId = chargeStatDTO.StatName;
                chargeStatDTOs.Add(chargeStatDTO);
            }
            if (result.FirstOrDefault(i => i.StatName == "120-above") == null)
            {
                chargeStatDTO = new ChargeStatDTO();
                chargeStatDTO.StatName = "120-above";
                chargeStatDTO.StatUId = chargeStatDTO.StatName;
                chargeStatDTOs.Add(chargeStatDTO);
            }

            return chargeStatDTO;
        }

        public async Task<IEnumerable<IChargeStatDTO>> ChargeStatByInsuranceCompany(bool? hasDenial)
        {
            try
            {
                var ignoredueby = new List<string> { "Primary", "Secondary" };

                var query = this.Connection.From<ChargeStat>()
                .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                .Join<ChargeStat, InsuranceCompany>((cs, i) => cs.InsuranceCompanyId == i.Id)
                .Select<ChargeStat, ChargeViewDTO, InsuranceCompany>((cs, c, i) => new
                {
                    //cs,
                    //EntryDate = c.EntryDate,
                    //cs.Adjustments,
                    //cs.Payments,
                    //cs.Charges,
                    Amount = c.DueAmount,//Sql.As((cs.Charges - ((cs.Payments ?? 0) + (cs.Adjustments ?? 0))), "Amount"),
                    StatName = i.CompanyName,
                    StatUId = i.UId,
                    DueByFlag = cs.DueByFlag
                })//.GroupBy<InsuranceCompany>(i => new { i.CompanyName, i.UId })
                .Where<ChargeViewDTO>(i => ignoredueby.Contains(i.DueByFlagCD) && i.DueAmount > 0 && i.IsDeleted == false).OrderBy<InsuranceCompany>(j => j.CompanyName);

                if (hasDenial.HasValue)
                    query = query.Where(i => i.HasDenial == hasDenial);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<ChargeStat>.MapList(queryResult);

                //chargeStats = chargeStats.Where(i => i.Amount > 0);

                var result = chargeStats.GroupBy(d => d.StatName).Select(g => new ChargeStatDTO
                {
                    Amount = g.Sum(s => (s.Amount)),
                    StatUId = g.FirstOrDefault().StatUId.ToString(),
                    StatName = g.FirstOrDefault().StatName,
                    Count = g.Count()
                });
                return result.OrderByDescending(i => i.Amount);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeStatDTO>> ChargeStatByInsuranceType(bool? hasDenial)
        {
            try
            {
                var ignoredueby = new List<string> { "Primary", "Secondary" };

                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                    .Join<ChargeStat, InsuranceCompany>((cs, i) => cs.InsuranceCompanyId == i.Id)
                                    .Join<InsuranceCompany, ConfigInsuranceCompanyType>((i, ci) => i.CompanyTypeId == ci.Id)
                                    .SelectDistinct<ChargeStat, ChargeViewDTO, ConfigInsuranceCompanyType>((cs, c, i) => new
                                    {
                                        cs,
                                        EntryDate = c.EntryDate,
                                        Amount = c.DueAmount,//Sql.As((cs.Charges - ((cs.Payments ?? 0) + (cs.Adjustments ?? 0))), "Amount"),
                                        StatName = i.CompanyType,
                                        StatId = i.Id
                                    })
                                    .Where<ChargeViewDTO>(i => ignoredueby.Contains(i.DueByFlagCD) && i.DueAmount > 0 && i.IsDeleted == false).OrderBy<ConfigInsuranceCompanyType>(j => j.CompanyType);

                if (hasDenial.HasValue)
                    query = query.Where(i => i.HasDenial == hasDenial);
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<ChargeStat>.MapList(queryResult);

                var result = chargeStats.Where(i => i.Amount > 0).GroupBy(d => d.StatName).Select(g => new ChargeStatDTO
                {
                    Amount = g.Sum(s => (s.Charges)) - (g.Sum(s => s.Payments) + g.Sum(s => s.Adjustments)),
                    StatUId = g.FirstOrDefault().StatId.ToString(),
                    StatName = g.FirstOrDefault().StatName,
                    Count = g.Count()
                });

                return result.OrderByDescending(i => i.Amount);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeStatDTO>> ChargeStatByReasonCode(bool? hasDenial)
        {
            try
            {
                hasDenial = hasDenial == null ? true : hasDenial.Value;
                string whereQuery = "";
                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, Charges>((cs, c) => cs.Id == c.Id, NoLockTableHint.NoLock)
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id, NoLockTableHint.NoLock)
                                    .Join<ChargeStat, PaymentCharge>((cs, pc) => cs.Id == pc.ChargeId, NoLockTableHint.NoLock)
                                    .Join<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId, NoLockTableHint.NoLock)
                                    .SelectDistinct<ChargeStat, PaymentCharge, PaymentAdjustment,Charges>((cs, pc, pa,c) => new
                                    {
                                        Amount = Sql.Sum(c.Amount),
                                        StatName = pa.ReasonCode,
                                        StatUId = pa.ReasonCode,
                                        Count = Sql.CountDistinct(pc.ChargeId)
                                    }).Where<ChargeViewDTO>(i => i.IsDeleted == false && i.DueAmount>0)
                                    .GroupBy<PaymentAdjustment>(i => i.ReasonCode)
                                    .OrderBy<PaymentAdjustment>(j => j.ReasonCode);

                if (hasDenial.HasValue)
                    whereQuery += " AND HasDenial  ='" + hasDenial + "'";

                query.WhereExpression = query.WhereExpression + whereQuery;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<ChargeStatDTO>.MapList(queryResult);

                return chargeStats.Distinct();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeStatDTO>> ChargeStatByActionCategory(bool? hasDenial)
        {
            try
            {
                var query = this.Connection.From<ChargeStat>()
                                .Join<ChargeStat, Charges>((cs, c) => cs.Id == c.Id)
                                .Join<ChargeStat, ActionNote>((cs, a) => cs.Id == a.ChargeId && a.IsNote == true)
                                .Join<ActionNote, ActionCategory>((a, ac) => a.ActionCategoryId == ac.Id)
                                .Select<ChargeStat, Charges, ActionCategory>((cs, c, a) => new
                                {
                                    cs.Adjustments,
                                    cs.Payments,
                                    c.Amount,
                                    StatName = a.CategoryName,
                                    StatUId = a.UId
                                }).Where<Charges>(i => i.IsDeleted == false)
                                .GroupBy<ActionCategory, ChargeStat, Charges>((i, cs,c) => new { i.CategoryName, i.UId, cs.Adjustments, cs.Payments, c.Amount });


                if (hasDenial.HasValue)
                    query = query.Where(i => i.HasDenial == hasDenial);
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<ChargeStat>.MapList(queryResult);

                var result = chargeStats.GroupBy(d => d.StatName).Select(g => new ChargeStatDTO
                {
                    Amount = g.Sum(s => (s.Amount)) - (g.Sum(s => s.Payments ?? 0) + g.Sum(s => s.Adjustments ?? 0)),
                    StatUId = g.FirstOrDefault().StatUId.ToString(),
                    StatName = g.FirstOrDefault().StatName,
                    Count = g.Count()
                });

                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IDenialBaseStatisticsDTO> DenialDashboardBaseStatistics(bool? hasDenial)
        {
            DenialBaseStatisticsDTO denialBaseStatisticsDTO = new DenialBaseStatisticsDTO();
            denialBaseStatisticsDTO.TotalClaimsInDenial = await ClaimDenial(hasDenial);
            denialBaseStatisticsDTO.AssignedToMe = await ChargesAssigned();
            denialBaseStatisticsDTO.MyFollowUp = await this.ChargesInFollowup();
            return denialBaseStatisticsDTO;
        }

        private async Task<BaseStatisticsDTO> ClaimDenial(bool? hasDenial)
        {
            try
            {
                var query = this.Connection.From<ChargeStat>()
                               .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                               .Select<ChargeStat, ChargeViewDTO>((cs, c) => new
                               {
                                   Charges = Sql.Sum(c.Amount),
                                   Count = Sql.Count(cs.Id)
                               }).Where<ChargeViewDTO>(i => i.IsDeleted == false && i.DueAmount>0);


                //var query = this.Connection.From<ChargeStat>()
                //                    .Join<ChargeStat, Charges>((cs, c) => cs.Id == c.Id)
                //                    .Join<ChargeStat, PaymentCharge>((cs, pc) => cs.Id == pc.ChargeId)
                //                    .Join<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId)
                //                    .SelectDistinct<ChargeStat, PaymentCharge, PaymentAdjustment>((cs, pc, pa) => new
                //                    {
                //                        Charges = Sql.Sum(cs.Charges),
                //                        Count = Sql.Count(pc.ChargeId)
                //                    });
                //.GroupBy<PaymentAdjustment>(i => i.ReasonCode);


                if (hasDenial.HasValue)
                    query = query.Where(i => i.HasDenial == hasDenial);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var baseStatisticsDTO = Mapper<BaseStatisticsDTO>.Map(queryResult);

                //BaseStatisticsDTO baseStatisticsDTO = new BaseStatisticsDTO();
                //baseStatisticsDTO.Charges = chargeStats.Sum(i => i.Charges);
                //baseStatisticsDTO.Count = chargeStats.Count();
                return baseStatisticsDTO;
            }
            catch
            {
                throw;
            }
        }

        private async Task<BaseStatisticsDTO> ChargesAssigned()
        {
            try
            {
                var query = this.Connection.From<ChargeStat>()
                                .Join<ChargeStat, Charges>((cs, c) => cs.Id == c.Id)
                                .Join<ChargeStat, DenialQueue>((cs, d) => cs.Id == d.ChargeId && d.AssignedTo == LoggedUser.UserName
                                && d.IsClosed == false)
                                .Select<ChargeStat, Charges, DenialQueue>((cs, c, d) => new
                                {
                                    Charges = Sql.Sum(c.Amount),
                                    Count = Sql.Count(cs.Charges)

                                }).Where<Charges>(i => i.IsDeleted == false);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var baseStatisticsDTO = Mapper<BaseStatisticsDTO>.Map(queryResult);
                //BaseStatisticsDTO baseStatisticsDTO = new BaseStatisticsDTO();
                //baseStatisticsDTO.Charges = chargeStats.Sum(i => i.Charges);
                //baseStatisticsDTO.Count = chargeStats.Count();
                return baseStatisticsDTO;
            }
            catch
            {
                throw;
            }
        }

        private async Task<BaseStatisticsDTO> ChargesInFollowup()
        {
            var query = this.Connection.From<ChargeStat>()
                                .Join<ChargeStat, Charges>((cs, c) => cs.Id == c.Id)
                                .Join<ChargeStat, DenialQueue>((cs, d) => cs.Id == d.ChargeId && d.AssignedTo == LoggedUser.UserName
                                && d.IsClosed == false && d.HasFollowUp == true && d.FollowUpDate >= DateTime.Now.AddYears(-1).Date
                                && d.FollowUpDate <= DateTime.Now.AddDays(1).Date)
                                .SelectDistinct<ChargeStat, Charges, DenialQueue>((cs, c, d) => new
                                {
                                    cs,
                                    EntryDate = c.EntryDate
                                }).Where<Charges>(i => i.IsDeleted == false);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var chargeStats = Mapper<ChargeStat>.MapList(queryResult);
            BaseStatisticsDTO baseStatisticsDTO = new BaseStatisticsDTO();
            baseStatisticsDTO.Charges = chargeStats.Sum(i => i.Charges);
            baseStatisticsDTO.Count = chargeStats.Count();
            return baseStatisticsDTO;
        }

        public async Task<string> RefreshDenialDashboard()
        {
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    await base.ExecuteStoredProcedureAsync<dynamic>("usp_insertorupdatechargestat");
                }
                return "Success";
            }

            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IDataFormDenailFileDTO>> GetDenailFileData()
        {
            try
            {
                //var query = this.Connection.From<ChargeStat>()
                //                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                //                    .Join<ChargeViewDTO, Claim>((cd, cl) => cd.ClaimId == cl.Id)
                //                    .SelectDistinct<ChargeViewDTO, Claim>((cd, cl) => new
                //                    {
                //                        cl.PatientAccountNumber,
                //                        cl.PatientFirstName,
                //                        cl.PatientLastName,
                //                        cl.PatientDOB,
                //                        cl.AccessionNumber,
                //                        cd.CPTCode,
                //                        cd.Amount,
                //                        cd.BillFromDate
                //                    })
                //                    .Where<ChargeStat,ChargeViewDTO>((i,j) => i.HasDenial == true && j.IsDeleted==false);

                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                    .Join<ChargeStat, PaymentCharge>((cs, pc) => cs.Id == pc.ChargeId)
                                    .Join<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId)
                                    .Join<ChargeViewDTO, PatientCase>((cs, pc) => cs.PatientCaseId == pc.Id)
                                    .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                                    .Join<ChargeViewDTO, Provider>((cs, pr) => cs.PerformingProviderId == pr.Id)
                                    .SelectDistinct<ChargeViewDTO, PaymentAdjustment, Patient, Provider>((cd, pa, p, pr) => new
                                    {
                                        PatientAccountNumber = Sql.As(p.Id.ToString(), "PatientAccountNumber"),
                                        PatientFirstName = p.FirstName,
                                        PatientLastName = p.LastName,
                                        PatientDOB = p.DOB,
                                        cd.AccessionNumber,
                                        cd.CPTCode,
                                        cd.BillFromDate,
                                        pa.Amount,
                                        pa.ReasonCode,
                                        ProviderFirstName = pr.FirstName,
                                        ProviderLastName = pr.LastName,
                                        cd.Id
                                    })
                                    .Where<ChargeStat, ChargeViewDTO>((i, j) => i.HasDenial == true && j.IsDeleted == false && j.DueAmount>0);                               

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<DataFormDenailFileDTO>.MapList(queryResult);


                return chargeStats;
            }
            catch
            {
                throw;
            }
        }


        public async Task<IEnumerable<IDataFormDenailFileDTO>> GetAgingFileData()
        {
            try
            {
                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                    .Join<ChargeViewDTO, PatientCase>((cd, pc) => cd.PatientCaseId == pc.Id)
                                    .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                                    .SelectDistinct<ChargeViewDTO, Patient>((cd, p) => new
                                    {
                                        PatientAccountNumber = Sql.As(p.Id.ToString(), "PatientAccountNumber"),
                                        PatientFirstName = p.FirstName,
                                        PatientLastName = p.LastName,
                                        PatientDOB = p.DOB,
                                        cd.AccessionNumber,
                                        cd.CPTCode,
                                        cd.DueAmount,
                                        cd.BillFromDate,                                        
                                    }).Where<ChargeViewDTO>(i => i.IsDeleted == false && i.DueAmount > 0);

                query = query.Where(i => i.HasDenial == true);
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<DataFormDenailFileDTO>.MapList(queryResult);
                return chargeStats;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IDataFormDenailFileDTO>> GetDenialReasonsFile()
        {
            try
            {
                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                    .Join<ChargeStat, PaymentCharge>((cs, pc) => cs.Id == pc.ChargeId)
                                    .Join<PaymentCharge, PaymentAdjustment>((pc, pa) => pc.Id == pa.PaymentChargeId)
                                    .Join<ChargeViewDTO, PatientCase>((cs, pc) => cs.PatientCaseId == pc.Id)
                                    .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                                    .Join<ChargeViewDTO, Provider>((cs, pr) => cs.PerformingProviderId == pr.Id)
                                    .LeftJoin<Provider, ConfigPractitionerService>((p, cps) => p.PractitionerServiceId == cps.Id)
                                    .LeftJoin<ConfigPractitionerService, CPTModifier>((cps, mod) => cps.CPTModifier_Id == mod.ID)
                                    .SelectDistinct<ChargeViewDTO, PaymentAdjustment, Patient, Provider, ConfigPractitionerService, CPTModifier>((cd, pa, p, pr, cps, mod) => new
                                    {
                                        PatientAccountNumber = Sql.As(p.Id.ToString(), "PatientAccountNumber"),
                                        PatientFirstName = p.FirstName,
                                        PatientLastName = p.LastName,
                                        PatientDOB = p.DOB,
                                        cd.AccessionNumber,
                                        cd.CPTCode,
                                        cd.BillFromDate,
                                        pa.Amount,
                                        pa.ReasonCode,
                                        ProviderFirstName = pr.FirstName,
                                        ProviderLastName = pr.LastName,                                        
                                        ProviderQualification = Sql.As((cps.ProfessionalAbbreviation + "-" + cps.ProvidingService), "ProviderQualification"),
                                        CPTModifier = mod.Code,                                        
                                        cd.PatientCaseId
                                    })
                                    .Where<ChargeStat, ChargeViewDTO>((i,j )=> i.HasDenial == true && j.IsDeleted==false)                                    
                                    .OrderBy<PaymentAdjustment>(j => j.ReasonCode);
                
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<DataFormDenailFileDTO>.MapList(queryResult);
                List<int> patientCaseIds = new List<int>();

                if (chargeStats != null && chargeStats.Count() > 0)
                {
                    patientCaseIds = chargeStats.Select(i => i.PatientCaseId).Distinct().ToList();
                }

                var resultInsPolicies = await this._insurancePolicyRepository.GetActivePolicies(patientCaseIds);
                chargeStats.ToList().ForEach(i =>
                {                    
                    var activePolicy = resultInsPolicies.Where(policy => policy.PatientCaseId == i.PatientCaseId
                                && (policy.PlanEffectiveDate.HasValue
                               && policy.PlanEffectiveDate.Value.Date <= i.BillFromDate.Date)
                               && ((policy.PlanExpirationDate == null)
                               || (policy.PlanExpirationDate.HasValue
                               && policy.PlanExpirationDate.Value.Date >= i.BillFromDate.Date))).FirstOrDefault();
                    if (activePolicy != null)
                        i.InsuranceCompanyName = activePolicy.InsuranceCompanyName;
                });

                return chargeStats;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IDataFormDenailFileDTO>> GetInsuranceCompaniesFile()
        {
            try
            {
                var ignoredueby = new List<string> { "Primary", "Secondary" };

                var query = this.Connection.From<ChargeStat>()
                .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                .Join<ChargeStat, InsuranceCompany>((cs, i) => cs.InsuranceCompanyId == i.Id)
                .Join<ChargeViewDTO, PatientCase>((cs, pc) => cs.PatientCaseId == pc.Id)
                .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                .Select<ChargeViewDTO, Patient>((cd, p) => new
                {
                    PatientAccountNumber = Sql.As(p.Id.ToString(), "PatientAccountNumber"),
                    PatientFirstName = p.FirstName,
                    PatientLastName = p.LastName,
                    PatientDOB = p.DOB,
                    cd.AccessionNumber,
                    cd.CPTCode,
                    cd.BillFromDate,
                    Amount = cd.DueAmount,                   
                })
                .Where<ChargeViewDTO>(i => ignoredueby.Contains(i.DueByFlagCD) && i.DueAmount > 0 && i.IsDeleted == false)
                .OrderBy<InsuranceCompany>(j => j.CompanyName);

                query = query.Where(i => i.HasDenial == true);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<DataFormDenailFileDTO>.MapList(queryResult);
                return chargeStats;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IDataFormDenailFileDTO>> GetInsuranceTypesFile()
        {
            try
            {
                var ignoredueby = new List<string> { "Primary", "Secondary" };

                var query = this.Connection.From<ChargeStat>()
                                    .Join<ChargeStat, ChargeViewDTO>((cs, c) => cs.Id == c.Id)
                                    .Join<ChargeStat, InsuranceCompany>((cs, i) => cs.InsuranceCompanyId == i.Id)
                                    .Join<InsuranceCompany, ConfigInsuranceCompanyType>((i, ci) => i.CompanyTypeId == ci.Id)
                                    .Join<ChargeViewDTO, PatientCase>((cs, pc) => cs.PatientCaseId == pc.Id)
                                    .Join<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                                    .Select<ChargeViewDTO, Patient>((cd, p) => new
                                    {
                                        PatientAccountNumber = Sql.As(p.Id.ToString(), "PatientAccountNumber"),
                                        PatientFirstName = p.FirstName,
                                        PatientLastName = p.LastName,
                                        PatientDOB = p.DOB,
                                        cd.AccessionNumber,
                                        cd.CPTCode,
                                        cd.BillFromDate,                                        
                                        Amount = cd.DueAmount,                                        
                                    })
                                    .Where<ChargeViewDTO>(i => ignoredueby.Contains(i.DueByFlagCD) && i.DueAmount > 0 && i.IsDeleted == false)
                                    .OrderBy<ConfigInsuranceCompanyType>(j => j.CompanyType);


                query = query.Where(i => i.HasDenial == true);
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var chargeStats = Mapper<DataFormDenailFileDTO>.MapList(queryResult);
                return chargeStats;
            }
            catch
            {
                throw;
            }
        }
    }
}
