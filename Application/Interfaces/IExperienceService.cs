using Application.DTOs.Common;
using Application.DTOs.Experience;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExperienceService
    {
        Task<ApiResponse> CreateExperienceAsync(ExperienceDto dto);
        Task<ApiResponse> UpdateExperienceAsync(ExperienceDto dto);
        Task<ApiResponse> DeleteExperienceAsync(long id);
        Task<ApiResponse<PagedResult<List<ExperienceVDto>>>> GetAllAsync(BaseInput input);
        Task<ApiResponse<ExperienceDto>> GetByIdAsync(long id);
    }
}
