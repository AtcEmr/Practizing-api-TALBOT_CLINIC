using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IReferringDoctorRepository : IBaseRepository
    {
        Task<IEnumerable<IReferringDoctor>> GetAll(IReferringDoctorFilter entity);
        Task<IEnumerable<IReferringDoctorDTO>> GetReferringDoctorDTO();
        Task<IReferringDoctor> GetById(Int16 id);
        Task<IReferringDoctor> GetByUId(Guid uid);
        Task<IReferringDoctor> AddNew(IReferringDoctor entity);
        Task<int> Update(IReferringDoctor entity);
        Task<int> Delete(Guid uid);
        Task<IEnumerable<IReferringDoctor>> GetReferringDoctors();
        Task<IReferringDoctor> GetByNPI(string npi);
        Task<IReferringDoctor> GetByNPI(IReferringDoctor entity);
        Task<IEnumerable<IReferringDoctor>> GetByUId(IEnumerable<Guid> Ids);
    }
}
