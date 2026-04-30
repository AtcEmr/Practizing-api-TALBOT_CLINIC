using PractiZing.Base.Entities.ERAService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ERAService
{
    public interface IERAClaimChargeRemarkRepository
    {
        Task<IEnumerable<IERAClaimChargeRemark>> Get(long[] ids);
    }
}
