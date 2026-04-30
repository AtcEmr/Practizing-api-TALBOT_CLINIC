using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class TransactionType
    {
        public const string Eligibility = "HS";
        public const string ClaimStatus = "HR";
        public const string ClaimProfessional = "HC";
        public const string ClaimInstitutional = "IN";
    }

    public static class ContactsTypeValues
    {
        public static readonly string Email = "EM";
        public static readonly string Fax = "FX";
        public static readonly string Phone = "TE";
        public static readonly string WebSite = "EX";
        public static readonly string Extension = "EX";
    }

}
