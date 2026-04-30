using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    internal sealed class FormSource :IDisposable
    {
        private const string cms1500 = @"PractiZing.ClaimCreator.Form.FormTemplates.Cms1500.pdf";
        private const string cms1500Config = @"PractiZing.ClaimCreator.Form.FormTemplates.Cms1500.json";

        public ClaimPDFDocument Document { get; set; }
        public ClaimFieldConfig ClaimFieldConfig { get; set; }
        public ClaimFieldsCollection ClaimFieldsCollection { get; set; }

        public FormSource (FormTemplateType template, string newFile)
        {
            try
            {
                ClaimPDFDocument document = null;
                switch (template)
                {
                    case FormTemplateType.CMS1500:
                        {
                            document = new ClaimPDFDocument(cms1500, newFile);
                            break;
                        }
                }

                this.Document = document;

                this.ClaimFieldConfig = ReadFromJSON(template);
                this.ClaimFieldsCollection = new ClaimFieldsCollection(this.ClaimFieldConfig);
            }
            catch(Exception ex)
            {
                Document.Dispose();
            }
        }

        
       

        private static ClaimFieldConfig ReadFromJSON(FormTemplateType formTemplateType)
        {

            var assembly = typeof(ClaimPDFDocument).GetTypeInfo().Assembly;

            using (var resourceStream = assembly.GetManifestResourceStream(cms1500Config))
            {
                string json = new StreamReader(resourceStream).ReadToEnd();
                var configX = JsonConvert.DeserializeObject<ClaimFieldConfig>(json);
                return configX;
            }

        }

        public void Dispose()
        {
            this.Document.Dispose();
        }
    }
}
