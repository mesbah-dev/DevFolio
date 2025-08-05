using Application.DTOs.Common;
using Application.DTOs.Skill;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;
        private readonly ISkillCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public SkillService(ISkillRepository repository, ISkillCategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateSkillAsync(SkillDto dto)
        {
            if (dto.SkillCategoryId == 0)
                return new ApiResponse(isSuccess: false, message: "CategoryId is required.");
            var skillCategory = await _categoryRepository.GetByIdAsync(dto.SkillCategoryId);
            if (skillCategory == null || !skillCategory.IsActive)
                return new ApiResponse(isSuccess: false, message: "Category not found or inactive.");
            var entity = _mapper.Map<Skill>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse> DeleteSkillAsync(long id)
        {
            var skill = await _repository.GetByIdAsync(id);
            if (skill == null)
                return new ApiResponse(isSuccess: false, message: "Skill not found.");
            await _repository.DeleteAsync(skill);
            return new ApiResponse(isSuccess: true, message: "Success.");

        }

        public ApiResponse<PagedResult<SkillVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Skill, SkillVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SkillVDto>>(data: pagedResult, isSuccess: true, message: "Success.");

        }

        public async Task<ApiResponse<SkillVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<SkillVDto>(result);

            return new ApiResponse<SkillVDto>(data: viewModel, isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<SkillVDto>> Search(SkillSearchInput input)
        {
            var query = _repository.GetAll();
            //Use 'Q' for filtering by Name
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.Name.Contains(input.Q));
            //Use 'SkillCategoryId' for filternig by SkillCategory
            if (input.SkillCategoryId != null)
                query = query.Where(s => s.SkillCategoryId == input.SkillCategoryId);
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Skill, SkillVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<SkillVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateSkillAsync(SkillDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Skill not found.");

            _mapper.Map(dto, entity);
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
