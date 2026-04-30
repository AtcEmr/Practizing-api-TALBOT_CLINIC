using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PractiZing.Api.Common.Controllers;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService.Objects;

namespace PractiZing.Api.SecurityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : SecuredRepositoryController<IUserPermissionRepository>
    {
        private readonly IUserService _userService;
        public UserPermissionController(IUserPermissionRepository userRoleRepository, IUserService userService)
            : base(userRoleRepository)
        {
            _userService = userService;
        }

        [HttpGet("getAllByUser/{userUId}")]
        public async Task<IActionResult> GetAllByUser(string userUId, [FromQuery]List<int> roleIds)
           {
            var result = await this._userService.GetAllByUser(userUId, roleIds.ToList());
            return Ok(result);
        }

        [HttpGet("getInheritedPermissions")]
        public async Task<IActionResult> GetInheritedPermissions([FromQuery]List<int> roleIds)
        {
            var result = await this._userService.GetAllByRoleIds(roleIds.ToList());
            return Ok(result);
        }


        [HttpPost("addOrUpdate")]
        public async Task<IActionResult> AddOrUpdate([FromBody]UserRolePermissionDTO entity)
        {
            try
            {
                var result = await this._userService.SaveRolesAndPermissions(entity);
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