using Application.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Extensions
{
    public static class SortingExtensions
    {
        public static IQueryable<T> ApplySortingById<T>(this IQueryable<T> query, SortEnum sortby) where T : class
        {
            return sortby switch
            {
                SortEnum.New => query.OrderByDescending(e => EF.Property<long>(e, "Id")),
                SortEnum.Old => query.OrderBy(e => EF.Property<long>(e, "Id")),
                _ => query
            };
        }
    }

}
