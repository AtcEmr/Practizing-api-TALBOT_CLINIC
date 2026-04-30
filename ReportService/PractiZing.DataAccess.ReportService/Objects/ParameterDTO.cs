using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ReportService.Objects
{
    public class ParameterDTO : IParameterDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
