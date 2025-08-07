using Application.Enums;

namespace Application.DTOs.Common
{
    public class BaseInput : PagingInput
    {
        /// <summary>
        /// A general search keyword used to filter results (e.g., by name or title).
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// Filter by active status. If null, no filtering is applied.
        /// </summary>
        public bool? Active { get; set; }
    }
}
