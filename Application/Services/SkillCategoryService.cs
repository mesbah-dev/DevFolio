using Application.DTOs.Common;
using Application.DTOs.SkillCategory;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillCategoryService : ISkillCategoryService
    {
        public Task<ApiResponse> CreateSkillCategoryAsync(SkillCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteSkillCategoryAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SkillCategoryVDto>>> GetAllAsync(PagingInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SkillCategoryVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SkillCategoryVDto>>> SearchAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateSkillCategoryAsync(SkillCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
