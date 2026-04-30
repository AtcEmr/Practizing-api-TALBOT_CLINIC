using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.MasterService
{
    public interface INotesCategoryService
    {
        Task<INotesCategory> AddNotesCategory(INotesCategory entity);
        Task<bool> UpdateNotesCategory(INotesCategory entity);
    }
}
