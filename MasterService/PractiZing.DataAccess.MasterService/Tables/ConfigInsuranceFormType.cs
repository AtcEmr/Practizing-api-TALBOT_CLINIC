using PractiZing.Base.Entities.MasterService;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigInsuranceFormType : IConfigInsuranceFormType
    {
        [Key]
        public Int16 Id { get; set; }
        public string FTName { get; set; }
        public Int16? MaxDiagnoses { get; set; }
        public Int16? MaxServices { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
    }
}
