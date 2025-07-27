using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface IProjectTechnologyRepository
    {
        Task<List<ProjectTechnology>> GetAllByProjectIdAsync(long projectId);
        Task<ProjectTechnology?> GetByIdAsync(long id);
        Task<List<ProjectTechnology>> GetAllAsync();
        Task AddAsync(ProjectTechnology projectTechnology);
        Task UpdateAsync(ProjectTechnology projectTechnology);
        Task DeleteAsync(ProjectTechnology projectTechnology);
    }
}
