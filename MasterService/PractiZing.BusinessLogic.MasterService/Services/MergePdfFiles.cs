using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public interface IMergePdfFiles
    {
        Task<string> CreatePDF(IEnumerable<string> filePath, string filePathMergedFile);
    }

    public class MergePdfFiles: IMergePdfFiles
    {
        public async Task<string> CreatePDF(IEnumerable<string> filePath, string filePathMergedFile)
        {
            List<PdfDocument> pdfFiles = new List<PdfDocument>();

            foreach (var item in filePath)
            {
                using (PdfDocument one = PdfReader.Open(item, PdfDocumentOpenMode.Import))
                {
                    pdfFiles.Add(one);
                };
            }
            
            using (PdfDocument outPdf = new PdfDocument())
            {
                foreach (var item in pdfFiles)
                {
                    CopyPages(item, outPdf);
                }
                
                outPdf.Save(filePathMergedFile);
            }

            void CopyPages(PdfDocument from, PdfDocument to)
            {
                for (int i = 0; i < from.PageCount; i++)
                {
                    to.AddPage(from.Pages[i]);
                }
            }

            return filePathMergedFile;
        }
    }
}
