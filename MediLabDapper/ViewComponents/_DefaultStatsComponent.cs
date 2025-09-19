using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultStatsComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
