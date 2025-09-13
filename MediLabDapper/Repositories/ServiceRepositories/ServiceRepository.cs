using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.ServiceDtos;
using System.Data;

namespace MediLabDapper.Repositories.ServiceRepositories
{
    public class ServiceRepository(DapperContext _context) : IServiceRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateServiceDto createServiceDto)
        {
            var query = "insert into Services (ServiceIcon, Title, Description) values (@ServiceIcon, @Title, @Description)";
            var parameters = new DynamicParameters(createServiceDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from Services where ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultServiceDto>> GetAllAsync()
        {
            var query = "select * from Services";
            return await _db.QueryAsync<ResultServiceDto>(query);
        }

        public async Task<GetServiceByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Services where ServiceId = @ServiceId";
            var parameters = new DynamicParameters();
            parameters.Add("@ServiceId", id);
            return await _db.QueryFirstOrDefaultAsync<GetServiceByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateServiceDto updateServiceDto)
        {
            var query = "update Services set ServiceIcon = @ServiceIcon, Title = @Title, Description = @Description where ServiceId = @ServiceId";
            var parameters = new DynamicParameters(updateServiceDto);
            return _db.ExecuteAsync(query,parameters);
        }
    }
}
