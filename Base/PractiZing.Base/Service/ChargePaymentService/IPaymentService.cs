using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.View.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IPaymentService
    {
        Task<IEnumerable<IPaymentBatch>> Get();
        Task<IEnumerable<IBulkPaymentScreenDTO>> GetBulkPayment(IBulkPaymentFilter filter);
        Task<IBatchListDTO> GetBatches(IBatchFilter filter);
        Task<IPayment> Get(Guid uid);
        Task<IEnumerable<IPaymentCharge>> GetByPaymentUId(string paymentUId);
        //Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeUId(string paymentChargeUId);
        //Task<IEnumerable<IPaymentAdjustment>> GetByPaymentChargeUId(string paymentChargeUId, bool isSave);
        Task<IEnumerable<IPayment>> GetByVoucher(string voucherUId, string patientUId);
        Task<bool> AddBulkAdjustment(Guid invoiceUId, string adjustmentCode, bool isRemarkCode);
        Task<int> AddNewPayment(IVoucher entity);
        Task<IVoucher> AddNewVoucher(IVoucher entity, IEnumerable<IFormFile> formFiles);
        Task<int> AddUpdateBulkPayment(IEnumerable<IPaymentBatchDTO> entities);
        Task<IVoucher> Update(IVoucher entity, IEnumerable<IFormFile> formFiles);
        Task<bool> CommitPayments(Guid? voucherUId, Guid? paymentUId);
        Task<int> Delete(Guid UId);
        Task<int> DeleteByBatchUId(Guid batchUId, bool IsDelete);
        Task<int> DeleteVoucher(Guid UId);
        Task<int> DeleteChargePayment(Guid Id);
        Task<bool> AddBalanceAdjustment(Guid invoiceUId, string adjustmentCode, string remarkCode, IEnumerable<ICharges> charges);
        Task<int> CompareVoucherWithBank();
        Task<bool> PostWriteOffForAdjusments();
        Task<IEnumerable<IVoucherViewDTO>> GetBulkVouchers(IVoucherViewFilter filter);
        Task<bool> WriteOffOldAdjustment(string dosDate);
        Task<bool> AddBalanceAdjustmentFromUI(IBalanceAdjustmentModel balanceAdjustmentModel);
        Task<bool> WriteOffCharges(string dosDate, string adjustmentCode, string postAdjustmentCode);
        Task<bool> WriteOffHandTCharges();
        Task<bool> WriteOffAdjusmentCharges(IBulkAdjustmentFROMUIModel balanceAdjustmentModel);
        Task<bool> WriteOffDueByPatientCharges(string dosDate);
    }
}
