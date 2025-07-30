using System;

namespace Application.DTOs.Experience
{
    public class ExperienceVDto
    {
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
