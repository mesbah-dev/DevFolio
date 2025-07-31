namespace Application.DTOs.Project
{
    public class ProjectDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string GitHubUrl { get; set; }
        public string DemoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
    }
}
