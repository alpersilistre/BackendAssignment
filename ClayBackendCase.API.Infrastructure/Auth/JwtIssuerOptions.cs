using Microsoft.IdentityModel.Tokens;
using System;

namespace ClayBackendCase.API.Infrastructure.Auth
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public DateTime Expires { get; set; } = DateTime.UtcNow.Add(TimeSpan.FromDays(7));
        public SigningCredentials SigningCredentials { get; set; }
    }
}
