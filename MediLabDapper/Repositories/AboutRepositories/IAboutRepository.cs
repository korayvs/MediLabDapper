using MediLabDapper.Dtos.AboutDtos;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public interface IAboutRepository
    {
        Task<IEnumerable<ResultAboutDto>> GetAllAsync();
        Task<GetAboutByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAboutDto createAboutDto);
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
        Task DeleteAsync(int id);
    }
}
