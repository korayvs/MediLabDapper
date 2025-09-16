using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.DoctorDtos;
using System.Data;
using System.Runtime.InteropServices;

namespace MediLabDapper.Repositories.DoctorRepositories
{
    public class DoctorRepository(DapperContext _context) : IDoctorRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> AllDoctorsWithDepartmentAsync()
        {
            var query = "select DoctorId, NameSurname, Doctors.ImageUrl, Doctors.Description, DepartmentName from Doctors Inner Join Departments On Doctors.DepartmentId = Departments.DepartmentId";
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query);
        }

        public async Task<IEnumerable<ResultDoctorWithDepartmentDto>> AllDoctorsWithDepartmentByIdAsync(int departmentId)
        {
            var query = "select DoctorId, NameSurname, Doctors.ImageUrl, Doctors.Description, DepartmentName from Doctors Inner Join Departments On Doctors.DepartmentId = Departments.DepartmentId where Doctors.DepartmentId = @DepartmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@DepartmentId", departmentId);
            return await _db.QueryAsync<ResultDoctorWithDepartmentDto>(query, parameters);
        }

        public async Task CreateDoctorAsync(CreateDoctorDto createDoctorDto)
        {
            var query = "insert into doctors (namesurname, ImageUrl, description, departmentId) values (@NameSurname, @ImageUrl, @Description, @DepartmentId)";
            var parameters = new DynamicParameters(createDoctorDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var query = "delete from doctors where DoctorId = @DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultDoctorDto>> GetAllDoctorsAsync()
        {
            var query = "select * from doctors";
            return await _db.QueryAsync<ResultDoctorDto>(query);
        }

        public async Task<GetDoctorByIdDto> GetDoctorByIdAsync(int id)
        {
            var query = "select * from doctors where DoctorId = @DoctorId";
            var parameters = new DynamicParameters();
            parameters.Add("@DoctorId", id);
            return await _db.QueryFirstOrDefaultAsync<GetDoctorByIdDto>(query, parameters);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorDto updateDoctorDto)
        {
            var query = "update doctors set NameSurname = @NameSurname, ImageUrl = @ImageUrl, Description = @Description, DepartmentId = @DepartmentId where DoctorId = @DoctorId";
            var parameters = new DynamicParameters(updateDoctorDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
