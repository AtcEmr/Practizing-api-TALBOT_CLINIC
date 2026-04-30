using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Authorize;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.Common.FilterTypes;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ICDCodeController : SecuredRepositoryController<IICDCodeRepository>
    {
        public ICDCodeController(IICDCodeRepository repository) : base(repository)
        {
        }

        [HttpGet("get"), SecuredFilter(ICDPermissions.View)]
        public async Task<IActionResult> Get([FromQuery]SearchQuery<ICDCodeFilter> entity)
        {
            var queryInterface = SearchQuery.Map<ICDCodeFilter, IICDCodeFilter>(entity);
            var result = await this.Repository.Get(queryInterface);
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}"), SecuredFilter(ICDPermissions.View)]
        public async Task<IActionResult> GetByUId(Guid uid)
        {
            var result = await this.Repository.GetByUId(uid);
            return Ok(result);
        }

        [HttpGet("getAllActiveICD"), SecuredFilter(ICDPermissions.View)]
        public async Task<IActionResult> GetAllActiveICD()
        {
            var result = await this.Repository.GetAllActiveICD();
            return Ok(result);
        }

        [HttpPost("checkIfICDExists")]
        public async Task<IActionResult> CheckIfICDExists([FromBody]IEnumerable<DiagnosisDTO> diagnoses)
        {
            this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
            var result = await this.Repository.CheckIfICDExists(diagnoses);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ICDCode entity)
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
        public async Task<IActionResult> Update([FromBody]ICDCode entity)
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