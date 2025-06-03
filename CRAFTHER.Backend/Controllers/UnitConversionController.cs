using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims; // สำหรับ HttpContext.User.FindFirst
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // ต้องมีการ Login ถึงจะเข้าถึงได้
    public class UnitConversionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnitConversionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper method เพื่อดึง OrganizationId ของผู้ใช้ที่ Login อยู่
        private Guid GetUserOrganizationId()
        {
            var orgIdClaim = HttpContext.User.FindFirst("OrganizationId");
            if (orgIdClaim == null || !Guid.TryParse(orgIdClaim.Value, out Guid orgId))
            {
                throw new InvalidOperationException("Organization ID not found in user claims.");
            }
            return orgId;
        }

        // GET: api/UnitConversion - ดึงรายการการแปลงหน่วยทั้งหมดสำหรับ Organization ของผู้ใช้
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitConversion>>> GetUnitConversions()
        {
            var userOrgId = GetUserOrganizationId();
            return await _context.UnitConversions
                                 .Where(uc => uc.OrganizationId == userOrgId)
                                 .Include(uc => uc.FromUnit)
                                 .Include(uc => uc.ToUnit)
                                 .ToListAsync();
        }

        // GET: api/UnitConversion/5 - ดึงการแปลงหน่วยตาม ID
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitConversion>> GetUnitConversion(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            var unitConversion = await _context.UnitConversions
                                               .Include(uc => uc.FromUnit)
                                               .Include(uc => uc.ToUnit)
                                               .FirstOrDefaultAsync(uc => uc.ConversionId == id && uc.OrganizationId == userOrgId);

            if (unitConversion == null)
            {
                return NotFound();
            }

            return unitConversion;
        }

        // POST: api/UnitConversion - สร้างการแปลงหน่วยใหม่
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<UnitConversion>> PostUnitConversion(UnitConversion unitConversion)
        {
            var userOrgId = GetUserOrganizationId();
            unitConversion.OrganizationId = userOrgId; // กำหนด OrganizationId จากผู้ใช้ที่ Login

            // *** ลบการตรวจสอบ OrganizationId ของ FromUnit และ ToUnit ***
            // ตรวจสอบว่า FromUnitId และ ToUnitId มีอยู่จริงในระบบหรือไม่ (ไม่สน OrganizationId แล้ว)
            var fromUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == unitConversion.FromUnitId);
            var toUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == unitConversion.ToUnitId);

            if (!fromUnitExists || !toUnitExists)
            {
                return BadRequest("หน่วยต้นทางหรือหน่วยปลายทางไม่ถูกต้อง.");
            }

            // ตรวจสอบว่ามีการแปลงหน่วยเดียวกันอยู่แล้วหรือไม่สำหรับ Organization ของผู้ใช้
            var existingConversion = await _context.UnitConversions
                .AnyAsync(uc => uc.OrganizationId == userOrgId && // ยังคงผูกกับ Organization ของผู้ใช้
                                (uc.FromUnitId == unitConversion.FromUnitId && uc.ToUnitId == unitConversion.ToUnitId));
            if (existingConversion)
            {
                return Conflict("มีการแปลงหน่วยนี้อยู่แล้วในองค์กรของคุณ.");
            }

            unitConversion.CreatedAt = DateTime.UtcNow;
            unitConversion.UpdatedAt = DateTime.UtcNow;

            _context.UnitConversions.Add(unitConversion);
            await _context.SaveChangesAsync();

            await _context.Entry(unitConversion).Reference(uc => uc.FromUnit).LoadAsync();
            await _context.Entry(unitConversion).Reference(uc => uc.ToUnit).LoadAsync();
            await _context.Entry(unitConversion).Reference(uc => uc.Organization).LoadAsync();

            return CreatedAtAction(nameof(GetUnitConversion), new { id = unitConversion.ConversionId }, unitConversion);
        }

        // PUT: api/UnitConversion/5 - อัปเดตการแปลงหน่วย
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> PutUnitConversion(Guid id, UnitConversion unitConversion)
        {
            if (id != unitConversion.ConversionId)
            {
                return BadRequest("รหัสการแปลงหน่วยไม่ตรงกัน.");
            }

            var userOrgId = GetUserOrganizationId();
            // ตรวจสอบว่าเป็นของ Organization เดียวกัน
            if (unitConversion.OrganizationId != userOrgId)
            {
                return Forbid("คุณไม่มีสิทธิ์ในการแก้ไขการแปลงหน่วยขององค์กรอื่น.");
            }

            // *** ลบการตรวจสอบ OrganizationId ของ FromUnit และ ToUnit ***
            // ตรวจสอบว่า FromUnitId และ ToUnitId มีอยู่จริงในระบบหรือไม่ (ไม่สน OrganizationId แล้ว)
            var fromUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == unitConversion.FromUnitId);
            var toUnitExists = await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == unitConversion.ToUnitId);

            if (!fromUnitExists || !toUnitExists)
            {
                return BadRequest("หน่วยต้นทางหรือหน่วยปลายทางไม่ถูกต้อง.");
            }

            // ตรวจสอบว่ามีการแปลงหน่วยเดียวกันอยู่แล้วหรือไม่ (ยกเว้นตัวมันเอง) สำหรับ Organization ของผู้ใช้
            var existingConversion = await _context.UnitConversions
                .AnyAsync(uc => uc.ConversionId != id && uc.OrganizationId == userOrgId && // ยังคงผูกกับ Organization ของผู้ใช้
                                (uc.FromUnitId == unitConversion.FromUnitId && uc.ToUnitId == unitConversion.ToUnitId));
            if (existingConversion)
            {
                return Conflict("มีการแปลงหน่วยนี้อยู่แล้วในองค์กรของคุณ.");
            }

            unitConversion.UpdatedAt = DateTime.UtcNow;

            _context.Entry(unitConversion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitConversionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/UnitConversion/5 - ลบการแปลงหน่วย
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")] // เฉพาะ Admin หรือ Manager เท่านั้นที่ลบได้
        public async Task<IActionResult> DeleteUnitConversion(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            var unitConversion = await _context.UnitConversions.FirstOrDefaultAsync(uc => uc.ConversionId == id && uc.OrganizationId == userOrgId);
            if (unitConversion == null)
            {
                return NotFound();
            }

            _context.UnitConversions.Remove(unitConversion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitConversionExists(Guid id)
        {
            var userOrgId = GetUserOrganizationId();
            return _context.UnitConversions.Any(e => e.ConversionId == id && e.OrganizationId == userOrgId);
        }
    }
}