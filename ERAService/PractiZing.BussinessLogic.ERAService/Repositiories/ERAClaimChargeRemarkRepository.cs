using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.DataAccess.ERAService;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Entities.SecurityService;
using ServiceStack.OrmLite.Dapper;

namespace PractiZing.BussinessLogic.ERAService.Repositiories
{
    public class ERAClaimChargeRemarkRepository : BaseRepository<ERAClaimChargeRemark>, IERAClaimChargeRemarkRepository

    {
        public ERAClaimChargeRemarkRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IERAClaimChargeRemark>> Get(long[] ids)
        {
           
            if (ids.Count() > 2000)
            {
                var query = this.Connection.From<ERAClaimChargeRemark>()
                           .Select<ERAClaimChargeRemark>(ea => new
                           {
                               ea
                           });

                query.SelectExpression = query.SelectExpression + query.FromExpression + "Where ERAClaimChargePaymentId In (" + string.Join(',', ids) + ")";

                var eRAClaimChargeRemark = await this.Connection.QueryAsync<ERAClaimChargeRemark>(query.SelectExpression);
                return eRAClaimChargeRemark;
            }


            return await this.Connection.SelectAsync<ERAClaimChargeRemark>(i => ids.Contains(i.ERAClaimChargePaymentId));
        }
    }
}
