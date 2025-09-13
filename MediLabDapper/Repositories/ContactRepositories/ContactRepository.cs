using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ContactDtos;
using System.Data;

namespace MediLabDapper.Repositories.ContactRepositories
{
    public class ContactRepository(DapperContext _context) : IContactRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateContactDto createContactDto)
        {
            var query = "insert into Contacts (Location, Phone, Email) values (@Location, @Phone, @Email)";
            var parameters = new DynamicParameters(createContactDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Contacts where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);
            return _db.ExecuteAsync(query, parameters);
        }

        public Task<IEnumerable<ResultContactDto>> GetAllAsync()
        {
            var query = "select * from Contacts";
            return _db.QueryAsync<ResultContactDto>(query);
        }

        public Task<GetContactByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Contacts where ContactId = @ContactId";
            var parameters = new DynamicParameters();
            parameters.Add("@ContactId", id);
            return _db.QueryFirstOrDefaultAsync<GetContactByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateContactDto updateContactDto)
        {
            var query = "update Contacts set Location = @Location, Phone = @Phone, Email = @Email where ContactId = @ContactId";
            var parameters = new DynamicParameters(updateContactDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
