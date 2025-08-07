namespace Application.Interfaces.Security
{
    public interface IJwtSettingsProvider
    {
        string Issuer { get; }
        string Audience { get; }
        string SecretKey { get; }
        int ExpiresInMinutes { get; }
    }
}
