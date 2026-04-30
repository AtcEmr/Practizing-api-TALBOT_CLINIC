using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PaymentAdjustmentRepository : ModuleBaseRepository<PaymentAdjustment>, IPaymentAdjustmentRepository
    {
        IPaymentAdjustmentNotesRepository _paymentAdjustmentNotesRepository;
        public PaymentAdjustmentRepository(ValidationErrorCodes errorCodes,
                                   DataBaseContext dbContext,
                                   ILoginUser loggedUser, IPaymentAdjustmentNotesRepository paymentAdjustmentNotesRepository)
                                   : base(errorCodes, dbContext, loggedUser)
        {
            this._paymentAdjustmentNotesRepository = paymentAdjustmentNotesRepository;
        }

        public async Task<IEnumerable<IPaymentAdjustment>> GetByCodes(IEnumerable<string> codes)
        {
            return await this.Connection.SelectAsync<PaymentAdjustment>(i => codes.Contains(i.ReasonCode));
        }

        public async Task<IEnumerable<int>> GetByCodes(string codes)
        {
            try
            {
                var codeList = codes.Split(',');
                var adjustments = await this.Connection.SelectAsync<PaymentAdjustment>(i => codeList.Contains(i.ReasonCode) && i.IsDenial);
                var result = adjustments.Count() == 0 ? new List<int>() : adjustments.Select(i => i.PaymentChargeId);
                return result;
                //return result.Distinct();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IPaymentAdjustment> GetById(int id)
        {
            return await this.Connection.SingleAsync<PaymentAdjustment>(i => i.Id == id);
        }

        public async Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeId(int paymentChargeId)
        {
            return await this.Connection.SelectAsync<PaymentAdjustment>(i => i.PaymentChargeId == paymentChargeId);
        }

        public async Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeId(IEnumerable<int> paymentChargeIds)
        {
            if (paymentChargeIds.Count() > 2000)
            {
                var query = this.Connection.From<PaymentAdjustment>()
                        .Select<PaymentAdjustment>((pc) => new
                        {
                            pc
                        })
                        .Where<PaymentAdjustment>(i => paymentChargeIds.Contains(i.PaymentChargeId));

                query.SelectExpression = query.SelectExpression + query.FromExpression + " Where PaymentChargeId  In (" + string.Join(',', paymentChargeIds) + ")";
                var queryResult = await this.Connection.QueryAsync<PaymentAdjustment>(query.SelectExpression);

                return queryResult;
            }

            return await this.Connection.SelectAsync<PaymentAdjustment>(i => paymentChargeIds.Contains(i.PaymentChargeId));
        }

        public async Task<IPaymentAdjustment> AddNew(IPaymentAdjustment entity)
        {
            try
            {
                PaymentAdjustment tEntity = entity as PaymentAdjustment;
                tEntity.ReasonCode = tEntity.ReasonCode.Replace("-", "");
                if (tEntity.ReasonCode.ToLower() == "oa23" || tEntity.ReasonCode.ToLower() == "pr100")
                {
                    tEntity.IsAccounted = false;
                    tEntity.IsDenial = false;
                    //if (entity.PaymentSourceCD.ToLower() == PaymentSourceTypeEnum.ERA_PAYMENT.ToString().ToLower())
                    //{
                    //    tEntity.IsAccounted = false;
                    //}   
                }
                if (tEntity.ReasonCode.ToLower() == "coadj")
                {
                    tEntity.IsAccounted = false;
                    tEntity.IsDenial = false;
                }

                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var item = await base.AddNewAsync(tEntity);

                if (item.ReasonCode.ToLower() == "co22")
                {
                    PaymentAdjustmentNotes paymentAdjustmentNotes = new PaymentAdjustmentNotes();
                    paymentAdjustmentNotes.PaymentAdjustmentId = item.Id;
                    paymentAdjustmentNotes.PaymentChargeId = item.PaymentChargeId;
                    paymentAdjustmentNotes.ReasonCode = item.ReasonCode;
                    paymentAdjustmentNotes.ChargeId = tEntity.ChargeId;
                    paymentAdjustmentNotes.Note = "Please capture of coordination of benefits from the client.";
                    await this._paymentAdjustmentNotesRepository.AddNew(paymentAdjustmentNotes);
                }
                else if (item.ReasonCode.ToLower() == "co146")
                {
                    PaymentAdjustmentNotes paymentAdjustmentNotes = new PaymentAdjustmentNotes();
                    paymentAdjustmentNotes.PaymentAdjustmentId = item.Id;
                    paymentAdjustmentNotes.PaymentChargeId = item.PaymentChargeId;
                    paymentAdjustmentNotes.ReasonCode = item.ReasonCode;
                    paymentAdjustmentNotes.ChargeId = tEntity.ChargeId;
                    paymentAdjustmentNotes.Note = "Please notify the provider to update the diagnosis codes.";
                    await this._paymentAdjustmentNotesRepository.AddNew(paymentAdjustmentNotes);
                }

                return item;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> AddOrUpdate(IEnumerable<IPaymentAdjustment> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    if (entity.Id != 0)
                        await this.Update(entity);
                    else
                        await this.AddNew(entity);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IPaymentAdjustment entity)
        {
            try
            {
                PaymentAdjustment tEntity = entity as PaymentAdjustment;
                tEntity.ModifiedDate = DateTime.Now;
                tEntity.ReasonCode = tEntity.ReasonCode.Replace("-", "");
                if (tEntity.ReasonCode.ToLower()=="oa23" || tEntity.ReasonCode.ToLower() == "pr100")
                {
                    tEntity.IsDenial = false;
                    tEntity.IsAccounted = false;
                }
                if (tEntity.ReasonCode.ToLower() == "coadj")
                {
                    tEntity.IsAccounted = false;
                    tEntity.IsDenial = false;
                }

                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<PaymentAdjustment>()
                                           .Update(x => new
                                           {
                                               x.Amount,
                                               x.ModifiedBy,
                                               x.ModifiedDate,
                                               x.IsDenial,
                                               x.IsAccounted
                                           })
                                           .Where(i => i.PaymentChargeId == entity.PaymentChargeId && i.UId == entity.UId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteById(IEnumerable<int> paymentChargeIds)
        {
            try
            {
                return await this.Connection.DeleteAsync<PaymentAdjustment>(i => paymentChargeIds.Contains(i.PaymentChargeId));
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                return await this.Connection.DeleteAsync<PaymentAdjustment>(i => i.UId == uid);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IPaymentAdjustment>> GetBonus(IEnumerable<int> paymentChargeIds)
        {
            return await this.Connection.SelectAsync<PaymentAdjustment>(i => paymentChargeIds.Contains(i.PaymentChargeId) && i.IsBonus == true);
        }
    }
}
