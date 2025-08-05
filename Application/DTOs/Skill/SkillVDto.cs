namespace Application.DTOs.Skill
{
    public class SkillVDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Proficiency { get; set; }
        public long SkillCategoryId { get; set; }
    }
}
