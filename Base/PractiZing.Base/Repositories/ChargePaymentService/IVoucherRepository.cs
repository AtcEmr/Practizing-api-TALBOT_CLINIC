using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IVoucherRepository
    {
        Task<IEnumerable<IVoucher>> GetByBatchId(IEnumerable<int> paymentBatchId);
        Task<IEnumerable<IVoucher>> GetByUId(string paymentBatchUId, string patientUId);
        Task<IEnumerable<IVoucher>> GetByPatientId(int patientId);
        Task<IEnumerable<IVoucher>> Get();
        Task<IVoucher> GetByUId(Guid uId);
        Task<IEnumerable<IVoucher>> GetByUId(IEnumerable<Guid> uIds);
        Task<IVoucher> Get(int Id);
        Task<IEnumerable<IVoucher>> GetVoucher();
        Task<IEnumerable<IVoucherDTO>> GetVoucher(IBulkPaymentFilter filter);

        Task<IEnumerable<IVoucher>> Get(IList<int> insuranceCompanyId, IList<int> patientId);


        Task<IEnumerable<IVoucher>> GetByBatchId(int paymentBatchId);
        Task<IVoucher> Get(Guid UId);
        Task<IVoucher> GetTotalPaymentsInVoucher(int paymentBatchId);
        Task<IVoucher> GetByInsuranceCompanyId(int companyId);
        Task<IVoucher> GetByCheckNumber(string refernceNo);
        Task<IVoucher> GetByCheckNumber(string refernceNo, int voucherId);
        Task<int> GetByPaymentId(int paymentId);
        Task<IVoucher> AddNew(IVoucher entity);
        Task<IVoucher> AddNewBulkAdjsutment(IVoucher entity, bool isSystem = true);
        Task<IVoucher> UpdateCommitedTransaction(Guid voucherGuid);
        Task<IVoucher> Update(IVoucher entity);
        Task<int> Delete(Guid uId);
        Task<int> CreateVoucherNo();
        Task<int> CreateTransactionNo();
        Task ThrowError(int count);
        Task VoucherExists();
        Task ThrowCheckNumber(string checkno);
        Task<int> Delete(int Id);
        Task<IVoucher> UpdateVoucherFromERA(IVoucher entity);
        Task<IVoucher> GetForBalanceAdjustment(string paymentSourceCD);
        Task<int> UpdatePlaidMatched(string xmlData, bool isMatchedWithBank, string practice);
        Task<IEnumerable<IVoucherPlaidDTO>> GetVouchersForBankMatched();
        Task<int> GetCardPaymentPaymentBatchId();
        Task<IVoucher> GetForBulkAdjustment_PatientWise(string paymentSourceCD, int insuranceCompanyId, int patientId);
    }
}
