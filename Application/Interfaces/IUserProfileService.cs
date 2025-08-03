using Application.DTOs.Common;
using Application.DTOs.UserProfile;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<ApiResponse> CreateUserProfileAsync(UserProfileDto dto);
        Task<ApiResponse> UpdateUserProfileAsync(UserProfileDto dto);
        Task<ApiResponse> DeleteUserProfileAsync(long id);
        Task<ApiResponse<UserProfileVDto>> GetByIdAsync(long id);
        ApiResponse<PagedResult<UserProfileVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<UserProfileVDto>> Search(BaseInput input);
    }
}
