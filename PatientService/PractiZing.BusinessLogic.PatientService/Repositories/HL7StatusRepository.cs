using Microsoft.Extensions.Configuration;
using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.PatientService.Repositories
{
    public class HL7StatusRepository : ModuleBaseRepository<HL7Status>, IHL7StatusRepository
    {

        private readonly ITransactionProvider _transactionProvider;
        private readonly ITransactionProvider _patientRepository;
        private readonly IConfigSettingRepository _configSettingRepository;
        private readonly string _appUrl;
        public HL7StatusRepository(ValidationErrorCodes errorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser,
                                            ITransactionProvider transactionProvider,
                                            IConfigSettingRepository configSettingRepository,
                                            ITransactionProvider patientRepository, IConfiguration configuration) : base(errorCodes, dbContext, loggedUser)
        {
            this._transactionProvider = transactionProvider;
            this._patientRepository = patientRepository;
            this._configSettingRepository = configSettingRepository;
            _appUrl = configuration["ApplicationUrl"];

        }

        public async Task<IEnumerable<IHL7Status>> GetAllData(IHL7StatusFilter filter)
        {
            try
            {
                if (filter.FromDate != string.Empty && filter.FromDate != null)
                    filter.FromDate = Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
                if (filter.ToDate != string.Empty && filter.ToDate != null)
                    filter.ToDate = Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

                var query = this.Connection
                                .From<HL7Status>()
                                .LeftJoin<HL7Status, Patient>((i, j) => i.BillingId.ToString() == j.BillingID)
                                .Select<HL7Status, Patient>((i, p) => new
                                {
                                    i,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName
                                })
                                .Where(i => i.PracticeId == LoggedUser.PracticeId).OrderByDescending(i => i.CreatedDate);

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string whereExpression = await WhereClauseProvider<IHL7StatusFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                //var result = (await this.Connection.QueryAsync<HL7Status, HL7Status>(query));
                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<HL7Status>.MapList(queryResult);

                return result;
            }
            catch
            {
                throw;
            }
        }

        private string ReadFile(string filePath)
        {
            string text = File.ReadAllText(filePath);
            return text;
        }

        public async Task<IHL7Status> GetById(int id)
        {
            var result = await this.Connection.SingleAsync<HL7Status>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);

            if (File.Exists(result.FilePath))
                result.FileContent = ReadFile(result.FilePath);
            return result;
        }

        public async Task<IEnumerable<IHL7Status>> GetByBillingId(string billingId)
        {
            return await this.Connection.SelectAsync<HL7Status>(i => i.BillingId == billingId && i.PracticeId == LoggedUser.PracticeId);
        }

        public async Task<bool> FindFileByName(IHL7StatusDTO dto)
        {
            var item = await this.Connection.SelectAsync<HL7Status>(i => i.FileName == dto.FileName && i.PracticeId == LoggedUser.PracticeId);
            if (item != null && item.Count > 0)
            {
                foreach (var record in item)
                {
                    await this.Delete((int)record.Id);
                }
            }
            return false;
        }

        public async Task<IHL7Status> AddNew(IHL7Status entity)
        {
            try
            {
                HL7Status tEntity = entity as HL7Status;



                var errors = await this.ValidateEntityToAdd(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                //if (entity.StatusCode.ToLower() == "error")
                //{
                //    return await base.AddNewAsync(tEntity);
                //}

                //var hl7StatusById = await this.GetByBillingId(tEntity.BillingId);
                //var hl7StatusByStatusCode = hl7StatusById.FirstOrDefault(i => i.FileName == tEntity.FileName && i.StatusCode == tEntity.StatusCode);
                //if (hl7StatusByStatusCode != null)
                //{
                //    tEntity.Id = hl7StatusByStatusCode.Id;
                //    tEntity.CreatedBy = hl7StatusByStatusCode.CreatedBy;
                //    tEntity.CreatedDate = hl7StatusByStatusCode.CreatedDate;
                //    return await this.Update(tEntity);
                //}

                return await base.AddNewAsync(tEntity);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IHL7Status> Update(IHL7Status entity)
        {
            try
            {
                HL7Status tEntity = entity as HL7Status;
                var errors = await this.ValidateEntityToUpdate(tEntity);
                if (errors.Count() > 0)
                    await this.ThrowEntityException(errors);

                var updateOnlyFields = this.Connection
                                           .From<HL7Status>()
                                           .Update(x => new
                                           {
                                               x.FilePath,
                                               x.ErrorMessage,
                                               x.FileName,
                                               x.ProcessedDate,
                                               x.SentBy,
                                               x.SentDate,
                                               x.StatusCode,
                                               x.MessageType,
                                               x.ModifiedBy,
                                               x.ModifiedDate
                                           })
                                           .Where(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IHL7Status> UpdateOnlyStatusCode(IHL7Status entity)
        {
            try
            {
                HL7Status tEntity = entity as HL7Status;
                var errors = await this.ValidateEntityToUpdate(tEntity);

                if (errors.Count() > 0)
                {
                    await this.ThrowEntityException(errors);
                }
                tEntity.StatusCode = "Removed";
                var updateOnlyFields = this.Connection
                                           .From<HL7Status>()
                                           .Update(x => new
                                           {
                                               x.StatusCode
                                           })
                                           .Where<HL7Status>(i => i.Id == entity.Id && i.PracticeId == LoggedUser.PracticeId);

                var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                return tEntity;
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
                return await this.Connection.DeleteAsync<HL7Status>(i => i.Id == id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }

        private async Task FileDoesNotExist(string filePath)
        {
            List<IValidationResult> errors = new List<IValidationResult>();

            errors.Add(new ValidationCodeResult(ErrorCodes[EnumErrorCode.FileDoesNotExist], filePath));

            await this.ThrowEntityException(errors);
        }

        public async Task<int> MoveFile(string entity)
        {
            try
            {
                string destinationPath = string.Empty;
                //IConfigSetting configObj = await _configSettingRepository.GetBySettingCDAndSettingGroupCD("HL7FilePath", "PRACTICE GENERAL CONFIGURATION");
                var configSettings = await this._configSettingRepository.Get("HL7 Service Configuration");
                if (configSettings.Where(i => i.SettingCD == "HL7InputFolderPath").FirstOrDefault() != null)
                    destinationPath = configSettings.Where(i => i.SettingCD == "HL7InputFolderPath").FirstOrDefault().SettingValue;

                //string[] folders = configObj.DefaultValues.Split(',');
                HL7Status entityObject = Newtonsoft.Json.JsonConvert.DeserializeObject<HL7Status>(entity);
                if (!string.IsNullOrEmpty(destinationPath))
                {

                    destinationPath = Path.Combine(destinationPath, entityObject.FileName);
                    if (!File.Exists(entityObject.FilePath))
                    {
                        await FileDoesNotExist(entityObject.FilePath);
                    }
                    if (File.Exists(destinationPath))
                    {
                        File.Delete(destinationPath);
                    }

                    File.Move(entityObject.FilePath, destinationPath);


                    await this.Delete((int)entityObject.Id);

                }

                return 1;
            }

            catch (UnauthorizedAccessException)
            {
                await this.ThrowAccessDeniedError();

                throw;
            }
            catch
            {
                throw;
            }
        }

        public async Task ThrowAccessDeniedError()
        {
            await this.ThrowEntityException(new ValidationCodeResult(ErrorCodes[EnumErrorCode.AccessDenied]));
        }

        public async Task<IHL7Status> DeleteFile(string entity)
        {
            try
            {
                HL7Status entityObject = Newtonsoft.Json.JsonConvert.DeserializeObject<HL7Status>(entity);
                //string sourcePath = AppDomain.CurrentDomain.BaseDirectory + entityObject.FilePath;
                //if (File.Exists(sourcePath))
                //    File.Delete(sourcePath);
                return await this.UpdateOnlyStatusCode(entityObject);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<IHL7Status>> GetAll(IHL7StatusFilter filter)
        {
            try
            {
                //if (filter.FromDate != string.Empty && filter.FromDate != null)
                //{
                //    DateTime date = DateTime.ParseExact(filter.FromDate, "M/d/yyyy h:m:s tt", System.Globalization.CultureInfo.InvariantCulture);
                //    filter.FromDate = date.ToString("yyyy-MM-dd");
                //}
                //if (filter.ToDate != string.Empty && filter.ToDate != null)
                //{
                //    DateTime date = DateTime.ParseExact(filter.ToDate, "M/d/yyyy h:m:s tt", System.Globalization.CultureInfo.InvariantCulture);
                //    filter.ToDate = date.ToString("yyyy-MM-dd");
                //}

                //if (filter.FromDate != string.Empty && filter.FromDate != null)
                //    filter.FromDate = DateTime.ParseExact(filter.FromDate, "yyyy-MM-dd 00:00:00", System.Globalization.CultureInfo.InvariantCulture).ToString();
                ////"yyyy-MM-dd 00:00:00"

                //if (filter.ToDate != string.Empty && filter.ToDate != null)
                // filter.ToDate = DateTime.ParseExact(filter.ToDate, "yyyy-MM-dd 23:59:59", System.Globalization.CultureInfo.InvariantCulture).ToString(); //Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

                if (filter.FromDate != string.Empty && filter.FromDate != null)
                    filter.FromDate = Convert.ToDateTime(filter.FromDate).ToString("yyyy-MM-dd 00:00:00");
                //"yyyy-MM-dd 00:00:00"

                if (filter.ToDate != string.Empty && filter.ToDate != null)
                    filter.ToDate = Convert.ToDateTime(filter.ToDate).ToString("yyyy-MM-dd 23:59:59");

                var query = this.Connection
                                .From<HL7Status>()
                                .LeftJoin<HL7Status, Patient>((i, j) => i.BillingId.ToString() == j.BillingID)
                                .Select<HL7Status, Patient>((i, p) => new
                                {
                                    BillingId = i.BillingId,
                                    CreatedDate = i.CreatedDate,
                                    ErrorMessage = i.ErrorMessage,
                                    FileName = i.FileName,
                                    MessageType = i.MessageType,
                                    ModifiedDate = i.ModifiedDate,
                                    ProcessedDate = i.ProcessedDate,
                                    SentBy = i.SentBy,
                                    SentDate = i.SentDate,
                                    StatusCode = i.StatusCode,
                                    FirstName = p.FirstName,
                                    LastName = p.LastName
                                })
                                .Where<HL7Status>(p => p.PracticeId == LoggedUser.PracticeId)
                                //.Where<HL7Status>(p => p.StatusCode == "Processed" && /*(accessionNumber == "" || filter.AccessionNumber.Contains(p.FileName)) && */p.PracticeId == LoggedUser.PracticeId)
                                .OrderByDescending(i => i.CreatedDate);

                //query = query.Where(i => i.PracticeId == LoggedUser.PracticeId);
                //var result = (await this.Connection.QueryAsync<HL7Status, HL7Status>(query, "Processed", LoggedUser.PracticeId));

                string selectExpression = $"{query.SelectExpression} {query.FromExpression}";
                string countExpression = query.ToCountStatement();
                string whereExpression = await WhereClauseProvider<IHL7StatusFilter>.GetWhereClause(filter);

                query.WhereExpression = query.WhereExpression + " AND " + whereExpression;

                var queryResult = await this.Connection.SelectAsync<dynamic>(query);
                var result = Mapper<HL7Status>.MapList(queryResult);

                if (filter.AccessionNumber != null)
                {
                    result = result.Where(i => filter.AccessionNumber.Contains(i.AccessionNumber));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteByAccessionNumber(string fileName)
        {
            try
            {

                var item = await this.Connection.SingleAsync<HL7Status>(i => i.FileName == fileName && i.PracticeId == LoggedUser.PracticeId);
                if (item != null)
                    await this.Connection.DeleteAsync<HL7Status>(i => i.Id == item.Id && i.PracticeId == LoggedUser.PracticeId);
            }
            catch
            {
                throw;
            }
        }
    }
}
