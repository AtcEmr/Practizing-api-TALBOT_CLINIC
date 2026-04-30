using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using Excel = Microsoft.Office.Interop.Excel;

namespace PractiZing.Api.Common
{

    public static class FileOperations
    {
        public static void ConvertCsvToXlsx(string excelFilePath, string csvFilePath)
        {
            string worksheetsName = "TEST";
            bool firstRowIsHeader = false;
            var format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.EOL = "\r";              // DEFAULT IS "\r\n";
                                            // format.TextQualifier = '"';
            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
                worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFilePath), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
                package.Save();
            }
        }
        public static async Task CreateFileUsingIFromFile(IFormFile file, string filePath)
        {
            using (var inputStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(inputStream);
            }
          
        }

        public static async Task DeleteFiles(List<string> filesList)
        {
            if (filesList != null && filesList.Count() > 0)
            {
                try
                {
                    foreach (var filePath in filesList)
                    {
                       File.Delete(filePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }
        public static async Task<string> SaveImageFromBase64(string base64String, string folderPath,string fileName="")
        {
            byte[] bytes = Convert.FromBase64String(base64String);
            if(fileName=="")
            {
                 fileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".pdf";
            }
            var filePath = Path.Combine(folderPath, fileName);
            FileStream stream = new FileStream(filePath, FileMode.CreateNew);
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write(bytes, 0, bytes.Length);
            writer.Dispose();
            return fileName;
        }
        public static string ConvertStreamToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return Convert.ToBase64String(bytes);
        }
        public static async Task<string> CreateFileFromBytes(byte[] bytes, string folderPath, string fileName = "")
        {
            //bytes = Convert.FromBase64String(Encoding.UTF8.GetString(bytes));
            if (fileName == "")
            {
                fileName = Guid.NewGuid().ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + ".pdf";
            }
            var filePath = Path.Combine(folderPath, fileName);
            File.WriteAllBytes(filePath, bytes);

            return fileName;
        }
        
    }
}
