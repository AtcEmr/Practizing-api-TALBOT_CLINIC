using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IARSCategoryReasonCode : IPracticeDTO, IActive
    {
        long Id { get; set; }
        int NotesCategoryId { get; set; }
        string ReasonCode { get; set; }
        bool IsReasonCodeDeleted { get; set; }
    }
}
