using Application.DTOs.Common;
using Application.DTOs.Education;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    internal interface IEducationService
    {
        Task<ApiResponse> CreateEducationAsync(EducationDto dto);
        Task<ApiResponse> UpdateEducationAsync(EducationDto dto);
        Task<ApiResponse> DeleteEducationAsync(long id);
        Task<ApiResponse<PagedResult<EducationVDto>>> GetAllAsync(BaseInput input);
        Task<ApiResponse<EducationDto>> GetByIdAsync(long id);
    }
}
