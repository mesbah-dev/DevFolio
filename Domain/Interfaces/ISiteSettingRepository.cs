using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace Domain.Interfaces
{
    public interface ISiteSettingRepository
    {
        Task<SiteSetting?> GetByIdAsync(long id);
        Task<List<SiteSetting>> GetAllAsync();
        Task AddAsync(SiteSetting siteSetting);
        Task UpdateAsync(SiteSetting siteSetting);
        Task DeleteAsync(SiteSetting siteSetting);
    }
}
