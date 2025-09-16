using MediLabDapper.Dtos.AllAppointmentDtos;

namespace MediLabDapper.Repositories.AllAppointmentRepositories
{
    public interface IAllAppointmentRepository
    {
        Task<IEnumerable<AllResultAppointmentDto>> GetAllAsync();
        Task<AllGetAppointmentByIdDto> GetByIdAsync(int id);
        Task CreateAsync(AllCreateAppointmentDto allCreateAppointmentDto);
        Task UpdateAsync(AllUpdateAppointmentDto allUpdateAppointmentDto);
        Task DeleteAsync(int id);

    }
}
