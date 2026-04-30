using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class PaymentBatch : IPaymentBatch
    {

        public PaymentBatch()
        {
            this.Vouchers = new List<Voucher>();
            this.AttFiles = new List<AttFile>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public string BatchNo { get; set; }
        public DateTime BatchDate { get; set; }
        public int RecordCount { get; set; }
        [Alias("Amount")]
        public decimal BatchAmount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsSystem { get; set; }

        [Ignore]
        public IEnumerable<IVoucher> Vouchers { get; set; }
        [Ignore]
        public IEnumerable<IAttFile> AttFiles { get; set; }
        [Ignore]
        public decimal Amount { get; set; }
    }
}
