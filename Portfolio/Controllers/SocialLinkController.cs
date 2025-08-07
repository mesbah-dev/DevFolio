using Application.DTOs.Common;
using Application.DTOs.SocialLink;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// SocialLink management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinkController : ControllerBase
    {
        private readonly ISocialLinkService _socialLinkService;
        public SocialLinkController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }

        /// <summary>
        /// Retrieves the details of a specific social link by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the social link.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the social link data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var resualt = await _socialLinkService.GetByIdAsync(id);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of social link.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of social links based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var resualt = _socialLinkService.GetAll(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of social links.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of social link.
        /// </returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var resualt = _socialLinkService.Search(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Creates a new social link with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the social link.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SocialLinkDto dto)
        {
            var resualt = await _socialLinkService.CreateSocialLinkAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Updates the information of an existing social link.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the social link.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] SocialLinkDto dto)
        {
            var resualt = await _socialLinkService.UpdateSocialLinkAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Deletes an social link by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the social link to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var resualt = await _socialLinkService.DeleteSocialLinkAsync(id);
            return Ok(resualt);
        }




    }
}
