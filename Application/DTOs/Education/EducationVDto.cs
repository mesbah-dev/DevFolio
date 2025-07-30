using System;

namespace Application.DTOs.Education
{
    public class EducationVDto
    {
        public string Degree { get; set; }
        public string University { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
