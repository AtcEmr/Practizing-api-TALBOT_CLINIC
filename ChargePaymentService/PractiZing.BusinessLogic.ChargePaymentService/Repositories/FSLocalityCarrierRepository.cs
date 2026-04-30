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
    public class FSLocalityCarrierRepository : ModuleBaseRepository<FSLocalityCarrier>, IFSLocalityCarrierRepository
    {
        public FSLocalityCarrierRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser
                                            ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IFSLocalityCarrier> AddNew(IFSLocalityCarrier entity)
        {
            try
            {
                FSLocalityCarrier tEntity = entity as FSLocalityCarrier;
                return await base.AddNewEntity(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(short id)
        {
            try
            {
                return await this.Connection.DeleteAsync<FSLocalityCarrier>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IFSLocalityCarrier>> GetAll()
        {
            return await this.Connection.SelectAsync<FSLocalityCarrier>();
        }

        public async Task<IFSLocalityCarrier> GetById(short id)
        {
            return await this.Connection.SingleAsync<FSLocalityCarrier>(i => i.Id == id);
        }

        public async Task<int> Update(IFSLocalityCarrier entity)
        {
            try
            {
                FSLocalityCarrier tEntity = entity as FSLocalityCarrier;

                var updateOnlyFields = this.Connection
                                           .From<FSLocalityCarrier>()
                                           .Update(x => new
                                           {
                                               x.Locality,
                                               x.CarrierNumber
                                           })
                                           .Where(i => i.Id == entity.Id);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetLocality()
        {
            var result = (await this.Connection.SelectAsync<FSLocalityCarrier>()).ToList();
            return (result.Select(i => i.Locality).Distinct());
        }

        public async Task<IEnumerable<short>> GetCarrierNumber()
        {
            var result = (await this.Connection.SelectAsync<FSLocalityCarrier>()).ToList();
            return result.Select(i => i.CarrierNumber).Distinct();
        }
    }
}
