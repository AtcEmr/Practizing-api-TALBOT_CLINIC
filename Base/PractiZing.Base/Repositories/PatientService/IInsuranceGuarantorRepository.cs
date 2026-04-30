using PractiZing.Base.Entities.PatientService;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IInsuranceGuarantorRepository
    {
        Task<IInsuranceGuarantor> GetByPatientId(int patientId);
        Task<IInsuranceGuarantor> AddNew(IInsuranceGuarantor entity);
        Task<IInsuranceGuarantor> Update(IInsuranceGuarantor entity);
        Task<int> Delete(int patientId);
    }
}
