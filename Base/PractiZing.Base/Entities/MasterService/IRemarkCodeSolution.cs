using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IRemarkCodeSolution
    {
        int Id { get; set; }
        string RemarkCode { get; set; }
        short StepNumber { get; set; }
        string Solution { get; set; }
    }
}
