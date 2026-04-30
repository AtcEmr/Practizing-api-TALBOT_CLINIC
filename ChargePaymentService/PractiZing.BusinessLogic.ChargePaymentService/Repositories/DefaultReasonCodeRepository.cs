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

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class DefaultReasonCodeRepository: ModuleBaseRepository<DefaultReasonCode>, IDefaultReasonCodeRepository
    {

        public DefaultReasonCodeRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser)
                                           : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IDefaultReasonCode>> GetAll()
        {
             return await this.Connection.SelectAsync<DefaultReasonCode>();
        }
    }
}
