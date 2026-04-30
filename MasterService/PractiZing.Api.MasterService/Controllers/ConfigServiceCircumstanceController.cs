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
    public class ConfigServiceCircumstanceController : SecuredRepositoryController<IConfigServiceCircumstanceRepository>
    {
        public ConfigServiceCircumstanceController(IConfigServiceCircumstanceRepository repository) : base(repository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceCircumstance()
        {
            var result = await this.Repository.Get();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(Int16 id)
        {
            var result = await this.Repository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]ConfigServiceCircumstance entity)
        {
            try
            {   
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
        public async Task<IActionResult> Update([FromBody]ConfigServiceCircumstance entity)
        {
            try
            {
                
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