using Application.Enums;

namespace Application.DTOs.Common
{
    public class PagingInput
    {
        public PagingInput()
        {
            PageIndex = 1;
            PageSize = 20;
            SortBy = SortEnum.New;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public SortEnum SortBy { get; set; }
    }
}
