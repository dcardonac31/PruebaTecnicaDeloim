using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PruebaTecnicaDeloimBackend.Common.ApplicationInsights.ServiceCollections;
using PruebaTecnicaDeloimBackend.Common.Configuration;
using PruebaTecnicaDeloimBackend.Common.Dapper;
using PruebaTecnicaDeloimBackend.Common.Proxy.Helpers;
using PruebaTecnicaDeloimBackend.Domain.Interfaces;
using PruebaTecnicaDeloimBackend.Domain.Services;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Context;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.Repository;
using PruebaTecnicaDeloimBackend.Infraestructure.DataAcces.UnitOfWork;

namespace PruebaTecnicaDeloimBackend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            #region Context SQL Server

            // Inicializa DataConext con la cadena de conexión.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectBDAfiliado"),
                    providerOptions => providerOptions.EnableRetryOnFailure()));

            #endregion Context SQL Server

            #region Register (dependency injection)

            // DataContext de la base de datos.
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddScoped<ILogger, Logger<ApplicationDbContext>>();

            // CustomerRepository await UnitofWork parameter ctor explicit
            services.AddScoped<UnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IDapperHelper, DapperHelper>();
            services.AddScoped<IHttpClientHelper, HttpClientHelper>();
            services.AddScoped<IAfiliadoService, AfiliadoService>();
            services.AddScoped<IDapperUtilitiesService, DapperUtilitiesService>();

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            #endregion Register (dependency injection)

            ConfigureCorsService(ref services);

            services.AddApplicationInsightsServiceCollection();

            services.AddDataProtection();

            services.AddBrowserDetection();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaTecnicaDeloimBackend.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaTecnicaDeloimBackend.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            ConfigureCorsApp(ref app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCorsService(ref IServiceCollection services)
        {
            // Enables CORS and httpoptions
            services.AddCors(options =>
            {
                options.AddPolicy(CommonConfiguration.EnableCorsName, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.WithHeaders(CommonConfiguration.Authorization, CommonConfiguration.Accept, CommonConfiguration.ContentType, CommonConfiguration.Origin);
                    builder.SetIsOriginAllowed((_) => true);
                });
            });
            services.AddRouting(r => r.SuppressCheckForUnhandledSecurityMetadata = true);
        }

        private void ConfigureCorsApp(ref IApplicationBuilder app)
        {
            app.UseCors(CommonConfiguration.EnableCorsName);
        }
    }
}
