using Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISiteSettingRepository
    {
        Task<SiteSetting?> GetByIdAsync(long id);
        IQueryable<SiteSetting> GetAll();
        Task AddAsync(SiteSetting siteSetting);
        Task UpdateAsync(SiteSetting siteSetting);
        Task DeleteAsync(SiteSetting siteSetting);
    }
}
