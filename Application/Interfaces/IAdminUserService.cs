using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminUserService
    {
        Task<ApiResponse> CreateAdminAsync(AdminUserDto dto);
        Task<ApiResponse> UpdateAdminAsync(AdminUserDto dto);
        Task<ApiResponse> DeleteAdminAsync(long id);
        Task<ApiResponse<PagedResult<List<AdminUserVDto>>>> GetAllAsync(BaseInput input);
        Task<ApiResponse<AdminUserDto>> GetByIdAsync(long id);
    }
}
