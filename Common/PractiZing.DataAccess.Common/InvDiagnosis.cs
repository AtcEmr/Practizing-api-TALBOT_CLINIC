using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.Common
{
    public class InvDiagnosis : IInvDiagnosis
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int InvoiceId { get; set; }

        [MaxLength(10, ErrorMessage = "ICDCode - Must not enter more than 10 characters.")]
        public string ICDCode { get; set; }

        [MaxLength(255, ErrorMessage = "Description - Must not enter more than 255 characters.")]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool IsICD10 { get; set; }

        [Ignore]
        public bool IsDiagnosisDeleted { get; set; }
        [Ignore]
        public string DiagnoseNo { get; set; }

        [Ignore]
        public int? IcdClassification { get; set; }

        [Ignore]
        public int? IcdType { get; set; }
    }
}
