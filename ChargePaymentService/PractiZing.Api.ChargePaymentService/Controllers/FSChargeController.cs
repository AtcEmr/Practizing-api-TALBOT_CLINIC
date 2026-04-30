using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.ChargePaymentService.Objects;
namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class FSChargeController : SecuredRepositoryController<IFSChargeRepository>
    {
        private readonly IFeeScheduleService _feeScheduleService;
        public FSChargeController(IFSChargeRepository FSChargeRepository, IFeeScheduleService feeScheduleService) : base(FSChargeRepository)
        {
            _feeScheduleService = feeScheduleService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("GetFeeSchedule/{cptCode}")]
        public async Task<IActionResult> GetFeeSchedule(string cptCode, string providerUId, string insuranceCompanyUId, IEnumerable<string> modifiers, DateTime fromDate)
        {
            try
            {
                var result = await this._feeScheduleService.GetChargeByCPT(cptCode, modifiers, providerUId, insuranceCompanyUId, fromDate);
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

        [HttpPost("getFeeSchedulesHL7")]
        public async Task<IActionResult> AddCPTCharge([FromBody]IEnumerable<Charges> charges, string providerUId, string insuranceCompanyUId, List<string> modifiers, DateTime fromDate)
        {

            foreach (var item in charges)
            {
                List<IFSDiscount> _fsDiscounts = new List<IFSDiscount>();
                fromDate = (fromDate == DateTime.MinValue) ? item.BillFromDate : fromDate;
                var result = await this._feeScheduleService.GetChargeByCPT(item.CPTCode, modifiers, providerUId, insuranceCompanyUId, fromDate);
                if (result != null)
                {
                    item.Amount = result.NonFacilityCharge;
                    _fsDiscounts = result.FSDiscounts.ToList();
                    if (_fsDiscounts.Count() > 0)
                        item.Discount = _fsDiscounts.FirstOrDefault().NonFacilityDiscount;
                }
            }
            return Ok(charges);
        }

        [HttpPost("getFeeSchedules")]
        public async Task<IActionResult> GetFeeCharges([FromBody]ChargeFeeDTO chargeFeeDTO)
        {

            foreach (var item in chargeFeeDTO.CptCodes)
            {
                List<IFSDiscount> _fsDiscounts = new List<IFSDiscount>();
                var result = await this._feeScheduleService.GetChargeByCPT(item.CPTCode, item.Modifiers, chargeFeeDTO.ProviderUId, chargeFeeDTO.InsuranceUId, chargeFeeDTO.DosDate);
                if (result != null)
                {
                    item.Amount = result.NonFacilityCharge;
                    _fsDiscounts = result.FSDiscounts.ToList();
                    if (_fsDiscounts.Count() > 0)
                        item.Discount = _fsDiscounts.FirstOrDefault().NonFacilityDiscount;
                }
            }
            return Ok(chargeFeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]FSCharge entity)
        {
            try
            {
                var result = await this._feeScheduleService.AddFSCharge(entity);
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]FSCharge entity)
        {
            try
            {
                var result = await this._feeScheduleService.UpdateFSCharge(entity);
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

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(short id)
        {
            try
            {
                var result = await this._feeScheduleService.DeleteFSCharge(id);
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