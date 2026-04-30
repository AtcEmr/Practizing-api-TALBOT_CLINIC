using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
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
    public class PaymentRemarkCodeRepository : ModuleBaseRepository<PaymentRemarkCode>, IPaymentRemarkCodeRepository
    {
        private IConfigERARemarkCodesRepository _configERARemarkCodesRepository;
        public PaymentRemarkCodeRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IPaymentAdjustmentRepository paymentAdjustmentRepository,
                                      IConfigERARemarkCodesRepository configERARemarkCodesRepository)
                                      : base(errorCodes, dbContext, loggedUser)
        {
            this._configERARemarkCodesRepository = configERARemarkCodesRepository;
        }

        /// <summary>
        /// add list of remark codes.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddAll(IEnumerable<IPaymentRemarkCode> entities)
        {
            try
            {
                List<PaymentRemarkCode> tEntity = entities as List<PaymentRemarkCode>;

                await base.AddAllAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codes"></param>
        /// <param name="paymentChargeId"></param>
        /// <returns></returns>
        public async Task AddAll(string codes, int paymentChargeId)
        {
            try
            {
                List<PaymentRemarkCode> paymentRemarkCodeList = new List<PaymentRemarkCode>();
                // split codes with comma and insert into payment remark code table.
                var paymentRemarkCodeArray = (codes == null || codes == "") ? null : codes.Split(',').ToArray();

                if (codes != null && codes != string.Empty)
                {
                    int[] ids = Array.ConvertAll(paymentRemarkCodeArray, s => int.Parse(s));
                    var remarkCodes = await this._configERARemarkCodesRepository.Get(ids);

                    foreach (var item in ids)
                    {
                        var remarkCode = remarkCodes.FirstOrDefault(i => i.Id == item);

                        if (remarkCode != null)
                        {
                            PaymentRemarkCode paymentRemarkCode = new PaymentRemarkCode();
                            paymentRemarkCode.Id = 0;
                            paymentRemarkCode.PaymentChargeId = paymentChargeId;
                            paymentRemarkCode.RemarkCode = remarkCode.RemarkCode;
                            paymentRemarkCode.RemarkQualifier = remarkCode.RemarkQualifier;

                            paymentRemarkCodeList.Add(paymentRemarkCode);
                        }
                    }
                }

                if (paymentRemarkCodeList.Count() > 0)
                    await this.AddAll(paymentRemarkCodeList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(IEnumerable<int> paymentChargeId)
        {
            var result = await this.Connection.DeleteAsync<PaymentRemarkCode>(i => paymentChargeId.Contains(i.PaymentChargeId));
            return result;
        }

        public async Task<IEnumerable<IPaymentRemarkCode>> Get()
        {
            var result = await this.Connection.SelectAsync<PaymentRemarkCode>();
            return result;
        }

        public async Task<IEnumerable<IPaymentRemarkCode>> Get(int PaymentChargeId)
        {
            var result = await this.Connection.SelectAsync<PaymentRemarkCode>(i => i.PaymentChargeId == PaymentChargeId);
            return result;
        }

        public async Task<IEnumerable<IPaymentRemarkCode>> Get(IEnumerable<int> paymentChargeIds)
        {
            if (paymentChargeIds.Count() > 2000)
            {
                //long chunkSize = 2000;
                //List<List<int>> retVal = new List<List<int>>();

                //List<int> newIds = new List<int>();
                //newIds.AddRange(paymentChargeIds);

                //while (newIds.Count() > 0)
                //{
                //    long count = newIds.Count() > chunkSize ? chunkSize : newIds.Count();
                //    retVal.Add(newIds.GetRange(0, (int)count));
                //    newIds.RemoveRange(0, (int)count);
                //}

                //List<PaymentRemarkCode> paymentRemarkCodes = new List<PaymentRemarkCode>();

                //foreach (var item in retVal)
                //{
                //    var eraClaimData = await this.Connection.SelectAsync<PaymentRemarkCode>(i => item.Contains(i.PaymentChargeId));
                //    paymentRemarkCodes.AddRange(eraClaimData);
                //}

                string query = "Select * from PaymentRemarkCode Where PaymentChargeId In (" + string.Join(',', paymentChargeIds) + ")";
                var results = await this.Connection.QueryAsync<PaymentRemarkCode>(query);
                return results;
            }

            var result = await this.Connection.SelectAsync<PaymentRemarkCode>(i => paymentChargeIds.Contains(i.PaymentChargeId));
            return result;
        }

        public async Task<IPaymentRemarkCode> AddNew(IPaymentRemarkCode entity)
        {
            try
            {
                PaymentRemarkCode tEntity = entity as PaymentRemarkCode;

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
    }
}
