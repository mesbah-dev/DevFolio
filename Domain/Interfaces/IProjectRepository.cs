using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project?> GetByIdAsync(long id);
        Task<List<Project>> GetAllAsync();
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(Project project);
    }
}
