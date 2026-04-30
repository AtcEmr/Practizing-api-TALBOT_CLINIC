using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class MasterCPTRepository : ModuleBaseRepository<MasterCPT>, IMasterCPTRepository
    {
        public MasterCPTRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }
        //public async Task<IEnumerable<IMasterCPT>> SearchCPT(string entity)
        //{
        //    try
        //    {
        //         return await this.Connection.SelectAsync<MasterCPT>(i => i.Code.Contains(entity) || i.Description.Contains(entity));
        //        
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}


        public async Task<IPaginationQuery<IMasterCPT>> SearchCPT(SearchQuery<IMasterCPTFilter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<MasterCPT>()
                              .Select<MasterCPT>((p) => new
                              {
                                  p
                              })
                               .OrderBy<MasterCPT>(i => i.Code);
                entity.PageSize = 100;
                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                //if (!string.IsNullOrEmpty(entity.Filter.Code))
                //    query.Where(i => i.Code.Contains(entity.Filter.Code));


                //if (!string.IsNullOrEmpty(entity.Filter.Description))
                //    query.Where(i => i.Code.Contains(entity.Filter.Description));

                //query.Where(i => i.Code.Contains(entity.ToString()) || i.Description.Contains(entity.ToString()));
                string whereExpression = await WhereClauseProvider<IMasterCPTFilter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;
                var result = await this.Connection.QueryPagination<MasterCPT, IMasterCPTFilter>(entity, selectExpression, whereExpression, countExpression);
                return new PaginationQuery<IMasterCPT>(result.Data, result.TotalRecords);
            }
            catch
            {
                throw;
            }
        }
    }
}
