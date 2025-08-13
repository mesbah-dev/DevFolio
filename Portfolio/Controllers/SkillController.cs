using Application.DTOs.Common;
using Application.DTOs.Skill;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    /// <summary>
    /// Skill management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        /// <summary>
        /// Retrieves the details of a specific skill by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the skill.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the skill data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long id)
        {
            var resualt = await _skillService.GetByIdAsync(id);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of skill.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of skill based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        [AllowAnonymous]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var resualt = _skillService.GetAll(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of skill.
        /// </summary>
        /// <param name="input">
        /// Filtering and paging options including:
        /// <list type="bullet">
        /// <item><description><c>SkillCategoryId</c>: Filternig by category ID.</description></item>
        /// <item><description><c>Q</c>: A general search term (e.g., name or title).</description></item>
        /// <item><description><c>Active</c>: Filters by active/inactive status (optional).</description></item>
        /// <item><description><c>PageIndex</c>, <c>PageSize</c>: Paging options.</description></item>
        /// <item><description><c>SortBy</c>: Sorting option (e.g., New, Old).</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the filtered list of skill.
        /// </returns>
        [HttpGet("search")]
        [AllowAnonymous]
        public IActionResult Search([FromQuery] SkillSearchInput input)
        {
            var resualt = _skillService.Search(input);
            return Ok(resualt);
        }


        /// <summary>
        /// Creates a new skill with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the skill.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SkillDto dto)
        {
            var resualt = await _skillService.CreateSkillAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Updates the information of an existing skill.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the skill.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] SkillDto dto)
        {
            var resualt = await _skillService.UpdateSkillAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Deletes an skill by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the skill to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            return Ok(result);
        }



    }
}
