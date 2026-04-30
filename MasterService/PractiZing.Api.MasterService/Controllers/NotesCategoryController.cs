using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Common;
using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.MasterService.Objects;
using PractiZing.DataAccess.MasterService.Tables;

namespace PractiZing.Api.MasterService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesCategoryController : SecuredRepositoryController<INotesCategoryRepository>
    {
        private readonly INotesCategoryService _notesCategoryService;
        public NotesCategoryController(INotesCategoryRepository NotesCategoryRepository, INotesCategoryService notesCategoryService) : base(NotesCategoryRepository)
        {
            _notesCategoryService = notesCategoryService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            var result = await this.Repository.GetByUId(UId);
            return Ok(result);
        }

        [HttpGet("GetNotesCategoryGrid")]
        public async Task<IActionResult> GetNotesCategoryGrid([FromQuery]SearchQuery<NotesCategoryFilter> entity)
        {
            try
            {
                var queryInterface = SearchQuery.Map<NotesCategoryFilter, INotesCategoryFilter>(entity);
                var result = await this.Repository.GetNotesCategoryGrid(queryInterface);
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

        [HttpGet("getNotesCategoryData/{categoryId}")]
        public async Task<IActionResult> GetNotesCategoryData(int categoryId)
        {
            try
            {
                var result = await this.Repository.GetNotesCategoryData(categoryId);
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
        public async Task<IActionResult> AddNew([FromBody]NotesCategory entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._notesCategoryService.AddNotesCategory(entity);
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
        public async Task<IActionResult> Update([FromBody]NotesCategory entity)
        {
            try
            {
                this.Repository.ValidateModel(ModelState.Values.SelectMany(v => v.Errors), ModelState.IsValid);
                var result = await this._notesCategoryService.UpdateNotesCategory(entity);
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
        public async Task<IActionResult> Delete(string uid)
        {
            try
            {
                var result = await this.Repository.Delete(uid);
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