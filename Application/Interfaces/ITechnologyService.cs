using Application.DTOs.Common;
using Application.DTOs.Technology;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITechnologyService
    {
        Task<ApiResponse> CreateTechnologyAsync(TechnologyDto dto);
        Task<ApiResponse> UpdateTechnologyAsync(TechnologyDto dto);
        Task<ApiResponse> DeleteTechnologyAsync(long id);
        Task<ApiResponse<TechnologyVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<TechnologyVDto>>> GetAllAsync(PagingInput input);
        Task<ApiResponse<List<TechnologyVDto>>> SearchAsync(BaseInput input);
    }
}
