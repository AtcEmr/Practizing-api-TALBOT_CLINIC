using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface ICallHistoryRepository
    {
        Task<ICallHistory> AddNew(ICallHistory entity);      
    }
}
