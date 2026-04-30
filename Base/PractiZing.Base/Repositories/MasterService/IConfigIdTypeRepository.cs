using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigIdTypeRepository
    {
        Task<IEnumerable<IConfigIdType>> GetAll();
        Task<IConfigIdType> GetById(short id);
        

    }
}
