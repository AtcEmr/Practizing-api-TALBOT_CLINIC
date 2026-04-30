using Microsoft.Extensions.Configuration;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PortalPaymentChildRepository : ModuleBaseRepository<PortalPaymentChild>, IPortalPaymentChildRepository
    {
        
        public PortalPaymentChildRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser                                           
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            
        }


        public async Task<IPortalPaymentChild> AddNew(IPortalPaymentChild entity)
        {
            try
            {
                PortalPaymentChild tEntity = entity as PortalPaymentChild;

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


        public async Task<IEnumerable<IPortalPaymentChild>> GetByPortalPaymentId(int portalPaymentId)
        {
            return await this.Connection.SelectAsync<PortalPaymentChild>(i => i.PortalPaymentId== portalPaymentId);
        }

        public async Task<IEnumerable<IPortalPaymentChild>> GetByPortalPaymentIdByIds(List<int> portalPaymentIds)
        {
            return await this.Connection.SelectAsync<PortalPaymentChild>(i => portalPaymentIds.Contains(i.PortalPaymentId));
        }

        public async Task<int> Delete(int paymentId)
        {
            try
            {
                return await this.Connection.DeleteAsync<PortalPaymentChild>(i => i.PaymentId == paymentId);
            }
            catch
            {
                throw;
            }
        }
    }
}
