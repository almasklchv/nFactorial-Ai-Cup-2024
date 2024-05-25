using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

using ExcelAI.API.Auth;
using ExcelAI.Infrastructure.DAL;
using ExcelAI.Infrastructure.ExternalServices;
using ExcelAI.Infrastructure.Files;
using ExcelAI.Infrastructure.Repositories;
using ExcelAI.Mapping;

using Prometheus;


namespace ExcelAI.API.StrartupConfiguration
{
    public class StartupConfiguration
    {
        private readonly WebApplicationBuilder builder;
        private WebApplication? application { get; set; }

        public StartupConfiguration()
        {
            this.builder = WebApplication.CreateBuilder();
        }

        public void BuildApp()
        {
            this.application = this.builder.Build();
        }
        public void RunApp()
        {
            if (this.application is null) throw new NullReferenceException();
            this.application.Run();
        }

        #region FILE_CONFIGURATION
        public void AddConfigurationJSON(params string[] filenames)
        {
            foreach (string filename in filenames)
            {
                this.builder.Configuration.AddJsonFile(filename);
            }
        }
        public void AddConfigurationJSON(string filename)
            => this.AddConfigurationJSON(filename);
        #endregion

        #region SERVICES
        public void ConfigureServices()
        {
            this.builder.Services.AddControllers();
            this.builder.Services.AddEndpointsApiExplorer();
            this.builder.Services.AddSwaggerGen();
            this.builder.Services.AddLogging();
            this.builder.Services.AddAutoMapper(typeof(MappingProfile));
            this.builder.Services.AddOpenAIService();
            this.builder.Services.AddExcelService();
            this.builder.Services.AddMetricsService();

            #region TRANSIENT
            this.builder.Services.AddTransient<IFileRepository, FileRepository>();
            this.builder.Services.AddTransient<UserRepository>();
            #endregion
        }
        #endregion

        #region AUTH
        public void ConfigureAuth()
        {
            this.builder.Services.AddTransient<AuthOptions>();
            var authOptions = new AuthOptions(this.builder.Configuration);
            this.builder.Services.AddAuthorization();
            this.builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = authOptions.GetTokenValidationParameters();
                });
        }
        #endregion

        #region MIDDLEWARE
        public void ConfigureMiddleware()
        {
            if (this.application is null) throw new NullReferenceException();

            if (this.application.Environment.IsDevelopment())
            {
                this.ConfigureDevelopmentMiddleware();
            }
            this.ConfigureProductionMiddleware();
        }

        private void ConfigureDevelopmentMiddleware()
        {
            this.application.UseSwagger();
            this.application.UseSwaggerUI();
        }
        private void ConfigureProductionMiddleware()
        {
            this.application.UseMetricServer();

            this.application.UseHttpsRedirection();
            this.application.UseAuthorization();
            this.application.MapControllers();
        }
        #endregion

        #region APPLICATION_CONTEXT
        public void ConfigureApplicationContext()
        {
            string dbConStr = this.builder.Configuration.GetConnectionString("PostgreSQL")
                ?? throw new KeyNotFoundException();
            this.builder.Services.AddNpgsql<ApplicationContext>(dbConStr);
        }
        public void ConfigureMigrationsOnStartup()
        {
            if(this.application is null) throw new NullReferenceException();
            using (var scope = this.application.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }
        }
        #endregion

        #region CORS
        public void CORSAllowAll()
        {
            this.builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                    builder =>
                    {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });
        }
        public void AddCORSPolicy()
        {
            this.application.UseCors("AllowAll");
        }
        #endregion
    }
}