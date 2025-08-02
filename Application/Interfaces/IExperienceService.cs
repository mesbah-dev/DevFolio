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
        ApiResponse<PagedResult<ExperienceVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<ExperienceVDto>> Search(BaseInput input);
        Task<ApiResponse<ExperienceVDto>> GetByIdAsync(long id);
    }
}
