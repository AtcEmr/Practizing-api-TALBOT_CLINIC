public class StediRootobject
{
    public Billing billing { get; set; }
    public Claiminformation claimInformation { get; set; }
    public Receiver receiver { get; set; }
    public Submitter submitter { get; set; }
    public Subscriber subscriber { get; set; }
    public string tradingPartnerName { get; set; }
    public string tradingPartnerServiceId { get; set; }
    public string usageIndicator { get; set; }
}

public class Billing
{
    public Address address { get; set; }
    public Contactinformation contactInformation { get; set; }
    public string employerId { get; set; }
    public string npi { get; set; }
    public string organizationName { get; set; }
    public string providerType { get; set; }
    public string taxonomyCode { get; set; }
}

public class Address
{
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string state { get; set; }
}

public class Contactinformation
{
    public string name { get; set; }
    public string phoneNumber { get; set; }
}

public class Claiminformation
{
    public string benefitsAssignmentCertificationIndicator { get; set; }
    public string claimChargeAmount { get; set; }
    public string claimFilingCode { get; set; }
    public string claimFrequencyCode { get; set; }
    public Healthcarecodeinformation[] healthCareCodeInformation { get; set; }
    public string patientControlNumber { get; set; }
    public string placeOfServiceCode { get; set; }
    public string planParticipationCode { get; set; }
    public string releaseInformationCode { get; set; }
    public Servicefacilitylocation serviceFacilityLocation { get; set; }
    public Serviceline[] serviceLines { get; set; }
    public string signatureIndicator { get; set; }
}

public class Servicefacilitylocation
{
    public Address1 address { get; set; }
    public string npi { get; set; }
    public string organizationName { get; set; }
}

public class Address1
{
    public string address1 { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string state { get; set; }
}

public class Healthcarecodeinformation
{
    public string diagnosisCode { get; set; }
    public string diagnosisTypeCode { get; set; }
}

public class Serviceline
{
    public Professionalservice professionalService { get; set; }
    public string providerControlNumber { get; set; }
    public Renderingprovider renderingProvider { get; set; }
    public string serviceDate { get; set; }
}

public class Professionalservice
{
    public Compositediagnosiscodepointers compositeDiagnosisCodePointers { get; set; }
    public string lineItemChargeAmount { get; set; }
    public string measurementUnit { get; set; }
    public string procedureCode { get; set; }
    public string procedureIdentifier { get; set; }
    public string[] procedureModifiers { get; set; }
    public string serviceUnitCount { get; set; }
}

public class Compositediagnosiscodepointers
{
    public string[] diagnosisCodePointers { get; set; }
}

public class Renderingprovider
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string npi { get; set; }
    public string providerType { get; set; }
    public string taxonomyCode { get; set; }
}

public class Receiver
{
    public string organizationName { get; set; }
}

public class Submitter
{
    public Contactinformation1 contactInformation { get; set; }
    public string organizationName { get; set; }
    public string submitterIdentification { get; set; }
}

public class Contactinformation1
{
    public string name { get; set; }
    public string phoneNumber { get; set; }
}

public class Subscriber
{
    public Address2 address { get; set; }
    public string dateOfBirth { get; set; }
    public string firstName { get; set; }
    public string gender { get; set; }
    public string groupNumber { get; set; }
    public string lastName { get; set; }
    public string memberId { get; set; }
    public string paymentResponsibilityLevelCode { get; set; }
    public string subscriberGroupName { get; set; }
}

public class Address2
{
    public string address1 { get; set; }
    public string city { get; set; }
    public string postalCode { get; set; }
    public string state { get; set; }
}
