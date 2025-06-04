using CRAFTHER.Backend.DTOs.UnitOfMeasures;
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    // [Authorize] // Commented out for now, assuming UnitOfMeasures are globally accessible and might not require authentication for READ operations.
    // If write operations (Create/Update/Delete) should be restricted, consider adding Authorize on specific methods or roles.
    [Route("api/unitsofmeasure")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;

        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }

        // GET: api/unitsofmeasure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureResponseDto>>> GetAllUnitsOfMeasure()
        {
            var units = await _unitOfMeasureService.GetAllUnitsOfMeasureAsync();
            return Ok(units);
        }

        // GET: api/unitsofmeasure/{unitId}
        [HttpGet("{unitId}")]
        public async Task<ActionResult<UnitOfMeasureResponseDto>> GetUnitOfMeasureById(Guid unitId)
        {
            var unit = await _unitOfMeasureService.GetUnitOfMeasureByIdAsync(unitId);

            if (unit == null)
            {
                return NotFound();
            }
            return Ok(unit);
        }

        // GET: api/unitsofmeasure/bygroup/{unitGroupId}
        [HttpGet("bygroup/{unitGroupId}")]
        public async Task<ActionResult<IEnumerable<UnitOfMeasureResponseDto>>> GetUnitsOfMeasureByGroupId(Guid unitGroupId)
        {
            var units = await _unitOfMeasureService.GetUnitsOfMeasureByGroupIdAsync(unitGroupId);
            if (units == null || !units.Any())
            {
                return NotFound($"No units of measure found for Unit Group ID: {unitGroupId}");
            }
            return Ok(units);
        }

        // POST: api/unitsofmeasure
        [HttpPost]
        [Authorize] // สร้าง UnitOfMeasure อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<ActionResult<UnitOfMeasureResponseDto>> CreateUnitOfMeasure([FromBody] CreateUnitOfMeasureDto createUnitOfMeasureDto)
        {
            try
            {
                var createdUnit = await _unitOfMeasureService.CreateUnitOfMeasureAsync(createUnitOfMeasureDto);
                return CreatedAtAction(nameof(GetUnitOfMeasureById), new { unitId = createdUnit.UnitId }, createdUnit);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/unitsofmeasure/{unitId}
        [HttpPut("{unitId}")]
        [Authorize] // อัปเดต UnitOfMeasure อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<ActionResult<UnitOfMeasureResponseDto>> UpdateUnitOfMeasure(Guid unitId, [FromBody] UpdateUnitOfMeasureDto updateUnitOfMeasureDto)
        {
            // Ensure ID in DTO matches route parameter
            if (unitId != updateUnitOfMeasureDto.UnitId)
            {
                return BadRequest("UnitId in route must match UnitId in request body.");
            }

            try
            {
                var updatedUnit = await _unitOfMeasureService.UpdateUnitOfMeasureAsync(updateUnitOfMeasureDto);
                if (updatedUnit == null)
                {
                    return NotFound();
                }
                return Ok(updatedUnit);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/unitsofmeasure/{unitId}
        [HttpDelete("{unitId}")]
        [Authorize] // ลบ UnitOfMeasure อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<IActionResult> DeleteUnitOfMeasure(Guid unitId)
        {
            try
            {
                var deleted = await _unitOfMeasureService.DeleteUnitOfMeasureAsync(unitId);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent(); // 204 No Content for successful deletion
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}