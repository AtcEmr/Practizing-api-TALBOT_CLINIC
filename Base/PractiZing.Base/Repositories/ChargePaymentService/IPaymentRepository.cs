using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<IPayment>> GetTotalPayments(IEnumerable<int> voucherIds);
        Task<IEnumerable<IPayment>> GetByVoucher(int voucherId, string patientUId);
        Task<IPayment> GetByUId(Guid id);
        Task<IEnumerable<IPayment>> GetByVoucherId(int voucherId);
        Task<IPayment> GetById(long Id);
        Task<IEnumerable<IPaymentDTO>> GetPayment(IEnumerable<int> voucherIds, IBulkPaymentFilter bulkPaymentFilter);
        Task<IEnumerable<IPayment>> Get(int patientId);
        Task<IPayment> AddNew(IPayment entity);
        Task<int> AddOrUpdate(IEnumerable<IPayment> entities);
        Task<IPayment> AddNewBulkPayment(IPayment entity);
        Task<int> Update(IPayment entity);
        Task<int> UpdatePaidAmount(Guid Id);
        Task<IPayment> UpdateCommitedTransaction(Guid? paymentGuid, int? voucherId);
        Task<int> Delete(IEnumerable<Guid> paymentIds);
        Task ThrowError(int count);
        Task<IEnumerable<IPayment>> Get(IEnumerable<int> voucherIds, string patientUId);
        Task<int> DeleteByChargeId(int chargeId);
        Task<int> Delete(int paymentId);
        Task<int> UpdateCommitedTransaction(IEnumerable<int> paymentGuid);
        Task<IEnumerable<IPaymentDTO>> GetPayment(IBulkPaymentFilter bulkPaymentFilter);
        Task<IEnumerable<IPaymentDTO>> GetBulkPaymentPayment(IEnumerable<int> voucherIds, IBulkPaymentFilter filter);
        Task<IEnumerable<IPaymentCharge>> ValidateDuplicatePayments(int voucherId, int patientId, List<ICharges> charges, bool IsReversePayment, string payerControlNumber);
        Task<int> UpdateSentAckToEMR(int Id);
        Task<IEnumerable<IPayment>> GetPaymetnsForACK();
        Task<DataTable> GetExcelForInsuranceWisePaymentReport(DateTime fromDate, DateTime toDate);
        Task<IEnumerable<IReversePaymentReportDTO>> GetReversPayments();
        Task<IEnumerable<IChargesReportData>> GetWriteOffForAdjusments();
        Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPayment(int paymentId);
        Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPaymentNew(List<int> paymentIds);
        Task<IEnumerable<IPayment>> GetByVoucherIdForReversePayment(int voucherId);
    }
}
