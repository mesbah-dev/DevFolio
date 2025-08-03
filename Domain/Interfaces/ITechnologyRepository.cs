using Domain.Entities;
using System.Collections.Generic;
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
        Task SaveChangesAsync();
        Task DeleteAsync(Technology technology);
        Task<List<Technology>> GetByIdsAsync(List<long> ids);
    }
}
