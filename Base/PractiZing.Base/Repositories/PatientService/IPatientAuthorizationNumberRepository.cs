using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientAuthorizationNumberRepository
    {
        Task<IEnumerable<IPatientAuthorizationNumber>> GetAll();
        Task<IPatientAuthorizationNumber> GetByInsurancePolicyId(long insurancePolicyId);
        Task<IPatientAuthorizationNumber> GetByUId(Guid UId);
        Task<IPatientAuthorizationNumber> AddNew(IPatientAuthorizationNumber entity);
        Task<int> Update(IPatientAuthorizationNumber entity);
        Task<int> Delete(string uid);
        Task<bool> AddNewEntities(IEnumerable<IPatientAuthorizationNumber> entities);
        Task<bool> UpdateEntities(IEnumerable<IPatientAuthorizationNumber> entities);
        Task<IEnumerable<IPatientAuthorizationNumber>> GetAuthorization(long insurancePolicyId);
        Task<int> DeleteInsurancePolicy(long insurancePolicyId);
        Task<IEnumerable<IPatientAuthorizationNumber>> GetAuthorizationNos(long insurancePolicyId, DateTime fromDate);
        Task<IPatientAuthorizationNumber> Get(int Id);
        Task<IPatientAuthorizationNumber> AddNewFromIntegration(IPatientAuthorizationNumber entity);
    }
}
