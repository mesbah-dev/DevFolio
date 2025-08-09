using System.Collections.Generic;

namespace Domain.Entities
{
    public class Technology
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
