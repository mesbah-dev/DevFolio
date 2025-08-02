using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISocialLinkRepository
    {
        Task<SocialLink?> GetByIdAsync(long id);
        IQueryable<SocialLink> GetAll();
        Task AddAsync(SocialLink socialLink);
        Task UpdateAsync(SocialLink socialLink);
        Task DeleteAsync(SocialLink socialLink);
    }
}
