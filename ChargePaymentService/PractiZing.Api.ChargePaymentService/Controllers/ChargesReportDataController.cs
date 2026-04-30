using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Objects;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.Helpers;

namespace PractiZing.Api.ChargesPaymentService.Controllers
{
    [Route("api/[controller]")]
    public class ChargesReportDataController : SecuredRepositoryController<IChargesReportDataRepository>
    {
        private readonly IChargesReportDataRepository _chargesReportDataRepository;
        public ChargesReportDataController(IChargesReportDataRepository chargesReportDataRepository) : base(chargesReportDataRepository)
        {
            _chargesReportDataRepository = chargesReportDataRepository;
        }

        /// <summary>
        /// get method's for claim  batches
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Get(ChargesReportDataFilterDTO filter)
        {
            try
            {
                var result = await this.Repository.Get(filter);
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
        [HttpPost("onlydenial")]
        public async Task<IActionResult> GetOnlyDenials(ChargesReportDataFilterDTO filter)
        {
            try
            {
                var result = await this.Repository.GetOnlyDenials(filter);
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
        [HttpPost("cpareport")]
        public async Task<IActionResult> GetCPAReportAnalytics()
        {
            try
            {
                var result = await this.Repository.GetCPAReportAnalytics();
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
        [HttpPost("cpareport/{value}")]
        public async Task<IActionResult> GetCPAChargesAnalytics(string value)
        {
            try
            {
                var result = await this.Repository.GetCPAChargesAnalytics(value);
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
        [HttpPost("getOnlyWriteOff")]
        public async Task<IActionResult> GetOnlyWriteOff()
        {
            try
            {
                var result = await this.Repository.GetOnlyWriteOff();
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
                var result = await this.Repository.GetPatientCharges(billingId);
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

        [HttpGet("patientBalancesList")]
        public async Task<IActionResult> GetPatientBalancesList()
        {
            try
            {
                var result = await this.Repository.GetPatientBalancesList();
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

        [HttpGet("getWriteOffDataToEMR")]
        public async Task<IActionResult> GetWriteOffDataToEMR()
        {
            try
            {
                var result = await this.Repository.GetPatientBalancesList();
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

        [HttpGet("getConsolidateData")]
        public async Task<IActionResult> GetConsolidateData()
        {
            try
            {
                var result = await this.Repository.GetConsolidateData();
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

        [HttpGet("getPatientBalalcesEMR")]
        public async Task<IActionResult> GetPatientBalancesForEMR()
        {
            try
            {
                var result = await this.Repository.GetPatientBalancesForEMR();
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

        [HttpPost("GetPatientBalancesForMobileAPP")]
        public async Task<IActionResult> GetPatientBalancesForMobileAPP([FromBody] MobileInputModel mobileInputModel)
        {
            try
            {
                var result = await this.Repository.GetPatientBalancesForMobileAPP(mobileInputModel);
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

        [HttpGet("PatientStatmentOverThreeMonth")]
        public async Task<IActionResult> GetPatientForStatementOverThreeMonths()
        {
            try
            {
                var result = await this.Repository.GetPatientForStatementOverThreeMonths();
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

        [HttpPost("GetBalancesForMobileAPP")]
        public async Task<IActionResult> GetBalancesForMobileAPP()
        {
            try
            {
                var result = await this.Repository.GetBalancesForMobileAPP();
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

        [HttpGet("GetBalancesForEMRWithDuemAmont/{dueAmount}")]
        public async Task<IActionResult> GetBalancesForEMRWithDuemAmont(decimal dueAmount)
        {
            try
            {
                var result = await this.Repository.GetBalancesForEMRWithDuemAmont(dueAmount);
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

        [HttpPost("DailyImportDataStaticsSend")]
        public async Task<IActionResult> DailyImportDataStaticsSend()
        {
            try
            {
                var result = await this.Repository.DailyImportDataStaticsSend();
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
