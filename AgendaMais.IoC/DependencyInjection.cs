using AgendaMais.Application.Interfaces;
using AgendaMais.Application.Services;
using AgendaMais.Domain.Interfaces;
using AgendaMais.Infra.Context;
using AgendaMais.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaMais.IoC
{
    public class DependencyInjection
    {
        public static IServiceCollection RegisterApps(IServiceCollection services)
        {
            //Context
            services.AddScoped<ApplicationDbContext>();

            //Repositories
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

            //Services
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IProfissionalService, ProfissionalService>();

            return services;
        }
    }
}
