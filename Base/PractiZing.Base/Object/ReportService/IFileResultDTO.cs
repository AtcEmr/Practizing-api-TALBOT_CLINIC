using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Object.ReportService
{
    public interface IFileResultDTO
    {       
        string Name { get; set; }

        byte[] Bytes { get; set; }
    }
}
