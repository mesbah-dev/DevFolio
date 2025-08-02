using Application.DTOs.Common;
using Application.DTOs.Experience;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExperienceService : IExperienceService
    {
        public Task<ApiResponse> CreateExperienceAsync(ExperienceDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteExperienceAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<List<ExperienceVDto>>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ExperienceDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<List<ExperienceVDto>>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateExperienceAsync(ExperienceDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
