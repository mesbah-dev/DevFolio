using Application.DTOs.Common;
using Application.DTOs.Education;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// Education management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;
        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        /// <summary>
        /// Retrieves the details of a specific education by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the education.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the education data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _educationService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of educations.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of educations based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _educationService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of educations.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of educations.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _educationService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new education with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the education.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] EducationDto dto)
        {
            var result = await _educationService.CreateEducationAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates the information of an existing education.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the education.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] EducationDto dto)
        {
            var result = await _educationService.UpdateEducationAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an education by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the education to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _educationService.DeleteEducationAsync(id);
            return Ok(result);
        }

    }
}
