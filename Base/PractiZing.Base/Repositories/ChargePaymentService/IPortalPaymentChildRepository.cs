using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.PatientService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPortalPaymentChildRepository
    {
        Task<IPortalPaymentChild> AddNew(IPortalPaymentChild entity);
        Task<IEnumerable<IPortalPaymentChild>> GetByPortalPaymentId(int portalPaymentId);
        Task<int> Delete(int paymentId);
        Task<IEnumerable<IPortalPaymentChild>> GetByPortalPaymentIdByIds(List<int> portalPaymentIds);
    }
}
