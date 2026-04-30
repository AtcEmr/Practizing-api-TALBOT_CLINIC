using PractiZing.Base.Entities.ChargePaymentService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IFSLocalityCarrierRepository
    {
        Task<IEnumerable<IFSLocalityCarrier>> GetAll();
        Task<IFSLocalityCarrier> GetById(short id);
        Task<IEnumerable<string>> GetLocality();
        Task<IEnumerable<short>> GetCarrierNumber();
        Task<IFSLocalityCarrier> AddNew(IFSLocalityCarrier entity);
        Task<int> Update(IFSLocalityCarrier entity);
        Task<int> Delete(short id);
    }
}
