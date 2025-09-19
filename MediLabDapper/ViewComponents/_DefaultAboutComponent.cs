using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultAboutComponent(IAboutRepository _aboutRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var abouts = await _aboutRepository.GetAllAsync();
            return View(abouts);
        }
    }
}
