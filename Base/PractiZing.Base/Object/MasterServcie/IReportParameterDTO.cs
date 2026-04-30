using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface IReportParameterDTO
    {
        string FromDate { get; set; }
        string ToDate { get; set; }
        int ReportId { get; set; }
        string PracticeName { get; set; }
        string ReasonCodes { get; set; }
        string ProviderID { get; set; }
        int? DepositID { get; set; }
        Guid DepositUID { get; set; }
        string UserID { get; set; }
        string InsuranceCompanyId { get; set; }
        string CptCodes { get; set; }
        string PracticeId { get; set; }
        string CompanyName { get; set; }
        int? FacilityId { get; set; }
        string FacilityUId { get; set; }
        string AuxillaryProviderUId { get; set; }
        string RefferingProviderUId { get; set; }
        string AuxillaryProviderId { get; set; }
        string RefferingProviderId { get; set; }
    }

    public interface IPatientStatementParameterDTO
    {
        string PatientId { get; set; }
        string PracticeName { get; set; }
        string FromDate { get; set; }
        string ToDate { get; set; }
        bool IsXML { get; set; }
        string Message { get; set; }
        bool IsFromEMR { get; set; }
        string IsBulkStatement { get; set; }
        int IsAllCharges { get; set; }
    }
}
