using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class CPTCodeController : SecuredRepositoryController<ICPTCodeRepository>
    {
        public CPTCodeController(ICPTCodeRepository repository) : base(repository)
        {
        }

        [HttpGet("getCPTCodes")]
        public async Task<IActionResult> GetCPTCodes()
        {
            var result = await this.Repository.GetCPTCodes();
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery]SearchQuery<CPTCodeFilter> entity)
        {
            var queryInterface = SearchQuery.Map<CPTCodeFilter, ICPTCodeFilter>(entity);
            var result = await this.Repository.Get(queryInterface);
            return Ok(result);
        }

        [HttpGet("getByUId/{uid}")]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            var result = await this.Repository.GetByUId(uid);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]CPTCodes entity)
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
        public async Task<IActionResult> Update([FromBody]CPTCodes entity)
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
    }
}