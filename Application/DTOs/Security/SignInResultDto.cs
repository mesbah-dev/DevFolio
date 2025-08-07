using System;

namespace Application.DTOs.Security
{
    public class SignInResultDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public DateTime Expiration { get; set; }
    }
}
