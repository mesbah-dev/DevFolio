using Application.DTOs.Common;
using Application.DTOs.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse> CreateProjectAsync(ProjectDto dto);
        Task<ApiResponse> UpdateProjectAsync(ProjectDto dto);
        Task<ApiResponse> DeleteProjectAsync(long id);
        Task<ApiResponse<PagedResult<List<ProjectVDto>>>> GetAllAsync(PagingInput input);
        Task<ApiResponse<PagedResult<List<ProjectVDto>>>> SearchAsync(BaseInput input);
        Task<ApiResponse<ProjectVDto>> GetByIdAsync(long id);
        Task<ApiResponse> UpdateProjectTechnologiesAsync(long projectId, List<long> technologyIds);

    }
}
