using Application.DTOs.Common;

namespace Application.DTOs.Skill
{
    public class SkillSearchInput : BaseInput
    {
        public long? SkillCategoryId { get; set; }
    }
}
