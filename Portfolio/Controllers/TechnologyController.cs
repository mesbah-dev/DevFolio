using Application.DTOs.Common;
using Application.DTOs.Technology;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Technology management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService _technologyService;
        public TechnologyController(ITechnologyService technologyService)
        {
            _technologyService = technologyService;
        }

        /// <summary>
        /// Retrieves the details of a specific technology by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the technology.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the technology data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var resualt = await _technologyService.GetByIdAsync(id);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of technology.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of technology based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var resualt = _technologyService.GetAll(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of technologies.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of technologies.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var resualt = _technologyService.Search(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Creates a new technology with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the technology.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] TechnologyDto dto)
        {
            var resualt = await _technologyService.CreateTechnologyAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Updates the information of an existing technology.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the technology.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] TechnologyDto dto)
        {
            var resualt = await _technologyService.UpdateTechnologyAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Deletes an technology by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the technology to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var resualt = await _technologyService.DeleteTechnologyAsync(id);
            return Ok(resualt);
        }



    }
}
