using Application.DTOs.Common;
using Application.DTOs.SkillCategory;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillCategoryService : ISkillCategoryService
    {
        private readonly ISkillCategoryRepository _repository;
        private readonly IMapper _mapper;
        public SkillCategoryService(ISkillCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateSkillCategoryAsync(SkillCategoryDto dto)
        {
            var entity = _mapper.Map<SkillCategory>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> DeleteSkillCategoryAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "SkillCategory not found.");
            await _repository.DeleteAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<SkillCategoryVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<SkillCategory, SkillCategoryVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SkillCategoryVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse<SkillCategoryVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<SkillCategoryVDto>(result);

            return new ApiResponse<SkillCategoryVDto>(data: viewModel, isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse<SkillCategoryVDto>> GetByIdWithSkillsAsync(long id)
        {
            var result = await _repository.GetByIdWithSkillsAsync(id);
            var viewModel = _mapper.Map<SkillCategoryVDto>(result);

            return new ApiResponse<SkillCategoryVDto>(data: viewModel, isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<SkillCategoryVDto>> Search(SkillCategorySearchInput input)
        {
            var query = _repository.GetAll();

            //Use 'Q' for filtering by Name
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.Name.Contains(input.Q));
            //Use 'SkillCategoryId' for filtering by Id
            if (input.SkillCategoryId != null)
                query = query.Where(s => s.Id == input.SkillCategoryId);

            query = query.ApplySortingById(input.SortBy);
            var pagedResult = new PagedResult<SkillCategory, SkillCategoryVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SkillCategoryVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateSkillCategoryAsync(SkillCategoryDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "SkillCategory not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
