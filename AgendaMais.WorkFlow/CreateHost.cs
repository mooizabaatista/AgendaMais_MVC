using AgendaMais.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace AgendaMais.WorkFlow
{
    public static class CreateHost
    {
        public static IHostBuilder CreateBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) => builder.SetBasePath(Directory.GetCurrentDirectory()))
                .ConfigureServices((context, services) => DependencyInjection.RegisterApps(services));
            return hostBuilder;
        }
    }
}
