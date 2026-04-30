using Newtonsoft.Json;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class PortalPaymentService : IPortalPaymentService
    {
        private IPaymentAdjustmentRepository _paymentAdjustmentRepository;
        private IPaymentChargeRepository _paymentChargeRepository;
        private IReportRepository _reportRepository;
        private IPatientRepository _patientRepository;
        private IPatientCaseRepository _patientCaseRepository;
        private IPaymentRepository _paymentRepository;
        private IVoucherRepository _voucherRepository;
        private IPaymentBatchRepository _paymentBatchRepository;
        private IPracticeRepository _practiceRepository;
        private IPortalPaymentRepository _portalPaymentRepository;
        private IChargesRepository _chargesRepository;
        private IInvoiceRepository _invoiceRepository;
        private IHistoryPaymentRepository _historyPaymentRepository;
        IDynmoPaymentsRepository _dynmoPaymentsRepository;
        private readonly IPortalPaymentChildRepository _portalPaymentChildRepository;
        private readonly ITransactionProvider _transactionProvider;
        public PortalPaymentService(IVoucherRepository voucherRepository,
                                    IPaymentRepository paymentRepository,
                                    IPatientRepository patientRepository,
                                    IPatientCaseRepository patientCaseRepository,
                                    IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                    IPaymentBatchRepository paymentBatchRepository,
                                    IPaymentChargeRepository paymentChargeRepository,
                                    IPortalPaymentRepository portalPaymentRepository,
                                    IChargesRepository chargesRepository,
                                    IInvoiceRepository invoiceRepository,
                                    IHistoryPaymentRepository historyPaymentRepository,
                                    IDynmoPaymentsRepository dynmoPaymentsRepository,
                                    IPortalPaymentChildRepository portalPaymentChildRepository,
                                    IPracticeRepository practiceRepository,
                                    ITransactionProvider transactionProvider,
                                    IReportRepository reportRepository)
        {
            this._reportRepository = reportRepository;
            this._practiceRepository = practiceRepository;
            this._portalPaymentChildRepository = portalPaymentChildRepository;
            this._voucherRepository = voucherRepository;
            this._paymentRepository = paymentRepository;
            this._patientCaseRepository = patientCaseRepository;
            this._patientRepository = patientRepository;
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._paymentBatchRepository = paymentBatchRepository;
            this._paymentChargeRepository = paymentChargeRepository;
            this._portalPaymentRepository = portalPaymentRepository;
            this._chargesRepository = chargesRepository;
            this._invoiceRepository = invoiceRepository;
            this._historyPaymentRepository = historyPaymentRepository;
            this._dynmoPaymentsRepository = dynmoPaymentsRepository;
            this._transactionProvider = transactionProvider;
        }

        public async Task<IEnumerable<IPortalPayment>> Get(IPortalPaymentFilterDTO filter)
        {
            var list=await this._portalPaymentRepository.Get(filter);
            List<int> needsToCommit = new List<int>();
            var paymentList = await this.GetChargesForPortalPaymentNew(list.Select(i=>i.Id).ToList());
            foreach (var item in list)
            {
                if (!item.LabAmount.HasValue)
                {
                    item.LabAmount = 0;
                }

                if (paymentList.Where(i=>i.PortalPaymentId==item.Id).Count() > 0)
                {
                    item.PostedAmount = paymentList.Where(i => i.PortalPaymentId == item.Id).Sum(i => i.PaidAmount);
                    item.RefundAmount = item.Amount - item.PostedAmount.Value;
                    if(item.PostedAmount==item.Amount && item.IsCommitted==false)
                    {
                        needsToCommit.Add(item.Id);
                    }
                }
                else
                {
                    item.PostedAmount = 0;
                    item.RefundAmount = item.Amount;
                }
               // item.PostedAmount = 0;
            }
            if(needsToCommit.Count>0)
            {
                await this._portalPaymentRepository.UpdateIsCommmited(needsToCommit);
            }

            return list;
        }

        public async Task<IEnumerable<IPortalPayment>> GetPatientPayments(Guid guid)
        {
            var patientData = await this._patientRepository.Get(guid);
            return await this._portalPaymentRepository.Get(patientData.Id);
        }

        public async Task<IEnumerable<IPortalPayment>> GetPatientPaymentsForEMR(string emrPatientId)
        {
            var patientData = await this._patientRepository.PatientByBillingId(emrPatientId.ToString());
            return await this._portalPaymentRepository.Get(patientData.Id);
        }

        public async Task<string> RefundChargeByChargeId(string chargeid, string reasons)
        {
            try
            {
                //var cardPaymentResponse = await this._portalPaymentRepository.RefundChargeByChargeId(chargeid, reasons);

                return "Success";
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPortalPayment> RefundPortalPayment(IRefundPaymentDTO entity)
        {
            try
            {

                var refPayment = await this._portalPaymentRepository.Get(entity.UId);

                var patientData = await this._patientRepository.Get(refPayment.PatientId);

                var cardPaymentResponse = await this._portalPaymentRepository.RefundCharge(refPayment, entity.RefundAmount, entity.Reasons);

                PortalPayment obj = new PortalPayment();

                if (cardPaymentResponse.Status == "succeeded")
                {

                    var stripeResponse = cardPaymentResponse.StripeResponse.ResponseJson;

                    var rootobject = JsonConvert.DeserializeObject<PractiZing.DataAccess.Stripe.Rootobject>(stripeResponse);
                    if (rootobject != null)
                    {
                        obj.ReceiptNumber = rootobject.receipt_number == null ? "" : rootobject.receipt_number.ToString();
                    }
                    obj.Amount = entity.RefundAmount;
                    obj.Reasons = entity.Reasons;
                    obj.PatientUId = patientData.UId;
                    obj.ApplicationId = cardPaymentResponse.BalanceTransactionId;
                    obj.CardId = refPayment.CardId;
                    obj.StripeResponse = cardPaymentResponse.Status;
                    obj.ResponseJson = stripeResponse;
                    obj.ChargeId = cardPaymentResponse.Id;
                    obj.IsRefund = true;
                    obj.RefChargeId = refPayment.ChargeId;

                    var objPayment = await this._portalPaymentRepository.AddNew(obj);
                    if (refPayment.IsRefundNeeded.HasValue && refPayment.IsRefundNeeded.Value)
                        await this._portalPaymentRepository.UpdateRefundMade(refPayment.UId);

                    return objPayment;

                }

                return null;
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> AddNewPayment(Guid portalPaymentUId)
        {
            try
            {
                var portalPayment = await this._portalPaymentRepository.Get(portalPaymentUId);

                if (portalPayment != null)
                {
                    var patientCase = await this._patientCaseRepository.GetPatients(portalPayment.PatientId);
                    int[] patientCaseIds = patientCase.Select(i => i.Id).ToArray();

                    var invoiceData = await this._invoiceRepository.Get(patientCaseIds);
                    int[] invoiceIds = invoiceData.Select(i => i.Id).ToArray();

                    var chargesData = await this._chargesRepository.GetChargeView(invoiceIds);
                    List <string> dueByList= new List<string>() { "","patient"};
                    chargesData = chargesData.Where(i => dueByList.Contains(i.DueByFlagCD.ToLower()));

                    var dueCharges = chargesData.Where(i => i.DueAmount > 0 );

                    decimal portalPaymentAmount = 0;

                    if (portalPayment.RefundAmount > 0)
                    {
                        portalPaymentAmount = portalPayment.RefundAmount;
                    }
                    else
                    {
                        portalPaymentAmount = portalPayment.Amount;
                    }


                    if (dueCharges.Count() == 0)
                    {

                        await this._portalPaymentRepository.UpdateRefundAmount(portalPaymentUId, portalPaymentAmount);
                        await this._portalPaymentRepository.ThrowRefundException("There are no charges for adjust this payment as due by Patient. Please refund the money.");
                        //throw new Exception("There are no charges for adjust this payment. Please refund the money.");                        
                    }

                    var chargesDueAmountSum = chargesData.Where(i => i.DueAmount > 0).Sum(i => i.DueAmount);
                    decimal tempdueAmount = 0;

                    


                    if (portalPaymentAmount > chargesDueAmountSum)
                    {
                        tempdueAmount = chargesDueAmountSum;
                        await this._portalPaymentRepository.UpdateRefundAmount(portalPaymentUId, (portalPaymentAmount - chargesDueAmountSum));
                    }
                    else
                    {
                        if(portalPayment.RefundAmount>0)
                        await this._portalPaymentRepository.UpdateRefundAmount(portalPaymentUId, 0);
                    }

                    var paymentBatchObject = await this.IniIPaymentBatch(tempdueAmount == 0 ? portalPaymentAmount : tempdueAmount);
                    var paymentBatch = await this._paymentBatchRepository.AddNew(paymentBatchObject);

                    var voucherObject = await this.IniIVoucher(paymentBatch, portalPayment.PatientId);
                    var voucherData = await this._voucherRepository.AddNewBulkAdjsutment(voucherObject);

                    var paymentObject = await this.InitPayment(voucherData, portalPayment.PatientId);
                    var paymentData = await this._paymentRepository.AddNew(paymentObject);

                    var paymentChargesObject = await this.InitPaymentCharge(chargesData, tempdueAmount == 0 ? portalPaymentAmount : tempdueAmount, paymentData.Id);

                    await this._paymentChargeRepository.AddAll(paymentChargesObject);

                    PortalPaymentChild portalPaymentChild = new PortalPaymentChild();
                    portalPaymentChild.PaymentId = paymentData.Id;
                    portalPaymentChild.PortalPaymentId = portalPayment.Id;
                    await this._portalPaymentChildRepository.AddNew(portalPaymentChild);

                    //int[] dueChargesIds = paymentChargesObject.Where(i => i.IsChargeDue).Select(i => i.ChargeId).ToArray();
                    //int[] nonDueChargesIds = paymentChargesObject.Where(i => !i.IsChargeDue).Select(i => i.ChargeId).ToArray();

                    //await this._chargesRepository.UpdateDueBy(dueChargesIds, true);
                    //await this._chargesRepository.UpdateDueBy(nonDueChargesIds, true);
                    await this._portalPaymentRepository.UpdatePaymentId(portalPaymentUId, paymentData.Id, tempdueAmount==0?true:false);
                    //await this._portalPaymentRepository.Update(portalPaymentUId);

                    return 1;
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentBatch> IniIPaymentBatch(decimal amount)
        {
            PaymentBatch paymentBatchEntity = new PaymentBatch();
            paymentBatchEntity.Id = 0;
            paymentBatchEntity.BatchAmount = amount;
            paymentBatchEntity.Amount = amount;
            paymentBatchEntity.RecordCount = 0;
            paymentBatchEntity.IsSystem = true;

            return paymentBatchEntity;
        }

        public async Task<IVoucher> IniIVoucher(IPaymentBatch paymentBatch, int patientId)
        {
            try
            {
                Voucher voucher = new Voucher();
                voucher.Amount = paymentBatch.BatchAmount;
                voucher.DepositTypeId = (short)DepositTypeEnum.ClinicCreditCards;
                voucher.Description = DateTime.Now.ToShortDateString().Replace("/", "-");
                voucher.EffectiveDate = DateTime.Now;
                voucher.CreatedDate = DateTime.Now;

                voucher.InsuranceCompanyId = null;
                voucher.InsuranceCompanyName = null;
                voucher.IsCommitted = false;
                voucher.IsSelfPayment = true;
                voucher.PatientId = patientId;
                voucher.PaymentBatchId = paymentBatch.Id;
                voucher.PaymentSourceCD = PaymentSourceTypeEnum.ERA_PAYMENT.ToString();
                voucher.ReferenceDate = voucher.EffectiveDate.Date;
                voucher.ReferenceNo = "CardPayment";
                voucher.VoucherTypeCD = VoucherTypeEnum.PAYMENT.ToString();
                voucher.VoucherNo = await this._voucherRepository.CreateVoucherNo();

                return voucher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IVoucher> IniIVoucher(IPaymentBatch paymentBatch, int patientId,decimal amount)
        {
            try
            {
                Voucher voucher = new Voucher();
                voucher.Amount = amount;
                voucher.DepositTypeId = (short)DepositTypeEnum.ClinicCreditCards;
                voucher.Description = DateTime.Now.ToShortDateString().Replace("/", "-");
                voucher.EffectiveDate = DateTime.Now;
                voucher.CreatedDate = DateTime.Now;

                voucher.InsuranceCompanyId = null;
                voucher.InsuranceCompanyName = null;
                voucher.IsCommitted = false;
                voucher.IsSelfPayment = true;
                voucher.PatientId = patientId;
                voucher.PaymentBatchId = paymentBatch.Id;
                voucher.PaymentSourceCD = PaymentSourceTypeEnum.CARD_PAYMENT.ToString();
                voucher.ReferenceDate = voucher.EffectiveDate.Date;
                voucher.ReferenceNo = "CardPayment";
                voucher.VoucherTypeCD = VoucherTypeEnum.PAYMENT.ToString();
                voucher.VoucherNo = await this._voucherRepository.CreateVoucherNo();

                return voucher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IPayment> InitPayment(IVoucher voucher, int patientId)
        {
            try
            {
                Payment payment = new Payment();

                payment.Id = 0;
                payment.IsCommitted = true;
                payment.NonAccAdjustment = 0;
                payment.PatientId = patientId;
                payment.TransactionNo = await this._voucherRepository.CreateTransactionNo();
                payment.VoucherId = voucher.Id;
                payment.Adjustment = 0;
                payment.Amount = voucher.Amount;
                payment.IsReversed = false;
                payment.PaymentSourceCD = PaymentSourceTypeEnum.CARD_PAYMENT.ToString();
                payment.PatientInsuranceCompanyId = 0;
                payment.DepositInsuranceCompanyId = null;
                payment.NonAccAdjustment = 0;
                payment.PayorControl = "";

                //var paymentReturn = await this._paymentRepository.AddNew(payment);
                //return paymentReturn;

                return payment;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentCharge>> InitPaymentCharge(IEnumerable<ICharges> charges, decimal amount, int paymentId)
        {
            try
            {
                List<IPaymentCharge> paymentChargesList = new List<IPaymentCharge>();
                charges = charges.Where(i => i.DueAmount > 0);

                foreach (var item in charges.OrderBy(i=>i.BillFromDate))
                {
                    if (amount == 0)
                        break;

                    PaymentCharge paymentCharge = new PaymentCharge();
                    paymentCharge.Id = 0;
                    paymentCharge.PaymentId = paymentId;
                    paymentCharge.ChargeId = item.Id;
                    paymentCharge.PaidAmount = amount >= item.DueAmount ? item.DueAmount : amount;
                    amount = amount >= item.DueAmount ? amount - item.DueAmount : 0;
                    paymentCharge.IsChargeDue = amount >= item.DueAmount ? false : true;

                    paymentChargesList.Add(paymentCharge);
                }

                return paymentChargesList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentCharge>> InitPaymentChargeForCopay(IEnumerable<IPostedCharges> charges, decimal amount, int paymentId)
        {
            try
            {
                List<IPaymentCharge> paymentChargesList = new List<IPaymentCharge>();
                charges = charges.Where(i => i.OnlinePostedAmount > 0);

                foreach (var item in charges)
                {
                    if (amount == 0)
                        break;

                    PaymentCharge paymentCharge = new PaymentCharge();
                    paymentCharge.PaidAmount = item.OnlinePostedAmount;
                    paymentCharge.Id = 0;
                    paymentCharge.PaymentId = paymentId;
                    paymentCharge.ChargeId = item.Id;
                    
                    //paymentCharge.IsChargeDue = amount >= item.DueAmount ? false : true;

                    paymentChargesList.Add(paymentCharge);
                }

                return paymentChargesList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentCharge>> InitPaymentChargeForCopay_BackUp(IEnumerable<ICharges> charges, decimal amount, int paymentId)
        {
            try
            {
                List<IPaymentCharge> paymentChargesList = new List<IPaymentCharge>();
                charges = charges.Where(i => i.DueAmount > 0);

                foreach (var item in charges)
                {
                    if (amount == 0)
                        break;

                    PaymentCharge paymentCharge = new PaymentCharge();
                    if (amount > item.DueAmount)
                    {
                        if (charges.Count() == 1)
                        {
                            paymentCharge.PaidAmount = amount;
                        }
                        else
                        {
                            paymentCharge.PaidAmount = item.DueAmount;
                            amount = amount - item.DueAmount;
                        }
                    }
                    else
                    {
                        paymentCharge.PaidAmount = amount;
                        amount = 0;
                    }
                    paymentCharge.Id = 0;
                    paymentCharge.PaymentId = paymentId;
                    paymentCharge.ChargeId = item.Id;

                    paymentCharge.IsChargeDue = amount >= item.DueAmount ? false : true;

                    paymentChargesList.Add(paymentCharge);
                }

                return paymentChargesList;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetHelpDeskPayments()
        {
            var list = await this._historyPaymentRepository.Find();

            //var test = list.Where(i => i.Phone == "+16147363058");

            List<IDynmoPayments> paymentList = new List<IDynmoPayments>();
            foreach (var item in list)
            {
                try
                {
                    if (item.Amount != null)
                        item.Amount = item.Amount.Replace("$", "");
                    DynmoPayments payment = new DynmoPayments();
                    payment.AccountNumber = item.AccountNumber;
                    payment.Amount = item.Amount;
                    payment.DOB = item.DOB;
                    payment.HistoryPaymentId = item.ID;
                    payment.PaymentConfirmationCode = item.PaymentConfirmationCode;
                    payment.Phone = item.Phone;
                    payment.TransactionDate = item.Date;//Convert.ToDateTime(item.Date.Substring(0, 15)).ToShortDateString();
                    payment.TransactionId = item.TransactionID;

                    bool badRecord = false;
                    string errorMessage = "";
                    if (string.IsNullOrWhiteSpace(item.TransactionID))
                    {
                        badRecord = true;
                        errorMessage += "TransactionID";
                    }
                    if (string.IsNullOrWhiteSpace(item.PaymentConfirmationCode))
                    {
                        badRecord = true;
                        errorMessage += errorMessage.Length > 0 ? "-PaymentConfirmation" : "PaymentConfirmation";
                    }
                    else
                    {
                        if (item.AccountNumber == null || item.AccountNumber == "1")
                        {
                            badRecord = true;
                            errorMessage += errorMessage.Length > 0 ? "-AccountNumber" : "AccountNumber";
                        }
                        if (item.Amount == null)
                        {
                            badRecord = true;
                            errorMessage += errorMessage.Length > 0 ? "-Amount" : "Amount";
                        }
                    }
                    if (badRecord)
                    {
                        payment.IsBadRecord = true;
                        payment.ErrorMessage = errorMessage;
                    }


                    var objDynmo = await _dynmoPaymentsRepository.AddNew(payment);

                    if (!badRecord)
                    {
                        paymentList.Add(objDynmo);
                    }

                    await this._historyPaymentRepository.Update(item.ID);
                }
                catch (Exception ex)
                {

                }

            }

            await SaveDatainPortalPaymentTables(paymentList);


            return 0;
        }

        public async Task<int> SaveDatainPortalPaymentTables(List<IDynmoPayments> list)
        {
            try
            {
                foreach (var item in list)
                {

                    try
                    {
                        PortalPayment obj = new PortalPayment();

                        int number;
                        bool isNumeric = int.TryParse(item.AccountNumber, out number);

                        DateTime date;

                        bool isDate = DateTime.TryParseExact(item.DOB, "yyyy-dd-MM", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out date);
                        if(!isDate)
                        {
                            isDate= DateTime.TryParse(item.DOB,  out date);
                        }


                        if (isNumeric && isDate)
                        {
                            Base.Entities.PatientService.IPatient patientData = null;
                            if (!string.IsNullOrEmpty(item.EmrAccountNumber))
                            {
                                patientData = await this._patientRepository.GetForDynmoWithEmrPatientId(item.EmrAccountNumber, date.ToShortDateString());                                
                            }
                            else
                            {
                                patientData = await this._patientRepository.GetForDynmoWithEmrPatientId(number.ToString(), date.ToShortDateString());
                            }
                           

                            if (patientData == null)
                            {
                                await this._dynmoPaymentsRepository.UpdateException(item.Id, "Patient Does not exist.");
                                continue;
                            }
                            obj.Amount = Convert.ToDecimal(item.Amount.Replace("$", ""));
                            obj.Reasons = "";
                            obj.ApplicationId = item.TransactionId;
                            obj.CardId = "";
                            obj.DosDate = item.DosDate; 
                            obj.StripeResponse = "";
                            obj.ResponseJson = "";
                            obj.ChargeId = item.PaymentConfirmationCode;
                            obj.IsRefund = false;
                            obj.RefChargeId = "";
                            obj.LocationName = item.LocationName;
                            if (item.HistoryPaymentId!=null && item.HistoryPaymentId != "TALBOT")
                            {

                                DateTime dosdate;
                                bool isDosDate = DateTime.TryParseExact(item.TransactionDate, "MM/dd/yyyy", new System.Globalization.CultureInfo("en-US"), System.Globalization.DateTimeStyles.None, out dosdate);
                                if(isDosDate)
                                {
                                    obj.CreatedDate = dosdate;
                                }
                                else
                                {
                                    //obj.CreatedDate = Convert.ToDateTime(item.TransactionDate.Substring(0, 15));
                                    obj.CreatedDate = Convert.ToDateTime(item.TransactionDate);
                                }
                                
                            }
                            else
                            {
                                obj.CreatedDate = Convert.ToDateTime(item.TransactionDate);
                            }
                            obj.PatientId = patientData.Id;
                            obj.StripeResponse = "succeeded";
                            var portalPaymentEntity=await this._portalPaymentRepository.AddNew(obj);

                            await this._dynmoPaymentsRepository.Update(item.Id, "TALBOT", portalPaymentEntity.Id);
                            return 1;
                        }
                        else
                        {
                            await this._dynmoPaymentsRepository.UpdateException(item.Id, "Account does not match OR DOB is wrong");
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;
        }

        public async Task<IEnumerable<IDynmoPayments>> GetDynmoPayments(IDynmoPaymentFilterDTO filter)
        {
            try
            {
                return await this._dynmoPaymentsRepository.Get(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTable> GetDynmoPaymentsForCatalystRCM()
        {
            try
            {
                return await this._dynmoPaymentsRepository.GetDynmoPaymentsForCatalystRCM();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateDynmoNotification(List<int> ids)
        {
            try
            {
                return await this._dynmoPaymentsRepository.UpdateFromCatalystRCM(ids);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateBadRecordFromCatalystRCM(List<int> ids)
        {
            try
            {
                return await this._dynmoPaymentsRepository.UpdateBadRecordFromCatalystRCM(ids);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateDynmoPayment(IDynmoPayments entity)
        {
            try
            {
                return await this._dynmoPaymentsRepository.Update(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> MoveInPortalPayment(int id)
        {
            try
            {
                var item = await this._dynmoPaymentsRepository.Get(id);
                List<IDynmoPayments> lst = new List<IDynmoPayments>();
                lst.Add(item);
                var result = await this.SaveDatainPortalPaymentTables(lst);
                if (result == 1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AutoMoveInPortalPayment()
        {
            try
            {
                DynmoPaymentFilterDTO filter = new DynmoPaymentFilterDTO();
                filter.FromDate = DateTime.Now.AddYears(-4).ToShortDateString();
                filter.ToDate = DateTime.Now.ToShortDateString();
                filter.IsImportInBilling = "0";

                var list=await this._dynmoPaymentsRepository.Get(filter);

                foreach (var dymaPayment in list)
                {
                    var item = await this._dynmoPaymentsRepository.Get(dymaPayment.Id);
                    List<IDynmoPayments> lst = new List<IDynmoPayments>();
                    lst.Add(item);
                    var result = await this.SaveDatainPortalPaymentTables(lst);
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> AdjustCopayPayment(IPortalPayment entity)
        {

            try
            {
                var chargeList = await this._chargesRepository.GetCharges(entity.InvChargeId.Select(i => i.Id));
                if (chargeList != null)
                {
                    
                    //var chargesAmount = chargeList.Sum(i => i.DueAmount);
                    var chargesAmount = entity.InvChargeId.Sum(i => i.OnlinePostedAmount);
                    if(chargesAmount==0)
                    {
                        await this._portalPaymentRepository.ThrowZeroPostedPayment();
                    }


                    IEnumerable<IPortalPaymentChargesDTO> alreadypaidList= await GetChargesForPortalPayment(entity.UId);
                    if(alreadypaidList!=null && alreadypaidList.Count()>0)
                    {
                        var totalPaid = alreadypaidList.Sum(i => i.PaidAmount) + chargesAmount;
                        if(totalPaid>entity.Amount)
                        {
                            await this._portalPaymentRepository.ThrowPaymentAmountGreaterThanActualOnline();
                        }
                    }
                    
                    //stopped on 10172024, @venkat requested
                    //if(chargesAmount<entity.Amount)
                    //{
                    //    await this._portalPaymentRepository.ThrowAmountNotEqual();
                    //}

                    // if (chargesAmount < entity.Amount)
                    // {
                    //     if(entity.InvChargeId.Count()>1)
                    //     {
                    //         await this._portalPaymentRepository.ThrowAmountNotEqualThenOnlySelectSignlePayment();
                    //     }
                    // }
                    //else if (chargesAmount > entity.Amount)
                    // {
                    //     await this._portalPaymentRepository.ThrowAmountNotEqual();
                    // }

                    if (chargesAmount != entity.Amount)
                    {
                      //  await this._portalPaymentRepository.ThrowAmountNotEqual();
                    }

                    if (chargesAmount > entity.Amount)
                    {
                        await this._portalPaymentRepository.ThrowPostPaymentGreaterValidation();
                    }

                    List<ICharges> chargesData = new List<ICharges>();
                    chargesData.AddRange(chargeList);
                    var paymentBatchObject = await this.IniIPaymentBatch(chargesAmount);
                    var paymentBatchId = await this._voucherRepository.GetCardPaymentPaymentBatchId();

                    IPaymentBatch paymentBatch = null;
                    if (paymentBatchId > 0)
                    {
                        paymentBatch = await this._paymentBatchRepository.GetById(paymentBatchId);
                    }
                    else
                    {
                        paymentBatch = await this._paymentBatchRepository.AddNew(paymentBatchObject);
                    }


                    var voucherObject = await this.IniIVoucher(paymentBatch, entity.PatientId, chargesAmount);
                    var voucherData = await this._voucherRepository.AddNewBulkAdjsutment(voucherObject);

                    var paymentObject = await this.InitPayment(voucherData, entity.PatientId);
                    var paymentData = await this._paymentRepository.AddNew(paymentObject);

                    var paymentChargesObject = await this.InitPaymentChargeForCopay(entity.InvChargeId, entity.Amount, paymentData.Id);
                    await this._paymentChargeRepository.AddAll(paymentChargesObject);


                    var portalPayment = await this._portalPaymentRepository.Get(entity.UId);
                    if (portalPayment != null)
                    {
                        PortalPaymentChild portalPaymentChild = new PortalPaymentChild();
                        portalPaymentChild.PaymentId = paymentData.Id;
                        portalPaymentChild.PortalPaymentId = portalPayment.Id;
                        await this._portalPaymentChildRepository.AddNew(portalPaymentChild);
                    }

                     IEnumerable <IPortalPaymentChargesDTO> paidList= await GetChargesForPortalPayment(entity.UId);
                    decimal totalPayment = 0;
                    if(paidList!=null && paidList.Count()>0)
                    {
                        totalPayment = paidList.Sum(i => i.PaidAmount);
                    }

                    await this._portalPaymentRepository.UpdatePaymentId(entity.UId, paymentData.Id, totalPayment);

                    if (paymentBatchId > 0)
                    {
                        paymentBatch.BatchAmount += chargesAmount;
                        await this._paymentBatchRepository.Update(paymentBatch);
                    }

                    return 1;
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AdjustCopayPayment_Backup_05252025(IPortalPayment entity)
        {
            try
            {
                var chargeList = await this._chargesRepository.GetCharges(entity.InvChargeId.Select(i=>i.Id));
                if (chargeList != null)
                {
                    //var chargesAmount = chargeList.Sum(i => i.DueAmount);
                    var chargesAmount = entity.InvChargeId.Sum(i => i.OnlinePostedAmount);
                    //stopped on 10172024, @venkat requested
                    //if(chargesAmount<entity.Amount)
                    //{
                    //    await this._portalPaymentRepository.ThrowAmountNotEqual();
                    //}

                    // if (chargesAmount < entity.Amount)
                    // {
                    //     if(entity.InvChargeId.Count()>1)
                    //     {
                    //         await this._portalPaymentRepository.ThrowAmountNotEqualThenOnlySelectSignlePayment();
                    //     }
                    // }
                    //else if (chargesAmount > entity.Amount)
                    // {
                    //     await this._portalPaymentRepository.ThrowAmountNotEqual();
                    // }

                    if (chargesAmount != entity.Amount)
                    {
                        await this._portalPaymentRepository.ThrowAmountNotEqual();
                    }

                    List<ICharges> chargesData = new List<ICharges>();
                    chargesData.AddRange(chargeList);
                    var paymentBatchObject = await this.IniIPaymentBatch(entity.Amount);
                    var paymentBatchId = await this._voucherRepository.GetCardPaymentPaymentBatchId();

                    IPaymentBatch paymentBatch = null;
                    if (paymentBatchId>0)
                    {
                        paymentBatch = await this._paymentBatchRepository.GetById(paymentBatchId);
                    }
                    else
                    {
                        paymentBatch = await this._paymentBatchRepository.AddNew(paymentBatchObject);
                    }
                    

                    var voucherObject = await this.IniIVoucher(paymentBatch, entity.PatientId,entity.Amount);
                    var voucherData = await this._voucherRepository.AddNewBulkAdjsutment(voucherObject);

                    var paymentObject = await this.InitPayment(voucherData, entity.PatientId);
                    var paymentData = await this._paymentRepository.AddNew(paymentObject);

                    var paymentChargesObject = await this.InitPaymentChargeForCopay(entity.InvChargeId, entity.Amount, paymentData.Id);
                    await this._paymentChargeRepository.AddAll(paymentChargesObject);

                    await this._portalPaymentRepository.UpdatePaymentId(entity.UId, paymentData.Id);


                    var portalPayment = await this._portalPaymentRepository.Get(entity.UId);
                    if(portalPayment!=null)
                    {
                        PortalPaymentChild portalPaymentChild = new PortalPaymentChild();
                        portalPaymentChild.PaymentId = paymentData.Id;
                        portalPaymentChild.PortalPaymentId = portalPayment.Id;
                        await this._portalPaymentChildRepository.AddNew(portalPaymentChild);
                    }

                    if (paymentBatchId>0)
                    {
                        paymentBatch.BatchAmount += entity.Amount;
                        await this._paymentBatchRepository.Update(paymentBatch);
                    }                    

                    return 1;
                }

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPayment(Guid guid)
        {
            var portalPayment = await this._portalPaymentRepository.Get(guid);            
            var portPaymentChildList = await this._portalPaymentChildRepository.GetByPortalPaymentId(portalPayment.Id);

            List<IPortalPaymentChargesDTO> lst = new List<IPortalPaymentChargesDTO>();

            foreach (var item in portPaymentChildList)
            {
                lst.AddRange(await this._paymentRepository.GetChargesForPortalPayment(item.PaymentId));
            }
            
            return lst;
        }

        public async Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPaymentNew(List<int> portalPaymentIds)
        {            
            var portPaymentChildList = await this._portalPaymentChildRepository.GetByPortalPaymentIdByIds(portalPaymentIds);
            
            var lst = await this._paymentRepository.GetChargesForPortalPaymentNew(portPaymentChildList.Select(i=>i.PaymentId).ToList());

            return lst;
        }

        public async Task<IEnumerable<IPortalPaymentEMRDTO>> GetOnlineUnPostedPayments(string billingId)
        {
            List<IPortalPaymentEMRDTO> lst = new List<IPortalPaymentEMRDTO>();
            lst.AddRange(await this._portalPaymentRepository.GetUnPostedPaymentByPatientId(billingId));
            lst.AddRange(await this._dynmoPaymentsRepository.GetUnMatchedPaymentsByBillingId(billingId));

            return lst;
        }

        public async Task<int> SendMoneyToLab(ILabPaymentDTO labPaymentDTO)
        {
            var portalPayment = await this._portalPaymentRepository.Get(labPaymentDTO.UId);
            if(labPaymentDTO.Amount> portalPayment.Amount)
            {
                throw new Exception("Cannot enter Lab Amount greater than actualt recieved payment.");
            }

            IEnumerable<IPortalPaymentChargesDTO> alreadypaidList = await GetChargesForPortalPayment(labPaymentDTO.UId);
            if (alreadypaidList != null && alreadypaidList.Count() > 0)
            {
                var totalPaid = alreadypaidList.Sum(i => i.PaidAmount);
                var restAmount = portalPayment.Amount - totalPaid;

                if (labPaymentDTO.Amount > restAmount)
                {
                    throw new Exception("Cannot enter Lab Amount greater than actualt recieved payment.");
                }
            }



            var dymoPayment = await this._dynmoPaymentsRepository.GetByPortalPaymentId(portalPayment.Id);
            dymoPayment.Amount = labPaymentDTO.Amount.ToString();

            int labPortalPaymentId=await SendMoneyToLab(dymoPayment);
            if(labPortalPaymentId>0)
            {
                await this._portalPaymentRepository.UpdateLabAmount(labPaymentDTO.UId, labPaymentDTO.Amount, labPortalPaymentId);
            }
            else
            {
                throw new Exception("Payment Could not be sent. Please contact to Admin");
            }
            

            return 0;
        }

        public async Task<int> SendMoneyToLab(IDynmoPayments dynmoPayments)
        {
            string fileContentResult = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    var practice = await this._practiceRepository.Get();
                    if (string.IsNullOrWhiteSpace(practice.LabURL))
                    {
                        throw new Exception("No Lab configration found.");
                    }
                    
                    string token = await _reportRepository.GetBillingToken(practice.LabURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    
                    string jsonString = JsonConvert.SerializeObject(dynmoPayments, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    content.Headers.ContentLength = jsonString.Length;

                    HttpResponseMessage response = client.PostAsync(practice.LabURL + "api/PortalPayment/AddDynmoPayment", content).Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        return 0;
                    }
                    else
                    {
                        fileContentResult = await response.Content.ReadAsAsync<string>();
                        return Convert.ToInt32(fileContentResult);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}


