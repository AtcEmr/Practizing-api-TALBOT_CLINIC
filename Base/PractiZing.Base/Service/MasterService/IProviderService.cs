using PractiZing.Base.Entities.MasterService;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface IProviderService
    {
        Task<IProvider> AddProvider(IProvider entity);
        Task<int> Update(IProvider entity);
    }
}
