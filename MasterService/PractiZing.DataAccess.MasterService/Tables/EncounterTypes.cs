using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class EncounterTypes : IEncounterTypes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsBillable { get; set; }
        public bool IsMentalHealthCPT { get; set; }
        public int EncounterTypeClacification { get; set; }
        public bool SupervisionRequired { get; set; }
        public bool Active { get; set; }
    }
}
