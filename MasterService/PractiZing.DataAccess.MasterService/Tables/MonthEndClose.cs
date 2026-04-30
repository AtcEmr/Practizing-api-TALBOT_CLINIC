using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("MonthEndClose")]
    public class MonthEndClose : IMonthEndClose
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public string CreatedBy { get; set; }
        public int PracticeId { get; set; }
    }
}
