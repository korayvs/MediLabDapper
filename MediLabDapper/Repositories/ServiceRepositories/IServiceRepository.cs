using MediLabDapper.Dtos.ServiceDtos;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<ResultServiceDto>> GetAllAsync();
        Task<GetServiceByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateServiceDto createServiceDto);
        Task UpdateAsync(UpdateServiceDto updateServiceDto);
        Task DeleteAsync(int id);
    }
}
