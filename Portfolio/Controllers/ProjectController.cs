using Application.DTOs.Common;
using Application.DTOs.Project;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Project management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Retrieves the details of a specific project by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the project.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the project data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _projectService.GetByIdWithTechnologiesAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of project.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of project based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _projectService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of project.
        /// </summary>
        /// <param name="input">
        /// Filtering and paging options including:
        /// <list type="bullet">
        /// <item><description><c>ProjectId</c>: Filters by project ID.</description></item>
        /// <item><description><c>TechnologyId</c>: Filters by Technology ID.</description></item>
        /// <item><description><c>Q</c>: A general search term (e.g., name or title).</description></item>
        /// <item><description><c>Active</c>: Filters by active/inactive status (optional).</description></item>
        /// <item><description><c>PageIndex</c>, <c>PageSize</c>: Paging options.</description></item>
        /// <item><description><c>SortBy</c>: Sorting option (e.g., New, Old).</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the filtered list of project.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] SearchInput input)
        {
            var result = _projectService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new project using the provided project data.
        /// </summary>
        /// <param name="dto">
        /// A <see cref="CreateProjectDto"/> containing the project's title, description, image, GitHub and demo URLs, active status, and associated technologies(required).
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the operation was successful, along with an optional message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
        {
            var result = await _projectService.CreateProjectAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing project with the provided information.
        /// </summary>
        /// <param name="dto">
        /// A <see cref="ProjectDto"/> containing the updated project details.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an optional message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ProjectDto dto)
        {
            var result = await _projectService.UpdateProjectAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates the list of associated technologies for the specified project.
        /// </summary>
        /// <param name="projectid">
        /// The ID of the project whose technologies are to be updated.
        /// </param>
        /// <param name="technologyIds">
        /// A list of technology IDs to associate with the project.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the operation was successful.
        /// </returns>
        [HttpPut("{projectid:long}/technologies")]
        public async Task<IActionResult> UpdateProjectTechnologies(long projectid, [FromBody] List<long> technologyIds)
        {
            var result = await _projectService.UpdateProjectTechnologiesAsync(projectid, technologyIds);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an project by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the project to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _projectService.DeleteProjectAsync(id);
            return Ok(result);
        }




    }
}
