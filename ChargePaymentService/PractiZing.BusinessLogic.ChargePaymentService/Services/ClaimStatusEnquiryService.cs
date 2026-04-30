using PractiZing.Base.Repositories.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.Base.Service.ChargePaymentService;
using System.IO;
using Microsoft.Extensions.Configuration;

using PractiZing.DataAccess.Common;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.Base.Object.ClaimService;

using Newtonsoft.Json;


using PractiZing.Base.Entities.MasterService;
using System.Text;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Model.Claim;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.ClaimCreator.Base;
using PractiZing.ClaimCreator.Form;
using PractiZing.ClaimCreator.Prof;
using PractiZing.Sftp;
using PractiZing.Base.Model.ChargePaymentService;
//using PractiZing.BusinessLogic.ChargePaymentService.Request;
using System.Xml.Serialization;
using System.Xml;
using System.Net;
using System.Net.Http;
//using TrizettoServiceReference;

namespace PractiZing.BusinessLogic.ChargePaymentService.Services
{
    public class ClaimStatusEnquiryService : IClaimStatusEnquiryService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly IClaimTotalRepository _claimTotalRepository;
        
        private readonly IClaimChargeRepository _claimChargeRepository;
        private readonly IInvDiagnosisRepository _invDiagnosisRepository;
        //private readonly IFillUB04FormService _fillUB04FormService;
        private readonly IClearingHouseRepository _clearingHouseRepository;
        private readonly IClaimBatchRepository _claimBatchRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IActionNoteRepository _actionNoteRepository;
        private readonly IScrubErrorRepository _scrubErrorRepository;
        private string _relativePath;
        private string _baseUrl;
        private string _claimFolder;
        private string _fileType;
        private string _filePath;
        private readonly IClaimConfigRepository _claimConfigRepository;
        private readonly IConfiguration _configuration;
        private readonly IClaimService _claimService;
        private readonly IPaymentChargeRepository _iPaymentChargeRepository;
        private readonly string _senderName;
        private ClaimFileCreator _claimFileCreator;
        private readonly IAppSettingRepository _appSettingRepository;


        public ClaimStatusEnquiryService(IClaimRepository claimRepository, IClaimTotalRepository claimTotalRepository,IClaimChargeRepository claimChargeRepository, IInvDiagnosisRepository invDiagnosisRepository,
            IConfiguration configuration, IClearingHouseRepository clearingHouseRepository, IClaimBatchRepository claimBatchRepository,
            IPracticeRepository practiceRepository, IClaimConfigRepository claimConfigRepository, IInsuranceCompanyRepository insuranceCompanyRepository, IActionNoteRepository actionNoteRepository,
            IScrubErrorRepository scrubErrorRepository, IClaimService claimService, 
            IPaymentChargeRepository iPaymentChargeRepository,
            ClaimFileCreator claimFileCreator, IAppSettingRepository appSettingRepository)
        {
            this._appSettingRepository = appSettingRepository;
            this._claimRepository = claimRepository;
            this._claimTotalRepository = claimTotalRepository;
            
            this._claimChargeRepository = claimChargeRepository;
            this._invDiagnosisRepository = invDiagnosisRepository;
            //this._fillUB04FormService = ub04FillFormService;
            _baseUrl = configuration["ApplicationUrl"];
            _relativePath = configuration["AttachmentFolder"];
            _claimFolder = configuration["ClaimViewFolder"];
            _fileType = configuration["ClaimType"];
            _filePath = configuration["ApiPath"];
            _senderName = configuration["BillLast"];

            this._clearingHouseRepository = clearingHouseRepository;
            this._claimBatchRepository = claimBatchRepository;
            this._configuration = configuration;
            this._practiceRepository = practiceRepository;
            this._claimConfigRepository = claimConfigRepository;
            this._insuranceCompanyRepository = insuranceCompanyRepository;
            this._actionNoteRepository = actionNoteRepository;
            this._scrubErrorRepository = scrubErrorRepository;
            this._claimService = claimService;
            this._iPaymentChargeRepository = iPaymentChargeRepository;
            this._claimFileCreator = claimFileCreator;
        }

        

