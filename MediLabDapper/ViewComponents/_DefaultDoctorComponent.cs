using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultDoctorComponent(IDoctorRepository _doctorRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var doctors = await _doctorRepository.AllDoctorsWithDepartmentAsync();
            return View(doctors);
        }
    }
}
