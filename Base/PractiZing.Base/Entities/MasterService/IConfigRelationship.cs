using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigRelationship : IActive
    {
        int ID { get; set; }
        string Description { get; set; }
        bool GuarantorVisible { get; set; }
        bool PolicyHolderVisible { get; set; }
        string RelationshipCode { get; set; }

    }
}
