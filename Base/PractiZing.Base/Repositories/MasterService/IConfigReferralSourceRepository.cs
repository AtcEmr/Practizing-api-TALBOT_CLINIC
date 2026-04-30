using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
 public   interface IConfigReferralSourceRepository
    {
        Task<IEnumerable<IConfigReferralSource>> GetAll();
        Task<IConfigReferralSource> GetById(Int16 Id);
    }
}
