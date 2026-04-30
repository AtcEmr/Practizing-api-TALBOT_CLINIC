using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "Address")]
    public class AddressDTO
    {
        public string AddressLine { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }
    }
}
