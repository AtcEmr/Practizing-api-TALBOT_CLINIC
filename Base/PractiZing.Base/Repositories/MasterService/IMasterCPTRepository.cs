using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IMasterCPTRepository
    {
        Task<IPaginationQuery<IMasterCPT>> SearchCPT(SearchQuery<IMasterCPTFilter> entity);
    }
}
