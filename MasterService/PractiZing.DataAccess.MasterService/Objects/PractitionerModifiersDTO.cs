using PractiZing.Base.Model.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Objects
{
    
    public class PractitionerModifiersDTO: IPractitionerModifiersDTO
    {
        public PractitionerModifiersDTO()
        {
            cptModifier = new Cptmodifier();
            sudcptModifier = new Sudcptmodifier();
        }

        public int id { get; set; }
        public string name { get; set; }
        public int cptModifierId { get; set; }
        public string description { get; set; }
        public bool? isSupervisionRequired { get; set; }
        public bool? canSuperviseOther { get; set; }
        public bool? canAdminSuperviseOther { get; set; }
        public ICptmodifier cptModifier { get; set; }
        public ISudcptmodifier sudcptModifier { get; set; }
    }

    public class Cptmodifier: ICptmodifier
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Sudcptmodifier: ISudcptmodifier
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

}

