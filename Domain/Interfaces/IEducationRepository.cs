using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IEducationRepository
    {
        Task<Education?> GetByIdAsync(long id);
        IQueryable<Education> GetAll();
        Task AddAsync(Education education);
        Task UpdateAsync(Education education);
        Task DeleteAsync(Education education);
    }
}
