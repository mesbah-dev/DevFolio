using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByIdAsync(long id);
        IQueryable<UserProfile> GetAll();
        Task AddAsync(UserProfile userProfile);
        Task SaveChangesAsync();
        Task DeleteAsync(UserProfile userProfile);
    }
}
