using iTextSharp.text.pdf;
using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class DiagnosisField : ClaimField
    {
        public override bool SetField(AcroFields acroFields, object value)
        {
            string[] codes = value as string[];
            SetFieldItem(codes, acroFields);
            
            return true;
        }

        private void SetFieldItem(string[] codes,AcroFields acroFields)
        {
            int index = 0;
            foreach (var code in codes)
            {
                index++;                
                var formField = this.FormFields.FirstOrDefault(i => i.Key.ToLower() == "code");
                if (formField.Value != null)
                {
                    string fieldName = String.Format(formField.Value, index);
                    bool result = acroFields.SetField(fieldName, code);
                }
            }
        }
    }

}
