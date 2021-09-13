using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using PruebaTecnicaDeloimBackend.Common.Mapper;

namespace PruebaTecnicaDeloimBackend.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // AutoMapper
            AutoMapperConfig.CreateMaps();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
