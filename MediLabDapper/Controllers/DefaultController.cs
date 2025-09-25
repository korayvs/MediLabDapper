using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using NuGet.Protocol.Core.Types;

namespace MediLabDapper.Controllers
{
    public class DefaultController(IAppointmentRepository _appointmentRepository) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> DefaultAvailableAppointments(int doctorId, int departmentId)
        {
            if (departmentId <= 0 || doctorId <= 0)
            {
                return Json(new { success = false, message = "Geçersiz departman veya doktor ID'si" });
            }

            try
            {
                var appointments = await _appointmentRepository.AvailableAppointmentWithDocWithDepart(departmentId, doctorId);
                var resultList = appointments?.ToList() ?? new List<ResultAppointmentDto>();

                var result = appointments?.Select(x => new
                {
                    appointmentId = x.AppointmentId,
                    date = x.Date.ToString("dd/MM/yyyy"),
                    time = x.Time.ToString(@"hh\:mm"),
                    doctorName = x.DoctorName,
                    departmentName = x.DepartmentName
                }).ToList();

                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DefaultAppointmentCreate(CreateAppointmentDto dto, string SelectedAppointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(SelectedAppointment) || !SelectedAppointment.Contains('|'))
            {
                ModelState.AddModelError("", "Lütfen listeden geçerli bir randevu saati seçiniz.");
                return BadRequest(ModelState);
            }

            var parts = SelectedAppointment.Split('|');

            if (parts.Length != 3 || !int.TryParse(parts[0], out int appointmentId))
            {
                ModelState.AddModelError("SelectedAppointment", "Seçilen randevu formatı geçersiz.");
                return BadRequest(ModelState);
            }

            try
            {
                await _appointmentRepository.UpdateAppointmentUserInfo(dto, appointmentId);
                return Ok("OK");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Randevu kaydedilirken sunucu hatası oluştu: " + ex.Message });
            }
        }
    }
}