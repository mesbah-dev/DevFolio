using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _repository;
        private readonly IMapper _mapper;
        public AdminUserService(IAdminUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateAdminAsync(AdminUserDto dto)
        {
            var cleanedUsername = dto.Username?.Trim();
            if (string.IsNullOrWhiteSpace(cleanedUsername))
                return new ApiResponse(isSuccess: false, message: "Username can't be empty or null");

            var usernameIsUnique = await _repository.IsUsernameUniqueAsync(cleanedUsername);
            if (!usernameIsUnique)
                return new ApiResponse(isSuccess: false, message: "Username should be unique");

            var cleanedPassword = dto.NewPassword?.Trim();
            if (string.IsNullOrWhiteSpace(cleanedPassword))
                return new ApiResponse(isSuccess: false, message: "Password can't be empty or null");

            var salt = PasswordHasherHelper.GenerateSalt();
            var hashedPassword = PasswordHasherHelper.HashPassword(cleanedPassword, salt);

            var newUser = new AdminUser
            {
                CreatedAt = DateTime.Now,
                Username = cleanedUsername,
                PasswordHash = hashedPassword,
                Salt = salt
            };

            await _repository.AddAsync(newUser);

            return new ApiResponse(isSuccess: true, message: "Success");
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
