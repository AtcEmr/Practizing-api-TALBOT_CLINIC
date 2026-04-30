using Newtonsoft.Json;
using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.DataAccess.ReportService;
using PractiZing.DataAccess.Common;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Enums.ReportService;
using Microsoft.Extensions.Logging;
using PractiZing.DataAccess.MasterServcie.Objects;
using PractiZing.DataAccess.ReportService.DTO;
using PractiZing.Base.Service.PatientService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Object.MasterServcie;
using System.Net.Http;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class ReportRepository<TReport, TReportDataDTO> : ModuleBaseRepository<TReport>, IReportRepository
           where TReport : class, IReport, new()
           where TReportDataDTO : class, IReportDataDTO, new()
    {

        private ILogger _logger;
        private readonly IStatementFileService _statementFileService;
        private readonly IPaymentChargeRepository _paymentChargeRepository;
        private readonly IPaymentAdjustmentRepository _paymentAdjustmentRepository;        
        public ReportRepository(IPaymentChargeRepository paymentChargeRepository,
                                    IPaymentAdjustmentRepository paymentAdjustmentRepository, ValidationErrorCodes errorCodes,
                                 DataBaseContext dbContext,
                                 ILoginUser loggedUser,
                                 IStatementFileService statementFileService,
                                 ILogger<ReportRepository<TReport, TReportDataDTO>> logger) : base(errorCodes, dbContext, loggedUser)
        {
            this._logger = logger;
            this._statementFileService = statementFileService;
            this._paymentAdjustmentRepository = paymentAdjustmentRepository;
            this._paymentChargeRepository = paymentChargeRepository;            
        }

        public async Task<IEnumerable<IReport>> GetAll()
        {
            return await this.Connection.SelectAsync<TReport>(i => i.ReportTypeId == (int)ReportType.RDLCReport && i.IsActive == true);
        }

        public async Task<IReport> GetPatientStatement()
        {
            return await this.Connection.SingleAsync<TReport>(i => i.ReportTypeId == (int)ReportType.PatientStatement && i.IsActive == true);
        }

        public async Task<IReport> GetById(long id)
        {
            var result = await this.Connection.SingleAsync<TReport>(i => i.ID == id && i.IsActive == true);
            return result;
        }

        /// <summary>
        /// This method is used to get report and their sub report data and post into a list and return Serialize form of that list.
        /// </summary>
        /// <param name="reportId"></param>
        /// <param name="parameterObject"></param>
        /// <returns>string</returns>
        public async Task<string> GenerateReportData(int reportId, object parameterObject)
        {
            try
            {
                this._logger.LogInformation(" reportId --" + reportId);
                var parentData = await this.GetById(reportId);
                this._logger.LogInformation(" parentData --" + parentData);
                // this allReportsData contains reportname as key and report data list as value
                var allReportsData = new Dictionary<string, IReportDataDTO>();

                var parentDataList = SerializeToDictionary(parentData.Command, parameterObject);
                this._logger.LogInformation(" parentDataList --" + parentDataList);
                allReportsData.Add(parentData.ReportName, parentDataList);

                //There the data is seriallize because rest api content will support only Serialize Data
                var stringPayload = JsonConvert.SerializeObject(allReportsData);
                this._logger.LogInformation(" stringPayload --" + stringPayload);
                stringPayload = stringPayload + "!" + parentData.DataSetName;
                this._logger.LogInformation(" stringPayload --" + stringPayload);

                return stringPayload;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GeneratePatientStatement(int reportId, object parameterObject)
        {
            try
            {
                this._logger.LogInformation(" reportId --" + reportId);
                var parentData = await this.GetById(reportId);
                this._logger.LogInformation(" parentData --" + parentData);
                // this allReportsData contains reportname as key and report data list as value
                var allReportsData = new Dictionary<string, IReportDataDTO>();

                var parentDataList = SerializeToDictionaryStatement(parentData.Command, parameterObject);
                this._logger.LogInformation(" parentDataList --" + parentDataList);
                allReportsData.Add(parentData.ReportName, parentDataList);

                //There the data is seriallize because rest api content will support only Serialize Data
                var stringPayload = JsonConvert.SerializeObject(allReportsData);
                this._logger.LogInformation(" stringPayload --" + stringPayload);
                stringPayload = stringPayload + "!" + parentData.DataSetName;
                this._logger.LogInformation(" stringPayload --" + stringPayload);

                return stringPayload;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Throw this method we are going to get data for report.In that we first parse paramater for report's query and then post into a list
        /// </summary>
        /// <param name="command"></param>
        /// <param name="parameterObject"></param>
        /// <returns>List<Dictionary<string, object>> </returns>
        public IReportDataDTO SerializeToDictionary(string command, object parameterObject)
        {
            try
            {
                List<List<Dictionary<string, object>>> newKeyValuePairs = new List<List<Dictionary<string, object>>>();
                List<Dictionary<string, string>> newscheaList = new List<Dictionary<string, string>>();
                this._logger.LogInformation("parameterObject -- " + parameterObject);
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);

                if (parameterData.Rows[0].ItemArray[2].ToString() != "1")
                {
                    if (parameterData.Columns[6].ColumnName.ToLower() == "providerid" && parameterData.Rows[0].ItemArray[6] == "")
                        command = command.Replace(",{providerID}", "");
                }
                    

                //parsing the parameters for the report's query
                var queryString = ParseParameter.ParseReport(command, parameterData.Rows[0]);
                //if (parameterData.Rows[0].ItemArray[2].ToString() != "1" && parameterData.Rows[0].ItemArray[2].ToString() != "41")
                //{
                //    if ((command.ToLower().Contains("providerid") == true && parameterData.Rows[0].ItemArray[6].ToString().ToLower() == "") || (command.ToLower().Contains("cptcodes") == true && parameterData.Rows[0].ItemArray[10].ToString().ToLower() == "")
                //     || (command.ToLower().Contains("reasoncodes") == true && parameterData.Rows[0].ItemArray[4].ToString().ToLower() == ""))
                //        queryString = queryString.Replace(",'null'", "");
                //    else if ((command.ToLower().Contains("insurancecompanyid") == true && parameterData.Rows[0].ItemArray[9].ToString().ToLower() == ""))
                //        queryString = queryString.Replace("'null'", "").Replace(",", " ");
                //}
                queryString = queryString.Replace("'null'", "null");



                this._logger.LogInformation("queryString -- " + queryString);

                var dataList = new List<Dictionary<string, object>>();
                var scheaList = new Dictionary<string, string>();
                var schema = new DataTable();

                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                this._logger.LogInformation("con -- " + con);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = queryString;
                con.Open();
                var data = this.ExecuteDataSet(cmd);
                this._logger.LogInformation("data -- " + data);
                for (int i = 0; i < data.Tables.Count; i++)
                {
                    DataTableReader reader = data.Tables[i].CreateDataReader();
                    var schemaTable = reader.GetSchemaTable();
                    scheaList = new Dictionary<string, string>();
                    dataList = new List<Dictionary<string, object>>();

                    foreach (DataRow item in schemaTable.Rows)
                    {
                        scheaList.Add(item["ColumnName"].ToString(), item["DataType"].ToString());
                    }

                    if (reader == null)
                    {
                        throw new Exception("Missing data source");
                    }

                    if (reader == null)
                    {
                        throw new Exception("Missing data source");
                    }

                    while (reader.Read())
                    {
                        var row = Enumerable.Range(0, reader.FieldCount)
                            .ToDictionary(reader.GetName, x =>
                            {
                                var val = reader.GetValue(x);
                                return val is System.DBNull ? string.Empty : val;
                            });
                        dataList.Add(row);
                    }

                    newscheaList.Add(scheaList);
                    newKeyValuePairs.Add(dataList);
                }

                TReportDataDTO reportDataDTO = new TReportDataDTO();
                reportDataDTO.Schema = newscheaList;
                reportDataDTO.Data = newKeyValuePairs;
                con.Close();
                this._logger.LogInformation("reportDataDTO -- " + reportDataDTO);
                return reportDataDTO;
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("ex.Message -- " + ex.Message);
                throw;
            }

        }

        public IReportDataDTO SerializeToDictionaryStatement(string command, object parameterObject)
        {
            try
            {
                List<List<Dictionary<string, object>>> newKeyValuePairs = new List<List<Dictionary<string, object>>>();
                List<Dictionary<string, string>> newscheaList = new List<Dictionary<string, string>>();
                this._logger.LogInformation("parameterObject -- " + parameterObject);
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);
                
                //parsing the parameters for the report's query
                var queryString = ParseParameter.ParseReport(command, parameterData.Rows[0]);
                queryString = queryString.Replace(",'null'", ",null");
                var dataList = new List<Dictionary<string, object>>();
                var scheaList = new Dictionary<string, string>();
                var schema = new DataTable();

                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                this._logger.LogInformation("con -- " + con);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = queryString;
                con.Open();
                var data = this.ExecuteDataSet(cmd);
                this._logger.LogInformation("data -- " + data);
                for (int i = 0; i < data.Tables.Count; i++)
                {
                    DataTableReader reader = data.Tables[i].CreateDataReader();
                    var schemaTable = reader.GetSchemaTable();
                    scheaList = new Dictionary<string, string>();
                    dataList = new List<Dictionary<string, object>>();

                    foreach (DataRow item in schemaTable.Rows)
                    {
                        scheaList.Add(item["ColumnName"].ToString(), item["DataType"].ToString());
                    }

                    if (reader == null)
                    {
                        throw new Exception("Missing data source");
                    }

                    if (reader == null)
                    {
                        throw new Exception("Missing data source");
                    }

                    while (reader.Read())
                    {
                        var row = Enumerable.Range(0, reader.FieldCount)
                            .ToDictionary(reader.GetName, x =>
                            {
                                var val = reader.GetValue(x);
                                return val is System.DBNull ? string.Empty : val;
                            });
                        dataList.Add(row);
                    }

                    newscheaList.Add(scheaList);
                    newKeyValuePairs.Add(dataList);
                }

                TReportDataDTO reportDataDTO = new TReportDataDTO();
                reportDataDTO.Schema = newscheaList;
                reportDataDTO.Data = newKeyValuePairs;
                con.Close();
                this._logger.LogInformation("reportDataDTO -- " + reportDataDTO);
                return reportDataDTO;
            }
            catch (Exception ex)
            {
                this._logger.LogInformation("ex.Message -- " + ex.Message);
                throw;
            }

        }

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            using (var sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(ds);
            }

            return ds;
        }

        public async Task<string> GeneratePatientForAutoStatement(int days)
        {
            try
            {

                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                this._logger.LogInformation("con -- " + con);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "EXEC usp_GetPatientForAutoStatment " + days;
                if (con.State == ConnectionState.Closed)
                    con.Open();
                var data = this.ExecuteDataSet(cmd);
                string result = "";
                if (data != null)
                {
                    if (data.Tables.Count > 0)
                        if (data.Tables[0].Rows.Count > 0)
                            result = data.Tables[0].Rows[0][0].ToString();
                }

                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GeneratePatientStatementXML(int reportId, object parameterObject, string xmlFilePath)
        {
            try
            {
                this._logger.LogInformation(" reportId --" + reportId);
                var parentData = await this.GetById(reportId);
                this._logger.LogInformation(" parentData --" + parentData);

                this._logger.LogInformation("parameterObject -- " + parameterObject);
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);

                parentData.Command = "exec rpt_PatientChargeStatementXML {patientId},{toDate},{Message}";

                //parsing the parameters for the report's query
                var queryString = ParseParameter.ParseReport(parentData.Command, parameterData.Rows[0]);
                queryString = queryString.Replace(",'null'", null);
                var dataList = new List<Dictionary<string, object>>();
                var scheaList = new Dictionary<string, string>();
                var schema = new DataTable();

                SqlConnection con = new SqlConnection(this.Connection.ConnectionString);
                this._logger.LogInformation("con -- " + con);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = queryString;
                if (con.State == ConnectionState.Closed)
                    con.Open();

                var data = this.ExecuteDataSet(cmd);

                var deserializeData = JsonConvert.DeserializeObject<PatientStatementParameterDTO>(parameterObject.ToString());

                string[] patientIds = deserializeData.PatientId.Split(",");
                Dictionary<int, object> xmlFilePathList = new Dictionary<int, object>();
                foreach (var item in patientIds)
                {
                    data.Tables[0].DefaultView.RowFilter = "PatientId = " + item;
                    DataTable dt = (data.Tables[0].DefaultView).ToTable();
                    if (dt.Rows.Count > 0)
                    {
                        var patientChargeStatementDTO = await GetPatientChargesStatement(dt);
                        string reportName = (item + "-" + parentData.ReportName);
                        var filePath = xmlFilePath + "\\" + reportName + ".xml";
                        this._statementFileService.GetXmlFile(patientChargeStatementDTO, filePath);
                        xmlFilePathList.Add(Convert.ToInt32(item), filePath);
                    }
                }

                //There the data is seriallize because rest api content will support only Serialize Data
                var stringPayload = JsonConvert.SerializeObject(xmlFilePathList);
                this._logger.LogInformation(" stringPayload --" + stringPayload);
                return stringPayload;
            }
            catch
            {
                throw;
            }
        }

        public async Task<PatientChargeStatementDTO> GetPatientChargesStatement(DataTable data)
        {
            PatientChargeStatementDTO patientChargeStatementDTO = new PatientChargeStatementDTO();
            patientChargeStatementDTO.ChargePayments = new List<IPatientChargePaymentDTO>();
            if (data.Rows.Count > 0)
            {
                DataRow row = data.Rows[0];

                patientChargeStatementDTO.FacilityName = row["Name"].ToString();
                patientChargeStatementDTO.FacilityAddress1 = row["FacilityAddress1"].ToString();
                patientChargeStatementDTO.FacilityAddress2 = row["FacilityAddress2"].ToString();
                patientChargeStatementDTO.FacilityCity = row["FacilityCity"].ToString();
                patientChargeStatementDTO.FacilityState = row["FacilityState"].ToString();
                patientChargeStatementDTO.FacilityZipCode = row["FacilityZipCode"].ToString();
                patientChargeStatementDTO.FacilityPhone = row["Phone"].ToString();
                patientChargeStatementDTO.FirstName = row["FirstName"].ToString();
                patientChargeStatementDTO.MiddleName = row["MiddleName"].ToString();
                patientChargeStatementDTO.LastName = row["LastName"].ToString();
                patientChargeStatementDTO.BillAddress1 = row["BillAddress1"].ToString();
                patientChargeStatementDTO.BillAddress2 = row["BillAddress2"].ToString();
                patientChargeStatementDTO.BillCity = row["BillCity"].ToString();
                patientChargeStatementDTO.BillState = row["BillState"].ToString();
                patientChargeStatementDTO.BillZip = row["BillZip"].ToString();

                patientChargeStatementDTO.GuarantorFirstName = row["GuarantorFirstName"].ToString();
                patientChargeStatementDTO.GuarantorMiddleName = "";
                patientChargeStatementDTO.GuarantorLastName = row["GuarantorLastName"].ToString();
                patientChargeStatementDTO.GuarantorAddress1 = row["GuarantorAddress1"].ToString();
                patientChargeStatementDTO.GuarantorAddress2 = row["GuarantorAddress2"].ToString();
                patientChargeStatementDTO.GuarantorCity = row["GuarantorCity"].ToString();
                patientChargeStatementDTO.GuarantorState = row["GuarantorState"].ToString();
                patientChargeStatementDTO.GuarantorZip = row["GuarantorZip"].ToString();

                patientChargeStatementDTO.PatientId = Convert.ToInt32(row["PatientId"].ToString());
                patientChargeStatementDTO.StatementDate = DateTime.Now;
                patientChargeStatementDTO.DueDate = DateTime.Now.AddDays(15);

                patientChargeStatementDTO.RemitAddress1 = row["RemitAddress1"].ToString();
                patientChargeStatementDTO.RemitAddress2 = row["RemitAddress2"].ToString();
                patientChargeStatementDTO.RemitCity = row["RemitCity"].ToString();
                patientChargeStatementDTO.RemitState = row["RemitState"].ToString();
                patientChargeStatementDTO.RemitZipCode = row["RemitZipCode"].ToString();
                patientChargeStatementDTO.RemitPhone = row["RemitPhone"].ToString();

                patientChargeStatementDTO.StatementMessage = row["Message"].ToString();
                patientChargeStatementDTO.DunningMessage = row["DunningMessage"].ToString();
                patientChargeStatementDTO.PayByWeb = row["PayByWeb"].ToString();
                patientChargeStatementDTO.PayByPhoneNumber = row["PayByPhoneNumber"].ToString();
                patientChargeStatementDTO.Note = row["Note"].ToString();

                decimal totalDueAmount = 0;
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    PatientChargePaymentDTO patientChargePaymentDTO = new PatientChargePaymentDTO();
                    patientChargePaymentDTO.IsCharge = true;
                    patientChargePaymentDTO.ChargeId = Convert.ToInt32(data.Rows[i]["ChargeId"].ToString());
                    patientChargePaymentDTO.DOS = Convert.ToDateTime(data.Rows[i]["DOS"]); // charge dos

                    DateTime? shiftDate = null;
                    if (!string.IsNullOrWhiteSpace(data.Rows[i]["ShiftDate"].ToString()))
                    {
                        shiftDate = Convert.ToDateTime(data.Rows[i]["ShiftDate"]); // charge dos
                    }

                    patientChargePaymentDTO.CreatedDate = Convert.ToDateTime(data.Rows[i]["DOS"]); // here passing charge date of service in item.CreatedDate;
                    patientChargePaymentDTO.CPTCode = data.Rows[i]["CPTCode"].ToString();
                    patientChargePaymentDTO.Description = data.Rows[i]["Description"].ToString();
                    patientChargePaymentDTO.ChargeAmount = Convert.ToDecimal(data.Rows[i]["Amount"].ToString());
                    patientChargePaymentDTO.DueAmount = Convert.ToDecimal(data.Rows[i]["DueAmount"].ToString());
                    patientChargeStatementDTO.ChargePayments.Add(patientChargePaymentDTO);

                    // payments    
                    int[] ids = { patientChargePaymentDTO.ChargeId };
                    var paymentCharges = await this._paymentChargeRepository.GetByChargeIds(ids);

                    foreach (var item in paymentCharges)
                    {
                        PatientChargePaymentDTO payment = new PatientChargePaymentDTO();
                        payment.IsPayment = true;
                        payment.ChargeId = patientChargePaymentDTO.ChargeId;
                        payment.PaidAmount = Convert.ToDecimal(item.PaidAmount.ToString("0.00"));
                        payment.CreatedDate = item.ModifiedDate.GetValueOrDefault(); // It's CreatedDate of payment charge;
                        patientChargeStatementDTO.ChargePayments.Add(payment);
                    }

                    // adjustments
                    int[] adjIds = paymentCharges.Select(k => k.Id).ToArray();
                    var paymentAdjustments = await this._paymentAdjustmentRepository.GetByPaymentChargeId(adjIds);
                    paymentAdjustments = paymentAdjustments.Where(k => k.IsAccounted == true && k.IsDenial == false);

                    foreach (var item in paymentAdjustments)
                    {
                        PatientChargePaymentDTO adjustment = new PatientChargePaymentDTO();
                        adjustment.IsPayment = false;
                        adjustment.ChargeId = patientChargePaymentDTO.ChargeId;
                        adjustment.AdjustmentAmount = Convert.ToDecimal(item.Amount.ToString("0.00"));
                        adjustment.CreatedDate = item.CreatedDate;
                        adjustment.AdjustmentReasonCode = item.ReasonCode;
                        patientChargeStatementDTO.ChargePayments.Add(adjustment);
                    }

                    // aging balances start                 

                    double dayDiff = DateTime.Now.Date.Subtract(shiftDate.HasValue ? shiftDate.Value : patientChargePaymentDTO.DOS.Date).Days;
                    if (dayDiff <= 29)
                    {
                        patientChargeStatementDTO.Current += patientChargePaymentDTO.DueAmount;
                    }

                    if (dayDiff >= 30 && dayDiff <= 59)
                    {
                        patientChargeStatementDTO.Over30Days += patientChargePaymentDTO.DueAmount;
                    }

                    if (dayDiff >= 60 && dayDiff <= 89)
                    {
                        patientChargeStatementDTO.Over60Days += patientChargePaymentDTO.DueAmount;
                    }

                    if (dayDiff >= 90 && dayDiff <= 119)
                    {
                        patientChargeStatementDTO.Over90Days += patientChargePaymentDTO.DueAmount;
                    }

                    if (dayDiff >= 120 && dayDiff <= 999999999999)
                    {
                        patientChargeStatementDTO.Over120Days += patientChargePaymentDTO.DueAmount;
                    }

                    // aging balances end

                    totalDueAmount += patientChargePaymentDTO.DueAmount;
                }

                patientChargeStatementDTO.TotalDueAmount = totalDueAmount;
            }

            return patientChargeStatementDTO;
        }

        public async Task<dynamic> usp_GetPatientAgingBalances_BatchStatement(string uid)
        {
            try
            {
                string query = "usp_GetPatientAgingBalances_BatchStatement '" + uid + "'";
                var result = await base.ExecuteStoredProcedureAsync<dynamic>(query);
                return result;

            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetBillingToken(string url)
        {
            var restApiRequestUrl = url + "api/Login";
            var content = new StringContent("{\"userName\":\"hl7\",\"password\":\"admin\"}", Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(10, 1, 1);
            // sending request on login api
            HttpResponseMessage response = await client.PostAsync(restApiRequestUrl, content);

            string responseString = null;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                // if response is successful then get access token
                responseString = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter().GetResult();
                var convert = JObject.Parse(responseString);
                return convert["AccessToken"].ToString();
            }
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new Exception(response.Content.ReadAsStringAsync().Result);
            }

            return string.Empty;
        }
    }
}
