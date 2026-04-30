using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargesReportDataConsolidateRepository
    {
        Task<int> Update(IEnumerable<IChargesReportDataConsolidate> entities);
    }
}
