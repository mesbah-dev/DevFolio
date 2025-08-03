using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(long id);
        Task<Project?> GetByIdWithTechnologiesAsync(long id);
        IQueryable<Project> GetAll();
        Task AddAsync(Project project);
        Task SaveChangesAsync();
        Task DeleteAsync(Project project);
    }
}
