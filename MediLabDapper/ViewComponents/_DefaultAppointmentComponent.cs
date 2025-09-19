using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultAppointmentComponent(IAppointmentRepository _appointmentRepository, IDepartmentRepository _departmentRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            return View();
        }
    }
}
