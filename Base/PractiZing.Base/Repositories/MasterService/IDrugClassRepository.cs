using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IDrugClassRepository : IBaseRepository
    {
        Task<IEnumerable<IDrugClass>> GetAll();
        Task<IDrugClass> GetById(int id);
        Task<IDrugClass> AddNew(IDrugClass entity);
        Task<long> Update(IDrugClass entity);
        Task<int> Delete(int id);
    }
}
