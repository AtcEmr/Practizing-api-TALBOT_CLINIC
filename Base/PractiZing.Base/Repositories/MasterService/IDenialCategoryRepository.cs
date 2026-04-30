using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.MasterService
{
    public interface IDenialCategoryRepository
    {
        Task<IEnumerable<IDenialCategory>> GetAll();
        Task<IDenialCategory> AddNew(IDenialCategory entity);
        Task<int> Update(IDenialCategory entity);
        Task<int> Delete(Guid UId);
    }
}
