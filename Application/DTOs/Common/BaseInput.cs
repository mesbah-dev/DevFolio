using Application.Enums;

namespace Application.DTOs.Common
{
    public class BaseInput
    {
        public BaseInput()
        {
            PageIndex = 1;
            PageSize = 20;
            SortBy = SortEnum.New;

        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Q { get; set; }
        public SortEnum SortBy { get; set; }
        public bool? Active { get; set; }
    }
}
