using PractiZing.Base.Model.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    public class ProviderEmrDTO: IProviderEmrDTO
    {
        public int id { get; set; }
        public string prefix { get; set; }
        public string firstName { get; set; }
        public string fullName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public DateTime dob { get; set; }
        public string primaryPhone { get; set; }
        public int primaryPhoneType { get; set; }
        public string practiceName { get; set; }
        public bool active { get; set; }
        public string degree { get; set; }
        public string comments { get; set; }
        public string clinicianId { get; set; }
        public int userId { get; set; }
        public int? supervisorId { get; set; }
        public bool? isOptedForGroupBilling { get; set; }
        public bool canBill { get; set; }
        public string primaryFax { get; set; }
        public string npi { get; set; }
        public string ssn { get; set; }
        public bool isLocked { get; set; }
        public int? supervisorTypeId { get; set; }
        public bool? billUnderSupervisor { get; set; }
        public int? circumstanceId { get; set; }
        public int? practitonerModifierId { get; set; }
        public bool isClinical { get; set; }
        public string dea { get; set; }
        public bool isNeedDosepot { get; set; }
        public bool isDefaultClinician { get; set; }
        public bool? isDiagnosisEvaluation { get; set; }
        public bool isTestProvider { get; set; }
        public int? MHPractitonerModifierId { get; set; }
        public int? SUDPractitonerModifierId { get; set; }
        //public Provideridentity[] providerIdentities { get; set; }        
        public  IProvideridentity[] providerIdentities { get; set; }
        public IProviderFacilityDTO[] providerFacility { get; set; }
    }

    public class Provideridentity
    {
        public int id { get; set; }
        public int providerId { get; set; }
        public int identityId { get; set; }
        public string value { get; set; }
        public DateTime activeDate { get; set; }
        public DateTime? inactiveDate { get; set; }
        public IIdentity identity { get; set; }
        
    }

    public class Identity
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public bool active { get; set; }
    }

}
