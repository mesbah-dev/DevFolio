using System.Collections.Generic;

namespace Application.DTOs.Project
{
    public class CreateProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string DemoUrl { get; set; }
        public bool IsActive { get; set; }
        public List<long> TechnologyIds { get; set; }
    }
}
