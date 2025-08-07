namespace Application.DTOs.Security
{
    public class JwtTokenPayload
    {
        public long UserId { get; set; }
        public string Username { get; set; }
    }
}
