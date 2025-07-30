using System;

namespace Application.DTOs.Experience
{
    public class ExperienceDto
    {
        public long Id { get; set; }

        public string CompanyName { get; set; }

        public string JobTitle { get; set; }

        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; } 
        public bool Deleted { get; set; } 
    }
}
