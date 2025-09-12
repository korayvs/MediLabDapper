using MediLabDapper.Context;
using MediLabDapper.Repositories.AboutRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddRepositoriesExt(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<DapperContext>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();

            return services;
        }
    }
}
