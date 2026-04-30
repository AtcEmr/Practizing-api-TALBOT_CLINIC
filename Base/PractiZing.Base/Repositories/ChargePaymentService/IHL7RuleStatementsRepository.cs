using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IHL7RuleStatementsRepository
    {
        Task RunChargePostIdHl7Scripts(int chargeId);
    }
}
