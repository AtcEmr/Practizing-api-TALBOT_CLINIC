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
    public class MasterICD10Repository : ModuleBaseRepository<MasterICD10>, IMasterICD10Repository
    {
        public MasterICD10Repository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {
                
        }

        //public async Task<IEnumerable<IMasterICD10>> SearchICD(string entity)
        //{
        //    try
        //    {
        //         return await this.Connection.SelectAsync<MasterICD10>(i => i.Code.Contains(entity) || i.Description.Contains(entity));
        //        
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}


        public async Task<IPaginationQuery<IMasterICD10>> SearchICD(SearchQuery<IMasterICD10Filter> entity)
        {
            try
            {
                var query = this.Connection
                              .From<MasterICD10>()
                              .Select<MasterICD10>((p) => new
                              {
                                  p
                              })
                               .OrderBy<MasterICD10>(i => i.Code);
                
                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();

                entity.Filter.Code = entity.Filter.Code ?? "";
                entity.Filter.Description = entity.Filter.Description ?? "";

                query.Where(i => i.Code.Contains(entity.Filter.Code) || i.Description.Contains(entity.Filter.Description));
                string whereExpression = await WhereClauseProvider<IMasterICD10Filter>.GetWhereClause(entity.Filter);
                entity.SortExpression = query.OrderByExpression;
                var result = await this.Connection.QueryPagination<MasterICD10, IMasterICD10Filter>(entity, selectExpression, whereExpression, countExpression);
                return new PaginationQuery<IMasterICD10>(result.Data, result.TotalRecords);
            }

            catch
            {
                throw;
            }
        }
    }
}
