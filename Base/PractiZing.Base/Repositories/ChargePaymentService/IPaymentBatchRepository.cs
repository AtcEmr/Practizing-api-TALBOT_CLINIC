using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.View.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentBatchRepository
    {
        Task<IEnumerable<IPaymentBatch>> Get();
        Task<IPaymentBatch> GetById(long? Id = 0);
        Task<IPaymentBatch> Get(Guid Id);
        Task<IPaymentBatch> GetForERA();
        Task<IPaymentBatch> AddNew(IPaymentBatch entity, IEnumerable<IFormFile> formFiles);
        Task<IPaymentBatch> AddNew(IPaymentBatch entity);
        Task<IPaymentBatch> Update(IPaymentBatch entity, IEnumerable<IFormFile> formFiles);
        Task<IPaymentBatch> Update(IPaymentBatch entity);
        Task<int> Delete(Guid batchId);
        Task<IGetBatchNumberDTO> GetBatchNumber();
        Task<IGetBatchNumberDTO> GetERABatchNumber();
        Task<IEnumerable<IBulkPaymentScreenDTO>> GetBatch(IBulkPaymentFilter filter, int[] batchIds);
        Task<IEnumerable<IBatchDTO>> GetPaymentBatchGrid(IBatchFilter filter);
        Task ThrowError();
        Task<IPaymentBatch> GetForBulkAdjustment();
        Task<IEnumerable<IBulkPaymentScreenDTO>> GetBatchByBatchIds(IEnumerable<int> ids);
        Task<IPaymentBatch> AddNewEraBatch(IPaymentBatch entity, IEnumerable<IFormFile> formFiles);
        Task<IEnumerable<IVoucherViewDTO>> GetBulkVouchers(IVoucherViewFilter entity);
    }
}
