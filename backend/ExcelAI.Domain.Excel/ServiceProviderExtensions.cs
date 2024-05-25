using ExcelAI.Domain.Excel;
using Microsoft.Extensions.DependencyInjection;

namespace ExcelAI.Infrastructure.ExternalServices
{
    public static class ServiceProviderExtensions
    {
        public static void AddExcelService(this IServiceCollection services)
        {
            services.AddTransient<IExcelService, ExcelService>();
        }
    }
}
