using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.BannerDtos;
using System.Data;

namespace MediLabDapper.Repositories.BannerRepositories
{
    public class BannerRepository(DapperContext _context) : IBannerRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateBannerDto createBannerDto)
        {
            var query = "insert into Banners (Icon, Title, Description) values (@Icon, @Title, @Description)";
            var parameters = new DynamicParameters(createBannerDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var query = "delete from Banners where BannerId = @BannerId";
            var parameters = new DynamicParameters();
            parameters.Add("@BannerId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultBannerDto>> GetAllAsync()
        {
            var query = "select * from Banners";
            return await _db.QueryAsync<ResultBannerDto>(query);
        }

        public async Task<GetBannerByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Banners where BannerId = @BannerId";
            var parameters = new DynamicParameters();
            parameters.Add("@BannerId", id);
            return await _db.QueryFirstOrDefaultAsync<GetBannerByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateBannerDto updateBannerDto)
        {
            var query = "update Banners set Icon = @Icon, Title = @Title, Description = @Description where BannerId = @BannerId";
            var parameters = new DynamicParameters(updateBannerDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
