using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IPracticeCentralPractice
    {
        int PracticeId { get; set; }
        string PracticeName { get; set; }
        string PracticeCode { get; set; }
        string PracticeURL { get; set; }
        string StripeKey { get; set; }
        string DBName { get; set; }
        string CustomerKey { get; set; }
        string LabDBName { get; set; }
        string DBConnectionString { get; set; }
        string PracticeCodeCLM { get; set; }
}
}
