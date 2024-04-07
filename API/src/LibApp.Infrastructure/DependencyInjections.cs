using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibApp.Application.Core.Services;
using LibApp.Domain.Core.Repositories;
using LibApp.Infrastructure.Data;
using LibApp.Infrastructure.Repositories;
using LibApp.Infrastructure.Services;

namespace LibApp.Infrastructure
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<LibAppDbContext>(options =>
                options.UseMySQL(Configuration.GetSection("ConnectionStrings:LibAppDatabase").Value,
                x => x.MigrationsAssembly("LibApp.Infrastructure")));

            services.AddScoped(typeof(IBaseRepositoryAsync<>), typeof(BaseRepositoryAsync<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<LibAppDbContext>>();
            
            using (var dbContext = new LibAppDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}