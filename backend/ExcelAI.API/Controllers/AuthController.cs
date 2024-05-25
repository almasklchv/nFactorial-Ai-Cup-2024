using ExcelAI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ExcelAI.Domain.Users;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ExcelAI.API.Auth;
using Microsoft.EntityFrameworkCore;
using ExcelAI.Infrastructure.ExternalServices.PrometheusMetrics;
using ExcelAI.API.Requests.AuthData;

namespace ExcelAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthController> logger;

        private readonly UserRepository userRepository; 
        private readonly AuthOptions authOptions;
        private readonly MetricsCollector metricsCollector;


        public AuthController(UserRepository userRepository, 
                                ILogger<AuthController> logger, 
                                IConfiguration configuration, 
                                AuthOptions authOptions,
                                MetricsCollector metricsCollector)
        {
            this.userRepository = userRepository;
            this.logger = logger;
            this.configuration = configuration;
            this.authOptions = authOptions;
            this.metricsCollector = metricsCollector;
        }


        [HttpPost("/singIn")]
        public async Task<IResult> SingIn(AuthDataRequest userData)
        {
            this.metricsCollector.EndpointRequestCounter.WithLabels("singIn").Inc();

            ClaimsIdentity? identity = this.GetIdentity(userData.Login, userData.Password);
            if (identity == null)
            {
                return Results.NotFound(userData);
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: this.authOptions.ISSUER(),
                    audience: this.authOptions.AUDIENCE(),
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(this.authOptions.LIFETIME())),
                    signingCredentials: new SigningCredentials(this.authOptions.SECURITY_KEY(), SecurityAlgorithms.HmacSha256)
                    );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Results.Ok(response);
        }

        [HttpPost("/singUp")]
        public async Task<IResult> SingUp(User user)
        {
            this.metricsCollector.EndpointRequestCounter.WithLabels("signUp").Inc();

            await this.userRepository.AddAsync(user);
            return Results.Ok();
        }


        private ClaimsIdentity? GetIdentity(string login, string password)
        {
            User? user = this.userRepository.GetAllAsQueryable()
                                            .FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
