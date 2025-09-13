using MediLabDapper.Dtos.ContactDtos;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<ResultContactDto>> GetAllAsync();
        Task<GetContactByIdDto> GetByIdAsync(int id);
        Task CreateAsync(CreateContactDto createContactDto);
        Task UpdateAsync(UpdateContactDto updateContactDto);
        Task DeleteAsync(int id);
    }
}
