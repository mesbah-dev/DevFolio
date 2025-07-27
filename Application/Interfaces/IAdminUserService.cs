using Application.DTOs;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminUserService
    {
        Task<ApiResponse> CreateAdminAsync(AdminUserDto dto);
    }
}
