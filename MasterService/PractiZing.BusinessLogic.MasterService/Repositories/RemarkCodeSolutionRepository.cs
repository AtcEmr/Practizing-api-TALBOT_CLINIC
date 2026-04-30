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
    public class RemarkCodeSolutionRepository : ModuleBaseRepository<RemarkCodeSolution>, IRemarkCodeSolutionRepository
    {
        public RemarkCodeSolutionRepository(ValidationErrorCodes errorCodes, DataBaseContext dbContext, ILoginUser loggedUser)
         : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IRemarkCodeSolution>> Get(string remarkCode)
        {
            List<string> codeList = remarkCode.Split(',').Select(i=>i.Trim()).ToList();
            return await this.Connection.SelectAsync<RemarkCodeSolution>(i => codeList.Contains(i.RemarkCode));
        }

        public async Task<IEnumerable<IRemarkCodeSolution>> GetAll()
        {
            return (await this.Connection.SelectAsync<RemarkCodeSolution>()).OrderBy(i => i.RemarkCode);
        }
    }
}
