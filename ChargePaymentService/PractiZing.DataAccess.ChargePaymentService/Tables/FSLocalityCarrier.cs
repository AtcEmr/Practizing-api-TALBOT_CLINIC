using PractiZing.Base.Entities.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class FSLocalityCarrier : IFSLocalityCarrier
    {
        [Key]
        public short Id { get; set; }

        [MaxLength(2, ErrorMessage = "Locality - Must not enter more than 2 characters.")]
        public string Locality { get; set; }

        public short CarrierNumber { get; set; }
    }
}
