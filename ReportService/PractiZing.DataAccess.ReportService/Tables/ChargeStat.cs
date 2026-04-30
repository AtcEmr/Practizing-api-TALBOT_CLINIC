using PractiZing.Base.Entities.ReportService;
using ServiceStack.DataAnnotations;
using System;

namespace PractiZing.DataAccess.ReportService.Tables
{
    public class ChargeStat : IChargeStat
    {
        public int Id { get; set; }
        public int? ActionStatusId { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public decimal? Charges { get; set; }
        public decimal? Payments { get; set; }
        public decimal? Adjustments { get; set; }
        public decimal? Denials { get; set; }
        public bool? HasDenial { get; set; }
        public string DueByFlag { get; set; }
        [Ignore]
        public DateTime? EntryDate { get; set; }
        [Ignore]
        public decimal? Amount { get; set; }
        [Ignore]
        public string StatName { get; set; }
        [Ignore]
        public string PatientName { get; set; }
        [Ignore]
        public Guid? StatUId { get; set; }
        [Ignore]
        public int? InsuranceCompanyTypeId { get; set; }
        [Ignore]
        public short? StatId { get; set; }
        [Ignore]
        public string OrderingPhysician { get; set; }
        [Ignore]
        public DateTime? EffectiveDate { get; set; }
        //[Ignore]
        //public decimal? Balance { get; set; }
        //[Ignore]
        //public string Modifier { get; set; }
        //[Ignore]
        //public decimal? PatientOverDue { get; set; }
    }
}
