using Application.DTOs.Common;
using Application.DTOs.SiteSetting;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// SiteSetting management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SiteSettingController : ControllerBase
    {
        private readonly ISiteSettingService _siteSettingService;
        public SiteSettingController(ISiteSettingService siteSettingService)
        {
            _siteSettingService = siteSettingService;
        }

        /// <summary>
        /// Retrieves the details of a specific siteSetting by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the siteSetting.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the siteSetting data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _siteSettingService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of siteSetting.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of siteSettings based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _siteSettingService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of siteSetting.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of siteSetting.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _siteSettingService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new siteSetting with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the siteSetting.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SiteSettingDto dto)
        {
            var result = await _siteSettingService.CreateSiteSettingAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates the information of an existing siteSetting.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the siteSetting.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] SiteSettingDto dto)
        {
            var result = await _siteSettingService.UpdateSiteSettingAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an siteSetting by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the siteSetting to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _siteSettingService.DeleteSiteSettingAsync(id);
            return Ok(result);
        }




    }
}
