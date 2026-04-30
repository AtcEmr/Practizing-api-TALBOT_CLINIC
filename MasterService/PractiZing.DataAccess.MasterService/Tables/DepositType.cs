using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class DepositType : IDepositType
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public string DepositPlace { get; set; }
        public bool IsSelfpayment { get; set; }
        public int PracticeId { get; set; }
    }
}
