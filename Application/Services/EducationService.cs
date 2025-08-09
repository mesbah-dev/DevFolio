using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.DTOs.Education;
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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _repository;
        private readonly IMapper _mapper;
        public EducationService(IEducationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateEducationAsync(EducationDto dto)
        {
            var entity = _mapper.Map<Education>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> DeleteEducationAsync(long id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Education not found");
            await _repository.DeleteAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }

        public ApiResponse<PagedResult<EducationVDto>> GetAll(PagingInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<EducationVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Education, EducationVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<EducationVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse<EducationVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
                return new ApiResponse<EducationVDto>(data: null, isSuccess: false, "Not found.");
            var viewModel = _mapper.Map<EducationVDto>(result);

            return new ApiResponse<EducationVDto>(data: viewModel, isSuccess: true, message: "Success");


        }

        public ApiResponse<PagedResult<EducationVDto>> Search(BaseInput input)
        {
            var result = ValidationHelper.IsValidINput(input);
            if (!result.IsValid)
                return new ApiResponse<PagedResult<EducationVDto>>(data: null, isSuccess: false, message: result.Message);

            var query = _repository.GetAll();

            // Use 'Q' for Filtering by University
            if (!string.IsNullOrEmpty(input.Q))
                query = query.Where(s => s.University.Contains(input.Q));
            
            query = query.ApplySortingById(input.SortBy);
            var pagedResult = new PagedResult<Education, EducationVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<EducationVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> UpdateEducationAsync(EducationDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Education not found.");

            _mapper.Map(dto, entity); 
            await _repository.SaveChangesAsync();
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
