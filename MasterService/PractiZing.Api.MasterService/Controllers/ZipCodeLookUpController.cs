using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class ZipCodeLookUpController : SecuredRepositoryController<IZipCodeLookUpRepository>
    {
        public ZipCodeLookUpController(IZipCodeLookUpRepository zipCodeLookupRepository) : base(zipCodeLookupRepository)
        {
        }

        [HttpGet("getByZip/{Zip}")]
        public async Task<IActionResult> GetByZip(string zip)
        {
            var result = await this.Repository.GetByZip(zip);
            return Ok(result);
        }

        [HttpGet("stateCodeList")]
        public async Task<IActionResult> GetStateCodeList()
        {
            var result = await this.Repository.GetStateCodeList();
            return Ok(result);
        }
    }
}