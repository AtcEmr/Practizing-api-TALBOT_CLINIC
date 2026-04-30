using System;
using System.Xml.Serialization;

namespace EdiFabric.Templates.Hipaa5010
{
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1065
    {
        [XmlEnum("1")]
        Item1,
        [XmlEnum("2")]
        Item2,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_4
    {
        [XmlEnum("85")]
        Item85,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_2
    {
        [XmlEnum("EI")]
        EI,

        [XmlEnum("SY")]
        SY,
    }

    public enum IdentificationCodeQualifier
    {
        [XmlEnum("XX")]
        XX,

        [XmlEnum("46")]
        Item46

    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_10
    {
        [XmlEnum("82")]
        Item82,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_26
    {
        [XmlEnum("0B")]
        Item0B,
        [XmlEnum("1G")]
        Item1G,

        [XmlEnum("G2")]
        G2,

        [XmlEnum("LU")]
        LU,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_16
    {
        [XmlEnum("DK")]
        DK,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1065_3
    {
        [XmlEnum("1")]
        Item1,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_143
    {
        [XmlEnum("837")]
        Item837,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1138
    {

        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        P,
        S,
        T,
        U,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1069_3
    {
        [XmlEnum("01")]
        Item01,
        [XmlEnum("18")]
        Item18,
        [XmlEnum("19")]
        Item19,
        [XmlEnum("20")]
        Item20,
        [XmlEnum("21")]
        Item21,
        [XmlEnum("39")]
        Item39,
        [XmlEnum("40")]
        Item40,
        [XmlEnum("53")]
        Item53,
        [XmlEnum("76")]
        Item76,
        [XmlEnum("27")]
        Item27,
        [XmlEnum("G8")]
        G8,
    }


    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_7
    {
        [XmlEnum("IL")]
        IL,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1250
    {
        [XmlEnum("D8")]
        D8,
    }

    
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_8
    {
        [XmlEnum("PR")]
        PR,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1065_2
    {
        [XmlEnum("2")]
        Item2,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_3
    {
        [XmlEnum("40")]
        Item40,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_366
    {
        [XmlEnum("IC")]
        IC,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98
    {
        [XmlEnum("41")]
        Item41,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1221
    {
        [XmlEnum("BI")]
        BI,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128
    {
        [XmlEnum("PXC")]
        PXC,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_11
    {
        [XmlEnum("77")]
        Item77,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_9
    {
        [XmlEnum("DN")]
        DN,

        [XmlEnum("P3")]
        P3,

        [XmlEnum("DQ")]
        DQ,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_235_2
    {
        [XmlEnum("ER")]
        ER,

        [XmlEnum("HC")]
        HC,

        [XmlEnum("IV")]
        IV,

        [XmlEnum("WK")]
        WK,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_374_19
    {
        [XmlEnum("472")]
        Item472,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1250_2
    {
        [XmlEnum("D8")]
        D8,

        [XmlEnum("RD8")]
        RD8,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_17
    {
        [XmlEnum("X4")]
        X4,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_32
    {
        [XmlEnum("6R")]
        Item6R,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_522_4
    {
        [XmlEnum("EAF")]
        EAF,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1033
    {
        [XmlEnum("CO")]
        CO,

        [XmlEnum("CR")]
        CR,

        [XmlEnum("OA")]
        OA,

        [XmlEnum("PI")]
        PI,

        [XmlEnum("PR")]
        PR,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_374_18
    {
        [XmlEnum("573")]
        Item573,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1270_3
    {
        [XmlEnum("ABF")]
        ABF,

        [XmlEnum("BF")]
        BF,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1270_2
    {
        [XmlEnum("ABK")]
        ABK,
        [XmlEnum("BK")]
        BK,
    }

    public class YesNoValues
    {
        public static readonly string Yes = "Y";
        public static readonly string No = "N";
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_374_10
    {
        [XmlEnum("314")]
        Item314,
        [XmlEnum("360")]
        Item360,
        [XmlEnum("361")]
        Item361,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_374_14
    {
        [XmlEnum("096")]
        Item096,
    }
    

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_374_13
    {
        [XmlEnum("435")]
        Item435,
    }
    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_15
    {
        [XmlEnum("G1")]
        G1,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_128_16
    {
        [XmlEnum("F8")]
        F8,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_1005
    {
        [XmlEnum("0019")]
        Item0019,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_353
    {
        [XmlEnum("00")]
        Item00,
        [XmlEnum("18")]
        Item18,
    }

    [XmlType(Namespace = "www.edifabric.com/x12", AnonymousType = true)]
    [XmlRoot(Namespace = "www.edifabric.com/x12", IsNullable = false)]
    public enum X12_ID_98_12
    {
        [XmlEnum("DQ")]
        DQ,
    }

}
