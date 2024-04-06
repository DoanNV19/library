using Microsoft.Extensions.DependencyInjection;
using LibApp.Application.Interfaces;
using LibApp.Application.Services;
using LibApp.Application.Resources;

namespace LibApp.Application
{
    public static class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IJwtUtils, JwtUtils>();
            services.AddScoped<IAuthenService, AuthenService>();
        }
    }
}