using System.Collections.Generic;

namespace Domain.Entities
{
    public class SkillCategory
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Skill> Skills { get; set; }
    }
}
