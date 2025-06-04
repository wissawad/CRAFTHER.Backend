// Path: CRAFTHER.Backend/Controllers/UnitConversionController.cs
using CRAFTHER.Backend.DTOs.UnitConversions;
using CRAFTHER.Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims; // สำหรับ HttpContext.User.FindFirst
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ต้องมีการ Login ถึงจะเข้าถึงได้
    public class UnitConversionController : ControllerBase
    {
        private readonly IUnitConversionService _unitConversionService;

        public UnitConversionController(IUnitConversionService unitConversionService)
        {
            _unitConversionService = unitConversionService;
        }

        // Helper method เพื่อดึง OrganizationId ของผู้ใช้ที่ Login อยู่
        private Guid GetUserOrganizationId()
        {
            var orgIdClaim = User.FindFirst("OrganizationId")?.Value; // Access User from ControllerBase
            if (string.IsNullOrEmpty(orgIdClaim) || !Guid.TryParse(orgIdClaim, out Guid orgId))
            {
                throw new InvalidOperationException("Organization ID claim not found or invalid.");
            }
            return orgId;
        }

        // GET: api/UnitConversion - ดึงรายการการแปลงหน่วยทั้งหมดสำหรับ Organization ของผู้ใช้
        /// <summary>
        /// Retrieves all unit conversions for the authenticated user's organization.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UnitConversionResponseDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UnitConversionResponseDto>>> GetAllUnitConversions()
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var conversions = await _unitConversionService.GetAllUnitConversionsAsync(userOrgId);
                return Ok(conversions);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message }); // เช่น OrganizationId ไม่ถูกต้อง
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving unit conversions: {ex.Message}" });
            }
        }

        // GET: api/UnitConversion/5 - ดึงการแปลงหน่วยตาม ID
        /// <summary>
        /// Retrieves a specific unit conversion by its ID for the authenticated user's organization.
        /// </summary>
        /// <param name="id">The ID of the unit conversion.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnitConversionResponseDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UnitConversionResponseDto>> GetUnitConversionById(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var unitConversion = await _unitConversionService.GetUnitConversionByIdAsync(id, userOrgId);

                if (unitConversion == null)
                {
                    return NotFound();
                }
                return Ok(unitConversion);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error retrieving unit conversion: {ex.Message}" });
            }
        }

        // POST: api/UnitConversion - สร้างการแปลงหน่วยใหม่
        /// <summary>
        /// Creates a new unit conversion. Requires Admin or Manager role.
        /// </summary>
        /// <param name="createDto">The unit conversion data.</param>
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UnitConversionResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UnitConversionResponseDto>> CreateUnitConversion([FromBody] CreateUnitConversionDto createDto)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                // OrganizationId ถูกส่งไปยัง Service จาก Controller เพื่อให้ Service ใช้ในการตรวจสอบ
                var createdUnitConversion = await _unitConversionService.CreateUnitConversionAsync(createDto, userOrgId);
                return CreatedAtAction(nameof(GetUnitConversionById), new { id = createdUnitConversion.UnitConversionId }, createdUnitConversion);
            }
            catch (InvalidOperationException ex) // Business rule violations like invalid unit, duplicate conversion
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // Invalid input data from DTO validation
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error creating unit conversion: {ex.Message}" });
            }
        }

        // PUT: api/UnitConversion/5 - อัปเดตการแปลงหน่วย
        /// <summary>
        /// Updates an existing unit conversion. Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the unit conversion to update.</param>
        /// <param name="updateDto">The updated unit conversion data.</param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnitConversionResponseDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUnitConversion(Guid id, [FromBody] UpdateUnitConversionDto updateDto)
        {
            if (id != updateDto.UnitConversionId)
            {
                return BadRequest("Conversion ID in route must match Conversion ID in request body.");
            }

            try
            {
                var userOrgId = GetUserOrganizationId();
                // OrganizationId ถูกส่งไปยัง Service จาก Controller เพื่อให้ Service ใช้ในการตรวจสอบสิทธิ์
                var updatedUnitConversion = await _unitConversionService.UpdateUnitConversionAsync(updateDto, userOrgId);
                if (updatedUnitConversion == null)
                {
                    return NotFound();
                }
                return Ok(updatedUnitConversion);
            }
            catch (InvalidOperationException ex) // Business rule violations, e.g., duplicate, invalid unit
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex) // Invalid input data
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error updating unit conversion: {ex.Message}" });
            }
        }

        // DELETE: api/UnitConversion/5 - ลบการแปลงหน่วย
        /// <summary>
        /// Deletes a unit conversion. Requires Admin or Manager role.
        /// </summary>
        /// <param name="id">The ID of the unit conversion to delete.</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUnitConversion(Guid id)
        {
            try
            {
                var userOrgId = GetUserOrganizationId();
                var deleted = await _unitConversionService.DeleteUnitConversionAsync(id, userOrgId);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent(); // 204 No Content
            }
            catch (InvalidOperationException ex) // Business rule violation (e.g., in use)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error deleting unit conversion: {ex.Message}" });
            }
        }

        /// <summary>
        /// Gets the conversion factor between two specified units for the current user's organization.
        /// </summary>
        /// <param name="fromUnitId">The ID of the source unit.</param>
        /// <param name="toUnitId">The ID of the target unit.</param>
        /// <returns>The conversion factor as a decimal, or NotFound if no conversion path is found.</returns>
        [HttpGet("factor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<decimal>> GetConversionFactor([FromQuery] Guid fromUnitId, [FromQuery] Guid toUnitId)
        {
            if (fromUnitId == Guid.Empty || toUnitId == Guid.Empty)
            {
                return BadRequest("FromUnitId and ToUnitId are required.");
            }

            try
            {
                var userOrgId = GetUserOrganizationId();
                var factor = await _unitConversionService.GetConversionFactorAsync(fromUnitId, toUnitId, userOrgId);

                if (!factor.HasValue)
                {
                    return NotFound($"No conversion path found from unit '{fromUnitId}' to '{toUnitId}' for your organization.");
                }

                return Ok(factor.Value);
            }
            catch (InvalidOperationException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = $"Error getting conversion factor: {ex.Message}" });
            }
        }
    }
}