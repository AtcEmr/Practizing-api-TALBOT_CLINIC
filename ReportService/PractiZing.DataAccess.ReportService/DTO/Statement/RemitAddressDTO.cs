using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    [XmlType(TypeName = "RemitAddress")]
    public class RemitAddressDTO
    {
        public string Name { get; set; }

        public AddressDTO Address { get; set; }        
    }
}
