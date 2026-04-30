using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<IInvoice>> GetAll();
        Task<IInvoice> GetById(int id);
        Task<IInvoice> GetByUId(Guid UId);
        Task<IInvoice> AddNew(IInvoice entity);
        Task<int> Update(IInvoice entity);
        Task<int> Delete(string uid);
        Task<IEnumerable<IInvoice>> GetAllAccessionNumber(int? patientCaseId);
        Task<IEnumerable<IInvoice>> GetByBatchId(int batchId);
        Task<IEnumerable<IInvoice>> GetInvoices(IInvoiceBillHistoryFilter filter);
        Task<IEnumerable<IInvoice>> GetInvoices(IEnumerable<int> patientCaseId);
        Task<IEnumerable<IInvoice>> Get(int patientCaseId);
        Task<IInvoice> GetInvoice(int patientCaseId, Guid invoiceUId);
        Task<bool> CheckForAccessionNumber(string accessionNumber);
        Task<IInvoice> GetInvoice(int patientCaseId, int invoiceId);
        Task ThrowError(int count);
        Task<IInvoice> GetByAccessionNumber(string accessionNumber);
        Task<IEnumerable<IInvoice>> GetByBatchUId(string batchUId);
        Task<int> GetMaxId();
        Task<int> UpdateIsDeleted(IInvoice entity);
        Task<int> UpdateClaimId(IInvoice entity);
        Task<IEnumerable<IInvoice>> Get(IEnumerable<int> patientCaseId);
        Task<IEnumerable<IInvoice>> GetInvoicesByIds(int[] idsArray);
        Task<int> UpdateReviewNeeded(Guid UId, bool flagYN, string comments);
        Task ThrowReviewNeededError();
        Task<IEnumerable<IInvoice>> GetAllNotMadeClaim();
        Task<int> UpdateIsBillable(Guid uId, bool isBillable, string billableCoupon);
        Task<IEnumerable<ICharges>> GetInvoicePaymentAdjustments(List<string> accessioList);
        Task<int> UpdateChargeRefComments(int invoiceId, string comments);
        Task ThrowIsBillableError();
        Task ThrowChargeLockedError();
        Task<IEnumerable<IInvoice>> GetAllAccessionNumberForRolledUp(int? patientCaseId);
        Task<int> UpdateFeeAmountWhileRollUP(int invoiceId, decimal feeAmount);
        Task ThrowRejectionPINNotMatched();
        Task<int> MarkAsRejected(Guid uId, string rejectedPIN);
        Task ThrowFurtureClaimError();
        Task<int> UpdatePerformingProviderIdForNineSeries(IInvoice entity);
    }
}
