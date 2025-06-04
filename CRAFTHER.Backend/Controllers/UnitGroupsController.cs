using CRAFTHER.Backend.DTOs.UnitGroups;
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    // [Authorize] // Commented out for now, assuming UnitGroups are globally accessible and might not require authentication for READ operations.
    // If write operations (Create/Update/Delete) should be restricted, consider adding Authorize on specific methods or roles.
    [Route("api/unitgroups")]
    [ApiController]
    public class UnitGroupsController : ControllerBase
    {
        private readonly IUnitGroupService _unitGroupService;

        public UnitGroupsController(IUnitGroupService unitGroupService)
        {
            _unitGroupService = unitGroupService;
        }

        // GET: api/unitgroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitGroupResponseDto>>> GetAllUnitGroups()
        {
            // ไม่ต้องใช้ organizationId แล้ว เนื่องจาก UnitGroup เป็น Global
            var unitGroups = await _unitGroupService.GetAllUnitGroupsAsync();
            return Ok(unitGroups);
        }

        // GET: api/unitgroups/{unitGroupId}
        [HttpGet("{unitGroupId}")]
        public async Task<ActionResult<UnitGroupResponseDto>> GetUnitGroupById(Guid unitGroupId)
        {
            // ไม่ต้องใช้ organizationId แล้ว
            var unitGroup = await _unitGroupService.GetUnitGroupByIdAsync(unitGroupId);

            if (unitGroup == null)
            {
                return NotFound();
            }
            return Ok(unitGroup);
        }

        // POST: api/unitgroups
        [HttpPost]
        [Authorize] // สร้าง UnitGroup อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<ActionResult<UnitGroupResponseDto>> CreateUnitGroup([FromBody] CreateUnitGroupDto createUnitGroupDto)
        {
            // ไม่ต้องรับ organizationId จาก DTO หรือ Claims แล้ว
            // การตรวจสอบสิทธิ์จะทำโดย [Authorize] attribute และ policy/roles หากมีการกำหนด
            try
            {
                var createdUnitGroup = await _unitGroupService.CreateUnitGroupAsync(createUnitGroupDto);
                return CreatedAtAction(nameof(GetUnitGroupById), new { unitGroupId = createdUnitGroup.UnitGroupId }, createdUnitGroup);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/unitgroups/{unitGroupId}
        [HttpPut("{unitGroupId}")]
        [Authorize] // อัปเดต UnitGroup อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<ActionResult<UnitGroupResponseDto>> UpdateUnitGroup(Guid unitGroupId, [FromBody] UpdateUnitGroupDto updateUnitGroupDto)
        {
            // Ensure ID in DTO matches route parameter
            if (unitGroupId != updateUnitGroupDto.UnitGroupId)
            {
                return BadRequest("UnitGroupId in route must match UnitGroupId in request body.");
            }

            try
            {
                var updatedUnitGroup = await _unitGroupService.UpdateUnitGroupAsync(updateUnitGroupDto);
                if (updatedUnitGroup == null)
                {
                    return NotFound();
                }
                return Ok(updatedUnitGroup);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/unitgroups/{unitGroupId}
        [HttpDelete("{unitGroupId}")]
        [Authorize] // ลบ UnitGroup อาจจะต้องมีสิทธิ์ (เช่น Admin)
        public async Task<IActionResult> DeleteUnitGroup(Guid unitGroupId)
        {
            try
            {
                var deleted = await _unitGroupService.DeleteUnitGroupAsync(unitGroupId);
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