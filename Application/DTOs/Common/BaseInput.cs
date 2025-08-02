using Application.Enums;

namespace Application.DTOs.Common
{
    public class BaseInput : PagingInput
    {
        public string Q { get; set; }
        public bool? Active { get; set; }
    }
}
