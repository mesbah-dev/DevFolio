using Application.DTOs.Common;
using Application.DTOs.UserProfile;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        public Task<ApiResponse> CreateUserProfileAsync(UserProfileDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteUserProfileAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<UserProfileVDto>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<UserProfileVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<UserProfileVDto>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateUserProfileAsync(UserProfileDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
