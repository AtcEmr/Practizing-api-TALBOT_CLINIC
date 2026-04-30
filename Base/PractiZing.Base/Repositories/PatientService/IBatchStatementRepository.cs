using PractiZing.Base.Entities.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IBatchStatementRepository
    {
        Task<IEnumerable<IBatchStatement>> GetAll();
        Task<IBatchStatement> Get(Guid uId);
        Task<IBatchStatement> AddNew(IBatchStatement entity);
        Task<int> Delete(string uid);
        Task<IEnumerable<IBatchStatement>> GetById(int Id);
        Task<bool> SaveFileOnSFTPFile(string fileName, string extension, byte[] content);
        Task<int> Update(Guid uId);
    }
}
