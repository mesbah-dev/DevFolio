namespace Domain.Entities
{
    public class Skill
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Proficiency { get; set; }

        public long SkillCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public bool Deleted { get; set; } = false;

        public SkillCategory SkillCategory { get; set; }
    }
}
