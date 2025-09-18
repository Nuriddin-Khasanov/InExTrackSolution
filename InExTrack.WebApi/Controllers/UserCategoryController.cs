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
    public class UserCategoryController(IUserCategoryService _userCategoryService) : ApiBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUserCategoriesAsync(CancellationToken cancellationToken)
        {
            var categories = await _userCategoryService.GetUserCategoriesAsync(cancellationToken);

            return Ok(categories);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCategoryByIdAsync(Guid userId, CancellationToken cancellationToken)
        {
            var category = await _userCategoryService.GetUserCategoryByIdAsync(userId, cancellationToken);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserCategoryAsync([FromBody] UserCategoryDto userCategoryDto, CancellationToken cancellationToken)
        {
            var createdCategory = await _userCategoryService.AddUserCategoryAsync(userCategoryDto, cancellationToken);

            return Ok(createdCategory);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserCategoryAsync(Guid id, [FromBody] UserCategoryDto userCategoryDto, CancellationToken cancellationToken)
        {
            var updatedCategory = await _userCategoryService.UpdateUserCategoryAsync(id, userCategoryDto, cancellationToken);
            
            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserCategoryAsync(Guid id, CancellationToken cancellationToken)
        {
            var result = await _userCategoryService.DeleteUserCategoryAsync(id, cancellationToken);

            return Ok(result);
        }
    }
}
