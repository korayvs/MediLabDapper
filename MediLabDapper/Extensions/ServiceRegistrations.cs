using MediLabDapper.Context;
using MediLabDapper.Repositories.AboutRepositories;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.BannerRepositories;
using MediLabDapper.Repositories.ContactRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.ServiceRepositories;
using MediLabDapper.Repositories.TestimonialRepositories;

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
            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            return services;
        }
    }
}
