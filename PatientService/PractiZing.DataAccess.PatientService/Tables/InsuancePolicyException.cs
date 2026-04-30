using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class InsurancePolicyException : IInsurancePolicyException
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public long PolicyId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
