using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigERARemarkCodesRepository
    {
        Task<IEnumerable<IConfigERARemarkCodes>> GetAll(string remarkCode);
        Task<IEnumerable<IConfigERARemarkCodes>> Get(IEnumerable<int> Ids);
        Task<IEnumerable<IConfigERARemarkCodes>> Get(string remarkCode);
        Task<IConfigERARemarkCodes> Get(int Id);
    }
}
