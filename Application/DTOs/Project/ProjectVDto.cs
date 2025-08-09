using Application.DTOs.Technology;
using System.Collections.Generic;

namespace Application.DTOs.Project
{
    public class ProjectVDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string DemoUrl { get; set; }

        public List<TechnologyVDto> Technologies { get; set; }
    }
}
