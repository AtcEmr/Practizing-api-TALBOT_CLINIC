using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.DataAccess.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Linq;

namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    public class ConfigERARemarkCodesRepository : ModuleBaseRepository<ConfigERARemarkCodes>, IConfigERARemarkCodesRepository
    {

        public ConfigERARemarkCodesRepository(ValidationErrorCodes errorCodes,
                                              DataBaseContext dbContext,
                                              ILoginUser loggedUser)
                                      : base(errorCodes, dbContext, loggedUser)
        {
        }

        public async Task<IEnumerable<IConfigERARemarkCodes>> GetAll(string remarkCode)
        {
            remarkCode = remarkCode == null ? string.Empty : remarkCode;
            return await this.Connection.SelectAsync<ConfigERARemarkCodes>(i=> i.IsActive == true && (remarkCode == "" || i.RemarkCode.Contains(remarkCode)));
        }

        public async Task<IEnumerable<IConfigERARemarkCodes>> Get(string code)
        {
            string[] codes = code.ToString().Split(',');
            var remarkCode = await this.Connection.SelectAsync<ConfigERARemarkCodes>(i => i.IsActive == true && codes.Contains(i.RemarkCode));
            remarkCode.ToList().ForEach((res) =>
            {
                res.FullCode = res.RemarkQualifier + ' ' + res.RemarkCode;
            });

            return remarkCode;
        }


        public async Task<IEnumerable<IConfigERARemarkCodes>> Get(IEnumerable<int> Ids)
        {
            return await this.Connection.SelectAsync<ConfigERARemarkCodes>(i => i.IsActive == true && Ids.Contains(i.Id));
        }

        public async Task<IConfigERARemarkCodes> Get(int Id)
        {
            return await this.Connection.SingleAsync<ConfigERARemarkCodes>(i => i.IsActive == true && i.Id == Id);
        }
    }
}
