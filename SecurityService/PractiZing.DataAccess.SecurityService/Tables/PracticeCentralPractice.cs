using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService.Tables
{
    [Alias("Practice")]
    public class PracticeCentralPractice : IPracticeCentralPractice
    {
        [Key]
        [AutoIncrement]
        public int PracticeId { get; set; }
        public string PracticeName { get; set; }
        public string PracticeCode { get; set; }
        public string PracticeURL { get; set; }
        public string StripeKey { get; set; }
        public string DBName { get; set; }
        public string CustomerKey { get; set; }
        public string LabDBName { get; set; }
        public string DBConnectionString { get; set; }
        public string PracticeCodeCLM { get; set; }
    }
}
