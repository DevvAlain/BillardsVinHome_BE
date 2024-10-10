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

    }
}
