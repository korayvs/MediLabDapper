using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MediLabDapper.Controllers
{
    public class AppointmentController(IAppointmentRepository _appointmentRepository, IDoctorRepository _doctorRepository, IDepartmentRepository _departmentRepository) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentRepository.AppointmentWithDocWithDepart();
            var appointmentList = appointments.OrderByDescending(x => x.Date).Where(x => x.FullName != null).ToList();
            return View(appointmentList);
        }

        public async Task<IActionResult> CreateAppointment()
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
        public async Task<IActionResult> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createAppointmentDto);
            }
            await _appointmentRepository.CreateAsync(createAppointmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var departments = await _departmentRepository.GetAllDepartmentsAsync();
            ViewBag.departments = (from x in departments
                                   select new SelectListItem
                                   {
                                       Text = x.DepartmentName,
                                       Value = x.DepartmentId.ToString()
                                   }).ToList();
            var doctors = await _doctorRepository.AllDoctorsWithDepartmentByIdAsync(appointment.DepartmentId);
            ViewBag.doctors = doctors.Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.DoctorId.ToString()
            }).ToList();

            var updateAppointment = new UpdateAppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                FullName = appointment.FullName,
                Email = appointment.Email,
                PhoneNumber = appointment.PhoneNumber,
                Date = appointment.Date,
                Time = appointment.Time,
                Message = appointment.Message,
                DoctorId = appointment.DoctorId,
                DepartmentId = appointment.DepartmentId,
                IsApproved = appointment.IsApproved
            };
            return View(updateAppointment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(UpdateAppointmentDto updateAppointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(updateAppointmentDto);
            }
            await _appointmentRepository.UpdateAsync(updateAppointmentDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> GetDoctorsByDepartment(int departmentId)
        {
            var doctors = await _doctorRepository.AllDoctorsWithDepartmentByIdAsync(departmentId);
            var doctorList = doctors.Select(x => new SelectListItem
            {
                Text = x.NameSurname,
                Value = x.DoctorId.ToString()
            }).ToList();
            return Json(doctorList);
        }

        public async Task<IActionResult> WaitingAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var updateAppointment = new UpdateAppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                FullName = appointment.FullName,
                Email = appointment.Email,
                PhoneNumber = appointment.PhoneNumber,
                Date = appointment.Date,
                Time = appointment.Time,
                Message = appointment.Message,
                DoctorId = appointment.DoctorId,
                DepartmentId = appointment.DepartmentId,
                IsApproved = StatusAppointmentDto.Beklemede
            };
            await _appointmentRepository.UpdateAsync(updateAppointment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ApprovedAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var updateAppointment = new UpdateAppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                FullName = appointment.FullName,
                Email = appointment.Email,
                PhoneNumber = appointment.PhoneNumber,
                Date = appointment.Date,
                Time = appointment.Time,
                Message = appointment.Message,
                DoctorId = appointment.DoctorId,
                DepartmentId = appointment.DepartmentId,
                IsApproved = StatusAppointmentDto.Onaylı
            };
            await _appointmentRepository.UpdateAsync(updateAppointment);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeclineAppointment(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            var updateAppointment = new UpdateAppointmentDto
            {
                AppointmentId = appointment.AppointmentId,
                FullName = appointment.FullName,
                Email = appointment.Email,
                PhoneNumber = appointment.PhoneNumber,
                Date = appointment.Date,
                Time = appointment.Time,
                Message = appointment.Message,
                DoctorId = appointment.DoctorId,
                DepartmentId = appointment.DepartmentId,
                IsApproved = StatusAppointmentDto.Reddedildi
            };
            await _appointmentRepository.UpdateAsync(updateAppointment);
            return RedirectToAction("Index");
        }
    }
}
