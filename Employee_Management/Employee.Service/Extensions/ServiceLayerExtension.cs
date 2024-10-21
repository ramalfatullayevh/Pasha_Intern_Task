using Employee.Service.Services.Abstractions;
using Employee.Service.Services.Concretes;
using EmployeeManagement.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection ServiceExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.DataExtension(configuration); // Database Configuration

            services.AddScoped<ICompanyService, CompanyService>();


            return services;
        }
    }
}
