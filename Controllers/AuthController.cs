using Azure;
using KaryeramAPI.DTOs;
using KaryeramAPI.Helpers;
using KaryeramAPI.Models;
using KaryeramAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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
        [HttpGet("account")]
        public async Task<IActionResult> Account()
        {
            try
            {
                var userId = User.GetUserId();
                var result = await _authService.GetUserByIdAsync(userId);
                if (result == null) return NotFound();
                var userRole = result.UserRole.ToString();

                return Ok(new UserProfileResponse
                {
                    Email = result.Email,
                    Role = userRole,
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user profile for user ID: {UserId}", User.FindFirstValue(ClaimTypes.NameIdentifier));
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            if (!Request.Cookies.TryGetValue("refreshToken", out var rawToken)) return Unauthorized();
            _logger.LogError($"Refreshing {rawToken}");

            var decodedToken = Uri.UnescapeDataString(rawToken);
            var tokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(decodedToken)));

            AuthResponse result;
            try
            {
                result = await _authService.RefreshTokenAsync(tokenHash, HttpContext);
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
                result.AccessToken,
                result.AccessTokenExpiresIn
            });
        }
    }

}
