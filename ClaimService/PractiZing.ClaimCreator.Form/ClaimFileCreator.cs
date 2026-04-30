using iTextSharp.text.pdf;
using PractiZing.Base.Model.Claim;
using PractiZing.ClaimCreator.Base;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.ClaimCreator.Form
{

    public class ClaimFileCreator
    {
        public async Task<FileResultX> CreateFileAsync(FormTemplateType formTemplate, IInsuranceClaimData data)
        {

            //ClaimData claimData = new ClaimData();
            //claimData.ClaimType = "Medicare";
            //claimData.InsuranceName = "Atena Insurance";
            //claimData.PatientFullName = "Manoj Taneja";

            InsuranceClaimData claimData = new InsuranceClaimData(data);
            var props = typeof(InsuranceClaimData).GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                                                                          .ToArray();
            var formsource = new FormSource(formTemplate, data.GetFileName());
            bool writingHasError = false;
            try
            {
                foreach (var prop in props)
                {
                    var propValue = prop.GetValue(claimData);
                    var field = formsource.ClaimFieldsCollection.ClaimFields.FirstOrDefault(i => i.Name.ToLower() == prop.Name.ToLower());
                    if (field != null)
                    {
                        field.SetField(formsource.Document.PdfFormFields, propValue);
                    }
                    else
                    {
                        Console.WriteLine("No field for-" + prop.Name.ToLower());
                    }
                }

                formsource.Document.LockDocument();
                formsource.Dispose();

                var fileStream = new FileStream(data.GetFileName(), FileMode.Open);
                byte[] bytesData = new byte[fileStream.Length];
                fileStream.Read(bytesData, 0, bytesData.Length);
                fileStream.Close();
                var result = new FileResultX(data.GetFileName(), bytesData);
                return result;

            }
            catch (Exception ex)
            {
                formsource.Document.LockDocument();
                formsource.Dispose();

                throw;
            }

            finally
            {
          

            }

          


        }
    }




}
