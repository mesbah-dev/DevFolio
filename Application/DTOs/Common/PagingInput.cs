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
        /// <summary>
        /// The page number to retrieve (starting from 1,default 1).
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// The number of items to include per page.(default 20).
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The sorting order for the result set.(default New)
        /// </summary>
        public SortEnum SortBy { get; set; }
    }
}
