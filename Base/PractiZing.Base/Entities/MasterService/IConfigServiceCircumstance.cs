using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigServiceCircumstance
    {
        Int16 Id { get; set; }
        string Circumstance { get; set; }
        Int16 CPTModifier_Id { get; set; }        
        Guid CPTModifierUId { get; set; }        
        string Modifier { get; set; }
    }
}
