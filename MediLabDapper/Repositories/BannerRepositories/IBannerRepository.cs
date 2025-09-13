using MediLabDapper.Dtos.BannerDtos;

namespace MediLabDapper.Repositories.BannerRepositories
{
    public interface IBannerRepository
    {
        Task<IEnumerable<ResultBannerDto>> GetAllAsync();
        Task<GetBannerByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateBannerDto createBannerDto);
        Task UpdateAsync(UpdateBannerDto updateBannerDto);
        Task DeleteAsync(int id);
    }
}
