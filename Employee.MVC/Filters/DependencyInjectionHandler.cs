using Employee.MVC.Interface.Repositories;
using Employee.MVC.Interface.Services;
using Employee.MVC.Repositories;
using Employee.MVC.Services;

namespace Employee.MVC.Filters
{
    public static class DependencyInjectionHandler
    {
        public static void DependencyInjectionConfig(IServiceCollection services)
        {
            services.AddScoped<HttpClient>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
           
        }

    }
}
