using PractiZing.Base.Object.MasterServcie;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    [Alias("vw_ConfigAdjustmentReasonCode")]
    public class ReasonCodeDTO : IReasonCodeDTO
    {
        public string GroupCode { get; set; }
        public string ReasonCode { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
