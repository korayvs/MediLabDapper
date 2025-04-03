using MediLabDapper.Context;
using MediLabDapper.Repositories.DepartmentRepositories;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<DapperContext>();

            return services;
        }
    }
}
