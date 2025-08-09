using Application.DTOs.Common;
using Application.DTOs.Experience;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// Experience management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        /// <summary>
        /// Retrieves the details of a specific experience by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the experience.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the experience data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _experienceService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of experience.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of experience based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _experienceService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of experience.
        /// </summary>
        /// <param name="input">
        /// Filtering and paging options including:
        /// <list type="bullet">
        /// <item><description><c>Q</c>: A general search term (e.g., name or title).</description></item>
        /// <item><description><c>Active</c>: Filters by active/inactive status (optional).</description></item>
        /// <item><description><c>PageIndex</c>, <c>PageSize</c>: Paging options.</description></item>
        /// <item><description><c>SortBy</c>: Sorting option (e.g., New, Old).</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the filtered list of experience.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _experienceService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new experience with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the experience.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an optional message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ExperienceDto dto)
        {
            var result = await _experienceService.CreateExperienceAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates the information of an existing experience.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the experience.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an optional message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ExperienceDto dto)
        {
            var result = await _experienceService.UpdateExperienceAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an experience by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the experience to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _experienceService.DeleteExperienceAsync(id);
            return Ok(result);
        }




    }
}
