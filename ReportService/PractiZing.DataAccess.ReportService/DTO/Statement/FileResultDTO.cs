using PractiZing.Base.Object.ReportService;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ReportService.DTO.Statement
{
    public class FileResultDTO : IFileResultDTO
    {
        public FileResultDTO(string name, byte[] bytes)
        {            
            Name = name;
            Bytes = bytes;
        }

        public string Name { get; set; }

        public byte[] Bytes { get; set; }
    }
}
