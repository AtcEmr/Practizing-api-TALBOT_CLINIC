using PractiZing.Base.Entities.MasterService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.ChargePaymentService
{
    public interface IPaymentBatch : IStamp, IUniqueIdentifier, IPracticeDTO
    {
        int Id { get; set; }
        string BatchNo { get; set; }
        DateTime BatchDate { get; set; }
        int RecordCount { get; set; }
        decimal BatchAmount { get; set; }
        bool IsSystem { get; set; }

        IEnumerable<IVoucher> Vouchers { get; set; }
        IEnumerable<IAttFile> AttFiles { get; set; }

        decimal Amount { get; set; }
    }
}
