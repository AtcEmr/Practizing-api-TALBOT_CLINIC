using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class AttFile : IAttFile
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileNameExt { get; set; }
        public string FullPath { get; set; }
        public Guid UId { get; set; }
        public int AttFileTableId { get; set; }
        public int TableIdValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int PracticeId { get; set; }

        [Ignore]
        public string FullPathAttachment { get; set; }
    }
}
