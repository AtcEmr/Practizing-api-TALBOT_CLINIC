using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class CPTModifier : ICPTModifier
    {
        [Key]
        [AutoIncrement]
        public short ID { get; set; }
        public Guid UId { get; set; }

        public byte? VisitType { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Code is required")]
        [MaxLength(5, ErrorMessage = "Code - Must not enter more than 5 characters.")]
        public string Code { get; set; }

        [MaxLength(75, ErrorMessage = "Description - Must not enter more than 75 characters.")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
        [Ignore]
        public short CircumstanceModifierId { get; set; }
        [Ignore]
        public bool IsServiceCircumstance { get; set; }
    }
}
