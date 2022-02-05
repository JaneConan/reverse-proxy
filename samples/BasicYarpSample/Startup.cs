using BasicYARPSample.Validator;
using FluentValidation;
using Yarp.ReverseProxy.Infrastructure;
using Yarp.ReverseProxy.Infrastructure.Entity;
using Yarp.ReverseProxy.Infrastructure.Management;

namespace BasicYARPSample
{
    // Sets up the ASP.NET application with the reverse proxy enabled.
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Default configuration comes from AppSettings.json file in project/output
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add capabilities to
        // the web application via services in the DI container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMemoryCache();

            services.AddSingleton<IValidator<Cluster>, ClusterValidator>();
            services.AddSingleton<IValidator<ProxyRoute>, ProxyRouteValidator>();
            // 
            Yarp.ReverseProxy.Infrastructure.Dependencies.ConfigureServices(Configuration, services);

            services.AddTransient<IClusterManagement, ClusterManagement>();
            services.AddTransient<IProxyRouteManagement, ProxyRouteManagement>();

            // Add the reverse proxy capability to the server
            var proxyBuilder = services.AddReverseProxy();

            // Initialize the reverse proxy from the "ReverseProxy" section of configuration
            //proxyBuilder.LoadFromConfig(Configuration.GetSection("ReverseProxy"));

            proxyBuilder.LoadFromEFCore();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request 
        // pipeline that handles requests
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable endpoint routing, required for the reverse proxy
            app.UseRouting();
            // Register the reverse proxy routes
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });
        }
    }
}
