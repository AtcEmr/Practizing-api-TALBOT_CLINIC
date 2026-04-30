using PractiZing.Base.Entities.BatchPaymentService;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.BatchPaymentService
{
    public interface IClaimBatchRepository
    {
        Task<IEnumerable<IClaimBatch>> Get(IClaimFilter claimFilter, bool isFilterWork = false);
        Task<IEnumerable<IClaimBatch>> Get(List<int> ids);
        Task<IClaimBatch> GetById(int claimBatchId);
        Task<IClaimBatchTabsCount> GetClaimBatches(IClaimFilter claimFilter);
        Task<IEnumerable<IClaimBatch>> AddNew(IEnumerable<IClaimBatch> claims);
        Task<IClaimBatch> AddNew(IClaimBatch entity);
        Task<int> Update(IClaimBatch entity);
        Task UpdateStatus(Guid uid, BatchStatus status, bool isDate, string filePath);
        Task UpdateFilePath(Guid uid, string filePath);
        Task<IClaimBatch> Get(Guid claimBatchUId);
        Task<IEnumerable<IScrubError>> RunScrub(string claimUId, string claimBatchUId, string providerUId, string facilityUId);
        Task<IEnumerable<IScrubError>> RunScrub(int claimId);
        Task<IEnumerable<IScrubError>> RunAutoScrub(IEnumerable<IScrubDTO> scrub, string spName, int scrubId, string practiceCode);
        Task<IClaimBatchScrubDTO> GetClaimBatchDTO(string claimBatchUId);
        Task<IClaimBatch> GetFileText(Guid batchUID);
        Task UpdateClaimCount(Guid uid, int claimCount);
        Task<int> Delete(int id);
        Task<int> Delete(Guid uid);
        Task<IEnumerable<IClaimBatch>> AddNew(IEnumerable<IClaimBatch> claims, int? providerId, int? insuranceCompanyId);
        Task<IEnumerable<IClaimBatch>> GetclaimBatchForBulkUpload();
        Task<IEnumerable<IClaimBatch>> GetClaimBatchForAutoRunScrub(int clearingHouseid);
        Task<IEnumerable<IClaimBatch>> GetClaimsForCreate837PEdiFile(int clearingHouseId);
        Task UpdateClaimCountByid(int id, int claimCount);
    }
}
