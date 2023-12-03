using HotelManagementAPI.Common;
using HotelManagementAPI.Contracts;
using HotelManagementAPI.Data;
using HotelManagementAPI.Models.User;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol;
using System.Security.Claims;

namespace HotelManagementAPI.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthManager> _logger;
        private IJwtTokenGenerator _jwtTokenGenerator;

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

            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(user);

            _logger.LogDebug("user {user}", user.ToJson().FormatJson());
            _logger.LogDebug("roleClaims {roleClaims}", roleClaims.ToJson());
            _logger.LogDebug("userClaims {userClaims}", userClaims.ToJson());

            var token = _jwtTokenGenerator.GenerateToken(user, roleClaims, userClaims);
            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(RegisterRequestDto userDto)
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
    }
}
