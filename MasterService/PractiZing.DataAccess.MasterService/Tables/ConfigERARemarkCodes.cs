using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigERARemarkCodes : IConfigERARemarkCodes
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string RemarkQualifier { get; set; }
        public string RemarkCode { get; set; }
        public string RemarkMessage { get; set; }
        public bool IsActive { get; set; }

        [Ignore]
        public  string FullCode { get; set; }
    }
}
