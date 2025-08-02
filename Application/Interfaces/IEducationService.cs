using Application.DTOs.Common;
using Application.DTOs.Education;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEducationService
    {
        Task<ApiResponse> CreateEducationAsync(EducationDto dto);
        Task<ApiResponse> UpdateEducationAsync(EducationDto dto);
        Task<ApiResponse> DeleteEducationAsync(long id);
        ApiResponse<PagedResult<EducationVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<EducationVDto>> Search(BaseInput input);
        Task<ApiResponse<EducationVDto>> GetByIdAsync(long id);
    }
}
