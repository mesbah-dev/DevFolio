using Application.DTOs.Common;
using Application.DTOs.Skill;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SkillService : ISkillService
    {
        public Task<ApiResponse> CreateSkillAsync(SkillDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteSkillAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<List<SkillVDto>>> GetAllAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<SkillVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateSkillAsync(SkillDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
