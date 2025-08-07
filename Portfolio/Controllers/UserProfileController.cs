using Application.DTOs.Common;
using Application.DTOs.UserProfile;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// UserProfile management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        /// <summary>
        /// Retrieves the details of a specific user profile by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user profile.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the user profile data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _userProfileService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of user profile.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of user profile based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _userProfileService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of user profiles.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of user profiles.
        /// </returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _userProfileService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new user profile with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the user profile.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserProfileDto dto)
        {
            var result = await _userProfileService.CreateUserProfileAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Updates the information of an existing user profile.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the user profile.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UserProfileDto dto)
        {
            var result = await _userProfileService.UpdateUserProfileAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an user profile by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the user profile to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _userProfileService.DeleteUserProfileAsync(id);
            return Ok(result);
        }



    }
}
