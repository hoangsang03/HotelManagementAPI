using Microsoft.AspNetCore.Identity;

namespace HotelManagementAPI.Data
{
    public class User : IdentityUser
    {
        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}
