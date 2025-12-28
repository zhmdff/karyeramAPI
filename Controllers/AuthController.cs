using KaryeramAPI.DTOs;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace KaryeramAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger=logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var result = await _authService.LoginAsync(request, HttpContext);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("verify")]
        public async Task<IActionResult> Verify()
        {
            return Ok(new { message = "Token is valid" });
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out var userId))  return Unauthorized();
            
            var result = await _authService.GetUserByIdAsync(userId);
            if (result == null) return NotFound();

            return Ok(new UserDto(result.Email, result.UserRole.ToString()));
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            if (!Request.Cookies.TryGetValue("refreshToken", out var rawToken)) return Unauthorized();

            AuthResponse result;
            try
            {
                result = await _authService.RefreshTokenAsync(rawToken, HttpContext);
                _logger.LogInformation("Ok Lil Bro");
            }
            catch (SecurityTokenException)
            {
                _logger.LogError("Unauthorized: Error during RefreshTokenAsync");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during RefreshTokenAsync");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(new
            {
                result.User,
                result.AccessToken,
                result.AccessTokenExpiresIn
            });
        }
    }

}
