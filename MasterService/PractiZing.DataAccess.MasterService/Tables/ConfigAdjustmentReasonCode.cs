using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("vw_ConfigAdjustmentReasonCode")]
    public class ConfigAdjustmentReasonCode : IConfigAdjustmentReasonCode
    {
        //[Key]
        //[AutoIncrement]
        public int Id { get; set; }
        public string GroupCode { get; set; }
        public string Code { get; set; }
        public string ReasonCode { get; set; }
        public string FLAG { get; set; }
        [Ignore]
        public string CodeType { get; set; }
        [Ignore]
        public string Category { get; set; }
        [Ignore]
        public string CategoryDescription { get; set; }
        [Ignore]
        public string CodeDescription { get; set; }
        public string Description { get; set; }
        [Ignore]
        public short? ActiveFlag { get; set; }
        [Ignore]
        public DateTime CreatedDateTime { get; set; }

        [Ignore]
        public string RemarkQualifier { get; set; }

        [Ignore]
        public bool Selected { get; set; }

        [Ignore]
        public int NotesCategoryId { get; set; }

        [Ignore]
        public bool IsReasonCodeDeleted { get; set; }        
        public bool IsForWriteOff { get; set; }

    }
}
