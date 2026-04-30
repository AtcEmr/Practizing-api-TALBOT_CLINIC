using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class ChargeBalanceAR90 : IChargeBalanceAR90
    {
        public int Id { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? ChargeAmount { get; set; }
        public decimal? WriteOffAmount { get; set; }
        public decimal? ChargeBalance1 { get; set; }
        public decimal? ChargeBalance2 { get; set; }
        public decimal? ChargeBalance3 { get; set; }
        public decimal? ChargeBalance4 { get; set; }
        public decimal? ChargeBalance5 { get; set; }
        public decimal? ChargeBalance6 { get; set; }
        public decimal? ChargeBalance7 { get; set; }
        public decimal? ChargeBalance8 { get; set; }
        public decimal? ChargeBalance9 { get; set; }
        public decimal? ChargeBalance10 { get; set; }
        public decimal? ChargeBalance11 { get; set; }
        public decimal? ChargeBalance12 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
