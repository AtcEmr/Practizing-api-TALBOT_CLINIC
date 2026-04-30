using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.DenialService;
using PractiZing.Base.Service.DenialService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.DenialService.Tables;

namespace PractiZing.Api.DenialService.Controllers
{
    [Route("api/[controller]")]
    public class ActionCategoryController : SecuredRepositoryController<IActionCategoryRepository>
    {
        private IActionCategoryService _actionCategoryService;
        public ActionCategoryController(IActionCategoryRepository repository, IActionCategoryService actionCategoryService) : base(repository)
        {
            _actionCategoryService = actionCategoryService;
        }

        [HttpGet("get/{uId}")]
        public async Task<IActionResult> Get(Guid uId)
        {
            try
            {
                var result = await this.Repository.Get(uId);
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

        [HttpGet("getAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var result = await this.Repository.Get(true);
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

        [HttpGet("getAllCategoryForDDO")]
        public async Task<IActionResult> GetAllCategorey()
        {
            try
            {
                var result = await this.Repository.Get(false);
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

        [HttpGet("getSubCategoryByCategoryUId/{categoryUId}")]
        public async Task<IActionResult> GetSubCategoryByCategoryUId(Guid categoryUId)
        {
            try
            {
                var result = await this.Repository.GetSubCategoryByCategoryUId(categoryUId);
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

        [HttpPost]
        public async Task<IActionResult> AddNew()
        {
            try
            {
                var files = Request.Form.Files;
                string obj = Request.Form["ActionCategory"].FirstOrDefault();
                var actionCategory = Newtonsoft.Json.JsonConvert.DeserializeObject<ActionCategory>(obj);
                var result = await this.Repository.AddNew(actionCategory, files);
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
        public async Task<IActionResult> Update()
        {
            try
            {
                var files = Request.Form.Files;
                string obj = Request.Form["ActionCategory"].FirstOrDefault();
                var actionCategory = Newtonsoft.Json.JsonConvert.DeserializeObject<ActionCategory>(obj);
                var result = await this.Repository.Update(actionCategory, files);
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
        public async Task<IActionResult> Delete(Guid uid)
        {
            try
            {
                var result = await this._actionCategoryService.Delete(uid);
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