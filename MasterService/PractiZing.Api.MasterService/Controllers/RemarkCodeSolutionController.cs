using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]

    public class RemarkCodeSolutionController : SecuredRepositoryController<IRemarkCodeSolutionRepository>
    {
        public RemarkCodeSolutionController(IRemarkCodeSolutionRepository repository) : base(repository)
        {
        }

        /// <summary>
        ///  get all soutions 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// get solutions by remark code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("get/{remarkCode}")]
        public async Task<IActionResult> Get(string remarkCode)
        {
            var result = await this.Repository.Get(remarkCode);
            return Ok(result);
        }
    }
}