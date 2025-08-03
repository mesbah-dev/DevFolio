using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IExperienceRepository
    {
        Task<Experience?> GetByIdAsync(long id);
        IQueryable<Experience> GetAll();
        Task AddAsync(Experience experience);
        Task SaveChangesAsync();
        Task DeleteAsync(Experience experience);
    }
}
