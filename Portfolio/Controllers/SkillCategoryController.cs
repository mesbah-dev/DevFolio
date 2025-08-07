using Application.DTOs.Common;
using Application.DTOs.SkillCategory;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    /// <summary>
    /// Skill category management
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoryController : ControllerBase
    {
        private readonly ISkillCategoryService _skillCategoryService;
        public SkillCategoryController(ISkillCategoryService skillCategoryService)
        {
            _skillCategoryService = skillCategoryService;
        }

        /// <summary>
        /// Retrieves the details of a specific skillCategory by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the skillCategory.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the skillCategory data if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyid/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var resualt = await _skillCategoryService.GetByIdAsync(id);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves the details of a specific skillCategory and its related skills by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the skillCategory.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the skillCategory data with related skills if found,
        /// along with a success flag and an message.
        /// </returns>
        [HttpGet("getbyidwithskills/{id:long}")]
        public async Task<IActionResult> GetByIdWithSkills(long id)
        {
            var resualt = await _skillCategoryService.GetByIdWithSkillsAsync(id);
            return Ok(resualt);
        }

        /// <summary>
        /// Retrieves a paginated and sorted list of skillCategories.
        /// </summary>
        /// <param name="input">
        /// Paging and sorting options including page number, page size, and sort order.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing a list of skillCategories based on the specified paging and sorting criteria.
        /// </returns>
        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] PagingInput input)
        {
            var resualt = _skillCategoryService.GetAll(input);
            return Ok(resualt);
        }


        /// <summary>
        /// Retrieves a paginated, sorted, and filtered list of skillCategories.
        /// </summary>
        /// <param name="input">
        /// Filtering and paging options including:
        /// <list type="bullet">
        /// <item><description><c>SkillCategoryId</c>: Filtering by Id</description></item>
        /// <item><description><c>Q</c>: A general search term (e.g., name or title).</description></item>
        /// <item><description><c>Active</c>: Filters by active/inactive status (optional).</description></item>
        /// <item><description><c>PageIndex</c>, <c>PageSize</c>: Paging options.</description></item>
        /// <item><description><c>SortBy</c>: Sorting option (e.g., New, Old).</description></item>
        /// </list>
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> containing the filtered list of skillCategories.
        /// </returns>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] SkillCategorySearchInput input)
        {
            var resualt = _skillCategoryService.Search(input);
            return Ok(resualt);
        }

        /// <summary>
        /// Creates a new skillCategory with the specified information.
        /// </summary>
        /// <param name="dto">
        /// The data required to create the skillCategory.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating the success status of the operation and an message.
        /// </returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] SkillCategoryDto dto)
        {
            var resualt = await _skillCategoryService.CreateSkillCategoryAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Updates the information of an existing skillCategory.
        /// </summary>
        /// <param name="dto">
        /// The updated data for the skillCategory.
        /// </param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the update was successful, along with an message.
        /// </returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] SkillCategoryDto dto)
        {
            var resualt = await _skillCategoryService.UpdateSkillCategoryAsync(dto);
            return Ok(resualt);
        }

        /// <summary>
        /// Deletes an skillCategory by their ID.
        /// </summary>
        /// <param name="id">The unique identifier of the skillCategory to delete.</param>
        /// <returns>
        /// An <see cref="ApiResponse"/> indicating whether the deletion was successful.
        /// </returns>
        [HttpDelete("delete/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var resualt = await _skillCategoryService.DeleteSkillCategoryAsync(id);
            return Ok(resualt);
        }




    }
}
