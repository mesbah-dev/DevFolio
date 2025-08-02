using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminUserService : IAdminUserService
    {
        public Task<ApiResponse> CreateAdminAsync(AdminUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteAdminAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<List<AdminUserVDto>>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<AdminUserDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<List<AdminUserVDto>>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateAdminAsync(AdminUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
