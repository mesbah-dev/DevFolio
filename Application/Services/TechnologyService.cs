using Application.DTOs.Common;
using Application.DTOs.Technology;
using Application.Extensions;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _repository;
        private readonly IMapper _mapper;
        public TechnologyService(ITechnologyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateTechnologyAsync(TechnologyDto dto)
        {
            var entity = _mapper.Map<Technology>(dto);
            await _repository.AddAsync(entity);
            return new ApiResponse(isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> DeleteTechnologyAsync(long id)
        {
            var technology = await _repository.GetByIdAsync(id);
            if (technology == null)
                return new ApiResponse(false, message: "Technology not found.");
            await _repository.DeleteAsync(technology);
            return new ApiResponse(isSuccess: true, message: "Success.");
        }

        public ApiResponse<PagedResult<TechnologyVDto>> GetAll(PagingInput input)
        {
            var query = _repository.GetAll();
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Technology, TechnologyVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<TechnologyVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse<TechnologyVDto>> GetByIdAsync(long id)
        {
            var result = await _repository.GetByIdAsync(id);
            var viewModel = _mapper.Map<TechnologyVDto>(result);
            return new ApiResponse<TechnologyVDto>(data: viewModel, isSuccess: true, message: "Success.");
        }

        public async Task<List<TechnologyDto>> GetTechnologiesByIdsAsync(List<long> ids)
        {
            var technologies = await _repository.GetByIdsAsync(ids);
            var dtos = _mapper.Map<List<TechnologyDto>>(technologies);
            return dtos;
        }

        public ApiResponse<PagedResult<TechnologyVDto>> Search(BaseInput input)
        {
            var query = _repository.GetAll();
            //Use 'Q' for filtering by Name
            if (!String.IsNullOrEmpty(input.Q))
                query = query.Where(t => t.Name.Contains(input.Q));
            //Use 'Active' for filtering by active status
            if (input.Active.HasValue)
                query = query.Where(t => t.IsActive == input.Active.Value);
            query = query.ApplySortingById(input.SortBy);

            var pagedResult = new PagedResult<Technology, TechnologyVDto>(input, query, _mapper);
            return new ApiResponse<PagedResult<TechnologyVDto>>(data: pagedResult, isSuccess: true, message: "Success.");
        }

        public async Task<ApiResponse> UpdateTechnologyAsync(TechnologyDto dto)
        {
            var technology = await _repository.GetByIdAsync(dto.Id);
            if (technology == null)
                return new ApiResponse(isSuccess: false, message: "Technology not found.");
            _mapper.Map(dto, technology);
            await _repository.SaveChangesAsync();
            return new ApiResponse(true, "Success");

        }
    }
}
