using Application.DTOs.Common;
using Application.DTOs.SkillCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISkillCategoryService
    {
        Task<ApiResponse> CreateSkillCategoryAsync(SkillCategoryDto dto);
        Task<ApiResponse> UpdateSkillCategoryAsync(SkillCategoryDto dto);
        Task<ApiResponse> DeleteSkillCategoryAsync(long id);
        Task<ApiResponse<SkillCategoryVDto>> GetByIdAsync(long id);
        Task<ApiResponse<List<SkillCategoryVDto>>> GetAllAsync(BaseInput input);

    }
}
