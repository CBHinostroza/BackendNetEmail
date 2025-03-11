using BackendNetEmail.Configurations;
using BackendNetEmail.Interfaces;
using BackendNetEmail.Services;

namespace BackendNetEmail.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuración de opciones desde appsettings.json
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            // Inyectar servicios con interfaz
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

    }
}
