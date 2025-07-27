using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IEducationRepository
    {
        Task<Education?> GetByIdAsync(long id);
        Task<List<Education>> GetAllAsync();
        Task AddAsync(Education education);
        Task UpdateAsync(Education education);
        Task DeleteAsync(Education education);
    }
}
