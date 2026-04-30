using PractiZing.Base.Object.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ChargePaymentService.Objects
{
    public class LabPaymentDTO : ILabPaymentDTO
    {
        public Guid UId { get; set; }
        public decimal Amount { get; set; }        
    }
}
