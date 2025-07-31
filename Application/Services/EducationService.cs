using Application.DTOs.Common;
using Application.DTOs.Education;
using Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EducationService : IEducationService
    {
        public Task<ApiResponse> CreateEducationAsync(EducationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteEducationAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<EducationVDto>>> GetAllAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<EducationDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateEducationAsync(EducationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
