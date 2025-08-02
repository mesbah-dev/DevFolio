using Application.DTOs.Common;
using Application.DTOs.Technology;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TechnologyService : ITechnologyService
    {
        public Task<ApiResponse> CreateTechnologyAsync(TechnologyDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteTechnologyAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<TechnologyVDto>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<TechnologyVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<TechnologyVDto>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateTechnologyAsync(TechnologyDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
