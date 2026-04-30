using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientStatement: IUniqueIdentifier, ICreatedStamp, IPracticeDTO
    {
        int Id { get; set; }
        DateTime? FromDate { get; set; }
        DateTime ToDate { get; set; }
        int PatientId { get; set; }
        int BatchStatementId { get; set; }
        bool? IsXml { get; set; }
        string Note { get; set; }
        bool? IsFromEMR { get; set; }
        decimal? TotalAmount { get; set; }
    }
}
