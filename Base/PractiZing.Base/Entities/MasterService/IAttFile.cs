using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IAttFile : IStamp, IPracticeDTO, IUniqueIdentifier
    {
        int Id { get; set; }
        string FileName { get; set; }
        string FileNameExt { get; set; }
        string FullPath { get; set; }
        int AttFileTableId { get; set; }
        int TableIdValue { get; set; }

        string FullPathAttachment { get; set; }
    }
}
