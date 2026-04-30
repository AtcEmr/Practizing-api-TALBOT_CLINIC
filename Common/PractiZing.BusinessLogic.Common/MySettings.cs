using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    public class MyConfiguration
    {
        public MySettings settings { get; set; }
        public MyConfiguration(IOptions<MySettings> options)
        {
            this.settings = options.Value;
        }
       
    }

    public class MySettings
    {

        public DefaultSettings DefaultSettings { get; set; } = new DefaultSettings();
    }

    public class DefaultSettings
    {
        public string TOS { get; set; }
        public string POS { get; set; }
        public bool BillToInsurance { get; set; }
        public bool Ultrasound { get; set; }
        public string CodeSystem { get; set; }
        public string DefaultFacility { get; set; }
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public string TimeZone { get; set; }
        public string ServiceTypeCode { get; set; }
    }



}

