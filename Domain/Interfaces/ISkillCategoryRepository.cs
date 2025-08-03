using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISkillCategoryRepository
    {
        Task<SkillCategory?> GetByIdAsync(long id);
        Task<SkillCategory?> GetByIdWithSkillsAsync(long id);
        IQueryable<SkillCategory> GetAll();
        Task AddAsync(SkillCategory skillCategory);
        Task SaveChangesAsync();
        Task DeleteAsync(SkillCategory skillCategory);
    }
}
