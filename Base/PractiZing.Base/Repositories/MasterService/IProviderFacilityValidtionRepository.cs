using Microsoft.AspNetCore.Http;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IProviderFacilityValidtionRepository
    {
        Task<IEnumerable<IProviderFacilityValidtion>> GetAll();
    }
}
