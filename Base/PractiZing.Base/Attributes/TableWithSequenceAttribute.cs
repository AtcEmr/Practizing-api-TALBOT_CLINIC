using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PractiZing.Base.Attributes
{
    public class TableWithSequenceAttribute : TableAttribute
    {
        public string SequenceName { get; set; }
        public TableWithSequenceAttribute(string name) : base(name)
        {

        }
    }
}
