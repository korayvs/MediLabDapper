using MediLabDapper.Dtos.AllAppointmentDtos;
using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AllAppointmentRepositories;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.Controllers
{
    public class AllAppointmentController(IAllAppointmentRepository _allAppointmentRepository, IAppointmentRepository _appointmentRepository, IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepository.AppointmentWithDocWithDepart();
            var appointmentList = appointments.OrderByDescending(x => x.Date).Where(x => x.FullName == null).ToList();
            return View(appointmentList);
        }

        public async Task<IActionResult> FullyAppointment()
        {
            var fullyAppointment = await _appointmentRepository.AppointmentWithDocWithDepart();
            ViewBag.fullyAppointments = fullyAppointment.OrderByDescending(x => x.Date).Where(x => x.FullName != null).ToList();
            return View(fullyAppointment);
        }

        public async Task<IActionResult> CreateAllAppointment()
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAllAppointment(AllCreateAppointmentDto allCreateAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(allCreateAppointmentDto);
            }
            await _allAppointmentRepository.CreateAsync(allCreateAppointmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAllAppointment(int id)
        {
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();

            var value = await _allAppointmentRepository.GetByIdAsync(id);

            var doctors = await _doctorRepository.AllDoctorsWithDepartmentByIdAsync(value.DepartmentId);
            ViewBag.doctors = doctors.Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.DoctorId.ToString()
            }).ToList();

            var updateAppointment = new AllUpdateAppointmentDto
            {
                AppointmentId = value.AppointmentId,
                Date = value.Date,
                Time = value.Time,
                DoctorId = value.DoctorId,
                DepartmentId = value.DepartmentId
            };
            return View(updateAppointment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAllAppointment(AllUpdateAppointmentDto allUpdateAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(allUpdateAppointmentDto);
            }
            await _allAppointmentRepository.UpdateAsync(allUpdateAppointmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAllAppointment(int id)
        {
            await _allAppointmentRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetDoctorsByDepartmentId(int departmentId)
        {
            var doctors = await _doctorRepository.AllDoctorsWithDepartmentByIdAsync(departmentId);
            var doctorList = doctors.Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.DoctorId.ToString()
            }).ToList();

            return Json(doctorList);
        }
    }
}
