using System.Collections.Generic;

namespace Application.DTOs.Technology
{
    public class TechnologyDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool Deleted { get; set; }
    }
}
