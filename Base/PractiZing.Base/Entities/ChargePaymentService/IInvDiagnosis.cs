using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IInvDiagnosis
    {
        int Id { get; set; }
        int InvoiceId { get; set; }
        string ICDCode { get; set; }
        string Description { get; set; }
        bool IsICD10 { get; set; }
        bool IsDiagnosisDeleted { get; set; }
        string DiagnoseNo { get; set; }
        int? IcdClassification { get; set; }
        int? IcdType { get; set; }
    }
}
