using Application.DTOs.Common;
using Application.DTOs.Education;
using Application.DTOs.Experience;
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
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _repository;
        private readonly IMapper _mapper;
        public ExperienceService(IExperienceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateExperienceAsync(ExperienceDto dto)
        {
            var entity = _mapper.Map<Experience>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> DeleteExperienceAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Experience not found");
            await _repository.DeleteAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<ExperienceVDto>> GetAll(PagingInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<ExperienceVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Experience, ExperienceVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ExperienceVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse<ExperienceVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return new ApiResponse<ExperienceVDto>(data: null, isSuccess: false, message: "Not found");

            var viewModel = _mapper.Map<ExperienceVDto>(result);

            return new ApiResponse<ExperienceVDto>(data: viewModel, isSuccess: true, message: "Success");

        }

        public ApiResponse<PagedResult<ExperienceVDto>> Search(BaseInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<ExperienceVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            //Use 'Q' for filternig by JobTitle
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.JobTitle.Contains(input.Q));
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Experience, ExperienceVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<ExperienceVDto>>(data: pagedResult, isSuccess: true, message: "Success");

        }

        public async Task<ApiResponse> UpdateExperienceAsync(ExperienceDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Experience not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
