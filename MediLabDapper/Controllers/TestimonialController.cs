using MediLabDapper.Dtos.TestimonialDtos;
using MediLabDapper.Repositories.TestimonialRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class TestimonialController(ITestimonialRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var testimonials = await _repository.GetAllAsync();
            return View(testimonials);
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createTestimonialDto);
            }
            await _repository.CreateAsync(createTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _repository.GetByIdAsync(id);
            var updateTestimonial = new UpdateTestimonialDto
            {
                TestimonialId = testimonial.TestimonialId,
                ImageUrl = testimonial.ImageUrl,
                NameSurname = testimonial.NameSurname,
                JobName = testimonial.JobName,
                Review = testimonial.Review,
                Comment = testimonial.Comment
            };
            return View(updateTestimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateTestimonialDto);
            }
            await _repository.UpdateAsync(updateTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
