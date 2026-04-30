using AutoMapper;
using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.MasterService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.View.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PaymentBatchRepository : ModuleBaseRepository<PaymentBatch>, IPaymentBatchRepository
    {
        private readonly IMapper _mapper;
        private IAttFileRepository _attFileRepository;
        private IInsuranceCompanyRepository _insuranceCompanyRepository;
        private IDepositTypeRepository _depositTypeRepository;
        public PaymentBatchRepository(ValidationErrorCodes errorCodes,
                                     DataBaseContext dbContext,
                                     ILoginUser loggedUser,
                                     IMapper mapper,
                                     IAttFileRepository attFileRepository,
                                     IInsuranceCompanyRepository insuranceCompanyRepository,
                                     IDepositTypeRepository depositTypeRepository)
                                     : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
            this._attFileRepository = attFileRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._depositTypeRepository = depositTypeRepository;
        }

        /// <summary>
        /// method to get payment batches with its attachments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IPaymentBatch>> Get()
        {
            var result = await this.Connection.SelectAsync<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId && i.IsSystem == false);
            foreach (var item in result)
                item.AttFiles = await this._attFileRepository.GetByTableId(item.Id, AttTableConstant.PaymentBatch);

            return result;
        }

        public async Task<IPaymentBatch> GetForBulkAdjustment()
        {
            var result = await this.Connection.SelectAsync<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId && i.IsSystem == false);
            return result.Where(i => i.CreatedDate.Year == DateTime.Now.Year && i.CreatedDate.Month == DateTime.Now.Month && i.CreatedDate.Day == DateTime.Now.Day).FirstOrDefault();
        }

        public async Task<IPaymentBatch> GetById(long? Id = 0)
        {
            try
            {
                return await this.Connection.SingleAsync<PaymentBatch>(i => i.Id == Id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// method for bulk payment to get all batches with its attachments acc. to filters 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IVoucherViewDTO>> GetBulkVouchers(IVoucherViewFilter entity)
        {
            var list = this.Connection.Select<VoucherViewDTO>(i => i.EffectiveDate >= Convert.ToDateTime(entity.FromDate) && i.EffectiveDate <= Convert.ToDateTime(entity.ToDate));
            if(entity.InsuranceCompanyId.HasValue && entity.InsuranceCompanyId.Value>0)
            {
                list = list.Where(i => i.InsuranceCompanyId == entity.InsuranceCompanyId).ToList();
            }            
            return list.OrderByDescending(i=>i.EffectiveDate);
        }

        /// <summary>
        /// method for bulk payment to get all batches with its attachments acc. to filters 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IBulkPaymentScreenDTO>> GetBatch(IBulkPaymentFilter entity, int[] batchIds)
        {
            var query = this.Connection.From<PaymentBatch>()
                        //.LeftJoin<PaymentBatch, Voucher>((pb, v) => pb.Id == v.PaymentBatchId)
                        //.LeftJoin<Voucher, Payment>((v, p) => v.Id == p.VoucherId)
                        .Select<PaymentBatch>((pb) => new
                        {
                            PaymentBatchId = pb.Id,
                            //BatchAmount = pb.BatchAmount,
                            BatchAmount = pb.Amount,
                            BatchNo = pb.BatchNo,
                            BatchDate = pb.BatchDate,
                            CreatedBy = pb.CreatedBy,
                            PaymentBatchUId = pb.UId
                        })
                        //.Where(i => batchIds.Contains(i.Id))
                        .OrderByDescending(i => i.BatchDate);

            var resultFilter = _mapper.Map<PaymentBatchFilter>(entity);

            string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
            string countExpression = query.ToCountStatement();
            string whereExpression = await WhereClauseProvider<IPaymentBatchFilter>.GetWhereClause(resultFilter);

            string defaultExpression = null;

            defaultExpression = $"{query.Where<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId).WhereExpression.Replace("@0", $"{LoggedUser.PracticeId}")}".Replace("WHERE", "");

            whereExpression = string.IsNullOrEmpty(whereExpression) ? defaultExpression : defaultExpression + " AND " + whereExpression;

            whereExpression = batchIds.Count() == 0 ? whereExpression : whereExpression + " OR " + "PaymentBatch.Id In ( " + string.Join(',', batchIds) + ")";

            var queryResult = await this.Connection.QueryAsync<BulkPaymentScreenDTO>(selectExpression + "Where " + whereExpression, LoggedUser.PracticeId);
            int[] paymentBatchIds = queryResult.Select(i => i.PaymentBatchId).Distinct().ToArray();

            var attachmentData = await this._attFileRepository.GetByTableId(paymentBatchIds, AttTableConstant.PaymentBatch);

            foreach (var item in queryResult)
            {
                item.AttFiles = attachmentData.Where(i => i.TableIdValue == item.PaymentBatchId);
            }

            return queryResult;
        }

        public async Task<IEnumerable<IBulkPaymentScreenDTO>> GetBatchByBatchIds(IEnumerable<int> ids)
        {
            var query = this.Connection.From<PaymentBatch>()
                        //.LeftJoin<PaymentBatch, Voucher>((pb, v) => pb.Id == v.PaymentBatchId)
                        //.LeftJoin<Voucher, Payment>((v, p) => v.Id == p.VoucherId)
                        .Select<PaymentBatch>((pb) => new
                        {
                            PaymentBatchId = pb.Id,
                            //BatchAmount = pb.BatchAmount,
                            BatchAmount = pb.Amount,
                            BatchNo = pb.BatchNo,
                            BatchDate = pb.BatchDate,
                            CreatedBy = pb.CreatedBy,
                            PaymentBatchUId = pb.UId
                        })
                        .Where(i => ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId)
                        .OrderByDescending(i => i.BatchDate);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<BulkPaymentScreenDTO>.MapList(queryResult);

            int[] paymentBatchIds = result.Select(i => i.PaymentBatchId).ToArray();

            var attachmentData = await this._attFileRepository.GetByTableId(paymentBatchIds, AttTableConstant.PaymentBatch);

            foreach (var item in result)
            {
                item.AttFiles = attachmentData.Where(i => i.TableIdValue == item.PaymentBatchId);
            }

            return result;
        }

        /// <summary>
        /// add batch with attachment
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="formFiles"></param>
        /// <returns></returns>
        public async Task<IPaymentBatch> AddNew(IPaymentBatch entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                PaymentBatch tEntity = entity as PaymentBatch;
                tEntity.BatchDate = DateTime.Now;
                tEntity.BatchNo = (await this.GetBatchNumber()).BatchNumber;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var saveBatch = await base.AddNewAsync(tEntity);

                if (formFiles != null)
                {
                    foreach (var formFile in formFiles)
                    {
                        var addAttachment = await this._attFileRepository.CreateAttachments(formFile, saveBatch.Id, AttTableConstant.PaymentBatch, formFile.FileName);
                        var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.PaymentBatch);
                    }
                }

                return saveBatch;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentBatch> AddNewEraBatch(IPaymentBatch entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                PaymentBatch tEntity = entity as PaymentBatch;
                tEntity.BatchDate = DateTime.Now;
                tEntity.BatchNo = (await this.GetERABatchNumber()).BatchNumber;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var saveBatch = await base.AddNewAsync(tEntity);

                if (formFiles != null)
                {
                    foreach (var formFile in formFiles)
                    {
                        var addAttachment = await this._attFileRepository.CreateAttachments(formFile, saveBatch.Id, AttTableConstant.PaymentBatch, formFile.FileName);
                        var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.PaymentBatch);
                    }
                }

                return saveBatch;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentBatch> AddNew(IPaymentBatch entity)
        {
            try
            {
                PaymentBatch tEntity = entity as PaymentBatch;
                tEntity.BatchDate = DateTime.Now;
                tEntity.BatchNo = (await this.GetBatchNumber()).BatchNumber;

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var saveBatch = await base.AddNewAsync(tEntity);

                return saveBatch;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// generate batch number which contains
        /// </summary>
        /// <returns></returns>
        public async Task<IGetBatchNumberDTO> GetBatchNumber()
        {
            var paymentBatch = await this.Connection.SelectAsync<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId);
            GetBatchNumberDTO number = new GetBatchNumberDTO();
            // this is creating batch number first 3 char of username - date with - separator - payment batch counts + 1;
            number.BatchNumber = LoggedUser.UserName.Substring(0, 3).ToUpper() + '-' + DateTime.Now.Date.ToShortDateString().Replace("/", "")
                + '-' + (paymentBatch.Count() == 0 ? 1 : Convert.ToInt32(paymentBatch.Max(i => i.Id) + 1));
            return number;
        }

        public async Task<IGetBatchNumberDTO> GetERABatchNumber()
        {
            var paymentBatch = await this.Connection.SelectAsync<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId);
            GetBatchNumberDTO number = new GetBatchNumberDTO();
            
            // this is creating batch number first 3 char of username - date with - separator - payment batch counts + 1;
            number.BatchNumber = "ERA_" + LoggedUser.UserName.Substring(0, 3).ToUpper() + '-' + DateTime.Now.Date.ToShortDateString().Replace("/", "")
                + '-' + (paymentBatch.Count() == 0 ? 1 : Convert.ToInt32(paymentBatch.Max(i => i.Id) + 1));

            return number;
        }

        public async Task<IPaymentBatch> Get(Guid Id)
        {
            var result = await this.Connection.SingleAsync<PaymentBatch>(i => i.UId == Id && i.PracticeId == LoggedUser.PracticeId);
            if (result != null)
                result.AttFiles = await this._attFileRepository.GetByTableId(result.Id, AttTableConstant.PaymentBatch);

            return result;
        }

        public async Task<IPaymentBatch> Update(IPaymentBatch entity, IEnumerable<IFormFile> formFiles)
        {
            try
            {
                PaymentBatch tEntity = entity as PaymentBatch;
                tEntity.Amount = tEntity.BatchAmount;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<PaymentBatch>()
                                           .Update(x => new
                                           {
                                               x.BatchAmount,
                                               x.RecordCount,
                                               x.Amount
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);
                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);

                if (formFiles != null)
                {
                    foreach (var formFile in formFiles)
                    {
                        var batchData = await base.GetById(tEntity.Id);
                        var addAttachment = await this._attFileRepository.CreateAttachments(formFile, batchData.Id, AttTableConstant.PaymentBatch, formFile.FileName);
                        var fullPath = await this._attFileRepository.SaveFile(formFile, addAttachment.UId.ToString(), AttTableConstant.PaymentBatch);
                    }
                }

                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid batchId)
        {
            return await this.Connection.DeleteAsync<PaymentBatch>(i => i.UId == batchId && i.PracticeId == LoggedUser.PracticeId);
        }

        /// <summary>
        /// method for payment and charge batch screen acc to filter.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IBatchDTO>> GetPaymentBatchGrid(IBatchFilter filter)
        {
            // filter.InsuranceCompanyId = filter.InsuranceCompanyId == null ? 0 : (await this._insuranceCompanyRepository.GetByUId(Guid.Parse(filter.InsuranceCompanyUId))).Id;

            List<IBatchDTO> batchDTOs = new List<IBatchDTO>();

            var query = this.Connection.From<PaymentBatch>()
                        .LeftJoin<PaymentBatch, Voucher>((pb, v) => pb.Id == v.PaymentBatchId)
                        .LeftJoin<Voucher, Payment>((v, p) => v.Id == p.VoucherId)
                        .LeftJoin<Payment, PaymentCharge>((pt, pc) => pt.Id == pc.PaymentId)
                        .LeftJoin<PaymentCharge, Charges>((ptc, ch) => ptc.ChargeId == ch.Id)
                        .SelectDistinct<PaymentBatch, Charges, PaymentCharge, Voucher>((pyt, ca, pct, v) => new
                        {
                            BatchAmount = pyt.BatchAmount,
                            BatchDate = pyt.BatchDate,
                            BatchNo = pyt.BatchNo,
                            RecordCount = pyt.RecordCount,
                            Id = pyt.Id,
                            PostedChargesValue = Sql.Sum(pct.PaidAmount),
                            PostedChargesCount = Sql.CountDistinct(ca.CPTCode),
                            v.InsuranceCompanyId
                        })
                        .GroupBy<PaymentBatch, Charges, PaymentCharge, Voucher>((i, j, k, v) => new { i.Id, i.BatchDate, i.BatchNo, i.RecordCount, k.PaidAmount, j.CPTCode, i.BatchAmount, v.InsuranceCompanyId })
                        .Where((x) => x.PracticeId == LoggedUser.PracticeId);

            var resultFilter = _mapper.Map<PayBatchFilter>(filter);

            //if (filter.InsuranceCompanyUId != null && filter.InsuranceCompanyUId != "")
            //{
            //    var insuranceCompany = await this._insuranceCompanyRepository.GetByUId(new Guid(filter.InsuranceCompanyUId));
            //    resultFilter.InsuranceCompanyId = insuranceCompany.Id;
            //}

            string whereExpression = await WhereClauseProvider<IPayBatchFilter>.GetWhereClause(resultFilter);

            query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<BatchDTO>.MapList(queryResult);

            // this method will remove duplicate batches.
            batchDTOs = (await this.GetBatch(result)).ToList();
            // batchDTOs = await this.FindDuplicates(result);

            batchDTOs.ToList().ForEach((res) =>
            {
                res.BatchAmount = res.Amount;
            });

            return batchDTOs;
        }

        private async Task<IEnumerable<IBatchDTO>> GetBatch(IEnumerable<IBatchDTO> batch)
        {
            List<IBatchDTO> batchDTOs = new List<IBatchDTO>();

            foreach (var item in batch)
            {
                // BatchDTO batchDTO = new BatchDTO();

                var batchData = batchDTOs.Where(i => i.Id == item.Id).FirstOrDefault();
                if (batchData == null)
                {
                    batchDTOs.Add(item);
                }
                else
                {
                    batchData.PostedChargesCount = item.PostedChargesCount;
                    batchData.PostedChargesValue = item.PostedChargesValue;
                    batchData.RecordCount = item.RecordCount;
                }
            }

            return batchDTOs;
        }

        public async Task ThrowError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.NoDeletionOfPaymentBatch]));
        }

        /// <summary>
        /// get payment batches for era file.  means where is system = true
        /// </summary>
        /// <returns></returns>
        public async Task<IPaymentBatch> GetForERA()
        {
            var result = await this.Connection.SelectAsync<PaymentBatch>(i => i.PracticeId == LoggedUser.PracticeId && i.IsSystem == true);
            return result.Where(i => i.CreatedDate.Year == DateTime.Now.Year && i.CreatedDate.Month == DateTime.Now.Month && i.CreatedDate.Day == DateTime.Now.Day).FirstOrDefault();
        }

        public async Task<IPaymentBatch> Update(IPaymentBatch entity)
        {
            try
            {
                PaymentBatch tEntity = entity as PaymentBatch;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<PaymentBatch>()
                                           .Update(x => new
                                           {
                                               x.BatchAmount,
                                               x.RecordCount
                                           })
                                           .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }
    }
}
