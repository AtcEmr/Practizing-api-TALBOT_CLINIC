using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IScrubErrorRepository
    {
        Task<IEnumerable<IScrubErrorDTO>> GetAll();

        Task<IEnumerable<IScrubError>> GetByClaimId(int claimId);

        Task<IScrubError> AddNew(IScrubError entity);

        Task DeleteByClaimId(int claimId);

        Task<IEnumerable<IScrubError>> GetByClaimId(IEnumerable<int> claimIds);
    }
}
