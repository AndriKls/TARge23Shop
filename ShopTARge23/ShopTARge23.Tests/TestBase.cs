using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;

namespace ShopTARge23.Tests
{
    public class TestBase : IDisposable
    {
        protected IServiceProvider ServiceProvider { get; }

        protected ShopTARge23Context _context;

        public TestBase()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            _context = ServiceProvider.GetService<ShopTARge23Context>();
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            // Registreeri teenused
            services.AddScoped<IKindergartenServices, KindergartenServices>();

            // Lisa andmebaasi kontekst in-memory andmebaasiga
            services.AddDbContext<ShopTARge23Context>(options =>
            {
                options.UseInMemoryDatabase("TestDb");
            });
        }

        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        public void Dispose()
        {
            // Puhasta ressursid
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
