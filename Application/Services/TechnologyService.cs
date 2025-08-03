using Application.DTOs.Common;
using Application.DTOs.Technology;
using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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
        public Task<ApiResponse> CreateTechnologyAsync(TechnologyDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteTechnologyAsync(long id)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<PagedResult<TechnologyVDto>> GetAll(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TechnologyVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TechnologyDto>> GetTechnologiesByIdsAsync(List<long> ids)
        {
            var technologies = await _repository.GetByIdsAsync(ids);
            var dtos = _mapper.Map<List<TechnologyDto>>(technologies);
            return dtos;
        }

        public ApiResponse<PagedResult<TechnologyVDto>> Search(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateTechnologyAsync(TechnologyDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
