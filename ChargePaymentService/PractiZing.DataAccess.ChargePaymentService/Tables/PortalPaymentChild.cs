using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PortalPaymentChild : IPortalPaymentChild
    {
        public PortalPaymentChild()
        {
            
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PortalPaymentId { get; set; }
        public int PaymentId { get; set; }

    }
}
