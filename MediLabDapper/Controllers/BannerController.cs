using MediLabDapper.Dtos.BannerDtos;
using MediLabDapper.Repositories.BannerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class BannerController(IBannerRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var banners = await _repository.GetAllAsync();
            return View(banners);
        }

        public IActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createBannerDto);
            }
            await _repository.CreateAsync(createBannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBanner(int id)
        {
            var banner = await _repository.GetByIdAsync(id);
            var updateBanner = new UpdateBannerDto
            {
                BannerId = banner.BannerId,
                Icon = banner.Icon,
                Title = banner.Title,
                Description = banner.Description
            };
            return View(updateBanner);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateBannerDto);
            }
            await _repository.UpdateAsync(updateBannerDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
