using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
   

    public static class CultureHelper
    {
        private static CultureInfo culture;

        public static CultureInfo Culture
        {
            get
            {
                if (culture == null)
                {
                    culture = new CultureInfo("En-us");
                }

                return culture;
            }
        }
    }
}
