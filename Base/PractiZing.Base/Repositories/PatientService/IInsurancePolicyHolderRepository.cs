using PractiZing.Base.Entities.PatientService;
using System;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IInsurancePolicyHolderRepository
    {
        Task<IInsurancePolicyHolder> GetById(int id);
        Task<IInsurancePolicyHolder> GetByUId(Guid uid);
        Task<IInsurancePolicyHolder> AddNew(IInsurancePolicyHolder entity);
        Task<IInsurancePolicyHolder> Update(IInsurancePolicyHolder entity);
        Task<int> Delete(Guid phUId);
        Task<int> DeleteByPatientId(int patientId);
        Task ThrowError();
        Task ValidateInsPolicyHolderAddress(string insLevel, string polHolderStreet, string polHolderState, string polHolderCity, string polHolderZip);
        Task<IInsurancePolicyHolder> GetByIdAndRel(int patientId, string relName);
    }
}
