using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigPractitionerService : IConfigPractitionerService
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        //[MaxLength(50, ErrorMessage = "Name - Must not enter more than 50 characters.")]
        public string ProvidingService { get; set; }
        //[MaxLength(2, ErrorMessage = "Prefix - Must not enter more than 2 characters.")]
        public string ProfessionalAbbreviation { get; set; }
        public Int16? CPTModifier_Id { get; set; }
        public bool IsActive { get; set; }
        public bool? IsSupervisionRequired { get; set; }
        public bool? CanBeSupervision { get; set; }
        public string Designation { get; set; }
        public string PractitionerModifier { get; set; }
        public int? EmrId { get; set; }
        [Ignore]
        public Guid CPTModifierUId { get; set; }
        [Ignore]
        public string Modifier { get; set; }
        [Ignore]
        public string Qualification { get; set; }
        [Ignore]
        public string SUDQualification { get; set; }
    }
}
