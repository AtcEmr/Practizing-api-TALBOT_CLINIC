using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.CommonEntites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IChargeBatchRepository
    {
        Task<IChargeBatch> AddNew(IChargeBatch entity);
        Task<IEnumerable<IChargeBatch>> GetAll(IEnumerable<int> chargeBatchIds);
        Task<int> Update(IChargeBatch entity);
        Task<IChargeBatch> GetCurrentBatch();
        Task<IChargeBatch> Get(int id);
        Task<IEnumerable<IBatchDTO>> GetChargeGrid(IBatchFilter entity);
        Task<IGetBatchNumberDTO> GetBatchNumber();
        Task ThrowError();
        Task<IChargeBatch> GetByUId(string uid);
        Task<int> Delete(Guid UId);
        Task<IEnumerable<IDropDownDTO>> GetActive();
        Task<int> UpdateStatus(string chargeBatchUId, bool isActive);
        Task<string> UpdateCCNClaims();
    }
}
