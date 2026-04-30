using PractiZing.Base.Entities.MasterService;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigDrugClassRepository
    {
        Task<IConfigDrugClass> Get(int count);
        Task<IConfigDrugClass> GetByCode(string cptcode);
    }
}
