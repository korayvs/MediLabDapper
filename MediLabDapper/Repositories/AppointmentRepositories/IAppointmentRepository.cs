using MediLabDapper.Dtos.AppointmentDtos;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<ResultAppointmentDto>> GetAllAsync();
        Task<GetAppointmentByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAppointmentDto createAppointmentDto);
        Task UpdateAsync(UpdateAppointmentDto updateAppointmentDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ResultAppointmentDto>> AppointmentWithDocWithDepart();
        Task<IEnumerable<ResultAppointmentDto>> AvailableAppointmentWithDocWithDepart(int doctorId, int departmentId);
        public Task UpdateAppointmentUserInfo(CreateAppointmentDto dto, int appointmentId);
    }
}
