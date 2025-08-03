using Application.DTOs.Common;
using Application.DTOs.Skill;
using Application.DTOs.SkillCategory;
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
        ApiResponse<PagedResult<SkillVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<SkillVDto>> Search(BaseInput input);
    }
}
