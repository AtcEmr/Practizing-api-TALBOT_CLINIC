using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class ClaimField
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> FormFields { get; set; }
        public Dictionary<string, string> FormFieldsValues { get; set; }

        public string FormField { get; set; }

        public virtual bool SetField(AcroFields acroFields, object value)
        {
            return true;
        }

        public static void CopyTo(ClaimField fromField, ClaimField toField)
        {
            toField.FormField = fromField.FormField;
            toField.FormFields = fromField.FormFields;
            toField.Type = fromField.Type;
            toField.Name = fromField.Name;
            toField.FormFieldsValues = fromField.FormFieldsValues;
        }
    }

    public class ClaimFieldConfig
    {
        public IEnumerable<ClaimField> ClaimFields { get; set; }

        
    }

}
