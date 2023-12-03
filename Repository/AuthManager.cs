using HotelManagementAPI.Common;
using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models.User;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HotelManagementAPI.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthManager> _logger;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private const string _loginProvider = "HotelManagementAPI";
        private const string _refreshToken = "RefreshToken";

        public AuthManager(
            IMapper mapper,
            UserManager<User> userManager,
            ILogger<AuthManager> logger,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValidUser == false)
            {
                return null;
            }

            return new AuthResponseDto
            {
                Token = await GenerateTokenAsync(user),
                UserId = user.Id,
                RefreshToken = await CreateRefreshTokenAsync(user)
            };
        }

        public async Task<IEnumerable<IdentityError>> RegisterAsync(RegisterRequestDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;

            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password); // plain password will be hashed by the library
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshTokenAsync(AuthResponseDto request)
        {

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null || user.Id != request.UserId)
            {
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(user, _loginProvider, _refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateTokenAsync(user);
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = user.Id,
                    RefreshToken = await CreateRefreshTokenAsync(user)
                };
            }

            await _userManager.UpdateSecurityStampAsync(user);
            return null;
        }

        private async Task<string> GenerateTokenAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            _logger.LogDebug("user {email}", user.Email);
            _logger.LogDebug("roleClaims {roleClaims}", roles.ToJson().FormatJson());
            _logger.LogDebug("userClaims {userClaims}", userClaims.ToJson());

            string token = _jwtTokenGenerator.GenerateToken(user, roleClaims, userClaims);

            return token;
        }

        public async Task<string> CreateRefreshTokenAsync(User user)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, _loginProvider, _refreshToken);
            string newRefreshToken = await _userManager.GenerateUserTokenAsync(user, _loginProvider, _refreshToken);

            //save in AspNetUserTokens table
            var result = await _userManager.SetAuthenticationTokenAsync(user, _loginProvider, _refreshToken, newRefreshToken);

            return result.Succeeded ? newRefreshToken : null;
        }
    }
}
