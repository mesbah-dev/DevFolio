using Application.DTOs.Security;
using Application.Interfaces.Security;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Security
{
    public class JwtSettingsProvider : IJwtSettingsProvider
    {
        private readonly JwtSettings _jwtSettings;

        public JwtSettingsProvider(IOptions<JwtSettings> options)
        {
            _jwtSettings = options.Value;
        }

        public string Issuer => _jwtSettings.Issuer;
        public string Audience => _jwtSettings.Audience;
        public string SecretKey => _jwtSettings.SecretKey;
        public int ExpiresInMinutes => _jwtSettings.ExpiresInMinutes;
    }
}
