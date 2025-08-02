using Application.DTOs.Common;
using Application.DTOs.UserProfile;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<ApiResponse> CreateUserProfileAsync(UserProfileDto dto);
        Task<ApiResponse> UpdateUserProfileAsync(UserProfileDto dto);
        Task<ApiResponse> DeleteUserProfileAsync(long id);
        Task<ApiResponse<UserProfileVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<UserProfileVDto>>> GetAllAsync(PagingInput input);
        Task<ApiResponse<List<UserProfileVDto>>> SearchAsync(BaseInput input);
    }
}
