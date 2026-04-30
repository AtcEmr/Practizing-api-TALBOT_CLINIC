using System.ComponentModel;

namespace PractiZing.Base.Enums.ChargePaymentEnums
{
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
        LifePartner = 6
    }
}
