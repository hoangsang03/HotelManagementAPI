using HotelManagementAPI.Data;
using HotelManagementAPI.Models.User;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementAPI.Contracts
{
    public interface IAuthManager
    {
        Task<string> CreateRefreshTokenAsync(User user);
        Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<IEnumerable<IdentityError>> RegisterAsync(RegisterRequestDto userDto);
        Task<AuthResponseDto> VerifyRefreshTokenAsync(AuthResponseDto request);
    }
}
