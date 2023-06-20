using Common.UI.Jwt;
using Contract.Repository;
using DAL.Entities;
using DAL.Repository;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using Models.AccessJwt;
using Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controller;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
public class RolesController : ControllerBase
{
    private readonly RoleManager<ApplicationRole> _roleManager;

    public RolesController(RoleManager<ApplicationRole> roleManager)
    {
        this._roleManager = roleManager;
    }

    
    [HttpGet]
    [Route("GetAllRoles")]
    public IActionResult GetAllRoles() => Ok(_roleManager.Roles.ToList());

  
    [HttpPost]
    [Route("InsertToRole")]
    public async Task<IActionResult> InsertToRole(RoleDto role)
    {

        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status100Continue, "Not Valid");

        var identityRole = new ApplicationRole { Name = role.Name };

        var result = await _roleManager.CreateAsync(identityRole).ConfigureAwait(false);

        if (!result.Succeeded)
            return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create Role");

        return Ok(new
        {
            identityRole.Id,
            identityRole.Name
        });
    }
  
}
