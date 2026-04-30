using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;

namespace PractiZing.Api.SecurityService.Controllers
{
    [Route("api/[controller]")]
    public class UserRoleController : SecuredRepositoryController<IUserRoleRepository>
    {
        private readonly IUserService _userService;
        public UserRoleController(IUserRoleRepository userRoleRepository, IUserService userService) : base(userRoleRepository)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.Repository.GetAll();
            return Ok(result);
        }

        [HttpGet("getAllByUser/{userUId}")]
        public async Task<IActionResult> GetAllByUser(string userUId)
        {
            var result = await this.Repository.GetAllByUser(userUId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Modify([FromBody]List<UserRole> entities)
        {
            try
            {
                var result = await this.Repository.ModifyList(entities);
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