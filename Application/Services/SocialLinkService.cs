using Application.DTOs.Common;
using Application.DTOs.SocialLink;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SocialLinkService : ISocialLinkService
    {
        private readonly ISocialLinkRepository _repository;
        private readonly IMapper _mapper;
        public SocialLinkService(ISocialLinkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateSocialLinkAsync(SocialLinkDto dto)
        {
            var entity = _mapper.Map<SocialLink>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse> DeleteSocialLinkAsync(long id)
        {
            var socialLink = await _repository.GetByIdAsync(id);
            if (socialLink == null)
                return new ApiResponse(isSuccess: false, message: "SocialLink not found.");
            await _repository.DeleteAsync(socialLink);
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public ApiResponse<PagedResult<SocialLinkVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<SocialLink, SocialLinkVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SocialLinkVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse<SocialLinkVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<SocialLinkVDto>(result);

            return new ApiResponse<SocialLinkVDto>(data: viewModel, isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<SocialLinkVDto>> Search(BaseInput input)
        {
            var query = _repository.GetAll();
            //Use 'Q' for filtering by PlatformName
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.PlatformName.Contains(input.Q));
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<SocialLink, SocialLinkVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SocialLinkVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateSocialLinkAsync(SocialLinkDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "SocialLink not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
