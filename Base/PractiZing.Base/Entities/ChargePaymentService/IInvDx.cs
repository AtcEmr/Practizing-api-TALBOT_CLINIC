using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IInvDx : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int InvoiceID { get; set; }
        Int16 DiagnosisNumber { get; set; }
        string ICD9_CM { get; set; }
        string Description { get; set; }
        Int16? BodyArea { get; set; }       
        bool? ICD10 { get; set; }

    }
}
