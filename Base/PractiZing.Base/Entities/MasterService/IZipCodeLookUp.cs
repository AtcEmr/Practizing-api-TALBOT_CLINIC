using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IZipCodeLookUp : IPracticeDTO, IActive
    {
        int ID { get; set; }
        string Zip { get; set; }
        string City { get; set; }
        string State { get; set; }
        string AreaCode { get; set; }
    }
}
