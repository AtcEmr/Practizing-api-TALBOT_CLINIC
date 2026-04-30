using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class FileResultX
    {
        public FileResultX(string name, byte[] bytes)
        {
            Name = name;
            Bytes = bytes;
        }

        public string Name { get; set; }

        public byte[] Bytes { get; }

    }
}
