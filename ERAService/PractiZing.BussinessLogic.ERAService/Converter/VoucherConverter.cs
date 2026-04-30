using Microsoft.Extensions.Logging;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Converter
{
    public interface IVoucherConverter
    {
        Task<IVoucher> IniIVoucher(IERAClaim eRAClaims, IERARoot eRARoot, IPaymentBatch paymentBatch, IInsuranceCompany insuranceCompany);
        Task<IVoucher> Get(int paymentUId);
        Task<IVoucher> GetByCheckNumber(string checkNumber);
    }

    public class VoucherConverter : IVoucherConverter
    {

        private readonly ILogger _logger;
        private readonly IERAClaimRepository _iERAClaimRepository;
        public readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        public readonly IVoucherRepository _voucherRepository;
        public readonly IMonthEndCloseRepository _monthEndCloseRepository;

        public VoucherConverter(ILogger<VoucherConverter> logger,
                               IERAClaimRepository iERAClaimRepository,
                               IInsuranceCompanyRepository insuranceCompanyRepository,
                               IMonthEndCloseRepository monthEndCloseRepository,
                               IVoucherRepository voucherRepository)
        {
            this._logger = logger;
            this._iERAClaimRepository = iERAClaimRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._voucherRepository = voucherRepository;
            this._monthEndCloseRepository = monthEndCloseRepository;
        }

        public async Task<IVoucher> IniIVoucher(IERAClaim eRAClaims, IERARoot eRARoot, IPaymentBatch paymentBatch, IInsuranceCompany insuranceCompany)
        {
            try
            {
                IVoucher result = null;
                _logger.LogInformation("insurance company exists with this name or not.");
                _logger.LogInformation("if yes then create voucher object");

                //var insuranceCompany = await this._insuranceCompanyRepository.GetInsuranceCompany(null, eRARoot.InsuranceCompanyName);

                if (insuranceCompany != null)
                {
                    var voucherDetail = await this.GetByCheckNumber(eRARoot.CheckNumber);
                    Voucher voucher = new Voucher();
                    voucher.Id = voucherDetail == null ? 0 : voucherDetail.Id;
                    voucher.UId = voucherDetail == null ? new Guid() : voucherDetail.UId;
                    voucher.Amount = eRARoot.EraPayment;// voucherDetail == null ? eRAClaims.ClaimPaymentAmount : (voucherDetail.Amount + eRAClaims.ClaimPaymentAmount);
                    //voucher.Amount = voucherDetail == null ? eRAClaims.ClaimPaymentAmount : voucherDetail.Amount + eRAClaims.ClaimPaymentAmount;
                    voucher.DepositTypeId = eRARoot.PaymentMethod.ToLower() == "chk" ? (short)DepositTypeEnum.ClinicMailChecks : eRARoot.PaymentMethod.ToLower() == "ach" ? (short)DepositTypeEnum.ClinicEFT : (short)0;
                    voucher.Description = voucher.InsuranceCompanyId == null ? null : DateTime.Now.ToShortDateString().Replace("/","-")+(await this._insuranceCompanyRepository.GetById(voucher.InsuranceCompanyId)).CompanyName;

                    DateTime date = eRARoot.PaymentEffectiveDate == null ? DateTime.Now : eRARoot.PaymentEffectiveDate.ToString().Contains("-") 
                                    ? await this.ConvertDateTime(eRARoot.PaymentEffectiveDate) : 
                                    DateTime.ParseExact(eRARoot.PaymentEffectiveDate, "yyyyMMdd", CultureInfo.InvariantCulture);

                    voucher.EffectiveDate = date;
                    voucher.CreatedDate = date;

                    //if (voucher.EffectiveDate != null)
                    //{
                    //    int year = voucher.EffectiveDate.Year;
                    //    int month = voucher.EffectiveDate.Month;
                    //    var monthEndStatus = await this._monthEndCloseRepository.GetByDateId(month, year);
                    //    DateTime lastDay = new DateTime(voucher.EffectiveDate.Year, voucher.EffectiveDate.Month, 1).AddMonths(1).AddDays(-1);

                    //    // tEntity.EffectiveDate = monthEndStatus == null ? tEntity.EffectiveDate.Month < DateTime.Now.Month ? lastDay.Date : tEntity.EffectiveDate : lastDay.Date;
                    //    voucher.EffectiveDate = voucher.EffectiveDate.Month < DateTime.Now.Month ? monthEndStatus == null ? DateTime.Now.Date : lastDay.Date : voucher.EffectiveDate;
                    //}

                    voucher.InsuranceCompanyId = insuranceCompany.Id;
                    voucher.InsuranceCompanyName = eRARoot.InsuranceCompanyName;
                    voucher.IsCommitted = false;
                    voucher.IsSelfPayment = false;
                    voucher.PatientId = null;
                    voucher.PaymentBatchId = paymentBatch.Id;
                    voucher.PaymentSourceCD = PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                    voucher.ReferenceDate = voucher.EffectiveDate.Date;
                    voucher.ReferenceNo = eRARoot.CheckNumber;
                    voucher.VoucherTypeCD = VoucherTypeEnum.PAYMENT.ToString();
                    voucher.VoucherNo = await this._voucherRepository.CreateVoucherNo();

                    //result = await this._voucherRepository.AddNew(voucher);
                    return voucher;
                }
                else
                {
                    _logger.LogInformation("if insurance company doesn't exists with this name. then error log update in voucher table and error will throw on era service.");
                    throw new Exception("No Insurance company exist's with this company name =" + eRARoot.InsuranceCompanyName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IVoucher> GetByCheckNumber(string checkNumber)
        {
            return await this._voucherRepository.GetByCheckNumber(checkNumber);
        }

        public async Task<IVoucher> Get(int Id)
        {
            return await this._voucherRepository.Get(Id);
        }

        private async Task<DateTime> ConvertDateTime(string dateTime)
        {
            CultureInfo culture = new CultureInfo("en-US");
            DateTime tempDate = Convert.ToDateTime(dateTime, culture);

            return tempDate;
        }
    }
}
