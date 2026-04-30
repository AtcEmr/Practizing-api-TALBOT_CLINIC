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
    public class ClearingHouseController : SecuredRepositoryController<IClearingHouseRepository>
    {
        public ClearingHouseController(IClearingHouseRepository repository) : base(repository)
        {

        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }

        [HttpGet("getByUId/{uid}")]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            var result = await this.Repository.GetByUId(uid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ClearingHouse entity)
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
        public async Task<IActionResult> Update([FromBody]ClearingHouse entity)
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

        [HttpGet("getforohioui")]
        public async Task<IActionResult> GetForOhioUi()
        {
            var result = await this.Repository.GetForOHIOUI();
            return Ok(result);
        }
    }
}