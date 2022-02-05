using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Yarp.ReverseProxy.Infrastructure
{

    public static class Dependencies
    {
        public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var useOnlyInMemoryDatabase = false;
            if (configuration["UseOnlyInMemoryDatabase"] != null)
            {
                useOnlyInMemoryDatabase = bool.Parse(configuration["UseOnlyInMemoryDatabase"]);
            }

            if (useOnlyInMemoryDatabase)
            {
                services.AddDbContext<ReverseProxyDbContext>(c =>
                   c.UseInMemoryDatabase("ReverseProxy"));
            }
            else
            {
                // use real database
                // Requires LocalDB which can be installed with SQL Server Express 2016
                // https://www.microsoft.com/en-us/download/details.aspx?id=54284
                var UseConnection = "MySQL";
                UseConnection = configuration["UseConnection"];
                switch (UseConnection)
                {
                    case "MySQL":
                        services.AddDbContext<ReverseProxyDbContext>(c =>
                    c.UseMySql(configuration.GetConnectionString("MySQL"),
                            ServerVersion.Parse("10.6.5-mariadb"))
                        .LogTo(Console.WriteLine, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors());
                        break;
                    case "MSSQL":
                        services.AddDbContext<ReverseProxyDbContext>(c =>
                    c.UseSqlServer(configuration.GetConnectionString("MSSQL")));
                        break;
                }
            }
        }
    }
}
