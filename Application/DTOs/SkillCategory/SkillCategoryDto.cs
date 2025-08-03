namespace Application.DTOs.SkillCategory
{
    public class SkillCategoryDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
