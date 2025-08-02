using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable enable

namespace Domain.Interfaces
{
    public interface IContactMessageRepository
    {
        Task<ContactMessage?> GetByIdAsync(long id);
        IQueryable<ContactMessage> GetAll();
        Task AddAsync(ContactMessage contactMessage);
        Task UpdateAsync(ContactMessage contactMessage);
        Task DeleteAsync(ContactMessage contactMessage);
    }
}
