using HotelManagementAPI.Models.User;
using Microsoft.AspNetCore.Identity;

namespace HotelManagementAPI.Contracts
{
    public interface IAuthManager
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<IEnumerable<IdentityError>> Register(RegisterRequestDto userDto);
    }
}
