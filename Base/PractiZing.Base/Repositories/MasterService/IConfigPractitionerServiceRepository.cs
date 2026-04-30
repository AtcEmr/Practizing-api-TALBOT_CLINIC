using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IConfigPractitionerServiceRepository
    {
        Task<IEnumerable<IConfigPractitionerService>> Get();
        Task<IConfigPractitionerService> AddNew(IConfigPractitionerService entity);
        Task<int> Update(IConfigPractitionerService entity);
        Task<IConfigPractitionerService> GetById(int id);
        Task<IConfigPractitionerService> GetByEmrId(int emrId);
        Task<IConfigPractitionerService> GetByQualticationId(int id);
    }
}
