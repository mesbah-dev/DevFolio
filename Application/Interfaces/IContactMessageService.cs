using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IContactMessageService
    {
        Task<ApiResponse> CreateMessageAsync(ContactMessageDto dto);
        ApiResponse<PagedResult<ContactMessageVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<ContactMessageVDto>> SearchAsync(BaseInput input);
        Task<ApiResponse<ContactMessageVDto>> GetByIdAsync(long id);

    }
}
