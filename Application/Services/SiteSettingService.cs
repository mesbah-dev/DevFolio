using Application.DTOs.Common;
using Application.DTOs.Education;
using Application.DTOs.SiteSetting;
using Application.Extensions;
using Application.Helpers;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SiteSettingService : ISiteSettingService
    {
        private readonly ISiteSettingRepository _repository;
        private readonly IMapper _mapper;
        public SiteSettingService(ISiteSettingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateSiteSettingAsync(SiteSettingDto dto)
        {
            var entity = _mapper.Map<SiteSetting>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> DeleteSiteSettingAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "SiteSetting not found.");

            await _repository.DeleteAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<SiteSettingVDto>> GetAll(PagingInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<SiteSettingVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<SiteSetting, SiteSettingVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SiteSettingVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse<SiteSettingVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return new ApiResponse<SiteSettingVDto>(data: null, isSuccess: false, "Not found.");

            var viewModel = _mapper.Map<SiteSettingVDto>(result);

            return new ApiResponse<SiteSettingVDto>(data: viewModel, isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<SiteSettingVDto>> Search(BaseInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<SiteSettingVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            // Use 'Q' for filtering by SiteTitle
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.SiteTitle.Contains(input.Q));

            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<SiteSetting, SiteSettingVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SiteSettingVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> UpdateSiteSettingAsync(SiteSettingDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "SiteSetting not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success.");

        }
    }
}
