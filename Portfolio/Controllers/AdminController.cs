using Application.DTOs.AdminUser;
using Application.DTOs.Common;
using Application.DTOs.Security;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// Admin users management
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminUserService _adminUserService;
        public AdminController(IAdminUserService adminUserService)
        {
            _adminUserService = adminUserService;
        }

        /// <summary>
        /// Retrieves the details of a specific admin user by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the admin user.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the admin user data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _adminUserService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of admins.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of admin users based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _adminUserService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of admin users.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of admin users.
        /// </returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _adminUserService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new admin user with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the admin user.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an optional message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] AdminUserDto dto)
        {
            var result = await _adminUserService.CreateAdminAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Authenticates an admin user with the provided credentials.
        /// </summary>
        /// <param name="dto">
        /// The login credentials including username and password.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a success flag, message, and authentication token if login is successful.
        /// </returns>
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto dto)
        {
            var result = await _adminUserService.SignInAsync(dto);
            return Ok(result);
        }
        /// <summary>
        /// Updates the information of an existing admin user.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the admin user.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an optional message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAdminDto dto)
        {
            var result = await _adminUserService.UpdateAdminAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Changes the password of an existing admin user.
        /// </summary>
        /// <param name="dto">
        /// The password change request containing the admin ID, current password, and new password.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the password was successfully changed.
        /// </returns>
        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var result = await _adminUserService.ChangeAdminPasswordAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Deletes an admin user by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the admin user to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _adminUserService.DeleteAdminAsync(id);
            return Ok(result);
        }





    }
}
