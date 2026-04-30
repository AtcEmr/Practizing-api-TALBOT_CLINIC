using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class ClaimFieldsCollection
    {
        public IEnumerable<ClaimField> ClaimFields { get; set; }
        public ClaimFieldsCollection(ClaimFieldConfig config)
        {
            var claimFields = new List<ClaimField>();
            foreach (var field in config.ClaimFields)
            {
                ClaimField toField = null;
                if (field.Type == "CheckBox")
                {
                    toField = new CheckBoxField();
                }
                else if (field.Type == "TextBox")
                {
                    toField = new TextBoxField();
                }
                else if (field.Type == "InsuranceServiceField")
                {
                    toField = new InsuranceServiceField();
                }
                else if (field.Type == "DiagnosisField")
                {
                    toField = new DiagnosisField();
                }                
                if (toField==null)
                {
                    Console.WriteLine("ww");
                }
                CheckBoxField.CopyTo(field, toField);
                claimFields.Add(toField);
            }

            this.ClaimFields = claimFields;
        }
    }

}
