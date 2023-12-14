namespace TicketManagement.Application.Models.Identity
{
    public class JwtSettings
    {
        public byte[] Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
