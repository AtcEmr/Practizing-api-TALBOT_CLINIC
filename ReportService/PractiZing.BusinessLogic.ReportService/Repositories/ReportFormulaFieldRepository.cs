using Newtonsoft.Json;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using PractiZing.Base.Entities.ReportService;
using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ReportService;
using PractiZing.BusinessLogic.Common;
using PractiZing.Base.Enums.ReportService;

namespace PractiZing.BusinessLogic.ReportService.Repositories
{
    public class ReportFormulaFieldRepository<TReportFormulaField> : ModuleBaseRepository<TReportFormulaField>, IReportFormulaFieldRepository
         where TReportFormulaField : class, IReportFormulaField, new()
    {
        private IReportRepository _reportRepository;
        public ReportFormulaFieldRepository(ValidationErrorCodes errorCodes,
                                DataBaseContext dbContext,
                                ILoginUser loggedUser, IReportRepository reportRepository) : base(errorCodes, dbContext, loggedUser)
        {
            this._reportRepository = reportRepository;
        }

        public async Task<IEnumerable<IReportFormulaField>> GetByReportId(int reportId)
        {
            return await this.Connection.SelectAsync<TReportFormulaField>(i => i.ReportId == reportId);
        }

        public async Task<string> GetFieldData(int reportId, object parameterObject)
        {
            try
            {
                var allRecord = await this._reportRepository.GetById(reportId);

                var keyValuePairsFields = new Dictionary<string, Dictionary<string, object>>();
                keyValuePairsFields = await this.AddRecord(allRecord, keyValuePairsFields, parameterObject);
                
                var stringPayload = JsonConvert.SerializeObject(keyValuePairsFields);
                return stringPayload;

            }
            catch
            {
                throw;
            }
        }

        public async Task<Dictionary<string, Dictionary<string, object>>> AddRecord(IReport report,
            Dictionary<string, Dictionary<string, object>> keyValuePairs, object parameterObject)
        {
            try
            {
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);
                var fieldRecord = await this.GetByReportId(report.ID);
                Dictionary<string, object> keyValuePairsFields = new Dictionary<string, object>();
                foreach (var item in fieldRecord)
                {

                    if (item.Type == ReportFormulaFieldType.UI.ToString())
                    {
                        keyValuePairsFields.Add(item.FieldName, parameterData.Rows[0][item.FieldName].ToString());
                    }

                    else if (item.Type == ReportFormulaFieldType.DB.ToString())
                    {
                        var result = await this._reportRepository.GenerateReportData(Convert.ToInt16(item.ReportId), parameterObject);
                        var data = new Dictionary<string, ReportDataDTO>();
                        data = JsonConvert.DeserializeObject<Dictionary<string, ReportDataDTO>>(result);
                        string fieldValue = (data.FirstOrDefault().Value.Data.FirstOrDefault().FirstOrDefault().Values).ToString();
                        keyValuePairsFields.Add(item.FieldName, fieldValue);
                    }

                    else if (item.Type == ReportFormulaFieldType.Custom.ToString())
                    {
                        Type loadType = (from t in System.Reflection.Assembly.Load("PractiZing.BusinessLogic.ReportService").GetExportedTypes()
                                         where !t.IsInterface && !t.IsAbstract
                                         where typeof(ICustomFormulaField).IsAssignableFrom(t)
                                         && t.Name == item.ValueSource
                                         select t).FirstOrDefault();
                        ICustomFormulaField instantiatedTypes = (ICustomFormulaField)Activator.CreateInstance(loadType);
                        var result = await instantiatedTypes.GetFormulaValue(parameterData, item.FieldName);
                        keyValuePairsFields.Add(item.FieldName, result);
                    }
                }
                if (fieldRecord.Count() > 0)
                {
                    keyValuePairs.Add(report.ReportName, keyValuePairsFields);
                }
                return keyValuePairs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
