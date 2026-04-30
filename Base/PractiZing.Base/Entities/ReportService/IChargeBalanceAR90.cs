using System;

namespace PractiZing.Base.Entities.ReportService
{
    public interface IChargeBalanceAR90
    {
        int Id { get; set; }
        int YearId { get; set; }
        int MonthId { get; set; }
        decimal? ChargeAmount { get; set; }
        decimal? WriteOffAmount { get; set; }
        decimal? ChargeBalance1 { get; set; }
        decimal? ChargeBalance2 { get; set; }
        decimal? ChargeBalance3 { get; set; }
        decimal? ChargeBalance4 { get; set; }
        decimal? ChargeBalance5 { get; set; }
        decimal? ChargeBalance6 { get; set; }
        decimal? ChargeBalance7 { get; set; }
        decimal? ChargeBalance8 { get; set; }
        decimal? ChargeBalance9 { get; set; }
        decimal? ChargeBalance10 { get; set; }
        decimal? ChargeBalance11 { get; set; }
        decimal? ChargeBalance12 { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
