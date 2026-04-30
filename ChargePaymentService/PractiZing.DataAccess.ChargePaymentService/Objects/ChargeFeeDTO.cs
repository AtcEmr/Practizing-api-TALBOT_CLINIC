using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class ChargeFeeDTO: IChargeFeeDTO
    {
        public ChargeFeeDTO()
        {
            CptCodes = new List<CPTFeeDTO>();
        }
        public string InsuranceUId { get; set; }
        public string  ProviderUId { get; set; }
        public DateTime DosDate { get; set; }
        public IEnumerable<ICPTFeeDTO> CptCodes { get; set; }        
    }
}
