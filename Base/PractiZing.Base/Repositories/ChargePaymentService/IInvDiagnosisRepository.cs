using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IInvDiagnosisRepository
    {
        Task<IEnumerable<IInvDiagnosis>> GetAll();
        Task<IInvDiagnosis> GetByInvoiceUId(string invoiceUId);
        Task<IEnumerable<IInvDiagnosis>> GetByInvoice(int invoiceId);
        Task<IInvDiagnosis> AddNew(IInvDiagnosis entity);
        Task<bool> AddNewEntities(IEnumerable<IInvDiagnosis> entities, int invoiceId);
        Task<int> Update(IInvDiagnosis entity);
        Task<bool> UpdateEntities(IEnumerable<IInvDiagnosis> entities, int invoiceId);
        Task<int> Delete(string invoiceUId);
        Task<int> DeleteDiagnosis(int invoiceId, int diagnosisId);
        Task<IEnumerable<IInvDiagnosis>> GetByInvoiceId(IEnumerable<int> invoiceIds);
    }
}
