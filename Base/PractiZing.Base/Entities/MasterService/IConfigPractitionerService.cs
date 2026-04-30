using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigPractitionerService
    {
        int Id { get; set; }        
        string ProvidingService { get; set; }        
        string ProfessionalAbbreviation { get; set; }
        Int16? CPTModifier_Id { get; set; }
        bool IsActive { get; set; }
        Guid CPTModifierUId { get; set; }        
        string Modifier { get; set; }
        bool? IsSupervisionRequired { get; set; }
        bool? CanBeSupervision { get; set; }
        string Qualification { get; set; }
        string Designation { get; set; }
        int? EmrId { get; set; }
        string PractitionerModifier { get; set; }
    }
}
