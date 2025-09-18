namespace MediLabDapper.Dtos.AllAppointmentDtos
{
    public class AllUpdateAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }
    }
}
