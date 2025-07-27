using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<AdminUser?> GetByIdAsync(long id);
        Task<List<AdminUser>> GetAllAsync();
        Task AddAsync(AdminUser adminUser);
        Task UpdateAsync(AdminUser adminUser);
        Task DeleteAsync(AdminUser adminUser);
    }
}
