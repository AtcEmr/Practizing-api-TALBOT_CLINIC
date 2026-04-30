using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IDrugChargeRepository
    {
        Task<IEnumerable<ICharges>> GetByInvoice(string invoiceUId);
        Task<ICharges> AddNew(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies);
        Task<int> Update(ICharges entity, IEnumerable<IInsurancePolicy> insurancePolicies);
        Task<int> DeleteCharge(int invoiceId, int chargeId);
        Task<int> DeletByInvoice(int invoiceId, int chargeNo);
        Task<int> DeletByInvoice(int invoiceId);
        Task<bool> GetDrugCharge(int chargeNo, int patientCaseId, string cptCode);
    }
}
