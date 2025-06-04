// Path: CRAFTHER.Backend/Controllers/ItemCategoryController.cs
using CRAFTHER.Backend.DTOs.ItemCategories;
using CRAFTHER.Backend.Models; // For ItemCategory if needed in return types directly
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Requires authentication for all actions
    public class ItemCategoryController : ControllerBase
    {
        private readonly IItemCategoryService _itemCategoryService;

        public ItemCategoryController(IItemCategoryService itemCategoryService)
        {
            _itemCategoryService = itemCategoryService;
        }

        /// <summary>
        /// Retrieves all item categories.
        /// </summary>
        [HttpGet]
        [AllowAnonymous] // Item categories might be public or require less strict auth for read
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ItemCategoryResponseDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ItemCategoryResponseDto>>> GetAllItemCategories()
        {
            try
            {
                var categories = await _itemCategoryService.GetAllItemCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving item categories: {ex.Message}" });
            }
        }

        /// <summary>
        /// Retrieves an item category by its ID.
        /// </summary>
        /// <param name="id">The ID of the item category.</param>
        [HttpGet("{id}")]
        [AllowAnonymous] // Item categories might be public or require less strict auth for read
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemCategoryResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ItemCategoryResponseDto>> GetItemCategoryById(Guid id)
        {
            try
            {
                var category = await _itemCategoryService.GetItemCategoryByIdAsync(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving item category: {ex.Message}" });
            }
        }

        /// <summary>
        /// Creates a new item category. Requires Admin role.
        /// </summary>
        /// <param name="createDto">The item category data.</param>
        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin can create new categories
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ItemCategoryResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ItemCategoryResponseDto>> CreateItemCategory([FromBody] CreateItemCategoryDto createDto)
        {
            try
            {
                var createdCategory = await _itemCategoryService.CreateItemCategoryAsync(createDto);
                return CreatedAtAction(nameof(GetItemCategoryById), new { id = createdCategory.ItemCategoryId }, createdCategory);
            }
            catch (InvalidOperationException ex) // Business rule violations, e.g., duplicate name
            {
                return Conflict(ex.Message); // 409 Conflict for duplicates
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error creating item category: {ex.Message}" });
            }
        }

        /// <summary>
        /// Updates an existing item category. Requires Admin role.
        /// </summary>
        /// <param name="id">The ID of the item category to update.</param>
        /// <param name="updateDto">The updated item category data.</param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can update categories
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemCategoryResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateItemCategory(Guid id, [FromBody] UpdateItemCategoryDto updateDto)
        {
            if (id != updateDto.ItemCategoryId)
            {
                return BadRequest("Item Category ID in route must match ID in request body.");
            }

            try
            {
                var updatedCategory = await _itemCategoryService.UpdateItemCategoryAsync(updateDto);
                if (updatedCategory == null)
                {
                    return NotFound();
                }
                return Ok(updatedCategory);
            }
            catch (InvalidOperationException ex) // Business rule violations
            {
                return Conflict(ex.Message);
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error updating item category: {ex.Message}" });
            }
        }

        /// <summary>
        /// Deletes an item category. Requires Admin role.
        /// </summary>
        /// <param name="id">The ID of the item category to delete.</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete categories
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // If deletion is prevented by business logic (e.g., in use)
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteItemCategory(Guid id)
        {
            try
            {
                var deleted = await _itemCategoryService.DeleteItemCategoryAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (InvalidOperationException ex) // Business rule violation (e.g., category is in use)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error deleting item category: {ex.Message}" });
            }
        }
    }
}