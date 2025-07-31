using Application.DTOs.Common;
using Application.DTOs.Project;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProjectService : IProjectService
    {
        public Task<ApiResponse> CreateProjectAsync(ProjectDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteProjectAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<PagedResult<List<ProjectVDto>>>> GetAllAsync(BaseInput input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse<ProjectVDto>> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateProjectAsync(ProjectDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> UpdateProjectTechnologiesAsync(long projectId, List<long> technologyIds)
        {
            throw new NotImplementedException();
        }
    }
}
