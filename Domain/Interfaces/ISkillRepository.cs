using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISkillRepository
    {
        Task<Skill?> GetByIdAsync(long id);
        IQueryable<Skill> GetAll();
        Task AddAsync(Skill skill);
        Task UpdateAsync(Skill skill);
        Task DeleteAsync(Skill skill);
    }
}
