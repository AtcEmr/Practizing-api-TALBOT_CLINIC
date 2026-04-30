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
    public class ConfigSystemCDController : SecuredRepositoryController<IConfigSystemCDRepository>
    {
        public ConfigSystemCDController(IConfigSystemCDRepository repository) : base(repository)
        {

        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByCD/{CD}")]
        public async Task<IActionResult> GetByCD(string CD)
        {
            var result = await this.Repository.GetByCD(CD);
            return Ok(result);
        }

        [HttpGet("getAllFollowUp")]
        public async Task<IActionResult> GetAllFollowUp()
        {
            var result = await this.Repository.GetAllFollowUp();
            return Ok(result);
        }

        [HttpGet("getAllAction")]
        public async Task<IActionResult> GetAllAction()
        {
            var result = await this.Repository.GetAllActionResponse();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ConfigSystemCD entity)
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
        public async Task<IActionResult> Update([FromBody]ConfigSystemCD entity)
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
        public async Task<IActionResult> Delete(string CD)
        {
            try
            {
                var result = await this.Repository.Delete(CD);
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