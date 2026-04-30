using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigAdjustmentReasonCode
    {
        int Id { get; set; }
        string GroupCode { get; set; }
        string Code { get; set; }
        string ReasonCode { get; set; }
        string CodeType { get; set; }
        string Category { get; set; }
        string CategoryDescription { get; set; }
        string CodeDescription { get; set; }
        string Description { get; set; }
        short? ActiveFlag { get; set; }
        DateTime CreatedDateTime { get; set; }
        string FLAG { get; set; }

        string RemarkQualifier { get; set; }
        bool Selected { get; set; }
        int NotesCategoryId { get; set; }
        bool IsReasonCodeDeleted { get; set; }
        bool IsForWriteOff { get; set; }
    }
}
