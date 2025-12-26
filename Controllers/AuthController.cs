using Azure.Core;
using KaryeramAPI.DTOs;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KaryeramAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }

        [Authorize]
        [HttpPost("verify")]
        public async Task<IActionResult> Verify()
        {
            return Ok(new { message = "Token is valid" });
        }

        [Authorize]
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var idString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(idString, out var id)) return Unauthorized();
            if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken)) return Unauthorized();
            var result = await _authService.RefreshTokenAsync(id, refreshToken);
            return Ok(result);
        }
    }

}
