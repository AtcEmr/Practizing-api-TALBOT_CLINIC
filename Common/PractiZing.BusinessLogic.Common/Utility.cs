using Microsoft.Extensions.Configuration;
using MimeKit;
using PractiZing.Base.Object.MasterServcie;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PractiZing.BusinessLogic.Common
{
    //public class Utility<T> where T : class, new()
    public class Utility
    {
        //public static T SwapObject(object first)
        //{
        //    object temp = first;
        //    T second = new T();
        //    first = second;
        //    second = temp as T;
        //    return second;
        //}

        //public static IEnumerable<T> SwapList(IEnumerable<object> first)
        //{
        //    IEnumerable<object> temp = first;
        //    IEnumerable<T> second = new List<T>();
        //    first = second;
        //    second = temp as List<T>;
        //    return second;
        //}

        //public static IConfigurationRoot GetConfigurationVariable()
        //{
        //    try
        //    {
        //        var enviornment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //        enviornment = enviornment == null ? "Development" : enviornment;

        //        string filePath = Directory.GetCurrentDirectory() + $"../../../appsettings.{enviornment}.json";
        //        string filePath2 = Directory.GetCurrentDirectory() + $"../../appsettings.{enviornment}.json";

        //        if (File.Exists(filePath))
        //        {

        //        }

        //        var builder = new ConfigurationBuilder()
        //           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //           .AddJsonFile(filePath, optional: true, reloadOnChange: true)
        //           .AddJsonFile(filePath2, optional: true, reloadOnChange: true)
        //           .AddEnvironmentVariables();

        //        return builder.Build();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static string SendMail(IMailObject mailObject, string contentType = "", Dictionary<object, object> attachFiles = null)//,List<string> attachFileNames = null)
        {
            try
            {
                Console.WriteLine("Inside SendMail method ");
                //var _configuration = GetConfigurationVariable();
                //Smtp Server  
                string SmtpServer = mailObject.SmtpUrl;
                if (string.IsNullOrEmpty(SmtpServer))
                    return "";

                //Smtp Port Number  
                int SmtpPortNumber = Convert.ToInt32(mailObject.SmtpPort);// 587;
                if (String.IsNullOrEmpty(mailObject.FromAddress) || String.IsNullOrEmpty(mailObject.FromAddressPassword))
                {
                    mailObject.FromAddress = mailObject.SmtpUserName;
                    mailObject.FromAddressPassword = mailObject.SmtpPassword;
                }
                var mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(mailObject.FromAddress, mailObject.FromAdressTitle);
                foreach (var to in mailObject.To)
                {
                    if (!string.IsNullOrEmpty(to.ToAddress))
                    {
                        mailMessage.To.Add(to.ToAddress);
                    }
                }
                mailMessage.Subject = mailObject.Subject;
                if (String.IsNullOrEmpty(contentType))
                {
                    mailMessage.Body = mailObject.BodyContent;
                }
                else
                {
                    var builder = new BodyBuilder();
                    builder.HtmlBody = mailObject.BodyContent;


                    if (attachFiles != null && attachFiles.Count() > 0)
                    {
                        foreach (var attach in attachFiles)
                        {
                            var fileName = attach.Key.ToString();
                            byte[] fileInfo = Convert.FromBase64String(attach.Value.ToString());

                            var stream = new MemoryStream(fileInfo, false);
                            var attachment = new System.Net.Mail.Attachment(stream, fileName);
                            mailMessage.Attachments.Add(attachment);
                        }
                    }
                    mailMessage.Body = mailObject.BodyContent;
                    mailMessage.IsBodyHtml = true;

                }
                var smtpClient = new System.Net.Mail.SmtpClient();
                smtpClient.Host = SmtpServer;
                smtpClient.Credentials = new System.Net.NetworkCredential(mailObject.FromAddress, mailObject.FromAddressPassword);
                smtpClient.EnableSsl = true;
                smtpClient.Port = SmtpPortNumber;
                smtpClient.Send(mailMessage);
                Console.WriteLine("Inside SendMail method mail sent successfully");
                return "The mail has been sent successfully !!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email Excel -> EmailExport Exception");
                Console.WriteLine(ex.Message + "==" + ex.StackTrace);
                Console.WriteLine(ex.InnerException != null ? ex.InnerException.ToString() : "");
                throw ex;
            }
        }
    }
}
