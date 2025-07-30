using Application.DTOs.Project;
using System.Collections.Generic;

namespace Application.DTOs.Technology
{
    public class TechnologyVDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; } 
        public ICollection<ProjectVDto> Projects { get; set; }
    }
}
