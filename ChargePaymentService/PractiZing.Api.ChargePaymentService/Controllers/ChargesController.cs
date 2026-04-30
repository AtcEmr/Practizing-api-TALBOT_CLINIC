using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.MasterServcie.Objects;

namespace PractiZing.Api.ChargesPaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ChargesController : SecuredRepositoryController<IChargesRepository>
    {
        private readonly IChargeInvoiceService _chargeInvoiceService;
        public ChargesController(IChargesRepository chargesRepository, IChargeInvoiceService chargeInvoiceService) : base(chargesRepository)
        {
            _chargeInvoiceService = chargeInvoiceService;
        }

        /// <summary>
        /// get method's for claim  batches
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(ChargeDashboardBatchFilter filter)
        {
            try
            {
                var result = await this.Repository.GetAll(filter);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("downloadInvoices")]
        public async Task<IActionResult> DownloadInvoices(ChargeDashboardBatchFilter filter)
        {
            try
            {
                var result = await this.Repository.GetInvoicesFromCharges(filter);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "Invoices");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[AllowAnonymous]
        [HttpGet("get/{accessionNumber}")]
        public async Task<IActionResult> GetDetailsByAccessionNumbers(string accessionNumber)
        {
            try
            {
                var result = await this.Repository.GetChargesByAccessionNumberWise(accessionNumber);

                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("downloadinvoicesaccessionnumberwise")]
        public async Task<IActionResult> DownloadInvoicesAccessionNumberWise([FromBody] List<string> invoiceUIds)
        {
            try
            {
                List<Guid> invoiceGUIds = new List<Guid>();
                //var invoiceIds = invoiceUIds.Split(',');
                //invoiceGUIds.AddRange(invoiceIds.Select(Guid.Parse).ToList());
                invoiceGUIds = invoiceUIds.ConvertAll(Guid.Parse);

                var result = await this.Repository.GetInvoicesFromChargesByInvoiceUids(invoiceGUIds);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result.ToList(), "Invoices");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Used for HL7 Data to fill CPT's Info like Description, Place of Service etc.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        [HttpPost("CPTDesc")]
        public async Task<IActionResult> AddCPTDesc([FromBody]IEnumerable<Charges> entities)
        {
            var result = await this._chargeInvoiceService.FillCPTDesc(entities);
            return Ok(result);
        }

        /// <summary>
        /// Payment statement for given patient.
        /// </summary>
        /// <param name="patientUId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("getStatements")]
        public async Task<IActionResult> GetStatement(Guid patientUId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetStatement(patientUId, fromDate, toDate);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCPTAmount([FromBody]IEnumerable<Charges> entities)
        {
            try
            {
                var result = await this._chargeInvoiceService.FillCPTDesc(entities);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete Charge 
        /// </summary>
        /// <param name="chargeUId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCharge(Guid chargeUId, bool isDelete)
        {
            try
            {
                var result = await this._chargeInvoiceService.DeleteCharge(chargeUId, isDelete);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetCharges/{patientUId}/{invoiceUId}")]
        public async Task<IActionResult> GetCharges(Guid patientUId, Guid invoiceUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetCharges(patientUId, invoiceUId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ChangeDueBy/{invoiceUId}/{chargeUId}/{dueBy}/{patientCaseUId}/{billFromDate}")]
        public async Task<IActionResult> ChangeDueBy(Guid invoiceUId, Guid chargeUId, string dueBy, Guid patientCaseUId, DateTime billFromDate)
        {
            try
            {
                var result = await this.Repository.ChangeDueBy(invoiceUId, chargeUId, dueBy, patientCaseUId, billFromDate);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetExcelForPatientDetailInsuranceAgingReport")]
        public async Task<IActionResult> GetExcelForPatientDetailInsuranceAgingReport([FromQuery] int reportId, [FromBody] object parameterObject)
        {
            try
            {
                var parameterData = ObjectConvertor<object>.ObjToDataTable(parameterObject);
                //var keyValuePairs = new Dictionary<string, string>();

                DateTime fromDate = Convert.ToDateTime(parameterData.Rows[0]["ToDate"].ToString());
                Guid insCompanyUId = System.Guid.Empty;

                if (parameterData.Columns.Contains("InsuranceCompanyId") == true)
                {
                    insCompanyUId = Guid.Parse(parameterData.Rows[0]["InsuranceCompanyId"].ToString());
                }
                //keyValuePairs.Add("ToDate", fromDate.ToString());
                //keyValuePairs.Add("insCompanyUId", insCompanyUId.ToString());

                var result = await this.Repository.GetExcelForPatientDetailInsuranceAging(fromDate, insCompanyUId);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result, "PatientDetailInsurances");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetExcelForPostingPatments")]
        public async Task<IActionResult> GetExcelForPostingPatments([FromBody] ReportParameterDTO parameterObject)
        {
            try
            {
                
                //var keyValuePairs = new Dictionary<string, string>();
                

                var result = await this.Repository.GetExcelForPostingPayments(parameterObject);
                byte[] fileBytes = ExcelExportHelper.DownloadExcel(result, "Sheet1");
                return File(fileBytes, ExcelExportHelper.ExcelContentType);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ExportExcelToCatalyst")]
        public async Task<IActionResult> ExportExcelToCatalyst()
        {
            try
            {
                var result = await this.Repository.UploadExcelForReportDataForCatalystAllChargesToSFTP();                
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ExportExcelActionNotes")]
        public async Task<IActionResult> ExportExcelActionNotes()
        {
            try
            {
                var result = await this.Repository.UploadExcelForActionNoteDataDataForCatalystAllChargesToSFTP();
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetChargesByPatient/{patientUId}")]
        public async Task<IActionResult> GetChargesByPatient(Guid patientUId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetChargesByPatient(patientUId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("patientBalances/{billingId}")]
        public async Task<IActionResult> GetPatientCharges(string billingId)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetDueChargesForEMR(billingId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetChargesForUpdateFeeAmount")]
        public async Task<IActionResult> GetChargesForUpdateFeeAmount([FromBody]List<int> ids)
        {
            try
            {
                var result = await this._chargeInvoiceService.GetChargesForUpdateFeeAmount(ids);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// get method's for claim  batches
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("getforai/{chargeId}")]
        public async Task<IActionResult> GetForAI(int chargeId)
        {
            try
            {
                var result = await this.Repository.GetById(chargeId);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("updatefromai")]
        public async Task<IActionResult> UpdateFromAI([FromBody]Charges entity)
        {
            try
            {
                var result = await this.Repository.UpdateFromAI(entity);
                return Ok(result);
            }
            catch (EntityException ex)
            {
                return StatusCode(400, ex.ValidationCodeResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
