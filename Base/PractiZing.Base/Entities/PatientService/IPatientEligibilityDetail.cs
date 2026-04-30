using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.PatientService
{
    public interface IPatientEligibilityDetail : IUniqueIdentifier
    {
        int Id { get; set; }        
        int PatientEligibilityId { get; set; }
        string Coverage { get; set; }
        string CoverageLevel { get; set; }
        string ServiceTypes { get; set; }
        string PlanName { get; set; }
        string PlanDescription { get; set; }
        string TimePeriod { get; set; }
        decimal? BenefitAmount { get; set; }
        decimal? BenefitPercentage { get; set; }
        string Authorization { get; set; }
        string PlanNetwork { get; set; }
        string Messages { get; set; }
        string Other { get; set; }
        string ReferenceId1 { get; set; }
        string ReferenceValue1 { get; set; }
        string ReferenceId2 { get; set; }
        string ReferenceValue2 { get; set; }
        string ReferenceId3 { get; set; }
        string ReferenceValue3 { get; set; }
        string ReferenceId4 { get; set; }
        string ReferenceValue4 { get; set; }
        string ReferenceId5 { get; set; }
        string ReferenceValue5 { get; set; }
        string DateId1 { get; set; }
        string DateValue1 { get; set; }
        string DateId2 { get; set; }
        string DateValue2 { get; set; }
        string DateId3 { get; set; }
        string DateValue3 { get; set; }
        string DateId4 { get; set; }
        string DateValue4 { get; set; }
        string DateId5 { get; set; }
        string DateValue5 { get; set; }
    }
}
