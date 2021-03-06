using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace IMPA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(b =>
            {
                b.UseStartup<Startup>();
            });

            host.Build().Run();
        }
    }
}
