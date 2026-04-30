using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class WriteOffEMRObjectDTO : IWriteOffEMRObjectDTO
    {
        public string AccessionNumber { get; set; }        
    }
}
