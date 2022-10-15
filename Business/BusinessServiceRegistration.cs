using Business.Abstract;
using Business.Concrete;
using Core.Security.JWT;
using Core.Utilities.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICityService, CityManager>();
            services.AddScoped<IActivityService, ActivityManager>();
            services.AddScoped<IUserActivityService, UserActivityManager>();

            return services;
        }
    }
}
