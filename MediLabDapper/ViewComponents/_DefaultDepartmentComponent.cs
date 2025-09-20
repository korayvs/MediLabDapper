using MediLabDapper.Repositories.DepartmentRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultDepartmentComponent(IDepartmentRepository _departmentRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            return View(departments);
        }
    }
}
