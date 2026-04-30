using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model.PatientService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IHL7StatusRepository
    {
        Task<IEnumerable<IHL7Status>> GetAllData(IHL7StatusFilter filter);
        Task<IHL7Status> AddNew(IHL7Status entity);
        Task<IHL7Status> Update(IHL7Status entity);
        Task<int> Delete(int id);
        Task<IHL7Status> GetById(int id);
        Task<IHL7Status> DeleteFile(string entity);
        Task<int> MoveFile(string entity);
        Task<IEnumerable<IHL7Status>> GetAll(IHL7StatusFilter filter);
        Task<bool> FindFileByName(IHL7StatusDTO dto);
        Task DeleteByAccessionNumber(string fileName);
    }
}
