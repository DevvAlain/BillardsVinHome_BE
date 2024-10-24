using BilliardManagement.Entities;
using BilliardManagement.Models.Creates;
using BilliardManagement.Models.Updates;
using BilliardManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilliardManagement.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService) 
        { 
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetRoles() { 
           var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoleById([FromRoute] Guid id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null)
            {
                return NotFound("deo tim duoc");
            }
            return Ok(role);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRole([FromRoute] Guid id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateRole([FromBody] RoleCreateModel model) 
        {
            var role = _roleService.CreateRole(model);
            if (role != null)
            {
                return StatusCode(201, role);
            }
            return StatusCode(400, "khong tao duoc");
        }

        [HttpPatch]
        [Route("{id:guid}/update")]
        public IActionResult UpdateRole([FromRoute] Guid id, [FromBody] RolePropertiesUpdateModel model)
        {
            var role = _roleService.UpdateRole(id, model);
            if (role != null)
            {
                return StatusCode(201, role);
            }
            return StatusCode(400, "khong update duoc");
        }

        [HttpPut]
        public IActionResult UpdateRole([FromBody] RoleUpdateModel model)
        {
            var role = _roleService.UpdateRole(model);
            if (role != null)
            {
                return StatusCode(201, role);
            }
            return StatusCode(400, "khong update duoc");
        }

    }
}
