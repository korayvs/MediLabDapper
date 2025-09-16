using MediLabDapper.Dtos.DoctorDtos;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.Controllers
{
    public class DoctorController(IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorRepository.AllDoctorsWithDepartmentAsync();
            return View(doctors);
        }

        private async Task GetDepartments()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from department in departments
                                   select new SelectListItem
                                   {
                                       Text = department.DepartmentName,
                                       Value = department.DepartmentId.ToString()
                                   }).ToList();
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctorAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateDoctor()
        {
            await GetDepartments();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            await GetDepartments();
            if (!ModelState.IsValid)
            {
                return View(createDoctorDto);
            }
            await _doctorRepository.CreateDoctorAsync(createDoctorDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDoctor(int id)
        {
            await GetDepartments();
            var doctor = await _doctorRepository.GetDoctorByIdAsync(id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorDto updateDoctorDto)
        {
            await GetDepartments();
            if (!ModelState.IsValid)
            {
                return View(updateDoctorDto);
            }
            await _doctorRepository.UpdateDoctorAsync(updateDoctorDto);
            return RedirectToAction("Index");
        }
    }
}
