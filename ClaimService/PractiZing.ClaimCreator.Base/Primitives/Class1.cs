using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property)]
    public class DescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public string Code { get; set; }

        public DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
    public enum BillToType
    {
        [Description("Primary insurance level")]
        Primary = 1,

        [Description("Secondary insurance level")]
        Secondary = 2

    }

    public enum AcceptAssignmentType
    {
        [Description("Not Assigned", Code = "N")]
        NotAssigned = 0,

        [Description("Assigned", Code = "Y")]
        Assigned = 1,

        [Description("Assignment Accepted on Clinical Lab Services Only")]
        AssignmentAcceptedOnly = 2
    }

    public enum RelationshipType
    {
        [Description("Self")]
        Self = 1,

        [Description("Spouse")]
        Spouse = 2,

        [Description("Child")]
        Child = 3,

        [Description("Other")]
        Other = 4,
        [Description("Life Partner")]
        LifePartner = 6,
        [Description("Dependent")]
        Dependent = 12,

        [Description("Student")]
        Student = 13
    }

    public enum GrpType
    {
        None,

        [Description("State License Number", Code = "0B")]
        StateLicenseNumber,

        [Description("Provider UPIN Number", Code = "1G")]
        ProviderUpinNumber,

        [Description("Provider Commercial Number", Code = "G2")]
        ProviderCommercialNumber,

        [Description("Location Number", Code = "LU")]
        LocationNumber,
        [Description("Provider Taxonomy", Code = "ZZ")]
        ProviderTaxonomy
    }

    public enum ContactsType
    {
        Phone = 1,
        Fax = 2,
        Email = 3,
        WebSite = 4,
        Extension = 5
    }

    public class CodeQualifierValues
    {
        public static string[] values = { "F2", "GR", "ME", "ML", "UN" };

        public static string[] ValuesArray { get { return values; } }
    }

    public static class AcceptAssignmentValues
    {
        public static readonly string NotAssigned = "C";
        public static readonly string Assigned = "A";
        public static readonly string AssignmentAcceptedOnly = "B";
    }

    public enum ClaimResubmissionCode
    {

        [Description("Original Claim", Code = "1")]
        Original = 1,

        [Description("Adjustment of Prior Claim", Code = "6")]
        Corrected = 6,

        [Description("Replacement of Prior Claim", Code = "7")]
        Replacement = 7,

        [Description("Cancel Prior Claim", Code = "8")]
        Cancel = 8
    }
}
