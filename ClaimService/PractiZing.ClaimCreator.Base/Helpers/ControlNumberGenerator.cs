using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class ControlNumberGenerator
    {
      
        public static string GenerateUniqueNumber()
        {
            Random random = new Random();
            string result = random.Next(111111111, 999999999).ToString();
            return result;
        }

        public static string GenerateUniqueIdentity()
        {
            Random random = new Random();
            string result = random.Next(1111111111, 1999999999).ToString();
            return result;
        }
    }
}
