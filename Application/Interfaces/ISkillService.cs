using Application.DTOs.Common;
using Application.DTOs.Skill;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISkillService
    {
        Task<ApiResponse> CreateSkillAsync(SkillDto dto);
        Task<ApiResponse> UpdateSkillAsync(SkillDto dto);
        Task<ApiResponse> DeleteSkillAsync(long id);
        Task<ApiResponse<SkillVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<SkillVDto>>> GetAllAsync(PagingInput input);
        Task<ApiResponse<List<SkillVDto>>> SearchAsync(BaseInput input);
    }
}
