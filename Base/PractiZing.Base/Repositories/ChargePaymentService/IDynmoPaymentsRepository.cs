using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IDynmoPaymentsRepository
    {
        Task<IDynmoPayments> AddNew(IDynmoPayments entity);
        Task<IEnumerable<IDynmoPayments>> Get(IDynmoPaymentFilterDTO filter);
        Task<int> Update(int dynmoPaymentid, string serviceProvider);
        Task<int> Update(int dynmoPaymentid, string serviceProvider, string errorMessage);
        Task<int> UpdateException(int dynmoPaymentid, string errorMessage);
        Task<DataTable> GetDynmoPaymentsForCatalystRCM();
        Task<int> UpdateFromCatalystRCM(List<int> dynmoPaymentids);
        Task<int> UpdateBadRecordFromCatalystRCM(List<int> dynmoPaymentids);
        Task<int> Update(IDynmoPayments entity);
        Task<bool> MoveInPortalPayment(int id);
        Task<IDynmoPayments> Get(int id);
        Task<int> Update(int dynmoPaymentid, string serviceProvider, int? portalPaymentId);
        Task<bool> SendToEMR();
        Task<IEnumerable<IPortalPaymentEMRDTO>> GetUnMatchedPaymentsByBillingId(string billingId);
        Task<IDynmoPayments> GetByPortalPaymentId(int portalPaymentId);
    }
}
