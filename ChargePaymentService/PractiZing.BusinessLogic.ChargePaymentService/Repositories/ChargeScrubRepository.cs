using Newtonsoft.Json;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Object;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChargeScrubRepository : ModuleBaseRepository<ChargeScrub>, IChargeScrubRepository
    {
        public ChargeScrubRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IChargeScrub>> GetAll()
        {
            try
            {
                return await this.Connection.SelectAsync<ChargeScrub>();                
            }
            catch
            {
                throw;
            }
        }

        public async Task<IChargeScrub> GetByChargeId(int chargeId)
        {
            try
            {                
                return await this.Connection.SingleAsync<ChargeScrub>(i => i.ChargeId == chargeId);                
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IChargeScrub>> GetByChargeIds(IEnumerable<int> chargeIds)
        {
            try
            {
                return await this.Connection.SelectAsync<ChargeScrub>(i => chargeIds.Contains(i.ChargeId));
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> AddChargeScrubErrors(IEnumerable<IScrubError> scrubErrors)
        {
            try
            {
                if (scrubErrors.Count() > 0)
                {
                    // delete charge scrub errors and then add new ones
                    var chargeIds = scrubErrors.Select(i => i.ChargeId).Distinct().ToList();
                    foreach (var item in chargeIds)
                    {
                        await this.DeleteByChargeId(item);
                    }
                }
                
                foreach (var item in scrubErrors)
                {                    
                    ChargeScrub chargeScrub = new ChargeScrub();
                    chargeScrub.ChargeId = item.ChargeId;
                    chargeScrub.ErrorJson = item.ErrorJson;
                    await base.AddNewAsync(chargeScrub);
                }
               
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteByChargeId(int chargeId)
        {
            await this.Connection.DeleteAsync<ChargeScrub>(i => i.ChargeId == chargeId);
            
        }
    }
}
