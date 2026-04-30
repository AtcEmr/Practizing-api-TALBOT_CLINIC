using AutoMapper;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Object;
using PractiZing.DataAccess.DenialService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargesReportDataRepository : ModuleBaseRepository<ChargesReportData>, IChargesReportDataRepository
    {
        private IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IProviderRepository _providerRepository;
        private IChargeStatementCountRepository _chargeStatementCountRepository;
        private readonly IInsurancePolicyRepository _insurancePolicyRepository; 
        private readonly IMapper _mapper;
        private readonly IChargesReportDataConsolidateRepository _chargesReportDataConsolidateRepository;
        private readonly IDynmoPaymentsRepository _dynmoPaymentsRepository;
        private readonly IPortalPaymentRepository _portalPaymentRepository;
        private readonly IPracticeRepository _practiceRepository;
        public ChargesReportDataRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                      IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                                      IInsuranceCompanyRepository insuranceCompanyRepository,
                                      IProviderRepository providerRepository,
                                      IChargeStatementCountRepository chargeStatementCountRepository,
                                      IChargesReportDataConsolidateRepository chargesReportDataConsolidateRepository,
                                      IInsurancePolicyRepository insurancePolicyRepository,
                                      IDynmoPaymentsRepository dynmoPaymentsRepository,
                                    IPortalPaymentRepository portalPaymentRepository,
                                    IPracticeRepository practiceRepository,
                                      IMapper mapper)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            this._practiceRepository = practiceRepository;
            this._portalPaymentRepository = portalPaymentRepository;
            this._dynmoPaymentsRepository = dynmoPaymentsRepository;
            this._insurancePolicyRepository = insurancePolicyRepository;
            this._chargeStatementCountRepository = chargeStatementCountRepository;
            this._chargesReportDataConsolidateRepository = chargesReportDataConsolidateRepository;
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
            this._mapper = mapper;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._providerRepository = providerRepository;
        }


        public async Task<IChargesReportDataDTO> Get(IChargesReportDataFilterDTO filter)
        {
            try
            {
                ChargesReportDataDTO chargesReportDataDTO = new ChargesReportDataDTO();
                if (filter != null)
                {
                    filter.FromDate = (filter.FromDate != null || filter.FromDate != string.Empty) ? Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00") : filter.FromDate;
                    filter.ToDate = (filter.ToDate != null || filter.ToDate != string.Empty) ? Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59") : filter.ToDate;
                }
                List<ChargesReportData> lst = new List<ChargesReportData>();
                SqlExpression<ChargesReportData> query;
                if (filter.IsPostOrDosDate == 0)
                {
                    //lst = await this.Connection.SelectAsync<ChargesReportData>(i=>i.ChargePostDate>=Convert.ToDateTime(filter.FromDate) && i.ChargePostDate <= Convert.ToDateTime(filter.ToDate));

                    query = this.Connection
                           .From<ChargesReportData>()
                           .Join<ChargesReportData, Provider>((x, y) => x.PerforingProviderId == y.Id)
                           .LeftJoin<Provider, ProviderIdentity>((x, y) => x.Id == y.ProviderId && y.TypeId == 10)
                           .Select<ChargesReportData, ProviderIdentity>
                           ((p, id) => new
                           {
                               p.Id,
                               p.ChargeId,
                               p.ChargePostDate,
                               p.DosDate,
                               p.CptCode,
                               p.Description,
                               p.ChargeAmount,
                               p.Payment,
                               p.Adjustment,
                               p.DueAmount,
                               Aging = p.AgingByPostDate,
                               AgingText = p.AgingByPostDateText,
                               p.AdjustmentCode,
                               p.Denial,
                               p.InsuranceCompanyId,
                               p.InsuranceCompanyName,
                               //InsuranceCompanyName= Sql.As((p.PrimaryInsuranceCompanyName==null? p.InsuranceCompanyName: p.PrimaryInsuranceCompanyName),"InsuranceCompanyName"),
                               p.CompanyType,
                               p.PerforingProviderId,
                               p.PerforingProviderName,
                               p.PaymentReceived,
                               p.ClaimId,
                               p.ClaimSentDate,
                               p.ClaimStatus,
                               p.PerformingFacilityId,
                               p.PerformingFacilityName,
                               p.CreatedDate,
                               p.DenialAmount,
                               p.DueBy,
                               p.ClaimSent,
                               p.PaymentPostDate,
                               p.RemitDate,
                               p.InvoiceId,
                               p.PatientCaseId,
                               p.BillingID,
                               p.FirstName,
                               p.LastName,
                               p.DOB,
                               p.PatientId,
                               p.PatientUId,
                               p.InvoiceUId,
                               p.PatientCaseUId,
                               p.PerformingProviderUId,
                               p.PatientName,
                               p.AccessionNumber,
                               p.AgingByPostDate,
                               p.ReasonCodeDescription,
                               p.WriteOffAmount,
                               p.FeeAmount,
                               p.PatientPayment,
                               p.ReasonCode1,
                               p.ReasonCode2,
                               p.ReasonCode3,
                               p.ReasonCode4,
                               p.PrimaryPolicyNo,
                               p.SecondaryPolicyNo,
                               p.ICNNumber,
                               p.ICNNumberSecondary,
                               p.Qty,
                               p.PrimaryInsuranceCompanyName,
                               p.SecondaryInsuranceCompanyName,
                               ProviderLicence = id.Identifier,
                               p.POS,
                               p.PatientAccountNumber,
                               p.PerformingProfessionalAbbreviation

                           }).Where<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ChargePostDate >= Convert.ToDateTime(filter.FromDate) && i.ChargePostDate <= Convert.ToDateTime(filter.ToDate));


                }
                else
                {
                    query = this.Connection
                           .From<ChargesReportData>()
                           .Join<ChargesReportData, Provider>((x, y) => x.PerforingProviderId == y.Id)
                           .LeftJoin<Provider, ProviderIdentity>((x, y) => x.Id == y.ProviderId && y.TypeId == 10)
                           .Select<ChargesReportData, ProviderIdentity>
                           ((p, id) => new
                           {
                               p.Id,
                               p.ChargeId,
                               p.ChargePostDate,
                               p.DosDate,
                               p.CptCode,
                               p.Description,
                               p.ChargeAmount,
                               p.Payment,
                               p.Adjustment,
                               p.DueAmount,
                               Aging = p.AgingByPostDate,
                               AgingText = p.AgingByPostDateText,
                               p.AdjustmentCode,
                               p.Denial,
                               p.InsuranceCompanyId,
                               p.InsuranceCompanyName,
                               //InsuranceCompanyName = Sql.As((p.PrimaryInsuranceCompanyName == null ? p.InsuranceCompanyName : p.PrimaryInsuranceCompanyName), "InsuranceCompanyName"),
                               p.CompanyType,
                               p.PerforingProviderId,
                               p.PerforingProviderName,
                               p.PaymentReceived,
                               p.ClaimId,
                               p.ClaimSentDate,
                               p.ClaimStatus,
                               p.PerformingFacilityId,
                               p.PerformingFacilityName,
                               p.CreatedDate,
                               p.DenialAmount,
                               p.DueBy,
                               p.ClaimSent,
                               p.PaymentPostDate,
                               p.RemitDate,
                               p.InvoiceId,
                               p.PatientCaseId,
                               p.BillingID,
                               p.FirstName,
                               p.LastName,
                               p.DOB,
                               p.PatientId,
                               p.PatientUId,
                               p.InvoiceUId,
                               p.PatientCaseUId,
                               p.PerformingProviderUId,
                               p.PatientName,
                               p.AccessionNumber,
                               p.AgingByPostDate,
                               p.ReasonCodeDescription,
                               p.WriteOffAmount,
                               p.FeeAmount,
                               p.PatientPayment,
                               p.ReasonCode1,
                               p.ReasonCode2,
                               p.ReasonCode3,
                               p.ReasonCode4,
                               p.PrimaryPolicyNo,
                               p.SecondaryPolicyNo,
                               p.ICNNumber,
                               p.ICNNumberSecondary,
                               p.Qty,
                               p.PrimaryInsuranceCompanyName,
                               p.SecondaryInsuranceCompanyName,
                               ProviderLicence = id.Identifier,
                               p.POS,
                               p.PatientAccountNumber,
                               p.PerformingProfessionalAbbreviation

                           }).Where<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.DosDate >= Convert.ToDateTime(filter.FromDate) && i.DosDate <= Convert.ToDateTime(filter.ToDate));
                }

                var dynamics = await this.Connection.SelectAsync<dynamic>(query);
                lst = Mapper<ChargesReportData>.MapList(dynamics).ToList();

                foreach (var item in lst)
                {
                    item.InsuranceCompanyName = item.PrimaryInsuranceCompanyName == null ? item.InsuranceCompanyName : item.PrimaryInsuranceCompanyName;
                }

                List<string> duyBy = new List<string>() { "", "patient" };

                chargesReportDataDTO.TotalSamples = lst.Select(i => i.InvoiceId).Distinct().Count();
                chargesReportDataDTO.ChargesAmount = lst.Sum(i => i.ChargeAmount);
                chargesReportDataDTO.Payments = lst.Sum(i => i.Payment);
                chargesReportDataDTO.FeeAmount = lst.Sum(i => i.FeeAmount);
                chargesReportDataDTO.WriteOffAmount = lst.Sum(i => i.WriteOffAmount);
                chargesReportDataDTO.Adjustments = lst.Where(i => i.Denial == "No").Sum(i => i.Adjustment);
                //chargesReportDataDTO.DenialsAmount = lst.Where(i => i.Denial == "Yes" && i.ClaimSent.ToLower() == "yes" && (Convert.ToDateTime(i.RemitDate) > i.ClaimSentDate.Value)
                //&& !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                chargesReportDataDTO.DenialsAmount = lst.Where(i => i.Denial == "Yes" && !duyBy.Contains(i.DueBy.ToLower())).Sum(i => i.DueAmount);
                chargesReportDataDTO.DueAmount = lst.Sum(i => i.DueAmount);


                



                chargesReportDataDTO.Charges = lst;
                if (chargesReportDataDTO.WriteOffAmount.HasValue && chargesReportDataDTO.Adjustments.HasValue)
                {
                    //chargesReportDataDTO.Adjustments = chargesReportDataDTO.Adjustments - chargesReportDataDTO.WriteOffAmount;
                }

                return chargesReportDataDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<ICPAReportDTO> GetCPAReportAnalytics()
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            //var lst = await this.Connection.SelectAsync<ChargesReportData>(i=>i.DueAmount!=0 && !duyBy.Contains(i.DueBy.ToLower())&& i.InsuranceCompanyName!= "SelfPay");
            var lst = await this.Connection.SelectAsync<ChargesReportData>();

            //var billedVsCurrentIns = lst.Where(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ChargeAmount == i.DueAmount
            //   && i.ClaimId > 0 && i.Denial.ToLower() == "yes" && !i.SecondaryInsuranceCompanyId.HasValue && i.InsuranceCompanyId > 0
            //   && i.PrimaryInsuranceCompanyId != i.InsuranceCompanyId).Sum(i => i.DueAmount);

            var billedVsCurrentIns = lst.Where(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ChargeAmount == i.DueAmount
                && i.ClaimId > 0 && i.Denial.ToLower() == "yes" && !i.SecondaryInsuranceCompanyId.HasValue && i.InsuranceCompanyId > 0
                && i.PrimaryInsuranceCompanyId != i.InsuranceCompanyId && i.DueBy.ToLower()=="primary");

            var totalWriteOff = lst.Where(i => i.WriteOffAmount > 0 && i.IsBillable.Value && i.Deleted.ToLower() == "no").Sum(i => i.WriteOffAmount);

            var rejectedCharges = lst.Where(i => i.IsRejected == true).Sum(i => i.ChargeAmount);


            List<string> payers = new List<string>() { "", "selfpay" };

            var payerRatherThanSelfAmount = lst.Where(i => duyBy.Contains(i.DueBy.ToLower()) && i.ChargeAmount == i.DueAmount && i.IsBillable.Value && i.Deleted.ToLower() == "no"
           && !payers.Contains(i.InsuranceCompanyName.ToLower()));


            lst = lst.Where(i => i.InsuranceCompanyName != "SelfPay" && i.Deleted.ToLower() == "no").ToList();

            var feeAmount = lst.Where(i => i.FeeAmount > i.Payment && i.Payment > 0 && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.DueAmount == 0).Sum(i => i.FeeAmount);
            var payment = lst.Where(i => i.FeeAmount > i.Payment && i.Payment > 0 && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.DueAmount == 0).Sum(i => i.Payment);

            lst = lst.Where(i => i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower())).ToList();

            var agingall = lst.Where(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ClaimId.HasValue).Sum(i => i.DueAmount);
            var aging0_30Days = lst.Where(i => (DateTime.Now - i.ChargePostDate).TotalDays < 30 && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.ClaimId.HasValue).Sum(i => i.DueAmount);
            var aging30_60Days = lst.Where(i => (DateTime.Now - i.ChargePostDate).TotalDays >= 30 && (DateTime.Now - i.ChargePostDate).TotalDays < 60 && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.ClaimId.HasValue).Sum(i => i.DueAmount);
            var aging90_120Days = lst.Where(i => (DateTime.Now - i.ChargePostDate).TotalDays >= 60 && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.ClaimId.HasValue).Sum(i => i.DueAmount);

            var billableButNotClaimed = lst.Where(i => (DateTime.Now - i.ChargePostDate).TotalDays <= 7 && i.IsBillable.Value && !i.ClaimId.HasValue && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);

            var notbillableClaimed = lst.Where(i => !i.IsBillable.Value && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);

            var unAdjucatedBalance = lst.Where(i => i.ClaimSent.ToLower() == "yes" && i.PaymentReceived.ToLower() == "no" && i.ClaimSentDate < DateTime.Now.AddDays(-15) && i.IsBillable.Value && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);


            //var untouchCharges = lst.Where(i => i.DueAmount > 0 && i.IsBillable.Value  && i.ChargePostDate < DateTime.Now.AddDays(-46) && i.ChargeNoteDate < DateTime.Now.AddDays(-15));//.Sum(i => i.ChargeAmount);
            //List<string> duyBy = new List<string>() { "", "patient" };
            var untouchChargesSUM = lst.Where(i => i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && i.ChargePostDate < DateTime.Now.AddDays(-46) && i.ChargeNoteDate < DateTime.Now.AddDays(-16) && i.Deleted.ToLower() == "no").Sum(i => i.DueAmount);


            var inWriteOffRequest = lst.Where(i => i.InWriteOffQueue == true && i.IsBillable.Value && i.Deleted.ToLower() == "no").Sum(i => i.DueAmount);




            DateTime dateTime = DateTime.Now.AddYears(-1);
            DateTime lastFromDate = new DateTime(dateTime.Year, dateTime.Month, 1);
            DateTime lastToDate = lastFromDate.AddMonths(2);

            var deniallastfromDate = lst.Where(i => i.Denial.ToLower() == "yes" && i.Deleted.ToLower() == "no" && i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && (i.DosDate >= lastFromDate && i.DosDate <= lastToDate)).Sum(i => i.DueAmount);
            var unAdjucatedlastfromDate = lst.Where(i => i.ClaimSent.ToLower() == "yes" && i.Deleted.ToLower() == "no" && i.PaymentReceived.ToLower() == "no" && i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && (i.DosDate >= lastFromDate && i.DosDate <= lastToDate)).Sum(i => i.DueAmount);




            CPAReportDTO cPAReportDTO = new CPAReportDTO();
            cPAReportDTO.AboveNintyBalance = aging90_120Days;
            cPAReportDTO.ThirtyDaysBalance = aging0_30Days;
            cPAReportDTO.SixtyDaysBalance = aging30_60Days;
            cPAReportDTO.UnderPaid = feeAmount - payment;
            cPAReportDTO.UnAdjucatedBalance = unAdjucatedBalance;
            cPAReportDTO.BillableButNotClaimed = billableButNotClaimed;
            cPAReportDTO.NotBillableClaim = notbillableClaimed;
            cPAReportDTO.UnTouchCharges = untouchChargesSUM;
            cPAReportDTO.AllCharges = agingall;
            cPAReportDTO.InWriteOffRequest = inWriteOffRequest;
            cPAReportDTO.ClaimFillingLimit = deniallastfromDate + unAdjucatedlastfromDate;
            cPAReportDTO.RejectedCharges = rejectedCharges;
            cPAReportDTO.TotalWriteOff = totalWriteOff;
            cPAReportDTO.PayerRatherThanSelfAmount = payerRatherThanSelfAmount.Sum(i => i.DueAmount);
            var billedVsCurrList = await this.GetBilledVsCurrentIns(billedVsCurrentIns);
            cPAReportDTO.BilledVsCurrentIns = billedVsCurrList.Sum(i => i.DueAmount);
            //cPAReportDTO.BilledVsCurrentIns = billedVsCurrentIns;

            return cPAReportDTO;
        }

        private async Task<IEnumerable<ChargesReportData>> GetBilledVsCurrentIns(IEnumerable<ChargesReportData> lst)
        {
            lst = lst.Where(i => i.ClaimSent.ToLower() == "yes" && (Convert.ToDateTime(i.RemitDate) > i.ClaimSentDate.Value) && i.ReviewNeeded==false).ToList();
            lst = lst.Where(i => !i.InsuranceCompanyName.ToLower().Contains("hold")).ToList();
            lst = lst.Where(i => !i.InsuranceCompanyName.ToLower().Contains("self")).ToList();

            var tCodes = lst.Where(i => i.CptCode.StartsWith("T"));
            var hCodes = lst.Where(i => i.CptCode.StartsWith("H"));

            List<ChargesReportData> ingoreTCodes = new List<ChargesReportData>();
            foreach (var item in tCodes)
            {
                if (item.PrimaryInsuranceCompanyId != item.InsuranceCompanyId)
                {
                    if (item.PrimaryInsuranceCompanyId == item.ChargeSecondaryCompanyId)
                    {
                        ingoreTCodes.Add(item);
                    }
                }
            }
            lst = lst.Except(ingoreTCodes).ToList();

            List<ChargesReportData> ingoreHCodes = new List<ChargesReportData>();
            foreach (var item in hCodes)
            {
                if (item.PrimaryInsuranceCompanyId != item.InsuranceCompanyId)
                {
                    if (item.PrimaryInsuranceCompanyId == item.ChargeSecondaryCompanyId)
                    {
                        ingoreHCodes.Add(item);
                    }
                }
            }
            lst = lst.Except(ingoreHCodes).ToList();

            return lst;
        }

        public async Task<IEnumerable<IChargesReportData>> GetCPAChargesAnalytics(string value)
        {
            var writeOfflstQuery = this.Connection.From<ChargeInWriteOff>().Select<ChargeInWriteOff>((p) => new { p.ChargeId });
            var dynamics = await this.Connection.SelectAsync<dynamic>(writeOfflstQuery);
            var chargeIdsList = Mapper<ChargeInWriteOff>.MapList(dynamics).ToList();
            IEnumerable<string> chargeIds = chargeIdsList.Select(i => i.ChargeId.ToString());

            IEnumerable<ChargesReportData> lst;

            if (chargeIds.Count() > 0)
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => !chargeIds.Contains(i.ChargeId.ToString()) && i.DueAmount != 0 && i.Deleted.ToLower() == "no" && i.IsBillable.Value);
            else
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value);

            List<string> duyBy = new List<string>() { "", "patient" };
            if (value == "A") //30 Days
            {
                lst = lst.Where(i => ((DateTime.Now - i.ChargePostDate).TotalDays < 30) && i.ClaimId.HasValue);
            }
            else if (value == "B") //60 Days
            {
                lst = lst.Where(i => ((DateTime.Now - i.ChargePostDate).TotalDays >= 30 && (DateTime.Now - i.ChargePostDate).TotalDays < 60) && i.ClaimId.HasValue);
            }
            else if (value == "C") //60 Days+
            {
                lst = lst.Where(i => ((DateTime.Now - i.ChargePostDate).TotalDays >= 60) && i.ClaimId.HasValue);
            }
            else if (value == "D") //UnAdjudicated
            {
                lst = lst.Where(i => i.ClaimSent.ToLower() == "yes" && i.PaymentReceived.ToLower() == "no" && i.ClaimSentDate < DateTime.Now.AddDays(-15)).OrderBy(i => i.DosDate);
            }
            else if (value == "E") //Under Paid
            {
                //lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.PaymentReceived.ToLower() == "yes" && i.IsBillable.Value && i.Payment>0 && i.FeeAmount>i.Payment);
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.FeeAmount > i.Payment && i.Payment > 0 && i.DueAmount == 0 && i.IsBillable.Value && i.Deleted.ToLower() == "no");
            }
            else if (value == "F") // Billable But Claim Not Made
            {
                lst = lst.Where(i => (DateTime.Now - i.ChargePostDate).TotalDays <= 7 && i.IsBillable.Value && !i.ClaimId.HasValue);
            }
            else if (value == "G") //Flagged Non Billable
            {
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DueAmount != 0 && i.Deleted.ToLower() == "no" && !i.IsBillable.Value);
            }
            else if (value == "H") //(45+ days aging) not worked  for past 15 Days 
            {

                lst = lst.Where(i => i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && i.ChargePostDate < DateTime.Now.AddDays(-46) && i.ChargeNoteDate < DateTime.Now.AddDays(-16));
            }
            else if (value == "I") //Write Off Request
            {
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DueAmount != 0 && i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.InWriteOffQueue == true);
            }
            else if (value == "K") //Time of Filing Limits
            {
                DateTime dateTime = DateTime.Now.AddYears(-1);
                DateTime lastFromDate = new DateTime(dateTime.Year, dateTime.Month, 1);
                DateTime lastToDate = lastFromDate.AddMonths(2);

                var deniallastfromDateLst = lst.Where(i => i.Denial.ToLower() == "yes" && i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && (i.DosDate >= lastFromDate && i.DosDate <= lastToDate));
                var unAdjucatedlastfromDateList = lst.Where(i => i.ClaimSent.ToLower() == "yes" && i.PaymentReceived.ToLower() == "no" && i.DueAmount != 0 && !duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable.Value && (i.DosDate >= lastFromDate && i.DosDate <= lastToDate));

                List<ChargesReportData> lstTemp = new List<ChargesReportData>();
                lstTemp.AddRange(deniallastfromDateLst);
                lstTemp.AddRange(unAdjucatedlastfromDateList);
                lst = lstTemp;
            }
            else if (value == "L") //rejected Charges
            {
                lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.IsRejected == true);
            }
            else if (value == "X") //rejected Charges
            {
                //lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.IsRejected == true);
                lst = lst.Where(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ClaimId.HasValue && i.DueAmount != 0);
                //lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ClaimId.HasValue);
            }
            else if (value == "M") //rejected Charges
            {
                List<string> payers = new List<string>() { "", "selfpay" };

                lst = lst.Where(i => duyBy.Contains(i.DueBy.ToLower()) && i.ChargeAmount == i.DueAmount
               && !payers.Contains(i.InsuranceCompanyName.ToLower()));


                return lst;
            }
            else if (value == "O") // BilledVsCurrentIns
            {
                lst = lst.Where(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ChargeAmount == i.DueAmount
                && i.ClaimId > 0 && i.Denial.ToLower() == "yes" && i.DueBy.ToLower() == "primary"
                && i.InsuranceCompanyId > 0 &&
                !i.SecondaryInsuranceCompanyId.HasValue && i.PrimaryInsuranceCompanyId != i.InsuranceCompanyId);

                lst=await this.GetBilledVsCurrentIns(lst);

                return lst;
            }


            //foreach (var item in lst)
            //{
            //    int lstcount = lst.Count();
            //    if (string.IsNullOrWhiteSpace(item.ChargeNote))
            //    {

            //        item.ChargeNoteDateTemp = null;
            //    }
            //    else
            //        item.ChargeNoteDateTemp = item.ChargeNoteDate.Value.ToShortDateString();
            //}
            if (value != "E")
                lst = lst.Where(i => !duyBy.Contains(i.DueBy.ToLower()) && i.InsuranceCompanyName != "SelfPay");

            return lst;//.Where(i=>!duyBy.Contains(i.DueBy.ToLower()) && i.InsuranceCompanyName != "SelfPay");
        }

        public async Task<IEnumerable<IChargesReportData>> GetOnlyWriteOff()
        {
            var writeOfflstQuery = this.Connection.From<ChargeInWriteOff>().Select<ChargeInWriteOff>((p) => new { p.ChargeId }).Where(i => i.StatusId == 1);
            var dynamics = await this.Connection.SelectAsync<dynamic>(writeOfflstQuery);
            var chargeIdsList = Mapper<ChargeInWriteOff>.MapList(dynamics).ToList();
            IEnumerable<string> chargeIds = chargeIdsList.Select(i => i.ChargeId.ToString());

            IEnumerable<IChargesReportData> lst = await this.Connection.SelectAsync<ChargesReportData>(i => chargeIds.Contains(i.ChargeId.ToString()));

            return lst;//.Where(i=>!duyBy.Contains(i.DueBy.ToLower()) && i.InsuranceCompanyName != "SelfPay");
        }

        public async Task<IChargesReportDataDTO> GetOnlyDenials(IChargesReportDataFilterDTO filter)
        {
            try
            {
                ChargesReportDataDTO chargesReportDataDTO = new ChargesReportDataDTO();

                List<ChargesReportData> lst = new List<ChargesReportData>();
                int insuranceCompanyId = 0;
                int providerId = 0;
                if (!string.IsNullOrWhiteSpace(filter.InsuranceCompanyUId) && filter.InsuranceCompanyUId != "undefined" && filter.InsuranceCompanyUId != "null")
                {
                    var insCompany = await this._insuranceCompanyRepository.GetByUId(Guid.Parse(filter.InsuranceCompanyUId));
                    if (insCompany != null)
                    {
                        insuranceCompanyId = insCompany.Id;
                    }
                }
                if (!string.IsNullOrWhiteSpace(filter.PerformingProviderUId) && filter.PerformingProviderUId != "undefined" && filter.PerformingProviderUId != "null")
                {
                    var provider = await this._providerRepository.GetByUId(Guid.Parse(filter.PerformingProviderUId));
                    if (provider != null)
                    {
                        providerId = provider.Id;
                    }
                }
                var query = this.Connection
                               .From<ChargesReportData>()
                               .LeftJoin<ChargesReportData, DenialQueue>((i, j) => i.ChargeId == j.ChargeId)
                               .Select<ChargesReportData, DenialQueue>((c, d) => new
                               {
                                   c,
                                   AssignedTo = d.AssignedTo,
                                   AssignedBy = d.AssignedBy,
                                   AssignedDate = d.AssignedDate
                               }).Where(i => i.Denial == "Yes");

                var dynamics = await this.Connection.SelectAsync<dynamic>(query);
                lst = Mapper<ChargesReportData>.MapList(dynamics).ToList();

                if (insuranceCompanyId > 0 && providerId > 0)
                {
                    //lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Denial == "Yes" && i.IsBillable.Value && i.Deleted == "No" && i.PerforingProviderId==providerId && i.PrimaryInsuranceCompanyId==insuranceCompanyId);
                    lst = lst.Where(i => i.Denial.ToLower() == "yes" && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.PerforingProviderId == providerId && i.PrimaryInsuranceCompanyId == insuranceCompanyId).ToList();
                }
                else if (insuranceCompanyId > 0)
                {
                    lst = lst.Where(i => i.Denial.ToLower() == "yes" && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.PrimaryInsuranceCompanyId == insuranceCompanyId).ToList();
                }
                else if (providerId > 0)
                {
                    lst = lst.Where(i => i.Denial.ToLower() == "yes" && i.IsBillable.Value && i.Deleted.ToLower() == "no" && i.PerforingProviderId == providerId).ToList();
                }
                else
                {
                    lst = lst.Where(i => i.Denial.ToLower() == "yes" && i.IsBillable.Value && i.Deleted.ToLower() == "no").ToList();
                }

                List<string> duyBy = new List<string>() { "", "patient" };



                chargesReportDataDTO.TotalSamples = lst.Select(i => i.InvoiceId).Distinct().Count();
                chargesReportDataDTO.ChargesAmount = lst.Sum(i => i.ChargeAmount);
                chargesReportDataDTO.Payments = lst.Sum(i => i.Payment);
                chargesReportDataDTO.FeeAmount = lst.Sum(i => i.FeeAmount);
                chargesReportDataDTO.WriteOffAmount = lst.Sum(i => i.WriteOffAmount);
                chargesReportDataDTO.Adjustments = lst.Where(i => i.Denial.ToLower() == "no").Sum(i => i.Adjustment);
                chargesReportDataDTO.DenialsAmount = lst.Where(i => i.Denial.ToLower() == "yes").Sum(i => i.ChargeAmount);
                chargesReportDataDTO.DueAmount = lst.Where(i => i.Denial.ToLower() == "no").Sum(i => i.DueAmount);


                lst = lst.Where(i => !duyBy.Contains(i.DueBy.ToLower())).ToList();
               // lst = lst.Where(i => i.ClaimSent.ToLower()=="yes" && (Convert.ToDateTime(i.RemitDate)>i.ClaimSentDate.Value)).ToList();

                if (!string.IsNullOrWhiteSpace(filter.ReasonCode))
                {
                    //chargesReportDataDTO.Charges = lst.Where(i=>i.ReasonCode1==filter.ReasonCode || i.ReasonCode2 == filter.ReasonCode || i.ReasonCode3 == filter.ReasonCode || i.ReasonCode3 == filter.ReasonCode);
                    chargesReportDataDTO.Charges = lst.Where(i => (!string.IsNullOrEmpty(i.ReasonCode1) ? i.ReasonCode1.Trim() == filter.ReasonCode : false)
                                           || (!string.IsNullOrEmpty(i.ReasonCode2) ? i.ReasonCode2.Trim() == filter.ReasonCode : false)
                                           || (!string.IsNullOrEmpty(i.ReasonCode3) ? i.ReasonCode3.Trim() == filter.ReasonCode : false)
                                           || (!string.IsNullOrEmpty(i.ReasonCode4) ? i.ReasonCode4.Trim() == filter.ReasonCode : false));
                }
                else
                {
                    chargesReportDataDTO.Charges = lst;
                }

                //var chargeIds = chargesReportDataDTO.Charges.Select(i => i.ChargeId);

                //var query = this.Connection.From<ActionNote>()
                //    .LeftJoin<ActionNote,ActionCategory>((i,j)=>i.ActionSubCategoryId==j.Id)
                //    .Select<ActionNote, ActionCategory>((v,h) => new
                //                 {
                //                     CreatedDate = Sql.Max(v.CreatedDate),
                //                     v.ChargeId,
                //        ActionSubCategoryName=h.CategoryName
                //    }).Where(j => j.NoteSourceCD == "NS.CHARGE" && j.UserName != "System" && j.IsNote == true && chargeIds.Contains(j.ChargeId.Value))
                //                 .GroupBy<ActionNote, ActionCategory>((i,j) => new { i.ChargeId,j.CategoryName });
                //var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                //var noteList= Mapper<ActionNote>.MapList(queryResult);
                //foreach (var item in noteList)
                //{
                //    var chargeRecord = chargesReportDataDTO.Charges.FirstOrDefault(i => i.ChargeId == item.ChargeId);
                //    if(chargeRecord!=null)
                //    {
                //        chargeRecord.CategoryName = item.ActionSubCategoryName;
                //        chargeRecord.LastNoteDate = item.CreatedDate;
                //    }
                //}


                return chargesReportDataDTO;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargesReportDataConsolidate>> GetPatientCharges(string billingId)
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            IEnumerable<IChargesReportDataConsolidate> lstClinic = await this.Connection.SelectAsync<ChargesReportDataConsolidate>(i => i.Deleted.ToLower() == "no" && i.BillingID == billingId && i.DBName == "Clinic");
            IEnumerable<IChargesReportDataConsolidate> lstLab = await this.Connection.SelectAsync<ChargesReportDataConsolidate>(i => i.Deleted.ToLower() == "no" && i.EmrBillingId == billingId && i.DBName == "LAB");
            IEnumerable<IChargesReportDataConsolidate> lstRes = await this.Connection.SelectAsync<ChargesReportDataConsolidate>(i => i.Deleted.ToLower() == "no" && i.BillingID == billingId && i.DBName == "RES");

            var lstlabamount = lstLab.Where(i => i.Denial.ToLower() == "yes").Sum(i => i.DueAmount);

            List<IChargesReportDataConsolidate> lst = new List<IChargesReportDataConsolidate>();
            lst.AddRange(lstClinic);
            lst.AddRange(lstLab);
            lst.AddRange(lstRes);
            return lst;
        }

        public async Task<IEnumerable<IChargesReportDataConsolidate>> GetPatientBalancesList()
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            IEnumerable<IChargesReportDataConsolidate> lst = lst = await this.Connection.SelectAsync<ChargesReportDataConsolidate>(i => i.Deleted.ToLower() == "no" && i.DueAmount != 0 && duyBy.Contains(i.DueBy.ToLower()) && i.IsBillable);
            return lst;
        }

        public async Task<IEnumerable<IChargesReportData>> GetData()
        {
            List<string> duyBy = new List<string>() { "", "patient" };
            return await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value);
        }

        public async Task<IEnumerable<IChargesReportDataConsolidate>> GetConsolidateData()
        {
            var query = this.Connection
                               .From<ChargesReportDataConsolidate>()
                               .Select<ChargesReportDataConsolidate>(c => new
                               {
                                   c

                               }).Where(i => !i.IsSynced.HasValue).Take(5000);

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var lst = Mapper<ChargesReportDataConsolidate>.MapList(dynamics).ToList();

            await this._chargesReportDataConsolidateRepository.Update(lst);
            return lst;
        }

        public async Task<IEnumerable<IPatientBalanceForEMR>> GetPatientBalancesForEMR()
        {

            List<string> duyBy = new List<string>() { "", "patient" };

            var query = this.Connection
                               .From<ChargesReportDataConsolidate>()
                               .Select<ChargesReportDataConsolidate>(c => new
                               {
                                   c.Adjustment,
                                   c.AdjustmentCode,
                                   c.BillingID,
                                   c.ChargeAmount,
                                   c.CptCode,
                                   c.DBName,
                                   c.DOB,
                                   c.DosDate,
                                   c.DueAmount,
                                   c.EmrBillingId,
                                   c.FeeAmount,
                                   c.FirstName,
                                   c.LastName,
                                   c.PatientId,
                                   Provider = c.PerforingProviderName,
                                   c.Payment,c.IsMedicaidCharge
                               }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && i.DueAmount > 0 && duyBy.Contains(i.DueBy.ToLower()));

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var lst = Mapper<PatientBalanceForEMR>.MapList(dynamics).ToList();
            foreach (var item in lst)
            {
                item.FirstName = item.FirstName.ToUpper();
                item.LastName = item.LastName.ToUpper();
            }
            return lst;
        }

        public async Task<IEnumerable<IPatientBalanceForEMR>> GetPatientBalancesForMobileAPP(IMobileInputModel mobileInputModel)
        {
            List<string> duyBy = new List<string>() { "", "patient" };
            List<PatientBalanceForEMR> lstLab = new List<PatientBalanceForEMR>();
            List<PatientBalanceForEMR> lstClinics = new List<PatientBalanceForEMR>();



            if (!string.IsNullOrWhiteSpace(mobileInputModel.BillingId))
            {
                bool isValid = true;
                var validPatient = await this.Connection.SingleAsync<ChargesReportDataConsolidate>(i => i.BillingID == mobileInputModel.BillingId
                && i.DBName != "LAB" && i.DOB == mobileInputModel.DOB);

                if (validPatient == null)
                {
                    isValid = false;
                }

                if (!isValid)
                {
                    validPatient = await this.Connection.SingleAsync<ChargesReportDataConsolidate>(i => i.EmrBillingId == mobileInputModel.BillingId
                        && i.DBName == "LAB" && i.DOB == mobileInputModel.DOB);
                    if (validPatient == null)
                    {
                        throw new Exception("Could not find Patient.");
                    }
                }

                var queryClinic = this.Connection
                               .From<ChargesReportDataConsolidate>()
                               .Select<ChargesReportDataConsolidate>(c => new
                               {
                                   c.Adjustment,
                                   c.AdjustmentCode,
                                   c.BillingID,
                                   c.ChargeAmount,
                                   c.CptCode,
                                   c.DBName,
                                   c.DOB,
                                   c.DosDate,
                                   c.DueAmount,
                                   c.EmrBillingId,
                                   c.FeeAmount,
                                   c.FirstName,
                                   c.LastName,
                                   c.PatientId,
                                   Provider = c.PerforingProviderName,
                                   c.Payment                                   
                               }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no"  && duyBy.Contains(i.DueBy.ToLower())
                               && i.BillingID == mobileInputModel.BillingId && i.DBName != "LAB" && i.DOB == mobileInputModel.DOB 
                               && (i.IsMedicaidCharge==null || i.IsMedicaidCharge==false));

                var dynamicsClinic = await this.Connection.SelectAsync<dynamic>(queryClinic);
                lstClinics = Mapper<PatientBalanceForEMR>.MapList(dynamicsClinic).ToList();

                var queryLab = this.Connection
                                   .From<ChargesReportDataConsolidate>()
                                   .Select<ChargesReportDataConsolidate>(c => new
                                   {
                                       c.Adjustment,
                                       c.AdjustmentCode,
                                       c.BillingID,
                                       c.ChargeAmount,
                                       c.CptCode,
                                       c.DBName,
                                       c.DOB,
                                       c.DosDate,
                                       c.DueAmount,
                                       c.EmrBillingId,
                                       c.FeeAmount,
                                       c.FirstName,
                                       c.LastName,
                                       c.PatientId,
                                       Provider = c.PerforingProviderName,
                                       c.Payment
                                   }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && duyBy.Contains(i.DueBy.ToLower())
                                   && i.EmrBillingId == mobileInputModel.BillingId && i.DBName == "LAB" && i.DOB == mobileInputModel.DOB
                                   && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false));

                var dynamicsLab = await this.Connection.SelectAsync<dynamic>(queryLab);
                lstLab = Mapper<PatientBalanceForEMR>.MapList(dynamicsLab).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(mobileInputModel.LastName))
            {
                var validPatient = await this.Connection.SingleAsync<ChargesReportDataConsolidate>(i => i.LastName == mobileInputModel.LastName && i.DOB == mobileInputModel.DOB);
                if (validPatient == null)
                {
                    throw new Exception("Could not find Patient.");
                }

                var queryClinic = this.Connection
                               .From<ChargesReportDataConsolidate>()
                               .Select<ChargesReportDataConsolidate>(c => new
                               {
                                   c.Adjustment,
                                   c.AdjustmentCode,
                                   c.BillingID,
                                   c.ChargeAmount,
                                   c.CptCode,
                                   c.DBName,
                                   c.DOB,
                                   c.DosDate,
                                   c.DueAmount,
                                   c.EmrBillingId,
                                   c.FeeAmount,
                                   c.FirstName,
                                   c.LastName,
                                   c.PatientId,
                                   Provider = c.PerforingProviderName,
                                   c.Payment
                               }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && duyBy.Contains(i.DueBy.ToLower())
                               && i.LastName == mobileInputModel.LastName && i.DBName != "LAB" && i.DOB == mobileInputModel.DOB
                               && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false));

                var dynamicsClinic = await this.Connection.SelectAsync<dynamic>(queryClinic);
                lstClinics = Mapper<PatientBalanceForEMR>.MapList(dynamicsClinic).ToList();

                var queryLab = this.Connection
                                   .From<ChargesReportDataConsolidate>()
                                   .Select<ChargesReportDataConsolidate>(c => new
                                   {
                                       c.Adjustment,
                                       c.AdjustmentCode,
                                       c.BillingID,
                                       c.ChargeAmount,
                                       c.CptCode,
                                       c.DBName,
                                       c.DOB,
                                       c.DosDate,
                                       c.DueAmount,
                                       c.EmrBillingId,
                                       c.FeeAmount,
                                       c.FirstName,
                                       c.LastName,
                                       c.PatientId,
                                       Provider = c.PerforingProviderName,
                                       c.Payment
                                   }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && i.DueAmount > 0 && duyBy.Contains(i.DueBy.ToLower())
                                   && i.LastName == mobileInputModel.LastName && i.DBName == "LAB" && i.DOB == mobileInputModel.DOB
                                   && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false));

                var dynamicsLab = await this.Connection.SelectAsync<dynamic>(queryLab);
                lstLab = Mapper<PatientBalanceForEMR>.MapList(dynamicsLab).ToList();
            }

            List<PatientBalanceForEMR> lst = new List<PatientBalanceForEMR>();

            lst.AddRange(lstClinics);
            lst.AddRange(lstLab);

            foreach (var item in lst)
            {
                item.FirstName = item.FirstName.ToUpper();
                item.LastName = item.LastName.ToUpper();
                if (item.DBName == "LAB")
                {
                    if (!string.IsNullOrWhiteSpace(item.EmrBillingId))
                    {
                        item.BillingID = item.EmrBillingId;
                    }
                }
            }
            return lst;
        }

        public async Task<IEnumerable<IChargesReportData>> GetChargesForWriteOffLessThanGivingDates(DateTime dosDate)
        {
            List<string> cptCodes = new List<string>() { "H2000", "H2019", "H2017", "H0036", "H0001", "H0004", "H0005", "H0006", "H0048", "T1002", "T1003", "H0015", "H2034", "H2036", "H0020" };

            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < dosDate && i.DueAmount > 0 && i.Deleted.ToLower() == "no" && cptCodes.Contains(i.CptCode));
            return lst;
        }


        public async Task<IEnumerable<IChargesReportData>> GetChargesForWriteOff(DateTime dosDate, string adjustmentCode)
        {
            List<string> adjustList = new List<string>() { adjustmentCode };

            string query = "select * from ChargesReportData where AdjustmentCode like '%" + adjustmentCode + "%' and DueAmount>0 AND DosDate<='" + dosDate + "' and Deleted='NO'";
            var results = await this.Connection.QueryAsync<ChargesReportData>(query);

            //var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < dosDate && i.DueAmount > 0 && i.Deleted.ToLower() == "no" && adjustList.Contains(i.AdjustmentCode));
            return results;
        }

        public async Task<IEnumerable<IChargesReportData>> GetDenialChargesForRebillWherePrimaryPolicyChanged()
        {
            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.Denial.ToLower() == "yes" && i.ChargeAmount == i.DueAmount
            && i.PrimaryInsuranceCompanyId != i.InsuranceCompanyId && i.DueBy.ToLower() == "primary");
            return lst.Where(i => !string.IsNullOrWhiteSpace(i.InsuranceCompanyName) && !i.InsuranceCompanyName.ToLower().Contains("selfpay"));
        }

        public async Task<IEnumerable<IChargesReportData>> GetPatientForStatementOverThreeMonths()
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable == true
            && duyBy.Contains(i.DueBy.ToLower()) && i.DueAmount > 0 && i.PatientStatementCount > 3);

            var result = lst.GroupBy(i => new { i.PatientId, i.PatientName, i.BillingID, i.PatientUId }).Select(g => new ChargesReportData
            {
                PatientId = g.FirstOrDefault().PatientId,
                PatientName = g.FirstOrDefault().PatientName,
                BillingID = g.FirstOrDefault().BillingID,
                PatientUId = g.FirstOrDefault().PatientUId,
                DueAmount = g.Select(i => i.DueAmount).Sum()
            });

            return result.Where(i => i.DueAmount > 500);
        }

        public async Task<string> DailyImportDataStaticsSend()
        {
            var todayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //var todayDate = new DateTime(DateTime.Now.Year, 11, 18);
            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.ChargePostDate ==todayDate.AddDays(-1));
            ;
            var claimErrrlst = await this.Connection.SelectAsync<ClaimStatusEnquiryDTO>(i => lst.Where(m=>m.ClaimId>0).Select(x=>x.ClaimId).ToList().Contains(i.ClaimId));

            int totalClaimErrorCharges = claimErrrlst.Where(i=>!string.IsNullOrWhiteSpace(i.ErrorMessage)).Count();
            decimal totalClaimErrorAmount = lst.Where(i => i.ClaimId>0  && claimErrrlst.Where(m => !string.IsNullOrWhiteSpace(m.ErrorMessage)).Select(x=>x.ClaimId).Contains(i.ClaimId.Value)).Sum(i => i.ChargeAmount);


            int totalCharges = lst.Select(i => i.AccessionNumber).Distinct().Count();
            decimal totalChargesAmount = lst.Sum(i=>i.ChargeAmount);

            int totalDeloitteClaims = lst.Where(i => i.PrimaryCompanyType == "Medicaid" && i.ClaimSent== "Yes" && i.Deleted.ToLower() == "no").Count();
            decimal totalDeloitteClaimsAmount = lst.Where(i => i.PrimaryCompanyType == "Medicaid" && i.ClaimSent == "Yes" && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);

            int totalStediClaims = lst.Where(i => i.PrimaryCompanyType != "Medicaid" && i.ClaimSent == "Yes" && i.Deleted.ToLower() == "no").Count();
            decimal totalStediAmount = lst.Where(i => i.PrimaryCompanyType != "Medicaid" && i.ClaimSent == "Yes" && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);

            int totalNotSentClaims = lst.Where(i => i.ClaimSent == "No" && i.Deleted.ToLower() == "no").Count();
            decimal totalNotSentAmount = lst.Where(i => i.ClaimSent == "No" && i.Deleted.ToLower() == "no").Sum(i => i.ChargeAmount);

            int totalRollUpCharges = lst.Where(i => i.IsRollUp == "Yes").Count();
            decimal totalRollUpChargesAmount = lst.Where(i => i.IsRollUp == "Yes").Sum(i => i.ChargeAmount);

            int totalErrorCharges = lst.Where(i => i.Deleted.ToLower() == "no" && i.ReviewNeeded==true).Count();
            decimal totalErrorChargesAmount = lst.Where(i => i.Deleted.ToLower() == "no" && i.ReviewNeeded == true).Sum(i => i.ChargeAmount);

            int totalRejectedCharges = lst.Where(i => i.IsRejected == true).Count();
            decimal totalRejectedChargesAmount = lst.Where(i => i.IsRejected == true).Sum(i => i.ChargeAmount);


            var practice = await this._practiceRepository.Get();


            MailObject mailObject = new MailObject();
            var toList = new List<MailToObject>();
            string[] emails = practice.DailyChargesEmail.Split(",");                        
            for (int i = 0; i < emails.Length; i++)
            {
                MailToObject mailToObject = new MailToObject();
                mailToObject.ToAddress = emails[i];
                toList.Add(mailToObject);
            }
            mailObject.To = toList;

            if (practice != null && !string.IsNullOrEmpty(practice.SmtpUrl))
            {
                mailObject.SmtpUrl = practice.SmtpUrl;
                mailObject.SmtpPort = practice.SmtpPort;
                mailObject.SmtpUserName = practice.SmtpUserName;
                var _encryptionProvider = new EncryptionProvider();
                mailObject.SmtpPassword = _encryptionProvider.Decrypt(practice.SmtpPassword);
            }

            string logo = ""; // _configuration.GetValue<string>("LogoUrl");
            mailObject.Subject = practice .PracticeName+" Clinic : Daily Charges Import Report " + todayDate.AddDays(-1).ToString("MM/dd/yyyy");


            

            //< p > < img src = '" + logo + @"' target = 'new' /> </ p >
            //< p style = 'font-family:Arial;font-size:13.0px;font-weight:normal;margin: 16.0px' > Dear " + entity.FirstName + " " + entity.LastName + @",</ p >

            string bodyContent = string.Format(@"
            <p style = 'font-family:Arial;font-size:13.0px;font-weight:normal;margin: 16.0px'>Hi,</ p>
            <table style='font-family:Arial;font-size:13.0px;font-weight:normal;margin: 0.0px; border: 1px solid black;'>
            <tr>
                <td style='width:300px; border: 1px solid black;'></td>
                <td style='width:100px; border: 1px solid black; text-align: center;'>Count</td>
                <td style='width:100px; border: 1px solid black;'>Amount</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Total Charges  Imported</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalCharges + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalChargesAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Claims billed from Deloitte</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalDeloitteClaims + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalDeloitteClaimsAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Claims billed from STEDI</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalStediClaims + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalStediAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Error</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalErrorCharges + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalErrorChargesAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Claims not Sent</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalNotSentClaims + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalNotSentAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Roll up</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalRollUpCharges + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalRollUpChargesAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Reject Charges</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalRejectedCharges + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalRejectedChargesAmount,2) + @"</td>
            </tr>
            <tr>
                <td style='width:300px; border: 1px solid black;'>Claim Error</td>
                <td style='border: 1px solid black; text-align: center;'>" + totalClaimErrorCharges + @"</td>
                <td style='border: 1px solid black;'>$" + Math.Round(totalClaimErrorAmount,2) + @"</td>
            </tr>
         </table> 
    <p style='margin-top: 20.0px'></p>            
            <p style='font-family:Arial;font-size:13.0px;font-weight:normal;margin: 16.0px'>Regards,</p>
            <p style='font-family:Arial;font-size:13.0px;font-weight:normal;margin: 16.0px'>The Admin Team</p>
            ");

            mailObject.BodyContent = bodyContent;
            return Utility.SendMail(mailObject, "html", null);

        }

        public async Task<IEnumerable<IChargesReportData>> GetPatientForStatement()
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            firstDayOfMonth = firstDayOfMonth.AddMonths(-1);

            var statmentCharges = await this._chargeStatementCountRepository.GetList();

            var lst = new List<ChargesReportData>();
            lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < firstDayOfMonth && i.Deleted.ToLower() == "no" && i.IsBillable == true && duyBy.Contains(i.DueBy.ToLower()) && i.DueAmount > 0
             && (i.ChargePrimaryCompanyType == null || i.ChargePrimaryCompanyType != "Medicaid")
            && (i.ChargeSecondaryCompanyType == null || i.ChargeSecondaryCompanyType != "Medicaid")
            && (i.ChargeTertiaryCompanyType == null || i.ChargeTertiaryCompanyType != "Medicaid")
            );
            lst = lst.Where(i => !statmentCharges.Contains(i.ChargeId.ToString())).ToList();


            //var result = lst.GroupBy(i => i.PatientId).Select(g => new ChargesReportData
            //{
            //    PatientId=g.FirstOrDefault().PatientId,
            //    DueAmount=g.Select(i=>i.DueAmount).Sum()
            //});            

            return lst;
        }

        public async Task<int> GetPatientForStatementWithOurMedicaid(string patientUid)
        {
            List<string> duyBy = new List<string>() { "", "patient" };
            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.PatientUId== patientUid && i.IsBillable == true && duyBy.Contains(i.DueBy.ToLower())
            && i.DueAmount > 0 
            && (i.ChargePrimaryCompanyType==null || i.ChargePrimaryCompanyType!="Medicaid" )
            && (i.ChargeSecondaryCompanyType ==null|| i.ChargeSecondaryCompanyType != "Medicaid" )
            && (i.ChargeTertiaryCompanyType==null || i.ChargeTertiaryCompanyType!= "Medicaid")
            );

            

            return lst.Count;
        }

        public async Task<IEnumerable<ICharges>> GetPatientChargesForStatements(List<int> patientIds)
        {
            List<string> duyBy = new List<string>() { "", "patient" };

            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            firstDayOfMonth = firstDayOfMonth.AddMonths(-1);
            //var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < firstDayOfMonth && i.Deleted.ToLower() == "no" && i.IsBillable == true && duyBy.Contains(i.DueBy.ToLower()) && i.DueAmount > 0
            //&& patientIds.Contains(i.PatientId));

            var query = this.Connection
                              .From<ChargesReportData>()
                              .Join<ChargesReportData, Charges>((i, j) => j.Id == i.ChargeId)
                              .Select<ChargesReportData, Charges>((c, ch) => new
                              {
                                  Id = c.ChargeId,
                                  PatientStatementCount = Sql.As((ch.PatientStatementCount + 1), "PatientStatementCount"),
                                  c.DueAmount,
                                  c.PatientId
                              }).Where<ChargesReportData>(i => i.DosDate < firstDayOfMonth && i.Deleted.ToLower() == "no" && i.IsBillable == true && duyBy.Contains(i.DueBy.ToLower()) && i.DueAmount > 0
                              && patientIds.Contains(i.PatientId));

            var dynamics = await this.Connection.SelectAsync<dynamic>(query);
            var lst = Mapper<Charges>.MapList(dynamics).ToList();

            return lst;
        }

        public async Task<IEnumerable<IBalanceForEMR>> GetBalancesForMobileAPP()
        {
            List<string> duyBy = new List<string>() { "", "patient" };
            List<BalanceForEMR> lstLab = new List<BalanceForEMR>();
            List<BalanceForEMR> lstClinics = new List<BalanceForEMR>();

            var queryClinic = this.Connection
                              .From<ChargesReportDataConsolidate>()
                              .Select<ChargesReportDataConsolidate>(c => new
                              {                                  
                                  c.BillingID,                                  
                                  c.DueAmount,                                                                    
                                  c.FirstName,
                                  c.LastName,
                                  c.PatientPhone,
                                  c.DOB,
                                  c.DBName
                              }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && i.DueAmount > 0 && duyBy.Contains(i.DueBy.ToLower())
                              && i.DBName != "LAB" && i.DueAmount>0 && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false));

            var dynamicsClinic = await this.Connection.SelectAsync<dynamic>(queryClinic);
            lstClinics = Mapper<BalanceForEMR>.MapList(dynamicsClinic).ToList();

            var queryLab = this.Connection
                              .From<ChargesReportDataConsolidate>()
                              .Select<ChargesReportDataConsolidate>(c => new
                              {
                                  BillingID=c.EmrBillingId,
                                  c.DueAmount,
                                  c.FirstName,
                                  c.LastName,
                                  c.PatientPhone,
                                  c.DOB,
                                  c.DBName
                              }).Where(i => i.IsBillable && i.Deleted.ToLower() == "no" && i.DueAmount > 0 && duyBy.Contains(i.DueBy.ToLower())
                              && i.DBName == "LAB" && i.DueAmount > 0 && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false));

            var dynamicsLab = await this.Connection.SelectAsync<dynamic>(queryLab);
            lstLab = Mapper<BalanceForEMR>.MapList(dynamicsLab).ToList();

            List<BalanceForEMR> lst = new List<BalanceForEMR>();
            lst.AddRange(lstClinics);
            lst.AddRange(lstLab);

            var result = lst.GroupBy(i => new { i.BillingID, i.FirstName, i.LastName, i.PatientPhone,i.DOB,i.DBName }).Select(g => new BalanceForEMR
            {
                BillingID = g.FirstOrDefault().BillingID,
                FirstName = g.FirstOrDefault().FirstName,
                LastName = g.FirstOrDefault().LastName,
                PatientPhone = g.FirstOrDefault().PatientPhone,
                DOB=g.FirstOrDefault().DOB,
                DBName = g.FirstOrDefault().DBName,
                DueAmount = g.Select(i => i.DueAmount).Sum()
            });

            return result;
        }


        public async Task<IEnumerable<IBalanceForEMR>> GetBalancesForEMRWithDuemAmont(decimal dueAmount)
        {
            if(dueAmount==0)
            {
                dueAmount = 100;
            }

            List<string> duyBy = new List<string>() { "", "patient" };
            List<BalanceForEMR> lstLab = new List<BalanceForEMR>();
            List<BalanceForEMR> lstClinics = new List<BalanceForEMR>();

            var queryClinic = this.Connection
                              .From<ChargesReportData>()
                              .Select<ChargesReportData>(c => new
                              {
                                  c.BillingID,
                                  c.DueAmount,
                                  c.FirstName,
                                  c.LastName,                                  
                                  c.DOB,
                                  c.PatientCaseUId,
                                  c.PatientCaseId,
                                  c.DosDate
                              }).Where(i => (i.IsBillable.HasValue && i.IsBillable.Value) && i.Deleted.ToLower()=="no" && i.DueAmount > 0
                              && (i.IsMedicaidCharge == null || i.IsMedicaidCharge == false)
                              && duyBy.Contains(i.DueBy.ToLower()));

            var dynamicsClinic = await this.Connection.SelectAsync<dynamic>(queryClinic);
            lstClinics = Mapper<BalanceForEMR>.MapList(dynamicsClinic).ToList();

            //var caseUIds = string.Join(",", lstClinics.Select(i => i.PatientCaseUId).Distinct()); 

            //var policies = await this._insurancePolicyRepository.GetByPatientCaseUIds(caseUIds);

            //List<BalanceForEMR> finalList = new List<BalanceForEMR>();

            //foreach (var item in lstClinics)
            //{
            //    var findMedicaid = policies.FirstOrDefault(i => i.PlanEffectiveDate <= item.DosDate.Date && i.PatientCaseId==item.PatientCaseId &&
            //       ((i.PlanExpirationDate == null) || (i.PlanExpirationDate.HasValue && i.PlanExpirationDate >= item.DosDate.Date))
            //       && i.InsuranceCompanyTypeId == 4);

            //    if (findMedicaid == null)
            //    {
            //        finalList.Add(item);
            //    }
            //}

            var result = lstClinics.GroupBy(i => new { i.BillingID, i.FirstName, i.LastName, i.DOB }).Select(g => new BalanceForEMR
            {
                BillingID = g.FirstOrDefault().BillingID,
                FirstName = g.FirstOrDefault().FirstName,
                LastName = g.FirstOrDefault().LastName,                
                DOB = g.FirstOrDefault().DOB,
                DueAmount = g.Select(i => i.DueAmount).Sum()
            });

            result = result.Where(i => i.DueAmount > dueAmount);

            foreach (var item in result)
            {
                var unMachedPayments = await this._dynmoPaymentsRepository.GetUnMatchedPaymentsByBillingId(item.BillingID);
                if (unMachedPayments.Count() > 0)
                {
                    item.UnMatchedAmount = unMachedPayments.Sum(i => i.Amount);
                }

                var unPostedAmounts = await this._portalPaymentRepository.GetUnPostedPaymentByPatientId(item.BillingID);
                if (unPostedAmounts.Count() > 0)
                {
                    item.UnPostedAmount = unPostedAmounts.Sum(i => i.Amount);
                }
            }

            return result;
        }

        public async Task<IEnumerable<IChargesReportData>> WriteOffHandTCharges()
        {
            string query = "select top 200 * from ChargesReportData where (CptCode like 'H%' OR CptCode like 'T%') " +
                "and DueAmount>0 and ISNULL(IsMedicaidCharge,0)=0 and DOSDATE<=DATEADD(DAY,-91,GETDATE()) " +
                " AND Deleted='NO' and IsBillable=1 AND InvoiceId not in (SELECT DISTINCT InvoiceId FROM WriteOffTHCode)";
            var results = await this.Connection.QueryAsync<ChargesReportData>(query);

            //var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < dosDate && i.DueAmount > 0 && i.Deleted.ToLower() == "no" && adjustList.Contains(i.AdjustmentCode));
            return results;
        }

        public async Task<IEnumerable<IChargesReportData>> GetChargesForMakeClaims_BilledVsCurrentIns()
        {
            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.Deleted.ToLower() == "no" && i.IsBillable.Value && i.ChargeAmount == i.DueAmount
               && i.ClaimId > 0 && i.Denial.ToLower() == "yes" && !i.SecondaryInsuranceCompanyId.HasValue && i.InsuranceCompanyId > 0
               && i.PrimaryInsuranceCompanyId != i.InsuranceCompanyId && i.DueBy.ToLower()=="primary" && i.ReviewNeeded==false);
            lst = lst.Where(i => !i.InsuranceCompanyName.ToLower().Contains("hold")).ToList();
            lst = lst.Where(i => !i.InsuranceCompanyName.ToLower().Contains("self")).ToList();

            var tCodes = lst.Where(i => i.CptCode.StartsWith("T"));
            var hCodes = lst.Where(i => i.CptCode.StartsWith("H"));

            List<ChargesReportData> ingoreTCodes = new List<ChargesReportData>();
            foreach (var item in tCodes)
            {
                if (item.PrimaryInsuranceCompanyId != item.InsuranceCompanyId)
                {
                    if (item.PrimaryInsuranceCompanyId == item.ChargeSecondaryCompanyId)
                    {
                        ingoreTCodes.Add(item);
                    }
                }
            }
            lst = lst.Except(ingoreTCodes).ToList();

            List<ChargesReportData> ingoreHCodes = new List<ChargesReportData>();
            foreach (var item in hCodes)
            {
                if (item.PrimaryInsuranceCompanyId != item.InsuranceCompanyId)
                {
                    if (item.PrimaryInsuranceCompanyId == item.ChargeSecondaryCompanyId)
                    {
                        ingoreHCodes.Add(item);
                    }
                }
            }
            lst = lst.Except(ingoreHCodes).ToList();

            lst = lst.Where(i => i.ClaimSent.ToLower() == "yes" && (Convert.ToDateTime(i.RemitDate) > i.ClaimSentDate.Value)).ToList();

            return lst;
        }

        public async Task<IEnumerable<IChargesReportData>> GetOldPatientDueCharges(DateTime dosDate)
        {
            List<string> duyBy = new List<string>() { "", "patient" };
            var lst = await this.Connection.SelectAsync<ChargesReportData>(i => i.DosDate < dosDate && i.DueAmount > 0 && i.Deleted.ToLower() == "no" 
            && duyBy.Contains(i.DueBy));
            return lst;
        }
    }
}
