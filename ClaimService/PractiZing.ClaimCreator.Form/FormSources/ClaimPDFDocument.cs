using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PractiZing.ClaimCreator.Form
{
    public class ClaimPDFDocument : IDisposable
    {
        private PdfReader _pdfReader;

        private PdfStamper _pdfStamper;

        public AcroFields PdfFormFields
        {
            get
            {
                return _pdfStamper.AcroFields;
            }
        }


        public ClaimPDFDocument(string resourceName,string newFile)
        {
                        
            var assembly = typeof(ClaimPDFDocument).GetTypeInfo().Assembly;

            using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                _pdfReader = new PdfReader(resourceStream);

                _pdfStamper = new PdfStamper(_pdfReader, new FileStream(
                      newFile, FileMode.Create));
            }

        }

        public void LockDocument()
        {
            _pdfStamper.FormFlattening = true;
        }

        
        public void Dispose()
        {
            _pdfStamper.Close();
            _pdfStamper.Dispose();
            _pdfReader.Close();
            _pdfReader.Dispose();
            
        }
    }
}
