using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{    
    public class BillingUnitConversionChart : IBillingUnitConversionChart
    {       
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public short MinimumMinutes { get; set; }
        public short MaximumMinutes { get; set; }
        public short BillingUnit { get; set; }

    }
}
