using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterServcie.Objects
{
    public class ReportParameterDTO : IReportParameterDTO
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int ReportId { get; set; }
        public Guid DepositUID { get; set; }
        public string PracticeName { get; set; }
        public string ReasonCodes { get; set; }
        public string ProviderID { get; set; }
        public int? DepositID { get; set; }
        public string UserID { get; set; }
        public string InsuranceCompanyId { get; set; }
        public string CptCodes { get; set; }
        public string PracticeId { get; set; }
        public string CompanyName { get; set; }
        public string FacilityUId { get; set; }
        public int? FacilityId { get; set; }
        public string AuxillaryProviderUId { get; set; }        
        public string RefferingProviderUId { get; set; }
        public string AuxillaryProviderId { get; set; }
        public string RefferingProviderId { get; set; }
    }

    public class PatientStatementParameterDTO : IPatientStatementParameterDTO
    {
        public string PracticeName { get; set; }
        public string PatientId { get; set; }
        public bool IsXML { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Message { get; set; }
        public bool IsFromEMR { get; set; }
        public string IsBulkStatement { get; set; }
        public int IsAllCharges { get; set; }
    }

    public class BatchPatientStatementDTO
    {
        public int Days { get; set; }
    }
}
