using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISocialLinkRepository
    {
        Task<SocialLink?> GetByIdAsync(long id);
        Task<List<SocialLink>> GetAllAsync();
        Task AddAsync(SocialLink socialLink);
        Task UpdateAsync(SocialLink socialLink);
        Task DeleteAsync(SocialLink socialLink);
    }
}
