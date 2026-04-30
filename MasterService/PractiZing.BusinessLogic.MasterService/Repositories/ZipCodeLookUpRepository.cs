using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ZipCodeLookUpRepository : ModuleBaseRepository<ZipCodeLookUp>, IZipCodeLookUpRepository
    {

        public ZipCodeLookUpRepository(ValidationErrorCodes errorCodes,
                                        DataBaseContext dbContext,
                                        ILoginUser loggedUser
                                        ) : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IZipCodeLookUp>> GetAll()
        {
            return (await this.Connection.SelectAsync<ZipCodeLookUp>(i => i.PracticeId == LoggedUser.PracticeId)).OrderBy(i => i.Zip);
        }

        public async Task<IZipCodeLookUp> GetByZip(string zip)
        {
            return await this.Connection.SingleAsync<ZipCodeLookUp>(i => i.Zip == zip && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<IEnumerable<IZipCodeLookUp>> SearchByZip(string zip)
        {
            try
            {
                return await this.Connection.SelectAsync<ZipCodeLookUp>(i => i.Zip.Contains(zip) && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetStateCodeList()
        {
            var result = (await this.Connection.SelectAsync<ZipCodeLookUp>(i => i.PracticeId == LoggedUser.PracticeId && i.IsActive == true))
                             .OrderBy(i => i.State);
            return result.Select(i => i.State).Distinct();
        }
    }
}
