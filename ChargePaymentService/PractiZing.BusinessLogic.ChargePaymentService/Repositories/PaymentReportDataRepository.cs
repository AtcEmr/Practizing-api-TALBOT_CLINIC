using AutoMapper;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
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
    public class PaymentReportDataRepository : ModuleBaseRepository<PaymentReportData>, IPaymentReportDataRepository
    {
        private IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        private IPlaidPaymentRepository _plaidPaymentRepository;
        private readonly IMapper _mapper;
        public PaymentReportDataRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                      IConfigERARemarkCodesRepository configERARemarkCodesRepository,
                                      IPlaidPaymentRepository plaidPaymentRepository,
                                      IMapper mapper)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
            this._plaidPaymentRepository = plaidPaymentRepository;
            this._mapper = mapper;
        }
       

        public async Task<IPaymentReportDataDTO> Get(IPaymentReportDataFilterDTO filter)
        {
            try
            {
                PaymentReportDataDTO paymentReportDataDTO = new PaymentReportDataDTO();
                if (filter != null)
                {
                    filter.FromDate = (filter.FromDate != null || filter.FromDate != string.Empty) ? Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00") : filter.FromDate;
                    filter.ToDate = (filter.ToDate != null || filter.ToDate != string.Empty) ? Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59") : filter.ToDate;                    
                }
                List<PaymentReportData> lst = new List<PaymentReportData>();
                object[] parameters=new object[] {filter.FromDate, filter.ToDate };
                

                lst= (await base.ExecuteStoredProcedureAsync<PaymentReportData>("usp_GetPaymentWareHouseReportData", parameters)).ToList();

                //var query = this.Connection
                //            .From<PaymentReportData>()
                //            .Select<PaymentReportData>
                //            ((p) => new
                //            {
                //                p.Id,
                //                p.ChargeId,
                //                p.ChargePostDate,
                //                p.DosDate,
                //                p.CptCode,
                //                p.Description,
                //                p.ChargeRowNumber,
                //                p.ChargeAmount,
                //                p.Payment,
                //                p.Adjustment,
                //                Aging = p.AgingByPostDate,
                //                AgingText = p.AgingByPostDateText,
                //                p.PaymentPostDate,
                //                p.RemitDate,
                //                p.BillingID,
                //                p.FirstName,
                //                p.LastName,
                //                p.DOB,
                //                p.PatientId,
                //                p.PatientUId,
                //                p.InvoiceUId,
                //                p.PatientCaseUId,
                //                p.PerformingProviderUId,
                //                p.PatientName,
                //                p.AccessionNumber,
                //                p.AgingByPostDate,
                //                p.InvoiceId,
                //                p.DepositType,
                //                p.IsAccounted,
                //                p.HasDenial

                //            }).Where<PaymentReportData>(i =>  i.RemitDate >= Convert.ToDateTime(filter.FromDate) && i.RemitDate <= Convert.ToDateTime(filter.ToDate));

                //var dynamics = await this.Connection.SelectAsync<dynamic>(query);
                //lst = Mapper<PaymentReportData>.MapList(dynamics).ToList();

                //var lstChargeIds = lst.Select(i => i.ChargeId).Distinct();

                //foreach (var item in lstChargeIds)
                //{
                //    var chargeRowNumber = lst.Where(i => i.ChargeId == item).Min(i=>i.ChargeRowNumber);
                //    foreach (var charge in lst.Where(i => i.ChargeId == item && i.ChargeRowNumber>chargeRowNumber))
                //    {
                //        charge.ChargeAmount = 0;
                //    }
                    
                //}

                paymentReportDataDTO.TotalSamples = lst.Select(i => i.ChargeId).Distinct().Count();
                paymentReportDataDTO.ChargesAmount = lst.Where(i=>i.ChargeRowNumber==1).Sum(i => i.ChargeAmount);
                paymentReportDataDTO.Payments = lst.Sum(i => i.Payment);
                paymentReportDataDTO.Adjustments = lst.Where(i=>i.IsAccounted==true && i.HasDenial==false).Sum(i => i.Adjustment);
                paymentReportDataDTO.DenialsCount = lst.Where(i => i.HasDenial == true).Select(i=>i.ChargeId).Distinct().Count();
                paymentReportDataDTO.Charges = lst;
                paymentReportDataDTO.BankDeposits = await this._plaidPaymentRepository.GetDepositsAmount(Convert.ToDateTime(filter.FromDate), Convert.ToDateTime(filter.ToDate));

                var results = lst.Select(x => new
                {
                    x.ChargeId,
                    x.Payment
                }).GroupBy(i => new
                {
                    i.ChargeId
                }).Where(i => i.Sum(x => x.Payment) == 0).Distinct().Count();

                paymentReportDataDTO.ZeroPaymentSamples = results;

                return paymentReportDataDTO;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private class ZeroPayment
        {
            public int ChargeCount { get; set; }
        }
    }
}
