using System.Collections.Generic;

namespace Domain.Entities
{
    public class Project
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string GitHubUrl { get; set; }

        public string DemoUrl { get; set; }
        public ICollection<Technology> Technologies { get; set; }
    }
}
