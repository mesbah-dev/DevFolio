using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IExperienceRepository
    {
        Task<Experience?> GetByIdAsync(long id);
        Task<List<Experience>> GetAllAsync();
        Task AddAsync(Experience experience);
        Task UpdateAsync(Experience experience);
        Task DeleteAsync(Experience experience);
    }
}
