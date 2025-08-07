using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.DTOs.Security;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminUserService
    {
        Task<ApiResponse> CreateAdminAsync(AdminUserDto dto);
        Task<ApiResponse> UpdateAdminAsync(UpdateAdminDto dto);
        Task<ApiResponse> DeleteAdminAsync(long id);
        ApiResponse<PagedResult<AdminUserVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<AdminUserVDto>> Search(BaseInput input);
        Task<ApiResponse<AdminUserVDto>> GetByIdAsync(long id);
        Task<ApiResponse> ChangeAdminPasswordAsync(ChangePasswordDto dto);
        Task<ApiResponse<SignInResultDto>> SignInAsync(SignInDto dto);
    }
}
