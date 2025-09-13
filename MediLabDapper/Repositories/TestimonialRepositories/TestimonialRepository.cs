using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.TestimonialDtos;
using System.Data;

namespace MediLabDapper.Repositories.TestimonialRepositories
{
    public class TestimonialRepository(DapperContext _context) : ITestimonialRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(CreateTestimonialDto createTestimonialDto)
        {
            var query = "insert into Testimonials (ImageUrl, NameSurname, JobName, Review, Comment) values (@ImageUrl, @NameSurname, @JobName, @Review, @Comment)";
            var parameters = new DynamicParameters(createTestimonialDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Testimonials where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return _db.ExecuteAsync(query, parameters);
        }

        public Task<IEnumerable<ResultTestimonialDto>> GetAllAsync()
        {
            var query = "select * from Testimonials";
            return _db.QueryAsync<ResultTestimonialDto>(query);
        }

        public Task<GetTestimonialByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Testimonials where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@TestimonialId", id);
            return _db.QueryFirstOrDefaultAsync<GetTestimonialByIdDto>(query, parameters);
        }

        public Task UpdateAsync(UpdateTestimonialDto updateTestimonialDto)
        {
            var query = "update Testimonials set ImageUrl = @ImageUrl, NameSurname = @NameSurname, JobName = @JobName, Review = @Review, Comment = @Comment where TestimonialId = @TestimonialId";
            var parameters = new DynamicParameters(updateTestimonialDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
