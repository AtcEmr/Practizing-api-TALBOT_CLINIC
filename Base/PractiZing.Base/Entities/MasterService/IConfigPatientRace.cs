using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigPatientRace 
    {
        int Id { get; set; }
        string Race { get; set; }
        string Description { get; set; }
        string Code { get; set; }
        string CodeSystem { get; set; }
        string ExternalID { get; set; }
    }
}
