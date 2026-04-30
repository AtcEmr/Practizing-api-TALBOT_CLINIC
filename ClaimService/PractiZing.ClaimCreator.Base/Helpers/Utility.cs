using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class Utility
    {
        public static (string lastName, string firstName) DivideName(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return ("", "");
            var split = fullname.Split(",");
            if (split.Length == 2)
                return (split[0].Trim(), split[1].Trim());
            else
                return (split[0].Trim(), "");
        }

        public static string GetGender(string genderType, bool isInt)
        {

            switch (genderType)
            {
                case "0":
                    return "M";
                case "1":
                    return "F";
                default:
                    return "U";
            }
        }
    }
}
