using PractiZing.Base.Model.PatientService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    public class HL7StatusFilter : IHL7StatusFilter
    {
        [SearchField(Name = HL7FilterModel.FromDate)]
        public string FromDate { get; set; }
        [SearchField(Name = HL7FilterModel.ToDate)]
        public string ToDate { get; set; }
        public IEnumerable<string> AccessionNumber { get; set; }
        [SearchField(Name = HL7FilterModel.BillingId)]
        public string BillingId { get; set; }
    }

    public class HL7FilterModel
    {
        public const string TableName = "HL7Status";
        public const string BillingId = TableName + "." + "BillingId";
        public const string FromDate = TableName + "." + "CreatedDate";
        public const string ToDate = TableName + "." + "CreatedDate";
    }
}
