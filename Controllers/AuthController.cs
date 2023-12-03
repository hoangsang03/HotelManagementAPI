using HotelManagementAPI.Contracts;
using HotelManagementAPI.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthManager _authManager;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthManager authManager)
        {
            _logger = logger;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var errors = await _authManager.RegisterAsync(registerRequestDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            _logger.LogInformation("User Login: {email}", loginRequestDto.Email);
            AuthResponseDto authResponse = await _authManager.LoginAsync(loginRequestDto);
            if (authResponse == null)
            {
                return Unauthorized();
            }
            _logger.LogInformation("User {email} Login Successfully!", loginRequestDto.Email);
            return Ok(authResponse);
        }

        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshTokenAsync(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
