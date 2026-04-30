using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class CheckBoxField : ClaimField
    {
        public override bool SetField(AcroFields acroFields, object value)
        {
            string finalValue = "";
            if (this.FormFieldsValues != null)
            {
                finalValue = this.FormFieldsValues.FirstOrDefault(i => i.Key.ToLower() == value.ToString().ToLower()).Value;
            }
            else if(value.ToString() == "True") {
                finalValue = "YES";
            }
            else if (value.ToString() == "False")
            {
                finalValue = "NO";
            }
            else
            {
                finalValue = value.ToString();
            }

    var formField = this.FormFields.FirstOrDefault(i => i.Key.ToLower() == value.ToString().ToLower());
            if (formField.Value != null)
                return acroFields.SetField(formField.Value, finalValue);
            else
                return false;
        }
    }

}
