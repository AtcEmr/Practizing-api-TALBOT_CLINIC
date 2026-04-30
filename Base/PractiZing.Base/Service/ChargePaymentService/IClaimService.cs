using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IClaimService
    {
        //Task<bool> CreateClaim(int patientCaseId, int invoiceId, int _level);
        Task<int> CreateBatch(string uids);
        //Task<bool> CreateClaim(int patientCaseId, int invoiceId);

        //Task<int> Delete(int id);
        Task<int> Delete(Guid uId);
        Task<IClaim> CreateClaim(IAddClaimInfoDTO entity);
        Task<bool> MakeClaim(List<Guid> guids);
        Task<int> UnBatchClaim(IClaim entity);
        Task<int> UnBatchClaims(Guid claimBatchUId);
        Task<bool> MakeClaim_Secondary();
        Task<IEnumerable<IClaimAckDTO>> GetForACK();
        Task<int> UpdateClaimAfterNotifyRevdx(long id);
        Task<bool> ReviewNeeded(List<Guid> guids, bool flagYN, string reviewComments);
        Task<int> CreateBatchAuto(string uids);
        Task<bool> MakeCorrectedClaim(List<int> claimIds);
        Task<bool> MakePrimaryClaimWithSecondary(List<Guid> guids);
        Task<bool> RebillDenialChargesWherePrimaryPolicyChanged();
        Task<bool> RebillDenialChargesWherePayerChanged();
        Task<bool> PrimaryClaimAutomation();
        Task<bool> MakeClaimForRatherThanSelf(List<Guid> guids);
        Task<int> CreateBatchAutomtion();
        
        Task<int> RunBatchScrubForAutomtion(int clearingHouseId);
    }
}
