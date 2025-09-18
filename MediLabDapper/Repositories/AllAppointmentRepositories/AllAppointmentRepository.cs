using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AllAppointmentDtos;
using System.Data;

namespace MediLabDapper.Repositories.AllAppointmentRepositories
{
    public class AllAppointmentRepository(DapperContext _context) : IAllAppointmentRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public async Task CreateAsync(AllCreateAppointmentDto allCreateAppointmentDto)
        {
            var query = "insert into Appointments (Date, Time, DoctorId, DepartmentId) values (@Date, @Time, @DoctorId, @DepartmentId)";
            var parameters = new DynamicParameters(allCreateAppointmentDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Appointments where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _db.ExecuteAsync(query, parameters);
        }

        public Task<IEnumerable<AllResultAppointmentDto>> GetAllAsync()
        {
            var query = "select * from Appointments";
            return _db.QueryAsync<AllResultAppointmentDto>(query);
        }

        public Task<AllGetAppointmentByIdDto> GetByIdAsync(int id)
        {
            var query = "select AppointmentId, Date, Time, Appointments.DoctorId, Appointments.DepartmentId, NameSurname, DepartmentName from Appointments Inner Join Doctors On Doctors.DoctorId = Appointments.DoctorId Inner Join Departments On Departments.DepartmentId = Appointments.DepartmentId where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _db.QueryFirstOrDefaultAsync<AllGetAppointmentByIdDto>(query, parameters);
        }

        public Task UpdateAsync(AllUpdateAppointmentDto allUpdateAppointmentDto)
        {
            var query = "update Appointments set Date = @Date, Time = @Time, DoctorId = @DoctorId, DepartmentId = @DepartmentId where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters(allUpdateAppointmentDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
