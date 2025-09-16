using MediLabDapper.Dtos.DepartmentDtos;
using MediLabDapper.Dtos.DoctorDtos;

namespace MediLabDapper.Dtos.AllAppointmentDtos
{
    public class AllResultAppointmentDto
    {
        public int AllAppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public ResultDepartmentDto DepartmentName { get; set; }
        public ResultDoctorDto NameSurname { get; set; }
    }
}
