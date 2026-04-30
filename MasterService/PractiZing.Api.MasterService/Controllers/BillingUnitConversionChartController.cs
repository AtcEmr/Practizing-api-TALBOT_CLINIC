using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class BillingUnitConversionChartController : SecuredRepositoryController<IBillingUnitConversionChartRepository>
    {
        public BillingUnitConversionChartController(IBillingUnitConversionChartRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all places of service
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBillingUnit(int minutes)
        {
            var result = await this.Repository.GetUnitByMinutes(minutes);
            return Ok(result);
        }
    }
}