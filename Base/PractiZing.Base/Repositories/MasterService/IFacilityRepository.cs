using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IFacilityRepository : IBaseRepository
    {
        Task<IEnumerable<IFacility>> GetAll();
        Task<IEnumerable<IFacility>> GetAllActiveFacility();
        Task<IFacility> GetByUId(Guid uid);
        Task<IFacility> GetById(Int16 id);
        Task<IFacility> AddNew(IFacility entity);
        Task<int> Update(IFacility entity);
        Task<int> Delete(int id);
        Task<IFacility> GetFacilityByName(string name);
        Task<IFacility> GetDefaultFacility();
        Task<IEnumerable<IFacility>> GetByUId(IEnumerable<Guid> Ids);
        Task<IEnumerable<IFacility>> GetParentActiveFacility();
        Task<IFacility> GetFacilityByNPI(string npi);
        Task<IFacility> GetByEmrId(int id);
        Task<IFacility> GetByEmrIdWithMH(int id, bool isMH);
        Task<IFacility> GetByCode(string code, bool isMH);
        Task<IFacility> GetFacilityByNPIAndCode(string npi, string facilityCode);
        Task ThrowError();
        Task ThrowError(string cptCode);
        Task<string> GetFacilityNPIByICDClassification(int classificationType);
    }
}
