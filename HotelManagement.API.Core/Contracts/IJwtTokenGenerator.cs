using HotelManagementAPI.Data;
using System.Security.Claims;

namespace HotelManagementAPI.Contracts
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user, IEnumerable<Claim> roleClaims, IEnumerable<Claim> userClaims);
    }
}
