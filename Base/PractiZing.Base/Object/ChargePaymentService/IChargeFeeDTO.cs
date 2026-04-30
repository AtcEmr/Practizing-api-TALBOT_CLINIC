using System;
using System.Collections.Generic;

namespace PractiZing.Base.Object.ChargePaymentService
{
    public interface IChargeFeeDTO
    {
        string InsuranceUId { get; set; }
        string ProviderUId { get; set; }
        DateTime DosDate { get; set; }
        IEnumerable<ICPTFeeDTO> CptCodes { get; set; }
    }
}
