using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.ViewComponents
{
    public class _DefaultContactComponent(IContactRepository _contactRepository) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contacts = await _contactRepository.GetAllAsync();
            return View(contacts);
        }
    }
}
