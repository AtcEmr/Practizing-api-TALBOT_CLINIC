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
    public class ScrubRepository : ModuleBaseRepository<Scrub>, IScrubRepository
    {
        private IConfiguration _configuration;
        public ScrubRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IConfiguration configuration
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            this._configuration = configuration;
            //this.Connection.ConnectionString = this._configuration.GetConnectionString("DefaultConnection");
            //this.DbContext.Connection.ConnectionString = this._configuration.GetConnectionString("DefaultConnection");
            
        }
        

        public async Task<IScrub> GetById(short id)
        {
            this.DbContext.SetPracticeCode();
            return await this.Connection.SingleAsync<Scrub>(i => i.Id == id);
        }

        public async Task<IEnumerable<IScrub>> GetScrubs()
        {
            return await this.Connection.SelectAsync<Scrub>();
        }

    }
}
