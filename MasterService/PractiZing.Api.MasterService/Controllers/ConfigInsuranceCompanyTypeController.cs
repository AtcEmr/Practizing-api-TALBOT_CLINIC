using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class ConfigInsuranceCompanyTypeController : SecuredRepositoryController<IConfigInsuranceCompanyTypeRepository>
    {
        private IInsuranceCompanyService _insuranceCompanyService;
        public ConfigInsuranceCompanyTypeController(IConfigInsuranceCompanyTypeRepository repository,
                                                    IInsuranceCompanyService insuranceCompanyService)
                                                  : base(repository)
        {
            this._insuranceCompanyService = insuranceCompanyService;
        }

        /// <summary>
        ///  get all insurance company types
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getAllCompanyTypes")]
        public async Task<IActionResult> GetAll(string companyTypeName)
        {
            var result = await this._insuranceCompanyService.Get(companyTypeName);
            return Ok(result);
        }
    }
}