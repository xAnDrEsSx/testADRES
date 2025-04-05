using Microsoft.Extensions.DependencyInjection;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TestADRES.Infrastructure.Persistence;

namespace TestADRES.Infrastructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructuraServices(this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Database")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // generic Base
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            //services.AddScoped<IPermissionRepository, PermissionRepository>();

            return services;
        }
    }

}
