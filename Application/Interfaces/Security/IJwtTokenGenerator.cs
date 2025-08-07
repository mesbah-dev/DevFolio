using Application.DTOs.Security;

namespace Application.Interfaces.Security
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(JwtTokenPayload payload);
    }
}
