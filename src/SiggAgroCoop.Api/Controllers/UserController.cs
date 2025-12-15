using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SiggAgroCoop.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // exige autenticação JWT por padrão
public class UserController : ControllerBase
{
    // ============================
    // 🔒 ADMIN ONLY
    // ============================
    [HttpPost("admin-action")]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult AdminAction()
    {
        return Ok(new
        {
            Message = "Admin action performed successfully.",
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    // ============================
    // 🔒 MANAGER ONLY
    // ============================
    [HttpPost("manager-action")]
    [Authorize(Policy = "ManagerOnly")]
    public IActionResult ManagerAction()
    {
        return Ok(new
        {
            Message = "Manager action performed successfully.",
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    // ============================
    // 🔒 EMPLOYEE ONLY
    // ============================
    [HttpPost("employee-action")]
    [Authorize(Policy = "EmployeeOnly")]
    public IActionResult EmployeeAction()
    {
        return Ok(new
        {
            Message = "Employee action performed successfully.",
            UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
            Role = User.FindFirstValue(ClaimTypes.Role)
        });
    }

    // ============================
    // 🔍 DEBUG – VER CLAIMS DO TOKEN
    // ============================
    [HttpGet("me")]
    public IActionResult Me()
    {
        var claims = User.Claims.Select(c => new
        {
            c.Type,
            c.Value
        });

        return Ok(new
        {
            IsAuthenticated = User.Identity?.IsAuthenticated,
            Claims = claims
        });
    }
}
