using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ClaimTotalRepository : ModuleBaseRepository<ClaimTotal>, IClaimTotalRepository
    {
        public ClaimTotalRepository(ValidationErrorCodes errorCodes,
                                    DataBaseContext dbContext,
                                    ILoginUser loggedUser)
                                    : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IClaimTotal>> GetAll()
        {
            var result = await this.Connection.SelectAsync<ClaimTotal>();
            return result;
        }

        public async Task<IClaimTotal> GetById(int id)
        {
            var result = await this.Connection.SingleAsync<ClaimTotal>(i => i.Id == id);
            return result;
        }

        public async Task<IEnumerable<IClaimTotal>> GetByClaimId(int id, long pageNumber=0)
        {
            var result=await this.Connection.SelectAsync<ClaimTotal>(i => i.ClaimId == id);
            if (pageNumber != 0)
                return result.Where(i => i.PageNumber == pageNumber);
            return result;
        }

        public async Task<IClaimTotal> AddNew(IClaimTotal entity)
        {
            try
            {
                ClaimTotal tEntity = entity as ClaimTotal;

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

        public async Task<int> Update(IClaimTotal entity)
        {
            try
            {
                ClaimTotal tEntity = entity as ClaimTotal;

                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection.From<ClaimTotal>()
                                                        .Update(x => new
                                                        {
                                                            x.ClaimId,
                                                            x.PageNumber,
                                                            x.LabCharges,
                                                            x.TotalCharges,
                                                            x.AmountPaid,
                                                            x.BalanceDue,
                                                            x.OutsideLab,
                                                            x.Reserved19,
                                                            x.MedicaidResubmissionCode,
                                                            x.OriginalReferenceNumber,
                                                            x.NumKind,
                                                            x.PriorAuthorizationNumber,
                                                            x.Flags
                                                        })
                                                        .Where<ClaimTotal>(i => i.Id == entity.Id);

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
                var result = await this.Connection.DeleteAsync<ClaimTotal>(i => i.Id == id);
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
                var result = await this.Connection.DeleteAsync<ClaimTotal>(i => i.ClaimId == claimId);
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
                var result = await this.Connection.DeleteAsync<ClaimTotal>(i => claimIds.Contains(i.ClaimId));
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
