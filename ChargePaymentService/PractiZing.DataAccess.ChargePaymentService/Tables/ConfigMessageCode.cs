using PractiZing.Base.Entities.ChargePaymentService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ConfigMessageCode : IConfigMessageCode
    {
        [MaxLength(10, ErrorMessage = "MessageCode - Must not enter more than 10 characters.")]
        public string MessageCode { get ; set ; }
        [MaxLength(40, ErrorMessage = "Description - Must not enter more than 40 characters.")]
        public string Description { get ; set ; }

        [MaxLength(1, ErrorMessage = "DeleteFlag - Must not enter more than 1 characters.")]
        public string DeleteFlag { get ; set ; }
        [MaxLength(1, ErrorMessage = "OnStatements - Must not enter more than 1 characters.")]
        public string OnStatements { get ; set ; }
        [MaxLength(1, ErrorMessage = "OnClaims - Must not enter more than 1 characters.")]
        public string OnClaims { get ; set ; }
        [MaxLength(1, ErrorMessage = "Available - Must not enter more than 1 characters.")]
        public string Available { get ; set ; }

        [MaxLength(4, ErrorMessage = "Category - Must not enter more than 4 characters.")]
        public string Category { get ; set ; }

        [MaxLength(1, ErrorMessage = "Task - Must not enter more than 1 characters.")]
        public string Task { get ; set ; }
        public bool? Visible { get ; set ; }
    }
}
