using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.DTOs.Security;
using Application.Extensions;
using Application.Helpers;
using Application.Interfaces;
using Application.Interfaces.Security;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IJwtSettingsProvider _jwtSetting;
        public AdminUserService(IAdminUserRepository repository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator, IJwtSettingsProvider jwtSetting)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
            _jwtSetting = jwtSetting;
        }

        public async Task<ApiResponse> ChangeAdminPasswordAsync(ChangePasswordDto dto)
        {
            var currentPassword = dto.CurrentPassword?.Trim();
            var newPassword = dto.NewPassword?.Trim();

            if (string.IsNullOrWhiteSpace(currentPassword))
                return new ApiResponse(isSuccess: false,message : "Current password cannot be empty.");

            if (string.IsNullOrWhiteSpace(newPassword))
                return new ApiResponse(isSuccess: false, message: "New password cannot be empty.");


            var admin = await _repository.GetByIdAsync(dto.AdminId);
            if (admin == null)
                return new ApiResponse(isSuccess: false, message: "Admin not found.");

            if (PasswordHasherHelper.VerifyPassword(newPassword, admin.Salt, admin.PasswordHash))
                return new ApiResponse(isSuccess: false, message: "New password cannot be same as current password.");


            var isPasswordValid = PasswordHasherHelper.VerifyPassword(
                password: currentPassword,
                salt: admin.Salt,
                hashedPassword: admin.PasswordHash
            );

            if (!isPasswordValid)
                return new ApiResponse(isSuccess: false, message: "Current password is incorrect.");

            var (newHashedPassword, newSalt) = GenerateHashedPassword(newPassword);

            admin.Salt = newSalt;
            admin.PasswordHash = newHashedPassword;

            await _repository.SaveChangesAsync();

            return new ApiResponse(isSuccess: true, message: "Success.");

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

            var (hashedPassword, salt) = GenerateHashedPassword(cleanedPassword);

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

        private (string hashedPassword, string salt) GenerateHashedPassword(string plainPassword)
        {
            var salt = PasswordHasherHelper.GenerateSalt();
            var hashedPassword = PasswordHasherHelper.HashPassword(plainPassword, salt);
            return (hashedPassword, salt);
        }

        public async Task<ApiResponse> DeleteAdminAsync(long id)
        {
            var admin = await _repository.GetByIdAsync(id);
            if (admin == null)
                return new ApiResponse(isSuccess: false, message: "Admin not found.");
            var totalCount = await _repository.CountAsync();
            if (totalCount <= 1)
                return new ApiResponse(isSuccess: false, message: "Cannot delete the last admin.");

            await _repository.DeleteAsync(admin);
            return new ApiResponse(isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<AdminUserVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<AdminUser, AdminUserVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<AdminUserVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse<AdminUserVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<AdminUserVDto>(result);

            return new ApiResponse<AdminUserVDto>(data: viewModel, isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<AdminUserVDto>> Search(BaseInput input)
        {
            var query = _repository.GetAll();
            //Use 'Q' for filtering by Username
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.Username.Contains(input.Q));

            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<AdminUser, AdminUserVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<AdminUserVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateAdminAsync(UpdateAdminDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Username))
                return new ApiResponse(isSuccess: false, message: "Username cannot be empty.");

            var cleanedUsername = dto.Username.Trim();

            var admin = await _repository.GetByIdAsync(dto.Id);
            if (admin == null)
                return new ApiResponse(isSuccess: false, message: "Admin not found.");

            if (admin.Username != cleanedUsername)
            {
                var isUnique = await _repository.IsUsernameUniqueAsync(cleanedUsername);

                if (!isUnique)
                    return new ApiResponse(isSuccess: false, message: "Username alreade exsits.");
            }

            admin.Username = cleanedUsername;
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse<SignInResultDto>> SignInAsync(SignInDto dto)
        {
            var username = dto.Username?.Trim() ?? string.Empty;
            var password = dto.Password?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return new ApiResponse<SignInResultDto>(data: null,isSuccess: false,message: "Username and password are required.");

            var admin = await _repository.GetByUsernameAsync(username);
            if (admin == null)
                return new ApiResponse<SignInResultDto>(data: null,isSuccess: false,message: "Invalid credentials.");

            var passwordIsValid = PasswordHasherHelper.VerifyPassword(password, admin.Salt, admin.PasswordHash);
            if (!passwordIsValid)
                return new ApiResponse<SignInResultDto>(data: null, isSuccess: false, message: "Invalid credentials.");

            var payload = new JwtTokenPayload()
            {
                UserId = admin.Id,
                Username = admin.Username,
            };

            var token = _jwtTokenGenerator.GenerateToken(payload);
            var expiresInMinutes = _jwtSetting.ExpiresInMinutes;
            var signInResultdto = new SignInResultDto()
            {
                Token = token,
                Username = admin.Username,
                Expiration = DateTime.UtcNow.AddMinutes(expiresInMinutes)
            };

            return new ApiResponse<SignInResultDto>(data: signInResultdto, isSuccess: true, message: "Success.");

        }
    }
}
