using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultHeaderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
