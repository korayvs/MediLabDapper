using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DepartmentDtos;

namespace MediLabDapper.Repositories.DepartmentRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DapperContext _context;

        public DepartmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            string query = "insert into departments (ImageUrl, departmentname, description) values (@ImageUrl, @DepartmentName, @Description)";
            var parameters = new DynamicParameters();
            parameters.Add("@ImageUrl", createDepartmentDto.ImageUrl);
            parameters.Add("@DepartmentName", createDepartmentDto.DepartmentName);
            parameters.Add("@Description", createDepartmentDto.Description);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            string query = "delete from departments where DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", id);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query,parameters);
        }

        public async Task<IEnumerable<ResultDepartmentDto>> GetAllDepartmentsAsync()
        {
            string query = "select * from departments";
            var connection = _context.CreateConnection();

            return await connection.QueryAsync<ResultDepartmentDto>(query);
        }

        public async Task<GetDepartmentByIdDto> GetDepartmentByIdAsync(int id)
        {
            var query = "select * from departments where DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", id);
            var connection = _context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<GetDepartmentByIdDto>(query, parameters);
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentDto updateDepartmentDto)
        {
            string query = "update departments set ImageUrl = @ImageUrl, DepartmentName = @DepartmentName, Description = @Description where DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters(updateDepartmentDto);
            var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
