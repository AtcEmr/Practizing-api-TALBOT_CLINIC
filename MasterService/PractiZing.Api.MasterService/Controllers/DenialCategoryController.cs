using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    public class DenialCategoryController : SecuredRepositoryController<IDenialCategoryRepository>
    {
        public DenialCategoryController(IDenialCategoryRepository repository) : base(repository)
        {
        }

       
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddNew([FromBody]DenialCategory entity)
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
        public async Task<IActionResult> Update([FromBody]DenialCategory entity)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid actionCategoryUId)
        {
            try
            {
                var result = await this.Repository.Delete(actionCategoryUId);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}