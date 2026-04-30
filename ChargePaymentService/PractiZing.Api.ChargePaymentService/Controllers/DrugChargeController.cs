using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.ChargePaymentService;
using System.Threading.Tasks;

namespace PractiZing.Api.ChargePaymentService.Controllers
{
    [Route("api/[controller]")]
    public class DrugChargeController : SecuredRepositoryController<IDrugChargeRepository>
    {
        public DrugChargeController(IDrugChargeRepository repository) : base(repository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(string invoiceUId)
        {
            var result = await this.Repository.GetByInvoice(invoiceUId);
            return Ok(result);
        }
    }
}
