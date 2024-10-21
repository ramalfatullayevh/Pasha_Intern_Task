using Employee.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static  IServiceCollection DataExtension(this IServiceCollection services, IConfiguration configuration)
        {
            //DataBase
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
