using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.BatchPaymentService
{
    public interface IClaimBatch : IUniqueIdentifier, IPracticeDTO, IModifiedStamp
    {
        int Id { get; set; }
        int? ClearingHouseId { get; set; }
        DateTime DateMade { get; set; }
        string UserName { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        DateTime? FirstSent { get; set; }
        DateTime? LastSent { get; set; }
        int ClaimCount { get; set; }
        decimal Total { get; set; }
        int ScrubStatus { get; set; }
        DateTime? ScrubSent { get; set; }
        int BatchStatus { get; set; }
        IEnumerable<IClaim> Claims { get; set; }
        string FilePath { get; set; }
        string FullFilePath { get; }
        string FullFileText { get; set; }
        string ClaimBatchNumber { get; set; }
        int? ProviderId { get; set; }
        int? InsuranceCompanyId { get; set; }
    }
}
