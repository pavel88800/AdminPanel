namespace APProject
{
    using System.Threading.Tasks;
    using APP.DB;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await InitGispDbContextAsync(host);
            host.Run();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureAppConfiguration((ctx, builder) =>
                {
                    builder.AddJsonFile("Meta/menuInfo.json");
                    builder.AddJsonFile("Meta/metaInfo.json");
                });
        }

        private static async Task InitGispDbContextAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<PanelContext>();
            dbContext.Init();
        }
    }
}