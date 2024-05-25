using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ExcelAI.API.Auth
{
    public class AuthOptions
    {
        private readonly IConfiguration configuration;
        public AuthOptions(IConfiguration configuration)
            => this.configuration = configuration;

        public string ISSUER()
        {
            return this.configuration["JWT:Issuer"] ??
                throw new Exception("\nERROR:\n\tError when loading JWT configuration");
        }
        public string AUDIENCE()
        {
            return this.configuration["JWT:Audience"] ??
                throw new Exception("\nERROR:\n\tError when loading JWT configuration");
        }
        public double LIFETIME()
        {
            return Convert.ToDouble(this.configuration["JWT:Lifetime"] ??
                throw new Exception("\nERROR:\n\tError when loading JWT configuration"));
        }
        public SecurityKey SECURITY_KEY()
        {
            string key = this.configuration["JWT:Key"] ??
                throw new Exception("\nERROR:\n\tError when loading JWT configuration");
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
        }

        public TokenValidationParameters GetTokenValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = this.ISSUER(),
                ValidateAudience = true,
                ValidAudience = this.AUDIENCE(),
                ValidateLifetime = true,
                IssuerSigningKey = this.SECURITY_KEY(),
                ValidateIssuerSigningKey = true,
            };
        }
    }
}
