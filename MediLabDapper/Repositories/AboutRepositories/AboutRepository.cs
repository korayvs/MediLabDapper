using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AboutDtos;
using System.Data;

namespace MediLabDapper.Repositories.AboutRepositories
{
    public class AboutRepository(DapperContext _context) : IAboutRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateAboutDto createAboutDto)
        {
            var query = "insert into abouts (AboutDescription, Title1, Description1, Title2, Description2, Title3, Description3) values (@AboutDescription, @Title1, @Description1, @Title2, @Description2, @Title3, @Description3)";
            var parameters = new DynamicParameters(createAboutDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from abouts where AboutId = @AboutId";
            var parameter = new DynamicParameters();
            parameter.Add("@AboutId", id);
            await _db.ExecuteAsync(query, parameter);
        }

        public async Task<IEnumerable<ResultAboutDto>> GetAllAsync()
        {
            var query = "select * from Abouts";
            return await _db.QueryAsync<ResultAboutDto>(query);
        }

        public async Task<GetAboutByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Abouts where AboutId = @AboutId";
            var parameters = new DynamicParameters();
            parameters.Add("@AboutId", id);
            return await _db.QueryFirstOrDefaultAsync<GetAboutByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateAboutDto updateAboutDto)
        {
            var query = "update Abouts set AboutDescription = @AboutDescription, Title1 = @Title1, Description1 = @Description1, Title2 = @Title2, Description2 = @Description2, Title3 = @Title3, Description3 = @Description3 where AboutId = @AboutId";
            var parameters = new DynamicParameters(updateAboutDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
