using Application.DTOs.Common;
using Application.DTOs.ContactMessage;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Contact message management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactMessageController : ControllerBase
    {
        private readonly IContactMessageService _contactMessageService;
        public ContactMessageController(IContactMessageService contactMessageService)
        {
            _contactMessageService = contactMessageService;
        }

        /// <summary>
        /// Retrieves the details of a specific contact message by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the contact message.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the contact message data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _contactMessageService.GetByIdAsync(id);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of contact message.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of contact message based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var result = _contactMessageService.GetAll(input);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of contact message.
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
        /// An <see cref="ApiResponse"/> containing the filtered list of contact message.
        /// </returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] BaseInput input)
        {
            var result = _contactMessageService.Search(input);
            return Ok(result);
        }

        /// <summary>
        /// Creates a new contact message with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the contact message.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an optional message.
        /// </returns>
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ContactMessageDto dto)
        {
            var result = await _contactMessageService.CreateMessageAsync(dto);
            return Ok(result);
        }



    }
}
