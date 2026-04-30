using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IMethaSoftInvoiceRepository
    {
        Task<IMethaSoftInvoice> AddNew(IMethaSoftInvoice entity);
        Task<bool> SendDataToEMR();
    }
}
