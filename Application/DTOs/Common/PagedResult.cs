using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Collections.Generic;
using System.Linq;

namespace Application.DTOs.Common
{
    public class PagedResult<TDto> : PagingInput
    {
        public PagedResult(PagingInput input)
        {
            base.PageIndex = input.PageIndex;
            base.PageSize = input.PageSize;
            base.SortBy = input.SortBy;
        }
        public List<TDto> Items { get; set; } = new();
        public int TotalCount { get; set; }
    }

    public class PagedResult<TEntity, TDto> : PagedResult<TDto>
    {
        public PagedResult(PagingInput input, IQueryable<TEntity> query, IMapper mapper) : base(input)
        {
            base.TotalCount = query.Count();
            var skip = (input.PageIndex - 1) * (input.PageSize);
            query = query.Skip(skip).Take(input.PageSize);
            base.Items = query.ProjectTo<TDto>(mapper.ConfigurationProvider).ToList();
        }
    }
}
