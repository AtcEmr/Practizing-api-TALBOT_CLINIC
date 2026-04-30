using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.Base.Common;
using PractiZing.DataAccess.BatchPaymentService.Tables;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ClaimChargeRepository : ModuleBaseRepository<ClaimCharge>, IClaimChargeRepository
    {
        private readonly IMapper _mapper;
        public ClaimChargeRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser,
                                    IMapper mapper)
                                    : base(errorCodes, dbContext, loggedUser)
        {
            this._mapper = mapper;
        }

        public async Task<IEnumerable<IClaimCharge>> GetAll()
        {
            var result = await this.Connection.SelectAsync<ClaimCharge>();
            return result;
        }

        public async Task<IEnumerable<ICharges>> GetByClaim(long claimId,long invoiceId, int? pageNumber)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, ClaimCharge>((i, j) => j.ChargeId == i.Id)
                        .LeftJoin<Charges, ConfigPOS>((c, cp) => c.POSId == cp.Code)
                        .LeftJoin<Charges, ConfigTOS>((c, ct) => c.TOSId == ct.Code)
                        .Select<ClaimCharge, Charges, ConfigTOS, ConfigPOS>((i, j, t, p) => new
                        {
                            j,
                            POSDescription = p.Description,
                            TOSDescription = t.Descr,
                            PageNumber = i.PageNumber,
                            CliaNumber = i.CliaNumber,
                            ClaimChargeMod1 = i.Mod1,
                            ClaimChargeMod2 = i.Mod2,
                            ClaimChargeMod3 = i.Mod3,
                            ClaimChargeMod4 = i.Mod4

                        }).Where<ClaimCharge,Charges>((i,j) => i.ClaimId == claimId && j.InvoiceId==invoiceId);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);
            foreach (var item in result)
            {
                if(!string.IsNullOrWhiteSpace(item.ClaimChargeMod1))
                {
                    item.Mod1 = item.ClaimChargeMod1;
                    item.Mod2 = "";
                    item.Mod3 = "";
                    item.Mod4 = "";
                }
                if (!string.IsNullOrWhiteSpace(item.ClaimChargeMod2))
                {
                    item.Mod2 = item.ClaimChargeMod2;
                }
                if (!string.IsNullOrWhiteSpace(item.ClaimChargeMod3))
                {
                    item.Mod3 = item.ClaimChargeMod3;
                }
                if (!string.IsNullOrWhiteSpace(item.ClaimChargeMod4))
                {
                    item.Mod4 = item.ClaimChargeMod4;
                }
            }
            if (pageNumber != null)
                return result.Where(i => i.PageNumber == pageNumber);
            return result;

        }

        public async Task<IEnumerable<ICharges>> GetByClaim(int[] claimIds)
        {
            var query = this.Connection.From<Charges>()
                        .Join<Charges, ClaimCharge>((i, j) => j.ChargeId == i.Id)
                        .Join<Charges, Invoice>((c, i) => c.InvoiceId == i.Id)
                        .Select<ClaimCharge, Charges, Invoice>((i, j, x) => new
                        {
                            j,
                            ClaimId = i.ClaimId,
                            AccessionNumber = x.AccessionNumber
                        })
                        .Where<ClaimCharge, Charges>((i, j) => claimIds.Contains(i.ClaimId));

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<Charges>.MapList(queryResult);

            return result;
        }

        public async Task<IClaimCharge> GetById(int id)
        {
            var result = await this.Connection.SingleAsync<ClaimCharge>(i => i.Id == id);
            return result;
        }

        public async Task<IEnumerable<IClaimCharge>> GetByIds(int chargeId)
        {
            var result = await this.Connection.SelectAsync<ClaimCharge>(i => i.ChargeId == chargeId);
            return result;
        }

        public async Task<IClaimCharge> GetByChargeId(int id)
        {
            var query = this.Connection.From<ClaimCharge>()
                        .LeftJoin<ClaimCharge, Claim>((cc, c) => cc.ClaimId == c.Id)
                        .LeftJoin<Claim, ClaimBatch>((c, cb) => c.ClaimBatchId == cb.Id)
                        .SelectDistinct<ClaimCharge, Claim, ClaimBatch>((cc, c, cb) => new
                        {
                            cc,
                            SentDate = c.SentDate,
                            BatchId = cb.Id,
                            ClaimStatus = c.Status,
                            BatchStatusId = cb.BatchStatus
                        })
                        .Where<ClaimCharge>(i => i.ChargeId == id);

            var queryResult = await this.Connection.SelectAsync<dynamic>(query);
            var result = Mapper<ClaimCharge>.Map(queryResult);

            return result;
        }

        public async Task<IClaimCharge> AddNew(IClaimCharge entity)
        {
            try
            {
                ClaimCharge tEntity = entity as ClaimCharge;


                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var result = await base.AddNewAsync(tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task AddNew(IEnumerable<IClaimCharge> entities)
        {
            try
            {
                foreach (var item in entities)
                {
                    await this.AddNew(item);
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IClaimCharge entity)
        {
            try
            {
                ClaimCharge tEntity = entity as ClaimCharge;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection.From<ClaimCharge>()
                                                        .Update(x => new
                                                        {
                                                            x.ChargeId,
                                                            x.ClaimId
                                                        })
                                                        .Where<ClaimCharge>(i => i.Id == entity.Id);

                var result = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ClaimCharge>(i => i.Id == id);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByClaimId(int claimId)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ClaimCharge>(i => i.ClaimId == claimId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByClaimId(int[] claimIds)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ClaimCharge>(i => claimIds.Contains(i.ClaimId));
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> DeleteByChargeId(int chargeId)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<ClaimCharge>(i => i.ChargeId == chargeId);
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CheckForDelete(int chargeId, bool isDelete)
        {
            try
            {
                List<IValidationResult> errors = new List<IValidationResult>();
                var result = await this.GetByChargeId(chargeId);

                if (result != null)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimforChargeDelete]));

                if (result != null && result.SentDate != null && result.BatchStatusId == 2 && result.ClaimStatus.ToLower() == "sent" && isDelete == false)
                    errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimCreatedforCharge, result.ClaimId, result.BatchId]));
                
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> CheckChargeForDelete(int chargeId)
        {
            try
            {
                List<IValidationResult> errors = new List<IValidationResult>();
                var result = await this.GetByChargeId(chargeId);

                if (result != null)
                {
                    if (result.SentDate.HasValue)
                        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimCreatedforCharge, result.BatchId]));
                    else
                        errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.ClaimforCharge]));
                }


                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                return 1;
            }
            catch
            {
                throw;
            }
        }

    }
}
