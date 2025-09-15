using Dapper;
using MediLabDapper.Context;
using MediLabDapper.Dtos.AppointmentDtos;
using System.Data;

namespace MediLabDapper.Repositories.AppointmentRepositories
{
    public class AppointmentRepository(DapperContext _context) : IAppointmentRepository
    {
        private readonly IDbConnection _db = _context.CreateConnection();

        public Task<IEnumerable<ResultAppointmentDto>> AppointmentWithDocWithDepart()
        {
            var query = "select AppointmentId, FullName, Email, PhoneNumber, Date, Time, NameSurname As DoctorName, DepartmentName, IsApproved from Appointments Inner Join Doctors On Doctors.DoctorId = Appointments.DoctorId Inner Join Departments On Departments.DepartmentId = Appointments.DepartmentId";
            return _db.QueryAsync<ResultAppointmentDto>(query);
        }

        public Task<IEnumerable<ResultAppointmentDto>> AvailableAppointmentWithDocWithDepart(int doctorId, int departmentId)
        {
            var query = "select AppointmentId, FullName, Email, PhoneNumber, Date, Time, NameSurname As DoctorName, DepartmentName, IsApproved from Appointments Inner Join Doctors On Doctors.DoctorId = Appointments.DoctorId Inner Join Departments On Departments.DepartmentId = Appointments.DepartmentId where Appointments.DoctorId = @doctorId And Appointments.DepartmentId = @departmentId And (Appointments.FullName Is Null Or Appointments.FullName = '')";
            var parameters = new DynamicParameters();
            parameters.Add("@doctorId", doctorId);
            parameters.Add("@departmentId", departmentId);
            return _db.QueryAsync<ResultAppointmentDto>(query, parameters);
        }

        public async Task CreateAsync(CreateAppointmentDto createAppointmentDto)
        {
            var query = "insert into Appointments (FullName, Email, PhoneNumber, Date, Time, Message, DoctorId, DepartmentId, IsApproved) values (@FullName, @Email, @PhoneNumber, @Date, @Time, @Message, @DoctorId, @DepartmentId, @IsApproved)";
            var parameters = new DynamicParameters(createAppointmentDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task DeleteAsync(int id)
        {
            var query = "delete from Appointments where AppointmentId = @AppointmentId";
            var parameter = new DynamicParameters();
            parameter.Add("@AppointmentId", id);
            return _db.ExecuteAsync(query, parameter);
        }

        public Task<IEnumerable<ResultAppointmentDto>> GetAllAsync()
        {
            var query = "select * from Appointments";
            return _db.QueryAsync<ResultAppointmentDto>(query);
        }

        public Task<GetAppointmentByIdDto> GetByIdAsync(int id)
        {
            var query = "select * from Appointments where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", id);
            return _db.QueryFirstOrDefaultAsync<GetAppointmentByIdDto>(query, parameters);
        }

        public async Task UpdateAppointmentUserInfo(CreateAppointmentDto dto, int appointmentId)
        {
            var query = @"update Appointments set FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Message = @Message, IsApproved = 0 where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters();
            parameters.Add("@AppointmentId", appointmentId);
            parameters.Add("@FullName", dto.FullName);
            parameters.Add("@Email", dto.Email);
            parameters.Add("@PhoneNumber", dto.PhoneNumber);
            parameters.Add("@Message", dto.Message);
            await _db.ExecuteAsync(query, parameters);
        }

        public Task UpdateAsync(UpdateAppointmentDto updateAppointmentDto)
        {
            var query = "update Appointments set FullName = @FullName, Email = @Email, PhoneNumber = @PhoneNumber, Date = @Date, Time = @Time, Message = @Message, DoctorId = @DoctorId, DepartmentId = @DepartmentId, IsApproved = @IsApproved where AppointmentId = @AppointmentId";
            var parameters = new DynamicParameters(updateAppointmentDto);
            return _db.ExecuteAsync(query, parameters);
        }
    }
}
