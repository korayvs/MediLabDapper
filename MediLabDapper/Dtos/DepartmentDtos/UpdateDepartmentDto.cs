﻿namespace MediLabDapper.Dtos.DepartmentDtos
{
    public class UpdateDepartmentDto
    {
        public int DepartmentId { get; set; }
        public string? ImageUrl { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
    }
}
