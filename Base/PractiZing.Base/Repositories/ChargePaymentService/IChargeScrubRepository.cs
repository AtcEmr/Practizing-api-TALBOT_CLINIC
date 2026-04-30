using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargeScrubRepository
    {
        Task<IEnumerable<IChargeScrub>> GetAll();

        Task<IChargeScrub> GetByChargeId(int chargeId);

        Task<bool> AddChargeScrubErrors(IEnumerable<IScrubError> entity);

        Task DeleteByChargeId(int chargeId);

        Task<IEnumerable<IChargeScrub>> GetByChargeIds(IEnumerable<int> chargeIds);
    }
}
