namespace Application.DTOs.Skill
{
    public class SkillDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Proficiency { get; set; }
        public long SkillCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
}
