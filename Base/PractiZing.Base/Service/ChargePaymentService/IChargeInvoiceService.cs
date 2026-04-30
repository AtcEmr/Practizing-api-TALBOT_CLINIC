using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.CommonEntites;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IChargeInvoiceService
    {
        Task<IInvoice> GetByInvoice(int patientCaseId, int invoiceId);
        Task<IEnumerable<IInvoice>> GetByInvoices(string patientCaseUId);
        Task<IStatementDTO> GetStatement(Guid patientUId, DateTime fromDate, DateTime toDate);
        Task<IInvoiceBillingHistoryDTO> GetBillingHistoryInvoice(IChargePaymentBillingHistoryFilter filter);
        Task<IEnumerable<IPaymentBatchDTO>> Get(IPaymentFilterDTO filter);
        Task<IInvoice> GetByInvoice(Guid patientCaseId, Guid invoiceUId);
        Task<IEnumerable<IDropDownDTO>> GetAccessionNumber(Guid patientId);
        Task<IEnumerable<ICharges>> GetCharges(Guid patientUId, Guid invoiceUId);
        Task<IInvoice> AddNew(IInvoice entity);
        Task<IInvoice> UpdateEntity(IInvoice entity);
        Task<int> UpdateGCCode(string invoiceUId);
        Task<int> Delete(string chargeBatchUId);
        Task<int> DeleteCharge(Guid chargeUId, bool isDelete);
        Task<int> CheckGCCode(string invoiceUId);
        Task<bool> UpdateCharges(IEnumerable<ICharges> charges);
        Task<string> GetForPaymentACK();
        Task<IEnumerable<ICharges>> FillCPTDesc(IEnumerable<ICharges> charges);
        Task<bool> RunEMRScrub();
        Task<ICharges> GetChargeByDosAndCptCode(int patientCaseId, string cptcode, DateTime dosDate);
        Task<bool> DoNotBillInvoices(List<Guid> invoiceUIds);
        Task<bool> BillInvoices(List<Guid> invoiceUIds, string billableCoupon);
        Task<ICharges> GetChargeByDosAndCptCodeAndProvider(int patientCaseId, string cptcode, DateTime dosDate, int performingProviderId);
        Task<IEnumerable<ICharges>> GetChargesByPatient(Guid patientUId);
        Task<IEnumerable<ICharges>> GetCahrges97201To05(int patientCaseId);
        Task<IEnumerable<ICharges>> Validate90791(int patientCaseId);
        Task<IEnumerable<IDropDownDTO>> GetAccessionNumbersForRolledUp(Guid patientUId);
        Task<IEnumerable<IDropDownDTO>> GetAccessionNumberForRolledUpChild(Guid invoiceUId);
        Task<int> RolledUpCharges(Guid parentInvoiceUId, Guid childInvoiceUid);
        Task<IInvoiceBillingHistoryDTO> GetBillingHistoryInvoiceForEMR(string billingId);
        Task<int> AddOrUpdateWriteOff(IChargeInWriteOffDTO chargeInWriteOffDTO);
        Task<int> UpdateWriteOff(IEnumerable<IEmrChargeInWriteOffDTO> lst);
        Task<bool> MarkAsRejected(List<Guid> invoiceUIds, string pin);
        Task<IEnumerable<IBalanceCharge>> GetChargesForAdjustment(Guid patientUId);
        Task<IChargesDueAmountForEMR> GetDueChargesForEMR(string billingId);
        Task<int> GetChargesForRefreshFeeAmountWhilePolicySyncing(int patientCaseId);
        Task<int> GetChargesForUpdateFeeAmount(List<int> ids);
        Task<string> GetLockedChargesForACK();
    }
}
