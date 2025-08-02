using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface ITechnologyRepository
    {
        Task<Technology?> GetByIdAsync(long id);
        IQueryable<Technology> GetAll();
        Task AddAsync(Technology technology);
        Task UpdateAsync(Technology technology);
        Task DeleteAsync(Technology technology);
    }
}
