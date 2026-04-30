using iTextSharp.text.pdf;
using PractiZing.Base.Model.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class InsuranceServiceField : ClaimField
    {
        public override bool SetField(AcroFields acroFields, object value)
        {
            InsuranceService[] services = value as InsuranceService[];
            PropertyInfo[] properties = typeof(InsuranceService).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                                                          .ToArray();
            foreach (var prop in properties)
            {
                SetFieldItem(services, prop, acroFields);
            }
            return true;
        }

        private void SetFieldItem(InsuranceService[] services, PropertyInfo property, AcroFields acroFields)
        {
            int index = 0;
            foreach (var service in services)
            {
                index++;
                var propValue = property.GetValue(service);
                var formField = this.FormFields.FirstOrDefault(i => i.Key.ToLower() == property.Name.ToLower());
                if (formField.Value != null)
                {
                    string fieldName = String.Format(formField.Value, index);
                    bool result = acroFields.SetField(fieldName, propValue?.ToString());
                }
            }
        }
    }

}
