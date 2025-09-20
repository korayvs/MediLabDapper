using MediLabDapper.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultTestimonialComponent(ITestimonialRepository _testimonialRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _testimonialRepository.GetAllAsync();
            return View(testimonials);
        }
    }
}