        private string Save(FileResultX result)
        {

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, _claimFolder);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string path = Path.Combine(filePath, "" + result.Name + "_batchReport.pdf");

            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                writer.Write(result.Bytes, 0, result.Bytes.Length);
            }
            return $"{_baseUrl}/{_relativePath}/{_claimFolder}/{result.Name + "_batchReport.pdf"}";
        }

      

        public async Task<string> SentClaimStatusInquiry()
        {
            try
            {
                Guid batchUId = new Guid("F566CAE9-FA40-4BA9-8B23-3E333C0D7402");

                var batchRecord = await this._claimBatchRepository.Get(batchUId);

                var clearningHouse = await this._clearingHouseRepository.GetById
                    (batchRecord != null ? batchRecord.ClearingHouseId.Value : 0);

                var inCorrectClaims = await this._claimService.UnBatchClaims(batchUId);

                var claims = await this._claimRepository.GetByBatchUId(batchUId);
                int[] claimIds = claims.Select(i => i.Id).Distinct().ToArray();
                await this._claimBatchRepository.UpdateClaimCount(batchUId, claims.Count());

                IEnumerable<ICharges> charges = await this._claimChargeRepository.GetByClaim(claimIds);

                try
                {

                  //  ServiceEndpoint serviceEndpoint = new ServiceEndpoint()



                    //CORETransactionsClient client = new CORETransactionsClient();
                    //client.ClientCredentials.UserName.UserName = clearningHouse.UserName;
                   // client.ClientCredentials.UserName.Password = clearningHouse.Password;
                    //client.Endpoint.Address = new System.ServiceModel.EndpointAddress("https://api.gatewayedi.com/v2/CORE_CAQH/soap");
                    //client.Endpoint.Binding.Name = "customBinding";
                    //client.Abort();
                    //await client.OpenAsync();


                    foreach (var item in claims)
                    {
                        item.ClaimTotal = (await this._claimTotalRepository.GetByClaimId(item.Id, 0)).FirstOrDefault();
                        var creatorclaim = new X12_276_Creator(GetClaimOptions(clearningHouse));
                        string x12claim = creatorclaim.Create((claims as IEnumerable<Claim>));
                      await   Test(clearningHouse, x12claim);
                      //  var coreRequest = CoreEnvelopeRealTimeRequestFactory(clearningHouse,x12claim);
                      //   client.Endpoint.Address = null;

                        // var coreRealTimeResponse= await client.RealTimeTransactionAsync(coreRequest);
                    }

                   // await client.CloseAsync();

                    return "";
                }
                catch
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private  async Task Test(IClearingHouse clearingHouse,string x12)
        {
            try
            {




                //TrizettoReference.CORETransactionsClient transactionsClient = new TrizettoReference.CORETransactionsClient(TrizettoReference.CORETransactionsClient.EndpointConfiguration.CoreSoapPort);


                //transactionsClient.ClientCredentials.UserName.UserName = clearingHouse.UserName;
                //transactionsClient.ClientCredentials.UserName.Password = "tnrrpkj8";
                ////transactionsClient.Endpoint.Address = new System.ServiceModel.EndpointAddress("https://api.gatewayedi.com/v2/CORE_CAQH/soap");
                ////transactionsClient.Endpoint.Binding.Name = "customBinding";
                ////transactionsClient.Abort();
                ////await transactionsClient.OpenAsync();


                //TrizettoReference.COREEnvelopeRealTimeRequest COREEnvelopeRealTimeRequest = new TrizettoReference.COREEnvelopeRealTimeRequest();
                
                //COREEnvelopeRealTimeRequest.CORERuleVersion = "2.2.0";
                //COREEnvelopeRealTimeRequest.Payload = x12;
                //COREEnvelopeRealTimeRequest.PayloadID = Guid.NewGuid().ToString(); 
                //COREEnvelopeRealTimeRequest.PayloadType = "X12_276_Request_005010X212";
                //COREEnvelopeRealTimeRequest.ProcessingMode = "RealTime";
                //COREEnvelopeRealTimeRequest.ReceiverID = clearingHouse.RECVR_ID;
                //COREEnvelopeRealTimeRequest.SenderID = clearingHouse.SENDER_ID;
                //COREEnvelopeRealTimeRequest.TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
                ////if(transactionsClient.State!=System.ServiceModel.CommunicationState.Opened)
                //TrizettoReference.RealTimeTransactionResponse realTimeResponse = await transactionsClient.RealTimeTransactionAsync(COREEnvelopeRealTimeRequest);

            }
            catch (Exception ex)
            {

                throw;
            }

           
            









            //Envelope envelope = new Envelope();
            //envelope.Header = new EnvelopeHeader();
            //envelope.Header.Security = new Security();
            
            //envelope.Header.Security.UsernameToken = new SecurityUsernameToken();
            //envelope.Header.Security.UsernameToken.Username = clearingHouse.UserName;
            //envelope.Header.Security.UsernameToken.Password = new SecurityUsernameTokenPassword();
            //envelope.Header.Security.UsernameToken.Password.Value = "tnrrpkj8"; //clearingHouse.Password;
            //envelope.Header.Security.UsernameToken.Password.Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
            //envelope.Body = new EnvelopeBody();
            //envelope.Body.COREEnvelopeRealTimeRequest = new COREEnvelopeRealTimeRequest();
            



            //COREEnvelopeRealTimeRequest coreenvelopeRealTimeRequest = new COREEnvelopeRealTimeRequest();
            //coreenvelopeRealTimeRequest.CORERuleVersion = "2.2.0";
            
            //coreenvelopeRealTimeRequest.Payload = x12;//EDIHelpers.Generate270Transaction_Medicare(header, config);

            //coreenvelopeRealTimeRequest.PayloadID = Guid.NewGuid().ToString();
            //coreenvelopeRealTimeRequest.PayloadType = "X12_276_Request_005010X212"; 
            //coreenvelopeRealTimeRequest.ProcessingMode = "RealTime";
            //coreenvelopeRealTimeRequest.ReceiverID = clearingHouse.RECVR_ID;//"MMISODJFS";// A_0.ISA08ReceiverID;
            //coreenvelopeRealTimeRequest.SenderID = clearingHouse.SENDER_ID;//"OH-0021876";// A_0.ISA06SenderID;
            //coreenvelopeRealTimeRequest.TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"); ;//"2020-06-04T09:34:54-00:00";// DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");

            //envelope.Body.COREEnvelopeRealTimeRequest = coreenvelopeRealTimeRequest;

            //XmlSerializer xsSubmit = new XmlSerializer(typeof(Envelope));
            //var subReq = envelope;
            //var xml = "";




            //using (var sww = new StringWriter())
            //{
            //    using (XmlWriter writer = XmlWriter.Create(sww))
            //    {
            //        xsSubmit.Serialize(writer, subReq);

            //        xml = sww.ToString(); // Your XML
            //    }
            //}

            //using (var wb = new WebClient())
            //{
                
            //    var responseVal = wb.UploadString("https://api.gatewayedi.com/v2/CORE_CAQH/soap", xml);
            //    int count = responseVal.IndexOf("<soap:Envelope");
            //    string lastword = "</soap:Envelope>";
            //    int count1 = responseVal.IndexOf(lastword) + lastword.Length;
            //    string resonseMessage = responseVal.Substring(count, count1 - count);

            //    var serializer = new XmlSerializer(typeof(PractiZing.BusinessLogic.ChargePaymentService.Response.Envelope));
            //    PractiZing.BusinessLogic.ChargePaymentService.Response.Envelope result;

            //    using (TextReader reader = new StringReader(resonseMessage))
            //    {
            //        result = (PractiZing.BusinessLogic.ChargePaymentService.Response.Envelope)serializer.Deserialize(reader);
            //    }

            //    Output271 output271 = new Output271();
            //    output271.Transaction270 = coreenvelopeRealTimeRequest.Payload;

            //    if (result.Body.COREEnvelopeRealTimeResponse.Payload.Contains("ST*277"))
            //    {
            //        //output271 = await Process271FilesExcel(result.Body.COREEnvelopeRealTimeResponse.Payload);
            //        output271.Status = result.Body.COREEnvelopeRealTimeResponse.ErrorCode;

            //    }
            //    else if (result.Body.COREEnvelopeRealTimeResponse.Payload.Contains("ST*999"))
            //    {
            //        output271.Status = result.Body.COREEnvelopeRealTimeResponse.ErrorCode;
            //        output271.ErrorMessage = result.Body.COREEnvelopeRealTimeResponse.ErrorMessage;
            //        output271.Transaction999 = result.Body.COREEnvelopeRealTimeResponse.Payload;

            //        //string str999 = result.Body.COREEnvelopeRealTimeResponse.Payload;
            //        //Stream stream999 = EDIHelpers.GenerateStreamFromString(str999);
            //        //List<IEdiItem> ediItems;
            //        //using (var ediReader = new X12Reader(stream999, TypeFactory999))
            //        //    ediItems = ediReader.ReadToEnd().ToList();
            //        //var ack999 = ediItems.OfType<TS999>();
            //    }

                

            //}
            
        }

        private class Output271
        {
            public string Transaction270 { get; set; }
            public string Status { get; set; }
            public string ErrorMessage { get; set; }
            public string Transaction999 { get; set; }


        }



        //private COREEnvelopeRealTimeRequest CoreEnvelopeRealTimeRequestFactory(IClearingHouse clearingHouse,string payload)
        //{
        //    return new COREEnvelopeRealTimeRequest
        //    {

        //        PayloadType = "X12_276_Request_005010X212",
        //        ProcessingMode = "RealTime",
        //        PayloadID = Guid.NewGuid().ToString(),
        //        TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
        //        SenderID = clearingHouse.SENDER_ID,
        //        ReceiverID = clearingHouse.RECVR_ID,
        //        CORERuleVersion = "2.2.0",
        //        Payload = payload
        //    };
        //}

        public async Task<string> SaveSFTPFile(string fileX12, IClearingHouse clearingHouse, IEnumerable<IClaim> claims, Guid batchUID)
        {
            try
            {
                SftpService sftpService = GetSftpService(clearingHouse);
                var practice = await _practiceRepository.Get(clearingHouse.PracticeId);
                string fileName = practice.PracticeCodeCLM + $"{(long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds}";

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _relativePath, clearingHouse.FolderName);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                string path = Path.Combine(filePath, "" + fileName + clearingHouse.ClaimExtension);

                var bytes = Encoding.UTF8.GetBytes(fileX12);

                using (FileStream writer = new FileStream(path, FileMode.Create))
                {
                    writer.Write(bytes, 0, bytes.Length);
                }

                await this._claimBatchRepository.UpdateFilePath(batchUID, $"{_relativePath}/{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}");

                await sftpService.UploadAsync(fileName, sftpService.claimExtension, Encoding.UTF8.GetBytes(fileX12));
                return $"{clearingHouse.FolderName}/{fileName + clearingHouse.ClaimExtension}";

            }
            catch
            {
                claims.ToList().ForEach((item) =>
                {
                    item.SentDate = null;
                    item.Status = "CREATED";
                });

                await this._claimRepository.UpdateEntity(claims);

                await _practiceRepository.ThrowPermissionDeniedError();
                throw;
            }
        }


        private static SftpService GetSftpService(IClearingHouse clearingHouse)
        {
            return new SftpService(clearingHouse.Host, clearingHouse.HostPort.Value,
                clearingHouse.UserName, clearingHouse.Password,
                clearingHouse.ClaimDirectory, clearingHouse.ClaimExtension,
                clearingHouse.ERADirectory, clearingHouse.ERAExtension, clearingHouse.AckDirectory,
                clearingHouse.AckExtension,clearingHouse.StatementDirectory,clearingHouse.StatementExtension);
        }

        //private ISubmitterContacts GetContactInfo()
        //{
        //    var sub = new SubmitterContacts();
        //    sub.Phone = this._configuration["phoneNumber"];
        //    sub.Fax = this._configuration["Fax"];
        //    sub.Email = this._configuration["Email"];
        //    sub.Extension = this._configuration["Extension"];
        //    return sub;
        //}

        public PracticeConfig GetSenderConfig(string senderId)
        {
            PracticeConfig practiceConfig = new PracticeConfig();
            practiceConfig.Code = senderId;
            practiceConfig.Name = _senderName;
            practiceConfig.Contact = new PracticeContact();
            practiceConfig.Contact.Phone = this._configuration["phoneNumber"];
            practiceConfig.Contact.Fax = this._configuration["Fax"];
            practiceConfig.Contact.Email = this._configuration["Email"];
            practiceConfig.Contact.Extension = this._configuration["Extension"];

            return practiceConfig;
        }

        private List<string> GetEMCodes()
        {
            List<string> strList = new List<string>();
            var item = this._appSettingRepository.GetAppSettingEMCodes().Result;

            if(item!=null && !string.IsNullOrWhiteSpace(item.SettingValue))
            {
                string[] codes = item.SettingValue.Split(",");                
                foreach (var str in codes)
                {
                    strList.Add(str);
                }
            }

            return strList;
        }


        private ClaimOptions GetClaimOptions(IClearingHouse clearingHouse)
        {
            ClaimOptions options = new ClaimOptions();
            options.ClearingHouse = clearingHouse;
            options.PracticeConfig = GetSenderConfig(clearingHouse.SENDER_ID);
            options.TransactionDate = DateTime.Now;
            options.CptCodes = GetEMCodes();
            return options;
        }

       

        public async Task<int> UpdateClaimAfterNotifyRevdx(long id)
        {
            return await this._claimRepository.UpdateClaimAfterNotifyRevdx(id);
        }


        

        
    }
}
