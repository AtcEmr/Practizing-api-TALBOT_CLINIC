using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IBatchStatement : IUniqueIdentifier, ICreatedStamp, IPracticeDTO
    {
        int Id { get; set; }        
        bool? IsXml { get; set; }
        string BatchFileName { get; set; }
        DateTime? SentDate { get; set; }
        bool? IsSent { get; set; }
        int Count { get; set; }
        int? StatementCount { get; set; }
        decimal? BatchTotal { get; set; }
        string SentBy { get; set; }
    }
}
