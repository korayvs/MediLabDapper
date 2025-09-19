using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultServiceComponent(IServiceRepository _serviceRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _serviceRepository.GetAllAsync();
            return View(services);
        }
    }
}
