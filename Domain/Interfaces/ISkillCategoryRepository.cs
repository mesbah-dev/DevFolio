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
        IQueryable<SkillCategory> GetAll();
        Task AddAsync(SkillCategory skillCategory);
        Task UpdateAsync(SkillCategory skillCategory);
        Task DeleteAsync(SkillCategory skillCategory);
    }
}
