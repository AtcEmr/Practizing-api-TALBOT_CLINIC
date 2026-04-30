using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IICDCodeRepository : IBaseRepository
    {
        Task<IPaginationQuery<IICDCode>> Get(SearchQuery<IICDCodeFilter> entity);
        Task<IICDCode> GetByUId(Guid uid);
        Task<IICDCode> AddNew(IICDCode entity);
        Task<int> Update(IICDCode entity);
        Task<int> Delete(int id);
        Task<IICDCode> GetICDCode(string code);
        Task<IEnumerable<IDiagnosisDTO>> CheckIfICDExists(IEnumerable<IDiagnosisDTO> charges);
        Task<IEnumerable<IICDCode>> GetAllActiveICD();
        Task<int> GetICDCodesByEncounterTypeId(List<string> codes, int encounterId);
        Task<IEnumerable<IICDCode>> GetICDCodes(List<string> codes);
    }
}
