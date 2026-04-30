using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ConfigCaseTypeController : SecuredRepositoryController<IConfigCaseTypeRepository>
    {
        public ConfigCaseTypeController(IConfigCaseTypeRepository configCaseTypeRepository) : base(configCaseTypeRepository)
        {
        }

        /// <summary>
        ///  get all config case types 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get case type by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(Int16 id)
        {
            var result = await this.Repository.Get(id);
            return Ok(result);
        }
    }
}