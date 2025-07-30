using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface ITechnologyRepository
    {
        Task<Technology?> GetByIdAsync(long id);
        Task<List<Technology>> GetAllAsync();
        Task AddAsync(Technology technology);
        Task UpdateAsync(Technology technology);
        Task DeleteAsync(Technology technology);
    }
}
