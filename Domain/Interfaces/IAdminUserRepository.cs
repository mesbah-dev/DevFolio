using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<AdminUser?> GetByIdAsync(long id);
        IQueryable<AdminUser> GetAll();
        Task AddAsync(AdminUser adminUser);
        Task UpdateAsync(AdminUser adminUser);
        Task DeleteAsync(AdminUser adminUser);
    }
}
