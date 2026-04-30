using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using System.Net.Http;
using Newtonsoft.Json;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class ChasePaymentChildRepository : ModuleBaseRepository<ChasePaymentChild>, IChasePaymentChildRepository
    {
        private readonly IBankReconciliationRepository _bankReconciliationRepository;
        
        public ChasePaymentChildRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IBankReconciliationRepository bankReconciliationRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            this._bankReconciliationRepository = bankReconciliationRepository;
        }

        public async Task<IEnumerable<IChasePaymentChild>> Get(int chasePaymentId)
        {
            var list = await this.Connection.SelectAsync<ChasePaymentChild>(i => i.ChasePaymentId==chasePaymentId);

            return list;
        }

        public async Task<bool> AddBulk(IEnumerable<IChasePaymentChild> entityList)
        {
            List<ChasePaymentChild> chasePaymentChildList = new List<ChasePaymentChild>();
            entityList.ToList().ForEach((res) =>
            {
                ChasePaymentChild chasePaymentChild = res as ChasePaymentChild;
                chasePaymentChildList.Add(chasePaymentChild);
            });

            await base.AddAllAsync(chasePaymentChildList);
            return true;
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await this.Connection.DeleteAsync<ChasePaymentChild>(i => i.Id == id);
            }
            catch
            {
                throw;
            }
        }


    }
}
