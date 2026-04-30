using PractiZing.Base.Entities.MasterService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IZipCodeLookUpRepository
    {
        Task<IEnumerable<IZipCodeLookUp>> GetAll();
        Task<IZipCodeLookUp> GetByZip(string zip);
        Task<IEnumerable<IZipCodeLookUp>> SearchByZip(string zip);
        Task<IEnumerable<string>> GetStateCodeList();
    }
}
