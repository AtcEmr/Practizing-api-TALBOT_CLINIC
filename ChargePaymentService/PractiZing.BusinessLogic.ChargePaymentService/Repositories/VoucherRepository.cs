using AutoMapper;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class VoucherRepository : ModuleBaseRepository<Voucher>, IVoucherRepository
    {

        private IPatientCaseRepository _patientCaseRepository;
        private IPaymentRepository _paymentRepository;
        private IPatientRepository _patientRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IAttFileRepository _attFileRepository;
        private readonly IMapper _mapper;
        private IMonthEndCloseRepository _monthEndCloseRepository;
        private IDepositTypeRepository _depositTypeRepository;
        private IPaymentBatchRepository _paymentBatchRepository;

        public VoucherRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 IPatientCaseRepository patientCaseRepository,
                                 IPaymentRepository paymentRepository,
                                 IInsuranceCompanyRepository insuranceCompanyRepository,
                                 IPatientRepository patientRepository,
                                 IAttFileRepository attFileRepository,
                                 IMonthEndCloseRepository monthEndCloseRepository,
                                 IMapper mapper,
                                 IDepositTypeRepository depositTypeRepository,
                                 IPaymentBatchRepository paymentBatchRepository)
                                 : base(errorCodes, dbContext, loggedUser)
        {
            this._patientCaseRepository = patientCaseRepository;
            this._paymentRepository = paymentRepository;
            this._patientRepository = patientRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._attFileRepository = attFileRepository;
            this._monthEndCloseRepository = monthEndCloseRepository;
            this._depositTypeRepository = depositTypeRepository;
            this._paymentBatchRepository = paymentBatchRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// add new voucher and issystem flag used to check from where deposit is coming (is it from era file or from desktop screen).
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSystem"></param>
        /// <returns></returns>
        public async Task<IVoucher> AddNew(IVoucher entity)
        {
            try
            {
                Voucher tEntity = entity as Voucher;

                var insuranceCompanyName = tEntity.InsuranceCompanyId.HasValue ? (await this._insuranceCompanyRepository.GetById(tEntity.InsuranceCompanyId.Value)).CompanyName : null;

                if (tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower())
                {
                    if (tEntity.ReferenceNo != string.Empty && tEntity.ReferenceNo != null)
                    {
                        var voucher = await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.ReferenceNo == tEntity.ReferenceNo);
                        if (voucher != null)
                            await this.ThrowCheckNumber(tEntity.ReferenceNo);
                    }
                }

                tEntity.CreatedBy = LoggedUser.UserName;
                tEntity.CreatedDate = tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower() ?
                tEntity.CreatedDate : DateTime.Now;
                tEntity.PracticeId = LoggedUser.PracticeId;
                // it means if deposit came from system then payment will automatically committed but it came from desktop screen then committed = false
                tEntity.IsCommitted = tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower() ? false : true;

                if (tEntity.EffectiveDate != null)
                {
                    int year = tEntity.EffectiveDate.Year;
                    int month = tEntity.EffectiveDate.Month;
                    var monthEndStatus = await this._monthEndCloseRepository.GetByDateId(month, year);
                    DateTime lastDay = new DateTime(tEntity.EffectiveDate.Year, tEntity.EffectiveDate.Month, 1).AddMonths(1).AddDays(-1);

                    // tEntity.EffectiveDate = monthEndStatus == null ? tEntity.EffectiveDate.Month < DateTime.Now.Month ? lastDay.Date : tEntity.EffectiveDate : lastDay.Date;
                    //tEntity.EffectiveDate = tEntity.EffectiveDate.Month < DateTime.Now.Month ? monthEndStatus == null ? DateTime.Now.Date : lastDay.Date : tEntity.EffectiveDate;
                    if (monthEndStatus != null)
                    {
                        tEntity.EffectiveDate = DateTime.Now;
                        tEntity.CreatedDate = DateTime.Now;
                    }
                }

                tEntity.VoucherTypeCD = Enum.GetName(typeof(VoucherTypeEnum), VoucherTypeEnum.PAYMENT);
                tEntity.InsuranceCompanyId = tEntity.InsuranceCompanyId != 0 ? tEntity.InsuranceCompanyId : null;
                tEntity.PatientId = (tEntity.PatientId == null || tEntity.PatientId == 0) ? null : tEntity.PatientId;
                //tEntity.PaymentSourceCD = tEntity.PaymentSourceCD.ToLower() == "era_payment" ? Enum.GetName(typeof(PaymentSourceTypeEnum), PaymentSourceTypeEnum.ERA_PAYMENT) : Enum.GetName(typeof(PaymentSourceTypeEnum), PaymentSourceTypeEnum.MANUAL_PAYMENT);
                tEntity.VoucherNo = await this.CreateVoucherNo();
                tEntity.Description = tEntity.InsuranceCompanyId == null ? string.Empty : tEntity.EffectiveDate.ToShortDateString().Replace("/", "-") + (await this._insuranceCompanyRepository.GetById(tEntity.InsuranceCompanyId)).CompanyName;
                tEntity.InsuranceCompanyName = tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower() ?
                tEntity.InsuranceCompanyName : insuranceCompanyName;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IVoucher> AddNewBulkAdjsutment(IVoucher entity, bool isSystem = true)
        {
            try
            {
                Voucher tEntity = entity as Voucher;
                tEntity.CreatedBy = LoggedUser.UserName;
                tEntity.CreatedDate = DateTime.Now;
                tEntity.ModifiedBy = LoggedUser.UserName;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.PracticeId = LoggedUser.PracticeId;

                if (isSystem)
                {
                    tEntity.EffectiveDate = DateTime.Now;
                    tEntity.ReferenceDate = DateTime.Now.Date;
                    tEntity.IsCommitted = true;
                    tEntity.ReferenceNo = "";
                    tEntity.PaymentSourceCD = PaymentSourceTypeEnum.CARD_PAYMENT.ToString();
                    tEntity.VoucherTypeCD = Enum.GetName(typeof(VoucherTypeEnum), VoucherTypeEnum.PAYMENT);
                }

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// error throw method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(IVoucher entity)
        {
            Voucher tEntity = entity as Voucher;
            List<IValidationResult> errors = new List<IValidationResult>();

            // if payment batch id = 0 then it throws error its mandatory.
            if (tEntity.PaymentBatchId == 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PaymentBatchIdMandatory]));

            // if patientid = 0 and insurance company id = 0 then it throws error its mandatory.
            if (tEntity.PatientId == 0 && tEntity.InsuranceCompanyId == 0)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.PatientIdMandatory]));

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        /// <summary>
        /// get voucher acc to payment batch ids
        /// </summary>
        /// <param name="paymentBatchId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IVoucher>> GetByBatchId(IEnumerable<int> paymentBatchId)
        {
            var query = this.Connection.From<Voucher>()
                        .LeftJoin<Voucher, Patient>((v, p) => v.PatientId == p.Id)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.Id == pc.PatientId)
                        .SelectDistinct<Voucher, Patient, PatientCase>((v, p, pc) => new
                        {
                            PatientName = p.FirstName,
                            v,
                            PatientCaseId = pc.Id
                        })
                        .Where(i => paymentBatchId.Contains(i.PaymentBatchId) && i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Voucher>.MapList(queryResult);

            List<int> patientIds = new List<int>();
            patientIds.AddRange(result.Where(i => i.PatientId != null).Select(i => i.PatientId.Value).ToList());
            var patientData = await this._patientCaseRepository.GetPatient(patientIds);

            int[] voucherIds = result.Select(i => i.Id).ToArray();
            var paymentData = await this._paymentRepository.Get(voucherIds, string.Empty);

            foreach (var item in result)
            {
                //item.PatientId = item.PatientId == null ? 0 : patientData.Where(i => i.PatientId == item.PatientId).FirstOrDefault() == null ? 0 : item.PatientId;

                //item.PatientCaseId = (patientData.Where(i => i.PatientId == item.PatientId)).Select(i => i.Id);
                // get payments acc. to voucher id
                item.Payments = paymentData.Where(i => i.Id == item.Id);
            }

            return result;
        }

        public async Task<IEnumerable<IVoucher>> GetByBatchId(int paymentBatchId)
        {
            return await this.Connection.SelectAsync<Voucher>(i => i.PaymentBatchId == paymentBatchId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<int> GetCardPaymentPaymentBatchId()
        {
            var list= await this.Connection.SelectAsync<Voucher>(i => i.PaymentSourceCD== PaymentSourceTypeEnum.CARD_PAYMENT.ToString() && i.CreatedDate>DateTime.Now.AddDays(-2)  && i.PracticeId == LoggedUser.PracticeId);
            var item= list.Where(i => i.CreatedDate.Year == DateTime.Now.Year && i.CreatedDate.Month == DateTime.Now.Month && i.CreatedDate.Day == DateTime.Now.Day).OrderByDescending(i=>i.Id).FirstOrDefault();
            return item==null?0:item.PaymentBatchId;
        }

        //PaymentSourceTypeEnum.CARD_PAYMENT.ToString()

        public async Task<IVoucher> GetTotalPaymentsInVoucher(int paymentBatchId)
        {
            Voucher voucher = new Voucher();
            // get voucher's acc to paymentbatchid.
            var voucherData = await this.Connection.SelectAsync<Voucher>(i => i.PaymentBatchId == paymentBatchId && i.PracticeId == LoggedUser.PracticeId);
            // get Payments acc to voucherData ids.
            voucher.Payments = await this._paymentRepository.GetTotalPayments(voucherData.Select(i => i.Id));

            voucher.TotalPaidAmountInVoucher = voucher.Payments.Sum(i => i.Amount);

            return voucher;
        }

        public async Task<IVoucher> Get(Guid uId)
        {
            // get voucher and payment batch acc. to uid 
            var query = this.Connection.From<Voucher>()
                       .Join<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id, NoLockTableHint.NoLock)
                       .SelectDistinct<Voucher, PaymentBatch>((v, pb) => new
                       {
                           v,
                           PaymentBatchAmount = pb.BatchAmount,
                           PaymentBatchId = pb.Id
                       })
                       .Where(i => i.UId == uId && i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            return Mapper<Voucher>.Map(queryResult);
        }

        public async Task<int> GetByPaymentId(int paymentBatchId)
        {
            // get voucher and payment batch acc. to uid 
            var query = this.Connection.From<Voucher>()
                       .Select<Voucher>((v) => new
                       {
                           v
                       })
                       .Where<Payment, Voucher>((p, i) => p.Id == paymentBatchId && i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Voucher>.Map(queryResult);

            return result == null ? 0 : 1;
        }

        public async Task<IEnumerable<IVoucher>> GetByUId(string paymentBatchUId, string patientUId)
        {
            var paymentBatchId = paymentBatchUId == null ? 0 : (await this._paymentBatchRepository.Get(Guid.Parse(paymentBatchUId))).Id;
            var patientId = patientUId == null ? 0 : (await this._patientRepository.GetByUId(Guid.Parse(patientUId))).Id;

            return await this.Connection.SelectAsync<Voucher>(i => i.PaymentBatchId == 10 && i.PracticeId == LoggedUser.PracticeId && i.PatientId == patientId);
        }

        public async Task<IVoucher> Get(int Id)
        {
            return await this.Connection.SingleAsync<Voucher>(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IVoucher>> GetByPatientId(int patientId)
        {
            return await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.PatientId == patientId);
        }

        public async Task ThrowError(int count)
        {
            if (count > 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.VoucherExist]));
        }

        public async Task VoucherExists()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.VoucherExists]));
        }

        /// <summary>
        /// get voucher, batch and patient by uid with its payments and atahcments
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public async Task<IVoucher> GetByUId(Guid uId)
        {
            var query = this.Connection.From<Voucher>()
                        .LeftJoin<Voucher, Patient>((v, p) => v.PatientId == p.Id)
                        .LeftJoin<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id)
                        .LeftJoin<Voucher, DataAccess.MasterService.Tables.DepositType>((v, dt) => v.DepositTypeId == dt.Id)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.DefaultCaseId == pc.Id)
                        .LeftJoin<Voucher, InsuranceCompany>((v,ins) => v.IsSelfPayment == false && v.InsuranceCompanyId == ins.Id)
                        .SelectDistinct<Voucher, Patient, PaymentBatch, DataAccess.MasterService.Tables.DepositType, PatientCase, InsuranceCompany>((v, p, pb, dt, pc, ins) => new
                        {
                            v,
                            DepositTypeUId = dt.UId,
                            PatientFirstName = p.FirstName,
                            PatientLastName = p.LastName,
                            PaymentBatchAmount = pb.BatchAmount,
                            PaymentBatchUId = pb.UId,
                            PatientUID = p.UId,
                            PatientCaseUId = pc.UId,
                            DepositInsuranceCompanyUId = ins.UId
                        })
                        .Where(v => v.UId == uId && v.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Voucher>.Map(queryResult);

            if (result != null)
            {
                result.PatientId = result.PatientId == null ? 0 : result.PatientId;
                List<int> patientIds = new List<int>() { result.PatientId.Value };
                // getting patient case ids by using patient id
                result.PatientCaseId = (await this._patientCaseRepository.GetPatient(patientIds)).Select(i => i.Id);
                // get payments according to voucher id.
                result.Payments = await this._paymentRepository.GetByVoucher(result.Id, string.Empty);
                // find attachment of voucher and its id.
                result.AttFiles = await this._attFileRepository.GetByTableId(result.Id, AttTableConstant.Voucher);
            }

            return result;
        }

        /// <summary>
        /// get voucher, batch and patient by uid with its payments and atahcments
        /// </summary>
        /// <param name="uId"></param>
        /// <returns></returns>
        public async Task<IVoucher> GetByUIdAndPatientId(Guid uId)
        {
            var query = this.Connection.From<Voucher>()
                        .LeftJoin<Voucher, Patient>((v, p) => v.PatientId == p.Id)
                        .LeftJoin<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id)
                        .LeftJoin<Voucher, DataAccess.MasterService.Tables.DepositType>((v, dt) => v.DepositTypeId == dt.Id)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.DefaultCaseId == pc.Id)
                        .LeftJoin<Voucher, InsuranceCompany>((v, ins) => v.IsSelfPayment == false && v.InsuranceCompanyId == ins.Id)
                        .SelectDistinct<Voucher, Patient, PaymentBatch, DataAccess.MasterService.Tables.DepositType, PatientCase, InsuranceCompany>((v, p, pb, dt, pc, ins) => new
                        {
                            v,
                            DepositTypeUId = dt.UId,
                            PatientFirstName = p.FirstName,
                            PatientLastName = p.LastName,
                            PaymentBatchAmount = pb.BatchAmount,
                            PaymentBatchUId = pb.UId,
                            PatientUID = p.UId,
                            PatientCaseUId = pc.UId,
                            DepositInsuranceCompanyUId = ins.UId
                        })
                        .Where(v => v.UId == uId && v.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Voucher>.Map(queryResult);

            if (result != null)
            {
                result.PatientId = result.PatientId == null ? 0 : result.PatientId;
                List<int> patientIds = new List<int>() { result.PatientId.Value };
                // getting patient case ids by using patient id
                result.PatientCaseId = (await this._patientCaseRepository.GetPatient(patientIds)).Select(i => i.Id);
                // get payments according to voucher id.
                result.Payments = await this._paymentRepository.GetByVoucher(result.Id, string.Empty);
                // find attachment of voucher and its id.
                result.AttFiles = await this._attFileRepository.GetByTableId(result.Id, AttTableConstant.Voucher);
            }

            return result;
        }

        public async Task<IEnumerable<IVoucher>> GetByUId(IEnumerable<Guid> uIds)
        {
            var query = this.Connection.From<Voucher>()
                        .LeftJoin<Voucher, Patient>((v, p) => v.PatientId == p.Id)
                        .LeftJoin<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id)
                        .LeftJoin<Voucher, DataAccess.MasterService.Tables.DepositType>((v, dt) => v.DepositTypeId == dt.Id)
                        .LeftJoin<Patient, PatientCase>((p, pc) => p.Id == pc.PatientId)
                        .LeftJoin<Voucher, InsuranceCompany>((v, i) => v.InsuranceCompanyId == i.Id)
                        .SelectDistinct<Voucher, Patient, PaymentBatch, DataAccess.MasterService.Tables.DepositType, PatientCase, InsuranceCompany>((v, p, pb, dt, pc, i) => new
                        {
                            v,
                            DepositTypeUId = dt.UId,
                            PatientFirstName = p.FirstName,
                            PatientLastName = p.LastName,
                            PaymentBatchAmount = pb.BatchAmount,
                            PatientCaseUId = pc.UId,
                            //PatientCaseId = pc.Id,
                            PatientId = p.Id,
                            PatientUId = p.UId,
                            PaymentBatchUId = pb.UId,
                            DepositInsuranceCompanyUId = i.UId
                        })
                        .Where(v => uIds.Contains(v.UId) && v.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var results = Mapper<Voucher>.MapList(queryResult);

            List<int> patientIds = new List<int>();
            patientIds.AddRange(results.Where(i => i.PatientId != null).Select(i => i.PatientId.Value).ToList());

            var patientData = await this._patientCaseRepository.GetPatient(patientIds);
            int[] voucherIds = results.Select(i => i.Id).ToArray();
            var paymentData = await this._paymentRepository.Get(voucherIds, string.Empty);

            var attTableData = await this._attFileRepository.GetByTableId(voucherIds, AttTableConstant.Voucher);

            results.ToList().ForEach((result) =>
            {
                result.PatientId = result.PatientId == null ? 0 : patientData.Where(i => i.PatientId == result.PatientId).FirstOrDefault() == null ? 0 : result.PatientId;
                // getting patient case ids by using patient id
                result.PatientCaseId = (patientData.Where(i => i.PatientId == result.PatientId)).Select(i => i.Id);
                // get payments according to voucher id.
                result.Payments = paymentData.Where(i => i.VoucherId == result.Id);
                // find attachment of voucher and its id.
                result.AttFiles = attTableData.Where(i => i.TableIdValue == result.Id);
            });

            return results;
        }

        public async Task<IVoucher> Update(IVoucher entity)
        {
            try
            {
                Voucher tEntity = entity as Voucher;
                tEntity.PatientId = tEntity.PatientId == 0 ? null : tEntity.PatientId;
                tEntity.Description = tEntity.Description == null ? DateTime.Now.ToShortDateString().Replace("/", "-") : tEntity.Description;
                tEntity.CreatedDate = tEntity.EffectiveDate;

                if (tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower())
                {
                    tEntity.DepositTypeId = tEntity.DepositTypeUId == Guid.Empty ? (short)0 : (short)(await this._depositTypeRepository.GetByUId(tEntity.DepositTypeUId)).Id;
                    tEntity.InsuranceCompanyName = !tEntity.InsuranceCompanyId.HasValue ? null : (await this._insuranceCompanyRepository.GetById(tEntity.InsuranceCompanyId.Value)).CompanyName;

                    var voucher = await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == tEntity.UId);
                    if (voucher != null)
                    {
                        if (voucher.ReferenceNo != tEntity.ReferenceNo)
                        {
                            var referenceNo = await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.ReferenceNo == tEntity.ReferenceNo);
                            if (referenceNo != null)
                                await this.ThrowCheckNumber(tEntity.ReferenceNo);
                        }
                    }
                }

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Voucher>()
                                           .Update(x => new
                                           {
                                               x.VoucherTypeCD,
                                               x.PaymentSourceCD,
                                               x.DepositTypeId,
                                               x.Amount,
                                               x.Description,
                                               x.EffectiveDate,
                                               x.ReferenceNo,
                                               x.ReferenceDate,
                                               x.IsSelfPayment,
                                               x.PatientId,
                                               x.InsuranceCompanyId,
                                               x.InsuranceCompanyName,
                                               x.CreatedDate
                                           })
                                           .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IVoucher> UpdateVoucherFromERA(IVoucher entity)
        {
            try
            {
                Voucher tEntity = entity as Voucher;
                tEntity.PatientId = tEntity.PatientId == 0 ? null : tEntity.PatientId;
                tEntity.Description = tEntity.Description == null ? DateTime.Now.ToShortDateString().Replace("/", "-") : tEntity.Description;

                if (tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.MANUAL_PAYMENT.ToString().ToLower())
                {
                    tEntity.DepositTypeId = tEntity.DepositTypeUId == Guid.Empty ? (short)0 : (short)(await this._depositTypeRepository.GetByUId(tEntity.DepositTypeUId)).Id;
                    tEntity.InsuranceCompanyName = !tEntity.InsuranceCompanyId.HasValue ? null : (await this._insuranceCompanyRepository.GetById(tEntity.InsuranceCompanyId.Value)).CompanyName;

                    var voucher = await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == tEntity.UId);
                    if (voucher != null)
                    {
                        if (voucher.ReferenceNo != tEntity.ReferenceNo)
                        {
                            var referenceNo = await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.ReferenceNo == tEntity.ReferenceNo);
                            if (referenceNo != null)
                                await this.ThrowCheckNumber(tEntity.ReferenceNo);
                        }
                    }
                }
                //else if(tEntity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower())
                //{
                //    if (tEntity.EffectiveDate != null)
                //    {
                //        int year = tEntity.EffectiveDate.Year;
                //        int month = tEntity.EffectiveDate.Month;
                //        var monthEndStatus = await this._monthEndCloseRepository.GetByDateId(month, year);
                //        DateTime lastDay = new DateTime(tEntity.EffectiveDate.Year, tEntity.EffectiveDate.Month, 1).AddMonths(1).AddDays(-1);

                //        // tEntity.EffectiveDate = monthEndStatus == null ? tEntity.EffectiveDate.Month < DateTime.Now.Month ? lastDay.Date : tEntity.EffectiveDate : lastDay.Date;
                //        //tEntity.EffectiveDate = tEntity.EffectiveDate.Month < DateTime.Now.Month ? monthEndStatus == null ? DateTime.Now.Date : lastDay.Date : tEntity.EffectiveDate;
                //        if (monthEndStatus != null)
                //        {
                //            tEntity.EffectiveDate = DateTime.Now;
                //        }
                //    }
                //}

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Voucher>()
                                           .Update(x => new
                                           {
                                               x.VoucherTypeCD,
                                               x.PaymentSourceCD,
                                               x.DepositTypeId,
                                               x.Amount,
                                               x.Description,
                                               x.ReferenceNo,
                                               x.ReferenceDate,
                                               x.PatientId,
                                               x.InsuranceCompanyId,
                                               x.InsuranceCompanyName
                                           })
                                           .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == entity.UId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IVoucher>> Get()
        {
            var voucher = await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId);

            foreach (var res in voucher)
            {
                // getting patient id.
                int _patientId = res.PatientId == null ? 0 : res.PatientId.Value;
                List<int> vs = new List<int>() { _patientId };
                // getting patient case ids by using patient id.
                res.PatientCaseId = (await this._patientCaseRepository.GetPatient(vs)).Select(i => i.Id);
            }

            return voucher;
        }

        public async Task<IEnumerable<IVoucher>> GetVoucher()
        {
            return await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IVoucher> GetByCheckNumber(string refernceNo)
        {
            return await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.ReferenceNo == refernceNo);
        }

        public async Task<IVoucher> GetByCheckNumber(string refernceNo, int voucherId)
        {
            return await this.Connection.SingleAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.ReferenceNo == refernceNo && i.Id != voucherId);
        }

        public async Task<int> CreateVoucherNo()
        {
            // voucher no is the total sum of practice ids of all vouchers + 1.
            var query = this.Connection.From<Voucher>()
                       .Select<Voucher>((v) => new
                       {
                           VoucherNo = Sql.Max(v.VoucherNo)
                       })
                       .Where<Voucher>(i => i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var voucherData = Mapper<Voucher>.Map(queryResult);

            return voucherData == null ? 1 : (voucherData.VoucherNo) + 1;
        }

        public async Task<int> CreateTransactionNo()
        {
            // transaction no is the maximum practice id + 1;
            var query = this.Connection.From<Voucher>()
                      .Select<Voucher>((v) => new
                      {
                          PracticeId = Sql.Sum(v.PracticeId)
                      })
                      .Where<Voucher>(i => i.PracticeId == LoggedUser.PracticeId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var voucherData = Mapper<Voucher>.Map(queryResult);

            return voucherData == null ? 1 : (voucherData.PracticeId) + 1;
        }

        public async Task<int> Delete(Guid UId)
        {
            try
            {
                return await this.Connection.DeleteAsync<Voucher>(i => i.UId == UId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int Id)
        {
            try
            {
                return await this.Connection.DeleteAsync<Voucher>(i => i.Id == Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IVoucherDTO>> GetVoucher(IBulkPaymentFilter filter)
        {
            var query = this.Connection.From<Voucher>()
                        .Join<Voucher, PaymentBatch>((v, pb) => v.PaymentBatchId == pb.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Voucher, Patient>((v, pb) => v.PatientId == pb.Id && v.IsSelfPayment == true, NoLockTableHint.NoLock)
                        .LeftJoin<Patient, PatientCase>((p,pb)=> p.DefaultCaseId == pb.Id, NoLockTableHint.NoLock)
                        .LeftJoin<Voucher, InsuranceCompany>((v, ic) =>  v.InsuranceCompanyId == ic.Id && v.IsSelfPayment == false, NoLockTableHint.NoLock)
                        .SelectDistinct<Voucher, PaymentBatch, InsuranceCompany, Patient, PatientCase>((v, pb, ic, p, pc) => new
                        {
                            DepositTypeId = v.DepositTypeId,
                            DepositDate = v.EffectiveDate,
                            CheckRefNo = v.ReferenceNo,
                            CreatedDate = v.CreatedDate,
                            CreatedBy = v.CreatedBy,
                            BatchNumber = pb.BatchNo,
                            PaymentBatchAmount = pb.Amount,
                            PaymentBatchId = pb.Id,
                            DepositAmount = v.Amount,
                            IsSelfPayment = v.IsSelfPayment,
                            VoucherId = v.Id,
                            InsuranceCompanyId = v.InsuranceCompanyId,
                            PatientId = v.PatientId,
                            PatientUID = p.UId,
                            VoucherGUId = v.UId,
                            IsCommitted = v.IsCommitted,
                            PaymentBatchGUId = pb.UId,
                            InsuranceCompanyName = ic.CompanyName,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            EffectiveDate = v.EffectiveDate,
                            ReferenceDate = v.ReferenceDate,
                            PatientCaseUID = pc.UId,
                            PaymentSourceCD = v.PaymentSourceCD,
                            v.IsMatchedWithBank
                        })
                       .Where(i => i.PracticeId == LoggedUser.PracticeId && i.PaymentSourceCD.ToLower() != PaymentSourceTypeEnum.BulkAdjustment_Payment.ToString().ToLower() && i.PaymentSourceCD.ToLower() != PaymentSourceTypeEnum.BalanceAdjustment_Payment.ToString().ToLower())
                       .OrderByDescending(i => i.CreatedDate);

            var resultFilter = _mapper.Map<VoucherFilter>(filter);
            resultFilter.DepositTypeIds = resultFilter.DepositTypeIds == "null" ? null : resultFilter.DepositTypeIds;
            resultFilter.IsCommitted = resultFilter.IsCommitted == "null" ? null : resultFilter.IsCommitted;
            resultFilter.PaymentSourceCD = resultFilter.PaymentSourceCD == "null" ? null : resultFilter.PaymentSourceCD;

            string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
            string countExpression = query.ToCountStatement();
            string whereExpression = await WhereClauseProvider<IVoucherFilter>.GetWhereClause(resultFilter);

            query.WhereExpression = string.IsNullOrEmpty(whereExpression) ? query.WhereExpression : query.WhereExpression + " AND " + whereExpression;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<VoucherDTO>.MapList(queryResult);

            // vouchers list and get ids of vouchers
            int[] voucherIds = result.Select(i => i.VoucherId).ToArray();

            // get payments with charges , adjsut. and remark codes acco. to filters.
            var paymentData = await this._paymentRepository.GetBulkPaymentPayment(voucherIds, filter);

            //find voucher of all payments and send into payment dto accor. to guid.
           // var voucherUIds = result.Select(i => i.VoucherGUId).ToArray();
            // get by uids.
           // var voucherData = await this.GetByUId(voucherUIds);

            ////paymentData.ToList().ForEach((res) =>
            ////{
            ////    res.Voucher = voucherData.Where(i => i.UId == res.VoucherUId).FirstOrDefault();
            ////});

            result.ToList().ForEach((item) =>
            {
                //item.Voucher = voucherData.Where(i => i.UId == item.VoucherGUId).FirstOrDefault();
                //if (resultFilter.DifferenceId != null && resultFilter.DifferenceId != 0)
                //    item.PaymentDTOs = resultFilter.DifferenceId == 1 ? paymentData.Where(i => i.VoucherId == item.VoucherId && i.DifferenceAmount != 0) : paymentData.Where(i => i.VoucherId == item.VoucherId && i.DifferenceAmount == 0);
                //else
                //    item.PaymentDTOs = paymentData.Where(i => i.VoucherId == item.VoucherId);

                var paymentDataAmount = paymentData.Where(i => i.VoucherId == item.VoucherId);
                //item.PostedAmount = (paymentDataAmount.Sum(i => i.TotalCrChargeAmount) + (paymentDataAmount.Sum(i => i.BonusAmount)) + paymentDataAmount.Sum(i => i.TotalDrChargeAmount));
                //item.PostedAmount = (paymentDataAmount.Sum(i => i.TotalCrChargeAmount) + paymentDataAmount.Sum(i => i.TotalDrChargeAmount));
                item.PostedAmount = paymentDataAmount.Sum(i => i.PaidAmount);
                // total deposit amount - posted amount
                item.DifferenceAmount = item.DepositAmount - (item.PostedAmount<0?(item.PostedAmount*-1): item.PostedAmount);
                item.TotalPaidAmount = paymentDataAmount.Sum(i => i.PaidAmount);
                
                // send payee name if self payment == true then patient first name and if is self payment = false == insurance company name.
                item.PayeeName = item.IsSelfPayment ? item.FirstName == null ? ""
                                 : item.LastName + ',' + item.FirstName :
                                 item.InsuranceCompanyName == null ? "" : item.InsuranceCompanyName;

            });

            return result;
        }

        public async Task<IVoucher> GetByInsuranceCompanyId(int companyId)
        {
            try
            {
                return await this.Connection.SingleAsync<Voucher>(i => i.InsuranceCompanyId == companyId && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IVoucher> UpdateCommitedTransaction(Guid voucherGuid)
        {
            try
            {
                Voucher tEntity = await this.Connection.SingleAsync<Voucher>(i => i.UId == voucherGuid && i.PracticeId == LoggedUser.PracticeId);
                if (tEntity == null)
                    await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[Convert.ToInt32(EnumErrorCode.VoucherNotExists), voucherGuid]));

                tEntity.IsCommitted = true;
                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Voucher>()
                                           .Update(x => new
                                           {
                                               x.IsCommitted
                                           })
                                           .Where(i => i.PracticeId == LoggedUser.PracticeId && i.UId == voucherGuid);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IVoucher>> Get(IList<int> insuranceCompanyIds, IList<int> patientIds)
        {
            try
            {
                var query = this.Connection
                                  .From<Voucher>()
                                  .Select<Voucher>((v) => new
                                  {
                                      EffectiveDate = Sql.Max(v.EffectiveDate),
                                      v.PatientId,
                                      v.InsuranceCompanyId
                                  })
                                  .Where(i => (i.PatientId == null && insuranceCompanyIds.Contains(i.InsuranceCompanyId.Value))
                                  || (i.InsuranceCompanyId == null && patientIds.Contains(i.PatientId.Value)))
                                  .GroupBy((i) => new { i.PatientId, i.InsuranceCompanyId });

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                return Mapper<Voucher>.MapList(queryResult);
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowCheckNumber(string checkno)
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.VoucherExistsCheckNo, checkno]));
        }

        public async Task<IVoucher> GetForBalanceAdjustment(string paymentSourceCD)
        {
            var result = await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.PaymentSourceCD == paymentSourceCD);
            return result.Where(i => i.CreatedDate.Year == DateTime.Now.Year && i.CreatedDate.Month == DateTime.Now.Month && i.CreatedDate.Day == DateTime.Now.Day).FirstOrDefault();
        }

        public async Task<IVoucher> GetForBulkAdjustment_PatientWise(string paymentSourceCD,int insuranceCompanyId,int patientId)
        {
            var result = await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.PaymentSourceCD == paymentSourceCD && i.PatientId==patientId && i.InsuranceCompanyId==insuranceCompanyId);
            return result.Where(i => i.CreatedDate.Year == DateTime.Now.Year && i.CreatedDate.Month == DateTime.Now.Month && i.CreatedDate.Day == DateTime.Now.Day).FirstOrDefault();
        }

        //public async Task<IEnumerable<IVoucher>> GetVouchersForBankMatched()
        //{
        //    return await this.Connection.SelectAsync<Voucher>(i => i.PracticeId == LoggedUser.PracticeId && i.IsMatchedWithBank==null);
        //}

        public async Task<IEnumerable<IVoucherPlaidDTO>> GetVouchersForBankMatched()
        {
            try
            {

                List<VoucherPlaidDTO> lst = new List<VoucherPlaidDTO>();
                lst = (await base.ExecuteStoredProcedureAsync<VoucherPlaidDTO>("usp_GetVouchersForPlaidPayments", null)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdatePlaidMatched(string xmlData,bool isMatchedWithBank,string practice)
        {
            try
            {   
                object[] parameters = new object[] { xmlData, isMatchedWithBank?1:0, practice };
                var lst = (await base.ExecuteStoredProcedureAsync<int>("usp_UpdatePlaidPayment_Voucher", parameters)).ToList();

                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
