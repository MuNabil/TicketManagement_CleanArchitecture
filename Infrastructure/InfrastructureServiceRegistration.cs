
using Core.Application.Contracts.Infrastructure;
using Core.Application.Models.Mail;
using Infrastructure.Infrastructure.FileExport;
using Infrastructure.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient< ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
