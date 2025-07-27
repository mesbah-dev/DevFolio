using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile?> GetByIdAsync(long id);
        Task<List<UserProfile>> GetAllAsync();
        Task AddAsync(UserProfile userProfile);
        Task UpdateAsync(UserProfile userProfile);
        Task DeleteAsync(UserProfile userProfile);
    }
}
