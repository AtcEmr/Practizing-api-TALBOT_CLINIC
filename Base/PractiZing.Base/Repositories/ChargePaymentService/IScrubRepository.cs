using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IScrubRepository
    {
        Task<IScrub> GetById(short id);

        Task<IEnumerable<IScrub>> GetScrubs();
    }
}
