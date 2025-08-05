using Application.DTOs.Common;
using Application.DTOs.UserProfile;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly IMapper _mapper;
        public UserProfileService(IUserProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateUserProfileAsync(UserProfileDto dto)
        {
            var entity = _mapper.Map<UserProfile>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> DeleteUserProfileAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "UserProfile not found");
            await _repository.DeleteAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");

        }

        public ApiResponse<PagedResult<UserProfileVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<UserProfile, UserProfileVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<UserProfileVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse<UserProfileVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<UserProfileVDto>(result);

            return new ApiResponse<UserProfileVDto>(data: viewModel, isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<UserProfileVDto>> Search(BaseInput input)
        {
            var query = _repository.GetAll();

            // Use 'Q' for Filtering by FullName
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.FullName.Contains(input.Q));

            query = query.ApplySortingById(input.SortBy);
            var pagedResult = new PagedResult<UserProfile, UserProfileVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<UserProfileVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> UpdateUserProfileAsync(UserProfileDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "UserProfile not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
