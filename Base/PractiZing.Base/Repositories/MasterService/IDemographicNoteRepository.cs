using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IDemographicNoteRepository : IBaseRepository
    {
        Task<IEnumerable<IDemographicNote>> GetAll();
        Task<IDemographicNote> GetById(int id);
        Task<IDemographicNote> GetByUId(Guid uid);
        Task<IDemographicNote> GetByChargeNumber(long chargeNumber);
        Task<IDemographicNote> AddNew(IDemographicNote entity);
        Task<int> Update(IDemographicNote entity);
        Task<int> Delete(Guid uid);
    }
}
