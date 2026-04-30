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
    public class MonthEndCloseController : SecuredRepositoryController<IMonthEndCloseRepository>
    {
        public MonthEndCloseController(IMonthEndCloseRepository repository) : base(repository)
        {
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }

        [HttpGet("getByUId/{uId}")]
        public async Task<IActionResult> Get(Guid uid)
        {
            var result = await this.Repository.Get(uid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]MonthEndClose entity)
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
        public async Task<IActionResult> Update([FromBody]MonthEndClose entity)
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

        [HttpDelete("deleteByUId/{uid}")]
        public async Task<IActionResult> DeleteByUId(Guid uid)
        {
            var result = await this.Repository.Delete(uid);
            return Ok(result);
        }
    }
}