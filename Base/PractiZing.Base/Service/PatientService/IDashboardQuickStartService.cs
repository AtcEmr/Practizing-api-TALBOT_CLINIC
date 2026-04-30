using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.PatientService
{
    public interface IDashboardQuickStartService
    {
        Task<string> GetUrl();
    }
}
