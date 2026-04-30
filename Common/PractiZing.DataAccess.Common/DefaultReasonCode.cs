using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class DefaultReasonCode : IDefaultReasonCode
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public bool IsFixed { get; set; }
        public bool IsAccounted { get; set; }
        public bool IsSystem { get; set; }
        public bool IsBonus { get; set; }

        [Ignore]
        public bool IsDenial { get; set; }
        [Ignore]
        public decimal AdjustmentAmount { get; set; }
        [Ignore]
        public int PaymentChargeId { get; set; }
    }
}
