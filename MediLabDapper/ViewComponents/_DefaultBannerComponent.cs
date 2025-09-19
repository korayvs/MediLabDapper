using MediLabDapper.Repositories.BannerRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultBannerComponent(IBannerRepository _bannerRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _bannerRepository.GetAllAsync();
            return View(banners);
        }
    }
}
