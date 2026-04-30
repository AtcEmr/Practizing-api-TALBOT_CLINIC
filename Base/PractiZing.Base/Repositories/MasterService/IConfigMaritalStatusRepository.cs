using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigMaritalStatusRepository
    {
        Task<IEnumerable<IConfigMaritalStatus>> GetAll();
        Task<IConfigMaritalStatus> Get(byte id);
    }
}
