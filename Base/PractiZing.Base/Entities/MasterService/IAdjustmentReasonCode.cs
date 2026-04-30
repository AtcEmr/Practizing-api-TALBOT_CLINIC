using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IAdjustmentReasonCode:IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        int Id { get; set; }
        string GroupCode { get; set; }
        string Code { get; set; }
        bool IsDenailCode { get; set; }
        string Description { get; set; }
        string ReasonCode { get; set; }
        bool? IsForWriteOff { get; set; }
    }
}
