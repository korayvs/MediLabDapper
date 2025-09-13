using MediLabDapper.Dtos.ServiceDtos;
using MediLabDapper.Repositories.ServiceRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class ServiceController(IServiceRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var services = await _repository.GetAllAsync();
            return View(services);
        }

        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createServiceDto);
            }
            await _repository.CreateAsync(createServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _repository.GetByIdAsync(id);
            var updateService = new UpdateServiceDto
            {
                ServiceId = service.ServiceId,
                ServiceIcon = service.ServiceIcon,
                Title = service.Title,
                Description = service.Description
            };
            return View(updateService);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateServiceDto);
            }
            await _repository.UpdateAsync(updateServiceDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
