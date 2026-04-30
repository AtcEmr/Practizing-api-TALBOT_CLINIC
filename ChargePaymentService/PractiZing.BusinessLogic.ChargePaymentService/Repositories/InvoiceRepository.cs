using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.Base.Common;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.PatientService.Tables;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.View;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class InvoiceRepository : ModuleBaseRepository<Invoice>, IInvoiceRepository
    {
        private IChargeBatchRepository _chargeBatchRepository;
        public InvoiceRepository(ValidationErrorCodes errorCodes,
                                             DataBaseContext dbContext,
                                             ILoginUser loggedUser,
                                             IChargeBatchRepository chargeBatchRepository
                                             ) : base(errorCodes, dbContext, loggedUser)
        {
            _chargeBatchRepository = chargeBatchRepository;
        }

        public async Task<IInvoice> AddNew(IInvoice entity)
        {
            try
            {
                Invoice tEntity = entity as Invoice;
                //tEntity.IllnessDate = tEntity.EntryDate;
                tEntity.IllnessDate = null;
                tEntity.IllnessSimDate = null;
                if (entity.ChargeBatchUId!=null && entity.ChargeBatchUId.ToString()!= "00000000-0000-0000-0000-000000000000")
                {
                    var _chargeBatch = await this._chargeBatchRepository.GetByUId(entity.ChargeBatchUId.ToString());
                    tEntity.ChargeBatchId = _chargeBatch.Id;
                }else
                {
                    var _chargeBatch = await this._chargeBatchRepository.GetCurrentBatch();
                    tEntity.ChargeBatchId = _chargeBatch.Id;
                }
                if(!entity.ReviewNeeded.HasValue)
                {
                    entity.ReviewNeeded = false;
                }
                

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(string uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<Invoice>(i => i.UId == Guid.Parse(uid) && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInvoice>> GetAll()
        {
            return await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
        }

        public async Task<IEnumerable<IInvoice>> GetByBatchId(int batchId)
        {
            return await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.ChargeBatchId == batchId && i.IsDeleted == false);
        }

        public async Task<IEnumerable<IInvoice>> GetByBatchUId(string batchUId)
        {
            var batchData = await this._chargeBatchRepository.GetByUId(batchUId);
            return await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.ChargeBatchId == batchData.Id && i.IsDeleted == false);
        }

        public async Task<IInvoice> GetById(int id)
        {
            return await this.Connection.SingleAsync<Invoice>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
        }

        public async Task<IInvoice> GetByUId(Guid UId)
        {
            return await this.Connection.SingleAsync<Invoice>(i => i.UId == UId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
        }

        public async Task<IInvoice> GetInvoice(int patientCaseId, Guid invoiceUId)
        {
            try
            {
                return await this.Connection.SingleAsync<Invoice>(i => i.PatientCaseId == patientCaseId && i.UId == invoiceUId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IInvoice> GetInvoice(int patientCaseId, int invoiceId)
        {
            try
            {
                return await this.Connection.SingleAsync<Invoice>(i => i.PatientCaseId == patientCaseId && i.Id == invoiceId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IInvoice>> GetAllNotMadeClaim()
        {
            var query = this.Connection.From<Invoice>().Select<Invoice>((i) => new
            {
                i.Id,
                i.PatientCaseId
            }).Where(i=>i.ClaimId==null && i.PracticeId== LoggedUser.PracticeId && i.IsDeleted==false && i.ReviewNeeded==false);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Invoice>.MapList(dynamicResult);
            return result;
        }

        public async Task<IEnumerable<IInvoice>> GetInvoices(IInvoiceBillHistoryFilter filter)
        {
            try
            {
                var query = this.Connection.From<Invoice>()
                      .LeftJoin<Invoice, ChargeBatch>((i, c) => i.ChargeBatchId == c.Id)
                      .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                      .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                      .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                      .SelectDistinct<Invoice, ChargeBatch, Patient, Claim, PatientCase>((i, cb, p, c, pc) => new
                      {
                          i,
                          BatchNo = cb.BatchNo,
                          BillingID = p.BillingID,
                          ClaimUId = c.UId,
                          SentDate = c.SentDate,
                          ChargeBatchUId = cb.UId,
                          PatientCaseUId = pc.UId
                      })
                       .Where(i => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == filter.PatientCaseId && i.IsDeleted == false);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IInvoiceBillHistoryFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<Invoice>.MapList(dynamicResult);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IInvoice>> GetInvoicesByIds(int[] idsArray)
        {
            try
            {
                var query = this.Connection.From<Invoice>()
                      .LeftJoin<Invoice, ChargeBatch>((i, c) => i.ChargeBatchId == c.Id)
                      .LeftJoin<Invoice, PatientCase>((i, pc) => i.PatientCaseId == pc.Id)
                      .LeftJoin<PatientCase, Patient>((pc, p) => pc.PatientId == p.Id)
                      .LeftJoin<Invoice, Claim>((i, c) => i.ClaimId == c.Id)
                      .SelectDistinct<Invoice, ChargeBatch, Patient, Claim, PatientCase>((i, cb, p, c, pc) => new
                      {
                          i,
                          BatchNo = cb.BatchNo,
                          BillingID = p.BillingID,
                          ClaimUId = c.UId,
                          SentDate = c.SentDate,
                          ChargeBatchUId = cb.UId,
                          PatientCaseUId = pc.UId,
                          PatientAccountNumber=c.PatientAccountNumber
                      })
                       .Where(i => i.PracticeId == LoggedUser.PracticeId && idsArray.Contains(i.Id) && i.IsDeleted == false);

                //string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                //string countExpression = query.ToCountStatement();
                //string whereExpression = await WhereClauseProvider<IInvoiceBillHistoryFilter>.GetWhereClause(filter);

                //query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<Invoice>.MapList(dynamicResult);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<IInvoice>> GetInvoices(IEnumerable<int> patientCaseId)
        {
            try
            {
                return await this.Connection.SelectAsync<Invoice>(i => patientCaseId.Contains(i.PatientCaseId) && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> GetMaxId()
        {
            try
            {
                var invoices = (await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId)).OrderByDescending(i => i.Id);
                var invoiceid = invoices.Select(i => i.Id);
                return invoiceid.FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IInvoice entity)
        {
            try
            {
                Invoice tEntity = entity as Invoice;

                if (tEntity.ServiceCircumstanceId == 0)
                    tEntity.ServiceCircumstanceId = null;

                if (entity.ChargeBatchUId != Guid.Empty)
                {
                    var _chargeBatch = await this._chargeBatchRepository.GetByUId(entity.ChargeBatchUId.ToString());
                    entity.ChargeBatchId = _chargeBatch != null ? _chargeBatch.Id : 0;
                }

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.BillFromDate,
                                               x.BillToDate,
                                               x.BillProviderId,
                                               x.BillFacilityId,
                                               x.ChargeBatchId,                                               
                                               x.DateOfSign,
                                               x.EntryDate,
                                               x.FacilityId,
                                               x.HospitalizedFrom,
                                               x.HospitalizedTo,
                                               x.IllnessDate,
                                               x.IllnessSimDate,
                                               x.MartialStatus,
                                               x.LabSalesRepID,
                                               x.PatientCaseId,
                                               x.PatientGender,
                                               x.RefDoctorId,
                                               x.SupervisingProviderId,
                                               x.EmployementStatus,
                                               x.DisabilityTo,
                                               x.DisabilityFrom,
                                               x.AuthorizationNumberId,
                                               x.AccessionNumber,
                                               x.AccEmploy,
                                               x.AccAuto,
                                               x.AccOther,
                                               x.AccState,
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.FromTime,
                                               x.ToTime,
                                               x.PerformingProviderId,
                                               x.ServiceCircumstanceId,
                                               x.IsAROldCharges,
                                               x.OrderringProviderId,
                                               x.AuxillaryProviderId,
                                               x.ReviewNeeded,
                                               x.IsBillable,
                                               x.NonBillableComments,
                                               x.IsRejected,
                                               x.RejectedPIN
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateClaimId(IInvoice entity)
        {
            try
            {
                Invoice tEntity = entity as Invoice;

                if (entity.ChargeBatchUId != Guid.Empty)
                {
                    var _chargeBatch = await this._chargeBatchRepository.GetByUId(entity.ChargeBatchUId.ToString());
                    entity.ChargeBatchId = _chargeBatch != null ? _chargeBatch.Id : 0;
                }

                //var errors = await this.ValidateEntityToUpdate(tEntity);
                //if (errors.Count() > 0)
                //    await this.ThrowEntityException(errors);
                
                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.ClaimId
                                              
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateIsDeleted(IInvoice entity)
        {
            try
            {
                Invoice tEntity = entity as Invoice;
                tEntity.IsDeleted = true;
                
                //var errors = await this.ValidateEntityToUpdate(tEntity);
                //if (errors.Count() > 0)
                //    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.IsDeleted,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdatePerformingProviderIdForNineSeries(IInvoice entity)
        {
            try
            {
                Invoice tEntity = entity as Invoice;

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.PerformingProviderId,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.Id == tEntity.Id && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }


        public async Task<int> UpdateReviewNeeded(Guid UId, bool flagYN,string comments)
        {
            try
            {
                Invoice tEntity = await this.GetByUId(UId) as Invoice;
                tEntity.ReviewNeeded = flagYN;
                tEntity.ReviewComments = comments;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.ReviewNeeded,
                                               x.ReviewComments,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateChargeRefComments(int invoiceId,string comments)
        {
            try
            {
                Invoice tEntity = await this.GetById(invoiceId) as Invoice;
                
                tEntity.ReviewComments = comments;
                tEntity.IsBillable = false;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {                                               
                                               x.ReviewComments,
                                               x.IsBillable,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> UpdateFeeAmountWhileRollUP(int invoiceId, decimal feeAmount)
        {
            try
            {
                Invoice tEntity = await this.GetById(invoiceId) as Invoice;

                tEntity.FeeAmount = feeAmount;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.FeeAmount,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToAdd(Invoice tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors = EntryDateValidation(tEntity, errors);
            if (!string.IsNullOrEmpty(tEntity.AccessionNumber))
            {
                var res = await this.Connection.SelectAsync<Invoice>(i => i.AccessionNumber == tEntity.AccessionNumber);
                if (res.Count() > 0)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AccessionNumberUnique]));
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        public override async Task<IEnumerable<IValidationResult>> ValidateEntityToUpdate(Invoice tEntity)
        {
            List<IValidationResult> errors = new List<IValidationResult>();
            errors = EntryDateValidation(tEntity, errors);

            if (!string.IsNullOrEmpty(tEntity.AccessionNumber))
            {
                var res = await this.Connection.SelectAsync<Invoice>(i => i.AccessionNumber.ToLower().Trim() == tEntity.AccessionNumber.ToLower().Trim()
                                                                       && i.UId != tEntity.UId);
                if (res.Count() > 0)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AccessionNumberUnique]));
            }

            var entityErrors = await base.ValidateEntity(tEntity);
            errors.AddRange(entityErrors);

            return errors;
        }

        private List<IValidationResult> EntryDateValidation(Invoice tEntity, List<IValidationResult> errors)
        {
            /* Post date should not be less than Bill from Date and Bill to Date*/
            if (tEntity.EntryDate.Date < tEntity.BillFromDate.Date || tEntity.EntryDate.Date < tEntity.BillToDate.Date)
                errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.EntryDateValidation]));
            return errors;
        }

        public async Task<bool> CheckForAccessionNumber(string accessionNumber)
        {
            /*Check Accession No exist in Invoice table*/
            var _invoice = await this.Connection.SelectAsync<Invoice>(i => i.AccessionNumber.ToLower().Trim() == accessionNumber.ToLower().Trim()
                                                                        && i.PracticeId == LoggedUser.PracticeId);
            return _invoice.Count() == 0 ? false : true;
        }

        //public async Task<bool> CheckForAccessionNumber(string accessionNumber)
        //{
        //    /*Check Accession No exist in Invoice table*/
        //    var query = this.Connection.From<Invoice>()
        //        .Join<Invoice, Invoice>((x, y) => x.Id == y.Id, NoLockTableHint.NoLock)
        //        .Select<Invoice>(i => i.AccessionNumber).Where(i => i.IsDeleted == false && i.AccessionNumber.ToLower().Trim() == accessionNumber.ToLower().Trim()
        //                                                                  && i.PracticeId == LoggedUser.PracticeId);

        //    var queryResult = await this.Connection.SelectAsync<dynamic>(query);
        //    var result = Mapper<Charges>.Map(queryResult);


        //    return result == null ? false : true;
        //}

        public async Task<IEnumerable<IInvoice>> Get(int patientCaseId)
        {
            return await this.Connection.SelectAsync<Invoice>(i => i.PatientCaseId == patientCaseId && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
        }
        public async Task<IEnumerable<IInvoice>> Get(IEnumerable<int> patientCaseId)
        {
            return await this.Connection.SelectAsync<Invoice>(i => patientCaseId.Contains(i.PatientCaseId) && i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false);
        }

        public async Task ThrowError(int count)
        {
            if (count > 0)
                await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ChargeExist]));
        }

        public async Task<IEnumerable<IInvoice>> GetAllAccessionNumber(int? patientCaseId)
        {
            return await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && (patientCaseId == null || i.PatientCaseId == patientCaseId));
        }

        public async Task<IEnumerable<IInvoice>> GetAllAccessionNumberForRolledUp(int? patientCaseId)
        {
            //return await this.Connection.SelectAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && (patientCaseId == null || i.PatientCaseId == patientCaseId));
            var query = this.Connection.From<Invoice>()
                     .LeftJoin<Invoice, Charges>((i, c) => i.Id == c.InvoiceId)
                     .Select<Invoice>((i) => new
                     {
                         i
                     })
                      .Where<Charges>(i => i.PracticeId == LoggedUser.PracticeId && i.PatientCaseId == patientCaseId && i.IsDeleted == false && i.IsLocked == false);

            var dynamicResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Invoice>.MapList(dynamicResult);

            return result.Distinct();
        }

        public async Task<IInvoice> GetByAccessionNumber(string accessionNumber)
        {
            return await this.Connection.SingleAsync<Invoice>(i => i.PracticeId == LoggedUser.PracticeId && i.IsDeleted == false && i.AccessionNumber == accessionNumber);
        }

        public async Task ThrowReviewNeededError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("This charge is in under Deficiency bucket. Please release first."));
        }

        public async Task ThrowIsBillableError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("This charge is marked as Non Billable."));
        }

        public async Task ThrowFurtureClaimError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("Cannot make future dates claim."));
        }

        public async Task ThrowChargeLockedError()
        {
            await this.ThrowEntityException(new ValidationCodeResult("This charge will be Non Billable due to came duplicate [DOS, Provider, CPT Code] and adjusted Quantity with first charge for this dos date"));
        }

        public async Task<int> UpdateIsBillable(Guid uId, bool isBillable, string billableCoupon)
        {
            try
            {
                Invoice tEntity = await this.GetByUId(uId) as Invoice;
                tEntity.IsBillable = isBillable;
                tEntity.BillableCoupon = (tEntity.IsBillable == true ? billableCoupon : "");

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.IsBillable,
                                               x.BillableCoupon,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> MarkAsRejected(Guid uId, string rejectedPIN)
        {
            try
            {
                Invoice tEntity = await this.GetByUId(uId) as Invoice;
                tEntity.IsRejected = true;
                tEntity.RejectedPIN = rejectedPIN;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<Invoice>()
                                           .Update(x => new
                                           {
                                               x.IsRejected,
                                               x.RejectedPIN,
                                               x.ModifiedDate,
                                               x.ModifiedBy
                                           })
                                           .Where(i => i.UId == tEntity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<ICharges>> GetInvoicePaymentAdjustments(List<string> accessioList)
        {
            try
            {
                var query = this.Connection.From<ChargeViewDTO>()
                             .Select<ChargeViewDTO>((ct) => new
                             {
                                 ct.AccessionNumber,
                                 PaidAmount = Sql.Sum(ct.PaidAmount),
                                 TotalAdjustment = Sql.Sum(ct.TotalAdjustment),
                                 DueAmount=Sql.Sum(ct.DueAmount)
                             })
                             .Where<ChargeViewDTO>(i => accessioList.Contains(i.AccessionNumber)).OrderBy(i => i.AccessionNumber).
                             GroupBy(i => i.AccessionNumber);
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<ChargeViewDTO>.MapList(queryResult);

                return result;
                //return 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowRejectionPINNotMatched()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ChargeRejectionPIN]));
        }
    }
}
