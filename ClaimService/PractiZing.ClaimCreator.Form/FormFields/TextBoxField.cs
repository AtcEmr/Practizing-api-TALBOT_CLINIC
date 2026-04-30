using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class TextBoxField : ClaimField
    {
        public override bool SetField(AcroFields acroFields, object value)
        {
            try
            {
                if (value != null)
                {
                    bool result = acroFields.SetField(this.FormField, value?.ToString());
                    return result;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }

}
