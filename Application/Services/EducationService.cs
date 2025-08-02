using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using Application.DTOs.Education;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
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
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Education, EducationVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<EducationVDto>>(data: pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse<EducationVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<EducationVDto>(result);

            return new ApiResponse<EducationVDto>(data: viewModel, isSuccess: true, message: "Success");


        }

        public ApiResponse<PagedResult<EducationVDto>> Search(BaseInput input)
        {
            var query = _repository.GetAll();
            // Use Q for Filtering By Email
            if (!string.IsNullOrEmpty(input.Q))
            {
                query = query.Where(s => s.University.Contains(input.Q));
            }
            query = query.ApplySortingById(input.SortBy);
            var pagedResult = new PagedResult<Education, EducationVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<EducationVDto>>(data:pagedResult, isSuccess: true, message: "Success");
        }

        public async Task<ApiResponse> UpdateEducationAsync(EducationDto dto)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
            if (entity == null)
                return new ApiResponse(isSuccess: false, message: "Education not found.");

            _mapper.Map(dto, entity); ;
            await _repository.UpdateAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success");
        }
    }
}
