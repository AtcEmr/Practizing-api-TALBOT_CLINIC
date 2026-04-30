using PractiZing.Base.Object.ReportService;
using System;

namespace PractiZing.DataAccess.ReportService.Objects
{
    public class DenialStatDTO : IDenialStatDTO
    {
        public int ChargeId { get; set; }
        public string AccessionNumber { get; set; }
        public DateTime? DOS { get; set; }
        public string CPTCode { get; set; }

        public string Mod1 { get; set; }
        public string Mod2 { get; set; }
        public string Mod3 { get; set; }
        public string Mod4 { get; set; }

        public string Modifier
        {
            get
            {
                return $"{this.Mod1} {this.Mod2} {this.Mod3} {this.Mod4}";
            }
        }

        //public decimal? Balance
        //{
        //    get
        //    {
        //        return (this.Charge - ((this.TotalPaidAmount ?? 0) + (this.TotalAdjustment ?? 0)));
        //    }
        //}

        public decimal? Balance { get; set; }

        public string DueByFlagCD { get; set; }

        public int? PatientCaseId { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int PatientId { get; set; }
        public Guid PatientUId { get; set; }
        public string PatientName
        {
            get
            {
                return $"{this.LastName} {this.FirstName}";
            }
        }

        public string OrderingPhysicianLastName { get; set; }
        public string OrderingPhysicianFirstName { get; set; }
        public string OrderingPhysician
        {
            get
            {
                return $"{this.OrderingPhysicianLastName} {this.OrderingPhysicianFirstName}";
            }
        }

        public decimal? TotalPaidAmount { get; set; }
        public decimal? TotalAdjustment { get; set; }
        public decimal? CoPay { get; set; }
        public decimal? Deductible { get; set; }
        public decimal? PatientOverDue
        {
            get
            {
                if (this.DueByFlagCD.ToLower() == "patient")
                    return this.Balance;
                return this.CoPay ?? 0 + this.Deductible ?? 0;
            }
        }
        public decimal? InsuranceOverDue
        {
            get
            {
                if (this.DueByFlagCD.ToLower() == "patient")
                    return 0;
                return this.Balance ?? 0 - this.PatientOverDue ?? 0;
            }
        }

        public string InsuranceCompanyName { get; set; }
        public int? InsuranceCompanyId { get; set; }
        public Guid? InsuranceCompanyUId { get; set; }

        public short? InsuranceCompanyTypeId { get; set; }
        public string InsuranceCompanyType { get; set; }

        public string ReasonCodes { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? PatientStatementSentCount { get; set; }
        public string StatName { get; set; }
        public decimal? Charge { get; set; }

        public string AssignedTo { get; set; }
        public DateTime? FollowUpDate { get; set; }

        public DateTime? EffectiveDate { get; set; }
        public Guid ChargeUId { get; set; }
        public int InvoiceId { get; set; }        
        public Guid InvoiceUId { get; set; }        
        public DateTime PatientDOB { get; set; }        
        public Guid PatientCaseUId { get; set; }        
        public Guid? PerformingProviderUId { get; set; }
        //public DateTime? fromDate { get; set; }
        //public DateTime? toDate { get; set; }
    }
}