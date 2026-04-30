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
    public class ConfigFollowUpPeriodController : SecuredRepositoryController<IConfigFollowUpPeriodRepository>
    {

        public ConfigFollowUpPeriodController(IConfigFollowUpPeriodRepository repository) : base(repository)
        {
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ConfigFollowUpPeriod entity)
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
        public async Task<IActionResult> Update([FromBody]ConfigFollowUpPeriod entity)
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
        public async Task<IActionResult> Delete(Int16 id)
        {
            try
            {
                var result = await this.Repository.Delete(id);
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