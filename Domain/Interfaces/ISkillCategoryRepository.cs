using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISkillCategoryRepository
    {
        Task<SkillCategory?> GetByIdAsync(long id);
        Task<List<SkillCategory>> GetAllAsync();
        Task AddAsync(SkillCategory skillCategory);
        Task UpdateAsync(SkillCategory skillCategory);
        Task DeleteAsync(SkillCategory skillCategory);
    }
}
