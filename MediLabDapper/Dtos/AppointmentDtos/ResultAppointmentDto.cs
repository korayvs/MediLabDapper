namespace MediLabDapper.Dtos.AppointmentDtos
{
    public class ResultAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string? Message { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public StatusAppointmentDto IsApproved { get; set; }
    }
}
