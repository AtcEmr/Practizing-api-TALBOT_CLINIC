using PractiZing.Base.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.ClaimService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.ChargePaymentService
{
    public interface IClaimRepository
    {
        Task<IEnumerable<IClaim>> Get();
        Task<IEnumerable<IClaim>> GetByBatchUId(Guid claimBatchUId);
        Task<IEnumerable<IClaim>> Get(List<Guid> ids);
        Task<int> GetClaimbyInvoice(string invoiceUId, short lvl);
        Task<bool> GetUnBatchClaimByInvoice(int invoiceId);
        Task<IClaim> Get(int id);
        Task<IEnumerable<IClaim>> GetClaims(IClaimFilter claimFilter);
        Task<IEnumerable<IClaim>> GetClaims(/*IEnumerable<int?> claimBatchIds*/);
        Task<IEnumerable<IClaim>> GetByInvoice(int invoiceId, int level);
        Task<IClaim> GetByUID(Guid uId);
        Task<IEnumerable<IClaim>> GetByInvoiceId(Guid invoiceUid);
        Task<IEnumerable<IClaim>> GetClaims(int claimBatchId);
        Task<IClaim> AddNew(IClaim entity);
        Task Update(IEnumerable<IClaim> claims, int batchId);
        Task<int> UpdateEntity(IClaim entity);
        Task<bool> UpdateEntities(IEnumerable<IClaim> entities);
        Task<int> Delete(int id);
        Task<int> UnBatchClaim(IClaim entity);
        Task<int> UnBatchClaims(Guid claimBatchUId);
        //Task<IOrganizationSubmitter> OrganizationSubmitterAsync(string senderId);
        Task ClaimIsInUse();
        Task ThrowError(List<IValidationResult> validationResults);
        Task<int> UpdateEntity(IEnumerable<IClaim> claims);
        Task<IClaim> GetByInvoiceId(int invoiceid);
        Task<int> Delete(int[] claimIds);
        Task<int> UpdateClaimScrubStatus(IClaim entity);
        Task<IClaim> GetByInvoiceIdNoDeleteClaims(int invoiceid, int claimId);
        Task<IEnumerable<IClaimAckDTO>> GetForACK();
        Task<int> UpdateClaimAfterNotifyRevdx(long id);
        Task ThrowClaimBatchInsuranceCompany();
        Task<short?> GetClaimLevel(string patientAccountNumber);
        Task<IClaim> GetByInvoiceIdByINSLevel(int invoiceid, int insLevel);
        Task ThrowDummyProviderError();
        Task<IClaim> GetClaimByPatientAccountNumber(string patientAccountNumber);
        Task<IEnumerable<IClaimLevelDTO>> GetClaimsForReversePayment(IEnumerable<string> patientAccountNumbers);
        Task<IClaim> GetByPatientControlNumber(string patientControlNumber);
        Task ThrowMedicaidPolicyLengthError();
        Task ThrowProviderQualificationError(string qualification);
        Task<IClaim> GetByInvoiceIdForAdjustment(int invoiceid);
        Task ThrowNoPaymentErrorForSecondary();
        Task ThrowPrimaryPaymentPostedWithWrongPayer();
        Task<IEnumerable<IClaim>> GetClaimsForAutomation(int clearingHouseId);
    }
}
