using Application.DTOs.Skill;
using System.Collections.Generic;

namespace Application.DTOs.SkillCategory
{
    public class SkillCategoryVDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; } 
        public bool Deleted { get; set; }

        public List<SkillVDto> Skills { get; set; }
    }
}
