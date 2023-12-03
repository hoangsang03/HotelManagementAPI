namespace HotelManagementAPI.Models.Authentication
{
    /// <summary>
    /// init: prevent subsequent modifications after the object has been created
    /// </summary>
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string DurationInMinutes { get; init; }
        public string SecretKey { get; init; }
    }
}
