using System.Collections.Generic;

namespace Application.DTOs.SkillCategory
{
    public class CreateSkillCategoryDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public List<long> SkillIds { get; set; }
    }
}
