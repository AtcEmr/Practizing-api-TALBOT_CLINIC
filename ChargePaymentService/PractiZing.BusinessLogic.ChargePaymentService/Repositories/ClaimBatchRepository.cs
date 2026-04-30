using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PractiZing.Base.Entities.BatchPaymentService;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Enums.ChargePaymentEnums;
using PractiZing.Base.Enums.ERAService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.BatchPaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.ChargePaymentService.View;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using RestSharp;
using ServiceStack;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.BatchPaymentService.Repositories
{
    public class ClaimBatchRepository : ModuleBaseRepository<ClaimBatch>, IClaimBatchRepository
    {
        private string _relativePath;
        private string _baseUrl;
        private readonly IClaimRepository _claimRepository;
        private readonly IPatientCaseRepository _patientCaseRepository;
        private readonly IScrubRepository _scrubRepository;
        private readonly IScrubCodingRepository _scrubCodingRepository;
        private readonly IScrubErrorRepository _scrubErrorRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly IClearingHouseRepository _clearingHouseRepository;
        List<ClaimBatch> _tempClaimBatches = new List<ClaimBatch>();
        private string _connectionString;
        private string scrubURL;
        private string _filePath;
        private ILogger _logger;

        public ClaimBatchRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            IClaimRepository claimRepository,
                                            IPatientCaseRepository patientCaseRepository,
                                            IScrubRepository scrubRepository,
                                            IScrubCodingRepository scrubCodingRepository,
                                            IScrubErrorRepository scrubErrorRepository,
                                            IConfiguration configuration,
                                            IFacilityRepository facilityRepository,
                                            IProviderRepository providerRepository,
                                            ILogger<ClaimBatchRepository> logger,
                                            IPracticeRepository practiceRepository,
                                            IClearingHouseRepository clearingHouseRepository
                                            ) : base(errorCodes, dbContext, loggedUser)
        {
            _baseUrl = configuration["ApplicationUrl"];
            _filePath = configuration["ApiPath"];
            _relativePath = configuration["AttachmentFolder"];
            _connectionString = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            scrubURL = configuration["ScrubServiceURL"];
            _claimRepository = claimRepository;
            this._clearingHouseRepository = clearingHouseRepository;
            _patientCaseRepository = patientCaseRepository;
            _scrubCodingRepository = scrubCodingRepository;
            _scrubRepository = scrubRepository;
            _facilityRepository = facilityRepository;
            _providerRepository = providerRepository;
            _scrubErrorRepository = scrubErrorRepository;
            _practiceRepository = practiceRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<IClaimBatch>> Get(IClaimFilter claimFilter, bool isFilterWork = false)
        {
            List<ClaimBatch> claimBatches = new List<ClaimBatch>();

            if (isFilterWork)
            {
                //claimBatches = await this.Connection.SelectAsync<ClaimBatch>(i => i.ModifiedDate >= claimFilter.FromDate.Date
                //                               && i.ModifiedDate <= claimFilter.ToDate.Date && i.PracticeId == LoggedUser.PracticeId && i.ClearingHouseId == claimFilter.ClearingHouseId);
                claimBatches = await this.Connection.SelectAsync<ClaimBatch>(
    i => i.DateMade >= claimFilter.FromDate.Date
         && i.DateMade < claimFilter.ToDate.Date.AddDays(1)
         && i.PracticeId == LoggedUser.PracticeId
         && i.ClearingHouseId == claimFilter.ClearingHouseId);
            }
            else
            {
                claimBatches = await this.Connection.SelectAsync<ClaimBatch>(i => i.PracticeId == LoggedUser.PracticeId && i.ClearingHouseId == claimFilter.ClearingHouseId);
            }

            foreach (var item in claimBatches)
            {
                if (item.FilePath != null)
                {
                    item.FullFilePath = JsonConvert.SerializeObject($"{_baseUrl}/{item.FilePath}");
                    //string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/{item.FilePath}";
                    //item.FullFileText = File.ReadAllText(filePath);
                }
            }
            return claimBatches;
        }

        public async Task<IClaimBatchTabsCount> GetClaimBatches(IClaimFilter claimFilter)
        {
            try
            {
                List<ClaimBatch> _claimBatches = new List<ClaimBatch>();
                List<ClaimBatch> _claimBatch = (await this.Get(claimFilter, true)) as List<ClaimBatch>;
                List<Claim> _claims = new List<Claim>();
                ClaimBatch _unBatchClaim = new ClaimBatch();
                ClaimBatchTabsCount batchTabsCount = new ClaimBatchTabsCount();

                var result = await this._claimRepository.GetClaims(claimFilter);
                batchTabsCount = await this.GetClaimCount(result.ToList());
                IEnumerable<int> claimIds = result.Select(i => i.Id);

                List<List<int>> tempClaimIds = new List<List<int>>();

                if (claimIds.Count() > 0)
                {
                    //Chunks a collection into smaller lists of a specified size.
                    tempClaimIds = CollectionChunksHelper.Chunk(claimIds, 2000);
                }

                List<ScrubError> resultScrubErrors = new List<ScrubError>();

                foreach (var item in tempClaimIds)
                {
                    claimIds = item;
                    var tempResultScrubErrors = await this._scrubErrorRepository.GetByClaimId(claimIds) as List<ScrubError>;
                    resultScrubErrors.AddRange(tempResultScrubErrors);
                }                

                result.ToList().ForEach((res) =>
                {
                    res.ScrubErrors = resultScrubErrors.Where(i => i.ClaimId == res.Id);
                });

                switch (claimFilter.SelectedType)
                {
                    case (int)ChargeBatchFilterEnum.Batched:
                        foreach (var item in result)
                            _claimBatches.AddRange((_claimBatch.Where(i => i.Id == item.ClaimBatchId && i.ClearingHouseId != 2)).ToList());
                        _claimBatches = _claimBatches.Distinct().ToList();
                        foreach (var item in _claimBatches)
                            item.Claims = result.Where(i => i.ClaimBatchId == item.Id);
                        break;

                    case (int)ChargeBatchFilterEnum.UnBatched:
                        _unBatchClaim.Claims = result.Where(i => i.ClaimBatchId == null && ((string.IsNullOrEmpty(i.HoldBy) && string.IsNullOrEmpty(i.ReleaseBy))
                                                                                        || (!string.IsNullOrEmpty(i.HoldBy) && !string.IsNullOrEmpty(i.ReleaseBy))) && i.ClearingHouseId != 2);
                        _unBatchClaim.Claims.OrderBy(i => i.Id);
                        if (_unBatchClaim.Claims.Count() > 0)
                            _claimBatches.Add(_unBatchClaim);
                        break;

                    case (int)ChargeBatchFilterEnum.Sent:
                        _claimBatches.AddRange((_claimBatch.Where(i => i.BatchStatus == 2)).ToList());
                        foreach (var item in _claimBatches)
                            item.Claims = result.Where(i => i.ClaimBatchId == item.Id && i.SentDate != null);


                        foreach (var item in _claimBatches)
                        {
                            if (item.Claims.Count() > 0)
                                _tempClaimBatches.Add(item);
                        }
                        _claimBatches = _tempClaimBatches;
                        break;

                    case (int)ChargeBatchFilterEnum.NotSent:
                        foreach (var item in result)
                            _claimBatches.AddRange((_claimBatch.Where(i => i.BatchStatus != 2)).ToList());
                        _claimBatches = _claimBatches.Distinct().ToList();
                        foreach (var item in _claimBatches)
                            item.Claims = result.Where(i => i.ClaimBatchId == item.Id && i.SentDate == null);

                        foreach (var item in _claimBatches)
                        {
                            if (item.Claims.Count() > 0)
                                _tempClaimBatches.Add(item);
                        }
                        _claimBatches = _tempClaimBatches;
                        break;

                    case (int)ChargeBatchFilterEnum.Printed:
                        foreach (var item in result)
                            _claimBatches.AddRange((_claimBatch.Where(i => i.Id == item.ClaimBatchId)).ToList());
                        _claimBatches = _claimBatches.Distinct().ToList();
                        foreach (var item in _claimBatches)
                            item.Claims = result.Where(i => i.ClaimBatchId == item.Id && (i.ShouldBePrinted == "X" || i.ClearingHouseId == 2));

                        foreach (var item in _claimBatches)
                        {
                            if (item.Claims.Count() > 0)
                                _tempClaimBatches.Add(item);
                        }
                        _claimBatches = _tempClaimBatches;
                        break;

                    case (int)ChargeBatchFilterEnum.NotPrinted:
                        foreach (var item in result)
                            _claimBatches.AddRange((_claimBatch.Where(i => i.Id == item.ClaimBatchId)).ToList());
                        _claimBatches = _claimBatches.Distinct().ToList();
                        foreach (var item in _claimBatches)
                            item.Claims = result.Where(i => i.ClaimBatchId == item.Id && i.ShouldBePrinted == "P");

                        foreach (var item in _claimBatches)
                        {
                            if (item.Claims.Count() > 0)
                                _tempClaimBatches.Add(item);
                        }
                        _claimBatches = _tempClaimBatches;
                        break;

                    case (int)ChargeBatchFilterEnum.OnHold:
                        _unBatchClaim.Claims = result.Where(i => i.ClaimBatchId == null && !string.IsNullOrEmpty(i.HoldBy) && string.IsNullOrEmpty(i.ReleaseBy));
                        if (_unBatchClaim.Claims.Count() > 0)
                            _claimBatches.Add(_unBatchClaim);
                        break;

                    default:
                        _claimBatches = null;
                        break;
                }

                _claimBatches = _claimBatches.Distinct().OrderBy(i => i.Id).ToList();
                batchTabsCount.ClaimBatches = _claimBatches;

                ClaimBatchFilter claimBatchFilter = new ClaimBatchFilter();
                if (claimFilter != null)
                {
                    claimBatchFilter.FromDate = Convert.ToDateTime(claimFilter.FromDate).ToString("yyyy-MM-dd 00:00:00");
                    claimBatchFilter.ToDate = Convert.ToDateTime(claimFilter.ToDate).ToString("yyyy-MM-dd 23:59:59");
                }
                var charges = await this.GetCharges(claimBatchFilter, claimFilter.ClearingHouseId);
                var queryResult = await this.Connection.SelectAsync<dynamic>(charges);
                var resultCharges = (Mapper<Charges>.MapList(queryResult)).ToList();
                if (resultCharges != null)
                {
                    batchTabsCount.ChargeCount = resultCharges.Where(i => i.ClaimId != null && i.ClaimBatchId != null && i.ScrubError == false).Count();
                    batchTabsCount.SentChargeCount = resultCharges.Where(i => i.ClaimId != null && i.SentDate != null && i.ScrubError == false).Count();
                }
                    

                return batchTabsCount;
            }
            catch
            {
                throw;
            }
        }

        private async Task<ClaimBatchTabsCount> GetClaimCount(List<IClaim> claims)
        {
            ClaimBatchTabsCount count = new ClaimBatchTabsCount();

            count.BatchedCount = claims.Count(i => i.ClaimBatchId != null && i.ClearingHouseId != 2);
            count.UnBatchedCount = claims.Count(i => i.ClaimBatchId == null && ((i.HoldBy == null && i.ReleaseBy == null) || (i.HoldBy != null && i.ReleaseBy != null)) && i.ClearingHouseId != 2);
            count.SentCount = claims.Count(i => i.ClaimBatchId != null && i.SentDate != null);
            count.NotSentCount = claims.Count(i => i.ClaimBatchId != null && i.SentDate == null);
            count.PrintedCount = claims.Count(i => i.ClaimBatchId != null && i.ShouldBePrinted == "X");
            count.NotPrintedCount = claims.Count(i => i.ClaimBatchId != null && i.ShouldBePrinted == "P" && i.ClearingHouseId == 2);
            count.OnHoldCount = claims.Count(i => i.ClaimBatchId == null && i.HoldBy != null && i.ReleaseBy == null);

            return count;
        }

        private async Task<SqlExpression<ChargeViewDTO>> GetCharges(IClaimBatchFilter filter, int clearingHouseId = 1)
        {
            var query = this.Connection.From<ChargeViewDTO>()    
                         .LeftJoin<ChargeViewDTO, Claim>((i, cl) => i.ClaimId == cl.Id, NoLockTableHint.NoLock)
                         .SelectDistinct<ChargeViewDTO,Claim>((c,  cl) => new
                         {   
                             c.InvoiceId,
                             c.ClaimId,
                             cl.SentDate,
                             c.ScrubError,
                             cl.ClaimBatchId
                         })
                         .Where(c => c.PracticeId == LoggedUser.PracticeId && c.IsDeleted == false).OrderBy(x => x.InvoiceId);


            //query.SelectExpression = query.SelectExpression.Replace("SELECT", "");

            query.Where<Claim>(i => i.ClearingHouseId == clearingHouseId);

            string whereExpression = await WhereClauseProvider<IClaimBatchFilter>.GetWhereClause(filter);
            query.WhereExpression = query.WhereExpression + " AND " + whereExpression;
            return query;
        }

        public async Task<IEnumerable<IClaimBatch>> Get(List<int> ids)
        {
            var result = await this.Connection.SelectAsync<ClaimBatch>(i => ids.Contains(i.Id) && i.PracticeId == LoggedUser.PracticeId);
            foreach (var item in result)
            {
                if (item.FilePath != null)
                    item.FullFilePath = JsonConvert.SerializeObject($"{_baseUrl}/{_relativePath}/{item.FilePath}");
            }
            return result;
        }

        public async Task<IClaimBatch> AddNew(IClaimBatch entity)
        {
            try
            {
                ClaimBatch tEntity = entity as ClaimBatch;
                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var clearingHouse = await this._clearingHouseRepository.GetById(tEntity.ClearingHouseId.Value);
                if (clearingHouse != null)
                {
                    if (clearingHouse.Name == "OHIOMEDICAID")
                    {
                        tEntity.ClaimBatchNumber = clearingHouse.ClaimBatchNumber.ToString();
                    }
                    else if (clearingHouse.Name == "STEDI")
                    {
                        tEntity.ClaimBatchNumber = clearingHouse.ClaimBatchNumber.ToString();
                    }
                    else
                    {
                        tEntity.ClaimBatchNumber = "C" + clearingHouse.ClaimBatchNumber;
                    }

                    clearingHouse.ClaimBatchNumber = clearingHouse.ClaimBatchNumber + 1;
                    await this._clearingHouseRepository.UpdateClaimBatchTransactionNumber(clearingHouse);
                }

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaimBatch>> AddNew(IEnumerable<IClaimBatch> claims)
        {
            try
            {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                List<ClaimBatch> newRecords = new List<ClaimBatch>();
                foreach (var item in claims)
                {
                    item.DateMade = DateTime.Now;
                    item.UserName = LoggedUser.UserName;
                    var record = await this.AddNew(item);
                    ClaimBatch claimBatchRecord = record as ClaimBatch;
                    newRecords.Add(claimBatchRecord);
                }
                return newRecords;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaimBatch>> AddNew(IEnumerable<IClaimBatch> claims, int? providerId, int? insuranceCompanyId)
        {
            try
            {
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                List<ClaimBatch> newRecords = new List<ClaimBatch>();
                foreach (var item in claims)
                {
                    item.DateMade = DateTime.Now;
                    item.UserName = LoggedUser.UserName;
                    item.ProviderId = providerId;
                    item.InsuranceCompanyId = insuranceCompanyId;
                    var record = await this.AddNew(item);
                    ClaimBatch claimBatchRecord = record as ClaimBatch;
                    newRecords.Add(claimBatchRecord);
                }
                return newRecords;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Update(IClaimBatch entity)
        {
            try
            {
                ClaimBatch tEntity = entity as ClaimBatch;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                //check if error exist
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                          .From<ClaimBatch>()
                                          .Update(x => new
                                          {
                                              x.BatchStatus,
                                              x.ClaimCount,
                                              x.ClearingHouseId,
                                              x.DateMade,
                                              x.FirstSent,
                                              x.FromDate,
                                              x.LastSent,
                                              x.ModifiedBy,
                                              x.ModifiedDate,
                                              x.ScrubSent,
                                              x.ScrubStatus,
                                              x.ToDate,
                                              x.Total,
                                              x.UserName,
                                              x.FilePath
                                          })
                                          .Where(i => i.UId == entity.UId && i.PracticeId == LoggedUser.PracticeId);

                return await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaimBatchScrubDTO> GetClaimBatchDTO(string claimBatchUId)
        {
            try
            {
                var claimBatch = await this.Connection.SingleAsync<ClaimBatch>(i => i.UId == Guid.Parse(claimBatchUId));
                var claimBatchId = claimBatch == null ? 0 : claimBatch.Id;

                ClaimBatchScrubDTO claimBatchScrubDTO = new ClaimBatchScrubDTO();
                var query = this.Connection.From<ClaimBatch>()
                        .Join<ClaimBatch, Claim>((i, j) => i.Id == j.ClaimBatchId)
                        .Join<Claim, ClaimCharge>((k, l) => k.Id == l.ClaimId)
                        .Join<ClaimCharge, Charges>((m, n) => m.ChargeId == n.Id && n.IsDeleted == false)
                        .Select<ClaimBatch, Claim, ClaimCharge, Charges>((i, j, k, l) => new
                        {
                            l,
                            ClaimBatchId = i.Id,
                            ClaimId = j.Id
                        }).Where<ClaimBatch>(i => i.Id == claimBatchId);

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);

                var result = Mapper<ScrubDTO>.MapList(queryResult);
                var res = await this._scrubRepository.GetScrubs();

                claimBatchScrubDTO.ClaimScrubs = result;
                claimBatchScrubDTO.Scrubs = res;
                claimBatchScrubDTO.ClaimBatchId = claimBatchId;
                claimBatchScrubDTO.PracticeCode = LoggedUser.PracticeCode;
                return claimBatchScrubDTO;
            }
            catch
            {
                throw;
            }
        }

        //Public Dataset ExecuteDataSet(cmd As SqlCommand) As DataSet
        //    Using sda As New SqlDataAdapter(cmd)
        //        Dim ds As New DataSet
        //        sda.Fill(ds)
        //        Return ds
        //    End Using
        //End Function

        //<Extension>
        //Public Function ExecuteDataTable(cmd As SqlCommand) As DataTable
        //    Return cmd.ExecuteDataSet().Tables(0)
        //End Function

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            var sda = new SqlDataAdapter(cmd);
            var ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public async Task<IEnumerable<IScrubError>> RunAutoScrub(IEnumerable<IScrubDTO> scrub, string spName, int scrubId, string practiceCode)
        {
            try
            {
                List<ScrubDTO> tEntity = scrub as List<ScrubDTO>;
                List<ScrubError> scrubErrors = new List<ScrubError>();
                var sc = tEntity.ToList<ScrubDTO>();

                using (SqlConnection con = new SqlConnection(this.Connection.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        var tbl = ToDataTable(sc);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Charges", tbl);
                        cmd.Parameters.AddWithValue("@ScrubId", scrubId);
                        cmd.Parameters.AddWithValue("@PracticeCode", practiceCode);

                        con.Open();
                        var res = this.ExecuteDataSet(cmd);

                        scrubErrors = ConvertDataTableToList(res.Tables[0]);
                    }
                }
                return scrubErrors;
            }
            catch
            {
                throw;
            }
        }

        private async Task<bool> AddScrubErrors(IEnumerable<IScrubError> scrubErrors)
        {
            try
            {
                if (scrubErrors.Count() > 0)
                {
                    // delete claims scrub errors and then add new ones
                    var claimIds = scrubErrors.Select(i => i.ClaimId).Distinct().ToList();
                    foreach (var item in claimIds)
                    {
                        await _scrubErrorRepository.DeleteByClaimId(item);
                    }
                }

                foreach (var item in scrubErrors)
                {
                    if (item.HasError)
                        await _scrubErrorRepository.AddNew(item);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        private List<ScrubError> ConvertDataTableToList(DataTable dt)
        {

            var convertedList = (from rw in dt.AsEnumerable()
                                 select new ScrubError()
                                 {
                                     //FacilityId = Convert.ToInt32(rw["FacilityId"]),
                                     //ClinicCode = Convert.ToString(rw["ClinicCode"]),
                                     //ChargeNumber = Convert.ToInt32(rw["ChargeNumber"]),
                                     ScrubDateTime = Convert.ToDateTime(rw["ActionDate"]),
                                     //CaseNo = Convert.ToInt32(rw["CaseNo"]),
                                     //ErrorMessage = Convert.ToString(rw["Message"]),
                                     //ScrubId = Convert.ToInt32(rw["ScrubId"]),
                                     //ScrubName = Convert.ToString(rw["ScrubName"])
                                 }).ToList();

            return convertedList;
        }

        public System.Data.DataTable ToDataTable<T>(List<T> items)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public async Task<IEnumerable<IScrubError>> RunScrub(string claimUId, string claimBatchUId, string providerUId, string facilityUId)
        {
            try
            {
                var claimBatch = await this.Get(Guid.Parse(claimBatchUId));
                var claimBatchId = claimBatch == null ? 0 : claimBatch.Id;

                var claims = await this._claimRepository.GetClaims(claimBatchId);                
                var result = await this.CallScrubEngine(claims);
                
                var entity = await GetById(claimBatchId);
                var scrubErrors = await this.GetClaims(claimBatchId);

                if (scrubErrors.Count() > 0 && !string.IsNullOrEmpty(scrubErrors.FirstOrDefault().ErrorJson))
                {
                    //scrub failed
                    entity.ScrubStatus = (int)ScrubErrorEnum.Failed;
                }
                else
                {
                    //scrub success
                    entity.ScrubStatus = (int)ScrubErrorEnum.Success;
                }

                await Update(entity);

                return scrubErrors;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IScrubError>> RunScrub(int claimId)
        {
            try
            {
                var claimData = await this._claimRepository.Get(claimId);
                var result = await this.CallScrubEngine(claimData);

                List<IScrubError> scrubErrors = new List<IScrubError>();

                var scrubErrorList = await this._scrubErrorRepository.GetByClaimId(claimData.Id);
                scrubErrors.AddRange(scrubErrorList);

                if (scrubErrors.Count() > 0 && !string.IsNullOrEmpty(scrubErrors.FirstOrDefault().ErrorJson))
                {
                    //scrub failed
                    claimData.ScrubStatus = (int)ScrubErrorEnum.Failed;
                    //  entity.ScrubStatus = 1;
                }
                else
                {
                    //scrub success
                    claimData.ScrubStatus = (int)ScrubErrorEnum.Success;
                    //entity.ScrubStatus = 2;
                }

                await this._claimRepository.UpdateClaimScrubStatus(claimData);

                return scrubErrors;
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IScrubError>> CallScrubEngine(IEnumerable<IClaim> claims)
        {
            try
            {
                List<int> claimIds = new List<int>();
                if (claims.Count() > 0)
                {
                    claimIds = claims.Select(i => i.Id).ToList();
                }

                var client = new RestClient();
                client.BaseUrl = new Uri(scrubURL + "api");
                var practiceData = await this._practiceRepository.Get();
                var request = new RestRequest($"Validate/runClaimScrub?claimIds={claimIds}&practiceCentralId={practiceData.PracticeCentralId}&practiceId={LoggedUser.PracticeId}");
                //var request = new RestRequest("Validate");

                request.AddHeader("ContentType", "application/json");
                request.Method = Method.POST;
                //request.AddJsonBody(claimBatchScrubDTO);
                request.AddJsonBody(claimIds);

                var okResult = client.Execute(request);
                var response = new List<ScrubError>();

                if (okResult.StatusCode == HttpStatusCode.OK)
                {
                    response = JsonConvert.DeserializeObject<List<ScrubError>>(okResult.Content);
                    var result = response.Distinct();
                    await this.AddScrubErrors(result);
                }
                return response;
            }
            catch
            {
                throw;
            }
        }

        private async Task<IEnumerable<IScrubError>> CallScrubEngine(IClaim claim)
        {
            try
            {
                var client = new RestClient();
                client.BaseUrl = new Uri(scrubURL + "api");
                var practiceData = await this._practiceRepository.Get();
                var request = new RestRequest($"Validate/runScrub?claimId={claim.Id}&practiceCentralId={practiceData.PracticeCentralId}&practiceId={LoggedUser.PracticeId}");
                //var request = new RestRequest("Validate");

                request.AddHeader("ContentType", "application/json");
                request.Method = Method.POST;
                //request.AddJsonBody(claimBatchScrubDTO);
                request.AddJsonBody(claim.Id);

                var okResult = client.Execute(request);
                var response = new List<ScrubError>();

                if (okResult.StatusCode == HttpStatusCode.OK)
                {
                    response = JsonConvert.DeserializeObject<List<ScrubError>>(okResult.Content);
                    var result = response.Distinct();
                    await this.AddScrubErrors(result);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<IEnumerable<IScrubError>> GetClaims(int claimBatchId)
        {
            try
            {
                var result = await this._claimRepository.GetClaims(claimBatchId);
                List<IScrubError> scrubErrors = new List<IScrubError>();

                foreach (var item in result)
                {
                    var scrubErrorList = await this._scrubErrorRepository.GetByClaimId(item.Id);
                    if (scrubErrorList.Count() > 0)
                    {
                        var claimEntity = await this._claimRepository.Get(item.Id);
                        claimEntity.ScrubStatus = (int)ScrubErrorEnum.Failed;
                        await this._claimRepository.UpdateClaimScrubStatus(claimEntity);
                    }
                    else
                    {
                        var claimEntity = await this._claimRepository.Get(item.Id);
                        claimEntity.ScrubStatus = (int)ScrubErrorEnum.Success;
                        await this._claimRepository.UpdateClaimScrubStatus(claimEntity);
                    }

                    scrubErrors.AddRange(scrubErrorList);
                }

                return scrubErrors;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaimBatch> GetById(int claimBatchId)
        {
            try
            {
                var result = await this.Connection.SingleAsync<ClaimBatch>(i => i.Id == claimBatchId && i.PracticeId == LoggedUser.PracticeId);
                if (result?.FilePath != null)
                    result.FullFilePath = JsonConvert.SerializeObject($"{_baseUrl}/{_relativePath}/{result.FilePath}");
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaimBatch> Get(Guid claimBatchUId)
        {
            var result = await this.Connection.SingleAsync<ClaimBatch>(i => i.UId == claimBatchUId && i.PracticeId == LoggedUser.PracticeId);
            if (result?.FilePath != null)
                result.FullFilePath = JsonConvert.SerializeObject($"{_baseUrl}/{_relativePath}/{result.FilePath}");
            return result;
        }

        public async Task UpdateFilePath(Guid uid, string filePath)
        {
            try
            {
                var batch = await this.Get(uid);
                if (!string.IsNullOrEmpty(filePath))
                    batch.FilePath = filePath;
                await this.Update(batch);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateClaimCount(Guid uid, int claimCount)
        {
            try
            {
                var batch = await this.Get(uid);
                batch.ClaimCount = claimCount;

                await this.Update(batch);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateClaimCountByid(int id, int claimCount)
        {
            try
            {
                var batch = await this.GetById(id);
                batch.ClaimCount = claimCount;
                batch.BatchStatus = 1;
                await this.Update(batch);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateStatus(Guid uid, BatchStatus status, bool isDate, string filePath)
        {
            try
            {
                var batch = await this.Get(uid);
                if (isDate)
                {
                    if (batch.FirstSent == null)
                        batch.FirstSent = DateTime.Now;
                    batch.LastSent = DateTime.Now;
                }
                if (!string.IsNullOrEmpty(filePath))
                    batch.FilePath = filePath;
                batch.BatchStatus = (int)status;
                await this.Update(batch);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IClaimBatch> GetFileText(Guid batchUID)
        {
            try
            {
                var claimBatch = await this.Connection.SingleAsync<ClaimBatch>(i => i.PracticeId == LoggedUser.PracticeId && i.UId == batchUID);
                if (claimBatch != null)
                {
                    string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/{claimBatch.FilePath}";
                    claimBatch.FullFileText = File.ReadAllText(filePath);
                }

                return claimBatch;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                return await base.DeleteByIdAsync<ClaimBatch>(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(Guid uid)
        {
            try
            {
                var batchData = await this.Connection.SingleAsync<ClaimBatch>(i => i.UId == uid && i.PracticeId == LoggedUser.PracticeId);
                return batchData == null ? 0 : await base.DeleteByIdAsync<ClaimBatch>(batchData.Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IClaimBatch>> GetclaimBatchForBulkUpload()
        {
            var claimBatches = await this.Connection.SelectAsync<ClaimBatch>(i=> i.BatchStatus==3);
            return claimBatches;
        }

        public async Task<IEnumerable<IClaimBatch>> GetClaimBatchForAutoRunScrub(int clearingHouseid)
        {
            var claimBatches = await this.Connection.SelectAsync<ClaimBatch>(i => i.BatchStatus == 0 && i.ScrubStatus==0 && i.ClearingHouseId== clearingHouseid && i.DateMade>DateTime.Now.AddDays(-30));
            return claimBatches.Take(20);
        }

        public async Task<IEnumerable<IClaimBatch>> GetClaimsForCreate837PEdiFile(int clearingHouseId)
        {
            var claimBatches = await this.Connection.SelectAsync<ClaimBatch>(i => i.ScrubStatus == 2 && i.ClearingHouseId == clearingHouseId && i.BatchStatus == 0
            && i.DateMade > DateTime.Now.AddDays(-30));
            return claimBatches;
        }
    }
}
