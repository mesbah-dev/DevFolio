using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContactMessageService
    {
        Task<ApiResponse> CreateMessageAsync(ContactMessageDto dto);
        Task<ApiResponse<PagedResult<ContactMessageDto>>> GetAllAsync(BaseInput input);
        Task<ApiResponse<ContactMessageDto>> GetByIdAsync(long id);

    }
}
