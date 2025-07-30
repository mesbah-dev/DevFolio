using System.Collections.Generic;

namespace Domain.Entities
{
    public class Technology
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public ICollection<Project> Projects { get; set; }
    }
}
