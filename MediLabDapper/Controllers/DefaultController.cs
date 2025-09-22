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
            try
            {
                Console.WriteLine($"DefaultAvailableAppointments çağrıldı - DepartmentId: {departmentId}, DoctorId: {doctorId}");

                if (departmentId <= 0 || doctorId <= 0)
                {
                    return Json(new { success = false, message = "Geçersiz departman veya doktor ID'si" });
                }

                var values = await _appointmentRepository.AvailableAppointmentWithDocWithDepart(departmentId, doctorId);
                var resultList = values?.ToList() ?? new List<ResultAppointmentDto>();

                Console.WriteLine($"Bulunan randevu sayısı: {resultList.Count}");

                var formattedResults = resultList.Select(x => new
                {
                    appointmentId = x.AppointmentId,
                    date = x.Date.ToString("dd/MM/yyyy"),
                    time = x.Time.ToString(@"hh\:mm"),
                    doctorName = x.DoctorName,
                    departmentName = x.DepartmentName
                }).ToList();

                return Json(formattedResults);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DefaultAvailableAppointments hatası: {ex.Message}");
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DefaultAppointmentCreate(CreateAppointmentDto dto, string SelectedAppointment)
        {
            System.Diagnostics.Debug.WriteLine($"Received DTO.Date: {dto.Date}, DTO.Time: {dto.Time}");
            System.Diagnostics.Debug.WriteLine($"Received SelectedAppointment: {SelectedAppointment}");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                System.Diagnostics.Debug.WriteLine("ModelState Errors: " + string.Join(", ", errors));
                return BadRequest(ModelState);
            }

            try
            {
                if (!string.IsNullOrEmpty(SelectedAppointment) && SelectedAppointment.Contains('|'))
                {
                    var parts = SelectedAppointment.Split('|');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int appointmentId))
                    {
                        await _appointmentRepository.UpdateAppointmentUserInfo(dto, appointmentId);
                        return Content("OK");
                    }
                    else
                    {
                        ModelState.AddModelError("SelectedAppointment", "Seçilen randevu formatı geçersiz.");
                        return BadRequest(ModelState);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen listeden geçerli bir randevu saati seçiniz.");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in DefaultAppointmentCreate: {ex.ToString()}");
                return StatusCode(500, new { message = "Randevu kaydedilirken bir sunucu hatası oluştu: " + ex.Message });
            }
        }
    }
}