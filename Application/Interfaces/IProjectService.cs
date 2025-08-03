using Application.DTOs.Common;
using Application.DTOs.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService
    {
        Task<ApiResponse> CreateProjectAsync(CreateProjectDto dto);
        Task<ApiResponse> UpdateProjectAsync(ProjectDto dto);
        Task<ApiResponse> DeleteProjectAsync(long id);
        ApiResponse<PagedResult<ProjectVDto>> GetAll(PagingInput input);
        ApiResponse<PagedResult<ProjectVDto>> Search(SearchInput input);
        Task<ApiResponse<ProjectVDto>> GetByIdWithTechnologiesAsync(long id);
        Task<ApiResponse> UpdateProjectTechnologiesAsync(long projectId, List<long> technologyIds);

    }
}
