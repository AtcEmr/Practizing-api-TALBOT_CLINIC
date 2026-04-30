using PractiZing.Base.Entities;
using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class AdjustmentReasonCode : IAdjustmentReasonCode
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage ="Please enter group code.")]
        public string GroupCode { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter code.")]
        public string Code { get; set; }
        public bool IsDenailCode { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please enter description.")]
        public string Description { get; set; }
        [Ignore]
        public string ReasonCode { get; set; }
        public Guid UId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int PracticeId { get; set; }
        public bool IsActive { get; set; }
        public bool? IsForWriteOff { get; set; }
    }
}
