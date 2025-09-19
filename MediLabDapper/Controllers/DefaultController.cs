using MediLabDapper.Dtos.AppointmentDtos;
using MediLabDapper.Repositories.AppointmentRepositories;
using Microsoft.AspNetCore.Mvc;
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
                return Json(new { success = false, message = "Geçersiz departman veya doktor ID'si" });

            try
            {
                var values = await _appointmentRepository.AvailableAppointmentWithDocWithDepart(departmentId, doctorId);
                var formattedResults = values?.Select(x => new
                {
                    appointmentId = x.AppointmentId,
                    date = x.Date.ToString("dd/MM/yyyy"),
                    time = x.Time.ToString(@"hh\\:mm"),
                    doctorName = x.DoctorName,
                    departmentName = x.DepartmentName
                });

                return Json(new { success = true, data = formattedResults });
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
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage);
                return BadRequest(new { success = false, errors });
            }

            if (string.IsNullOrWhiteSpace(SelectedAppointment))
                return BadRequest(new { success = false, message = "Lütfen listeden geçerli bir randevu seçiniz." });

            try
            {
                var parts = SelectedAppointment.Split('|');
                if (parts.Length == 3 && int.TryParse(parts[0], out int appointmentId))
                {
                    await _appointmentRepository.UpdateAppointmentUserInfo(dto, appointmentId);
                    return Json(new { success = true });
                }

                return BadRequest(new { success = false, message = "Seçilen randevu formatı geçersiz." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Sunucu hatası: " + ex.Message });
            }
        }
    }
}
