using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IDefaultReasonCode
    {
        int Id { get; set; }
        Guid Uid { get; set; }
        string Code { get; set; }
        string DisplayName { get; set; }
        bool IsFixed { get; set; }
        bool IsAccounted { get; set; }
        bool IsSystem { get; set; }

        bool IsDenial { get; set; }
        bool IsBonus { get; set; }
        decimal AdjustmentAmount { get; set; }
        int PaymentChargeId { get; set; }
    }
}
