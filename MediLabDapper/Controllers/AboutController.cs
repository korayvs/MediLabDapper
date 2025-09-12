using MediLabDapper.Dtos.AboutDtos;
using MediLabDapper.Repositories.AboutRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class AboutController(IAboutRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var abouts = await _repository.GetAllAsync();
            return View(abouts);
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createAboutDto);
            }
            await _repository.CreateAsync(createAboutDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var about = await _repository.GetByIdAsync(id);
            var aboutDto = new UpdateAboutDto
            {
                AboutId = about.AboutId,
                AboutDescription = about.AboutDescription,
                Title1 = about.Title1,
                Description1 = about.Description1,
                Title2 = about.Title2,
                Description2 = about.Description2,
                Title3 = about.Title3,
                Description3 = about.Description3
            };
            return View(aboutDto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateAboutDto);
            }
            await _repository.UpdateAsync(updateAboutDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
