using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Authorize;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;

namespace PractiZing.Api.SecurityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SecuredRepositoryController<IUserRepository>
    {
        private readonly IUserService _userService;
        public UserController(IUserRepository UserRepository, IUserService userService) : base(UserRepository)
        {
            this._userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await this.Repository.GetAll();
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

        [HttpGet("getByUId/{UId}")]
        public async Task<IActionResult> GetByUId(Guid UId)
        {
            try
            {
                var result = await this.Repository.GetByUId(UId);
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
        public async Task<IActionResult> AddNew([FromBody]User entity)
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
        public async Task<IActionResult> Update([FromBody]User entity)
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
        public async Task<IActionResult> Delete(Guid uid)
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