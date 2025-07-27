using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISkillRepository
    {
        Task<Skill?> GetByIdAsync(long id);
        Task<List<Skill>> GetAllAsync();
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
    }
}
