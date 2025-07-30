using System;

namespace Application.DTOs.Education
{
    public class EducationDto
    {
        public long Id { get; set; }
        public string Degree { get; set; }
        public string University { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
