using Application.DTOs.Common;

namespace Application.DTOs.Project
{
    public class SearchInput : BaseInput
    {
        public long? ProjectId { get; set; }
        public long? TechnologyId { get; set; }
    }
}
