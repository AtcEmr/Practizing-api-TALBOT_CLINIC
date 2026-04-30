using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigAdjustmentReasonCodeController : SecuredRepositoryController<IConfigAdjustmentReasonCodeRepository>
    {
        public ConfigAdjustmentReasonCodeController(IConfigAdjustmentReasonCodeRepository repository) : base(repository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByReasonCode/{reasonCode}")]
        public async Task<IActionResult> GetByReasonCode(string reasonCode)
        {
            var result = await this.Repository.Get(reasonCode);
            return Ok(result);
        }

        [HttpGet("GetAllCodes")]
        public async Task<IActionResult> GetAllCodes(string reasonCode)
        {
            var result = await this.Repository.GetAll(reasonCode);
            return Ok(result);
        }

        [HttpGet("getRemarkCode")]
        public async Task<IActionResult> GetRemarkCode()
        {
            var result = await this.Repository.GetRemarkCode();
            return Ok(result);
        }

        [HttpGet("get/{categoryId}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            try
            {
                var result = await this.Repository.Get(categoryId);
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
        public async Task<IActionResult> AddNew([FromBody]ConfigAdjustmentReasonCode entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this.Repository.AddNew(entity);
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
        public async Task<IActionResult> Update([FromBody]ConfigAdjustmentReasonCode entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this.Repository.Update(entity);
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

        [HttpDelete]
        public async Task<IActionResult> Delete(string reasonCode)
        {
            try
            {
                var result = await this.Repository.Delete(reasonCode);
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

        [HttpGet("getAllWriteOff")]
        public async Task<IActionResult> GetAllWriteOff()
        {
            var result = await this.Repository.GetAllWriteOff();
            return Ok(result);
        }
    }
}