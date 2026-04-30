using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IDepositType : IPracticeDTO, IUniqueIdentifier
    {
        int Id { get; set; }
        string Description { get; set; }
        bool Active { get; set; }
        string DepositPlace { get; set; }
        bool IsSelfpayment { get; set; }
    }
}
