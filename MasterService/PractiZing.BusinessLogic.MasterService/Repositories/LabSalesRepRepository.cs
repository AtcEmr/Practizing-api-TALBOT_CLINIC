using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class LabSalesRepRepository : ModuleBaseRepository<LabSalesRep>, ILabSalesRepRepository
    {
        public LabSalesRepRepository(ValidationErrorCodes errorCodes,
                                           DataBaseContext dbContext,
                                           ILoginUser loggedUser
                                           ) : base(errorCodes, dbContext, loggedUser)
        {

        }

        public async Task<IEnumerable<ILabSalesRep>> GetAll()
        {
            return (await this.Connection.SelectAsync<LabSalesRep>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.FirstName);
        }

        public async Task<ILabSalesRep> GetByUId(Guid uid)
        {
            return await this.Connection.SingleAsync<LabSalesRep>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<ILabSalesRep> AddNew(ILabSalesRep entity)
        {
            try
            {
                LabSalesRep tEntity = entity as LabSalesRep;
                return await base.AddNewEntity(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(ILabSalesRep entity)
        {
            try
            {
                LabSalesRep tEntity = entity as LabSalesRep;

                var updateOnlyFields = this.Connection
                                           .From<LabSalesRep>()
                                           .Update(x => new
                                           {
                                               x.FirstName,
                                               x.LastName
                                           })
                                           .Where<LabSalesRep>(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);
                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }
    }
}
