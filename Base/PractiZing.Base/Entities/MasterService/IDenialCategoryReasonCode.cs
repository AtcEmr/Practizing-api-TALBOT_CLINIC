using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IDenialCategoryReasonCode
    {
        int Id { get; set; }

        int DenialCategoryId { get; set; }

        string ReasonCode { get; set; }

    }
}
