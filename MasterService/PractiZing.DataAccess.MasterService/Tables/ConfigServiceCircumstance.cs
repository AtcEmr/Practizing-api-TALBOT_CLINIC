using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigServiceCircumstance : IConfigServiceCircumstance
    {
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public string Circumstance { get; set; }
        public Int16 CPTModifier_Id { get; set; }
        [Ignore]
        public Guid CPTModifierUId { get; set; }
        [Ignore]
        public string Modifier { get; set; }
    }
}
