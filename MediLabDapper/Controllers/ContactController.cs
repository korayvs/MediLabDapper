using MediLabDapper.Dtos.ContactDtos;
using MediLabDapper.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;

namespace MediLabDapper.Controllers
{
    public class ContactController(IContactRepository _repository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var contacts = await _repository.GetAllAsync();
            return View(contacts);
        }

        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createContactDto);
            }
            await _repository.CreateAsync(createContactDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var contact = await _repository.GetByIdAsync(id);
            var updateContact = new UpdateContactDto
            {
                ContactId = contact.ContactId,
                Location = contact.Location,
                Phone = contact.Phone,
                Email = contact.Email
            };
            return View(updateContact);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateContactDto);
            }
            await _repository.UpdateAsync(updateContactDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
