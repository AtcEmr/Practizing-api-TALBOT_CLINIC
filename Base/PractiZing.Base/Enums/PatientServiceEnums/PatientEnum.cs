using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Enums.PatientEnums

{
    public enum PatientEnum
    {
        Female = 'F',
        Male = 'M',
        Undefined = 'U'
    }

    public enum PrefferedPhoneNumberEnum
    {
        Home = 'H',
        Mobile = 'M',
        Work = 'W'
    }

    public enum InsurancePolicyEnum
    {
        Primary = 1,
        Secondary = 2,
        Ternary = 3,
        Fourth= 4
    }

    public enum HL7StatusEnum
    {
        Pending,
        Error,
        Input,
        Processed
    }
}
