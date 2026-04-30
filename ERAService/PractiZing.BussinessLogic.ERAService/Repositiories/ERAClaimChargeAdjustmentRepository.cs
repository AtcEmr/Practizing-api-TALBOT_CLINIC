using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ERAService;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.DataAccess.ERAService.Tables;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Entities.SecurityService;
using ServiceStack.OrmLite.Dapper;

namespace PractiZing.BussinessLogic.ERAService.Repositiories
{
    public class ERAClaimChargeAdjustmentRepository : BaseRepository<ERAClaimChargeAdjustment>, IERAClaimChargeAdjustmentRepository

    {
        public ERAClaimChargeAdjustmentRepository(ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<IERAClaimChargeAdjustment>> Get(long[] ids)
        {
            if (ids.Count() > 2000)
            {
                var query = this.Connection.From<ERAClaimChargeAdjustment>()
                            .Select<ERAClaimChargeAdjustment>(ea => new
                            {
                                ea
                            });

                query.SelectExpression = query.SelectExpression + query.FromExpression + "Where ERAClaimChargePaymentId In (" + string.Join(',', ids) + ")";

                var eRAClaimChargeAdjustment = await this.Connection.QueryAsync<ERAClaimChargeAdjustment>(query.SelectExpression);
                return eRAClaimChargeAdjustment;
            }

            return await this.Connection.SelectAsync<ERAClaimChargeAdjustment>(i => ids.Contains(i.ERAClaimChargePaymentId));
        }


    }

}
