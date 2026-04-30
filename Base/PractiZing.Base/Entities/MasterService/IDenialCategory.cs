using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IDenialCategory : IPracticeDTO, IUniqueIdentifier, IStamp
    {
        int Id { get; set; }

        string DenialCategoryName { get; set; }
        string[] ReasonCodes { get; set; }
        string ReasonCode { get; set; }

    }
}
