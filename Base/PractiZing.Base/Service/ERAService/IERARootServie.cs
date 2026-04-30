using PractiZing.Base.Entities.ERAService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ERAService
{
    public interface IERARootService
    {
        Task<IERARoot> Get(long id, bool isErrorRecords = false);
        Task<IEnumerable<IERARoot>> Get();
        Task<IEnumerable<IERARoot>> GetStatus(string checkNo);
        Task<IEnumerable<IERARoot>> GetErrorStatus();
    }
}
