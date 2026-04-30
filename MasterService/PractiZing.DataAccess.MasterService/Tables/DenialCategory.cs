using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class DenialCategory : IDenialCategory
    {
        public DenialCategory()
        {
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string DenialCategoryName { get; set; }
        public int PracticeId { get; set; }
        public Guid UId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Ignore]
        public string[] ReasonCodes { get; set; }
        [Ignore]
        public string ReasonCode { get; set; }
        
    }
}
