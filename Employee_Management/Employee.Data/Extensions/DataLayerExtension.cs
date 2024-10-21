using Employee.Data.Context;
using Employee.Data.Repositories.Abstraction;
using Employee.Data.Repositories.Concrete;
using Employee.Data.UnitOfWorks;
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

            //Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
