using InExTrack.Application.DTOs;
using InExTrack.Application.Interfaces.Services;
using InExTrack.WebApi.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategories(getUserId(), cancellationToken);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.GetCategoryById(getUserId(), id, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.CreateCategory(getUserId(), categoryDto, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] Guid id, CategoryDto updatedCategory, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.UpdateCategory(getUserId(), id, updatedCategory, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _categoryService.DeleteCategory(getUserId(), id, cancellationToken));
        }

    }
}
