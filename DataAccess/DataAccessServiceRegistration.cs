using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkDal;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            services.AddDbContext<OnlineActivityContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("OnlineActivityConString")));
            services.AddScoped<IActivityDal, EfActivityDal>();
            services.AddScoped<ICityDal, EfCityDal>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IUserRoleDal, EfUserRoleDal>();
            services.AddScoped<IUserActivityDal, EfUserActivityDal>();

            return services;
        }
    }
}
