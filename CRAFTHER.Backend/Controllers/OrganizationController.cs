using CRAFTHER.Backend.Data;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRAFTHER.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrganizationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- HTTP GET: ดึงข้อมูลทั้งหมด ---
        // GET: api/Organization
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
        {
            // Eager loading: โหลด IndustryType และ SubscriptionPlan มาพร้อมกับ Organization
            return await _context.Organizations
                                 .Include(o => o.IndustryType)
                                 .Include(o => o.SubscriptionPlan)
                                 .ToListAsync();
        }

        // --- HTTP GET: ดึงข้อมูลตาม ID ---
        // GET: api/Organization/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(Guid id)
        {
            // Eager loading: โหลด IndustryType และ SubscriptionPlan มาพร้อมกับ Organization
            var organization = await _context.Organizations
                                        .Include(o => o.IndustryType)
                                        .Include(o => o.SubscriptionPlan)
                                        .FirstOrDefaultAsync(o => o.OrganizationId == id);

            if (organization == null)
            {
                return NotFound();
            }

            return organization;
        }

        // --- HTTP POST: สร้างข้อมูลใหม่ ---
        // POST: api/Organization
        [Authorize(Roles = "Admin")] // <<-- ใช้ Role "Admin"
        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(Organization organization)
        {
            // ตั้งค่า CreatedAt และ UpdatedAt ก่อนบันทึก
            organization.CreatedAt = DateTime.UtcNow;
            organization.UpdatedAt = DateTime.UtcNow;

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync(); // บันทึกข้อมูลลงฐานข้อมูล

            // โหลด Navigation Properties เพื่อให้ Object ที่คืนค่ากลับไปมีข้อมูลสมบูรณ์
            await _context.Entry(organization)
                          .Reference(o => o.IndustryType).LoadAsync();
            await _context.Entry(organization)
                          .Reference(o => o.SubscriptionPlan).LoadAsync();

            // คืนค่า 201 Created พร้อม Header Location และข้อมูล Organization ที่สร้างใหม่
            return CreatedAtAction(nameof(GetOrganization), new { id = organization.OrganizationId }, organization);
        }

        // --- HTTP PUT: อัปเดตข้อมูล ---
        // PUT: api/Organization/5
        [Authorize(Roles = "Admin")] // <<-- ใช้ Role "Admin"
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(Guid id, Organization organization)
        {
            if (id != organization.OrganizationId)
            {
                return BadRequest("Organization ID mismatch.");
            }

            // ตั้งค่า UpdatedAt ก่อนบันทึก
            organization.UpdatedAt = DateTime.UtcNow;

            // ตรวจสอบว่า Organization ที่จะอัปเดตมีอยู่ใน DbContext หรือไม่
            _context.Entry(organization).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // บันทึกการเปลี่ยนแปลง
            }
            catch (DbUpdateConcurrencyException)
            {
                // ตรวจสอบว่า Organization ที่พยายามอัปเดตมีอยู่จริงหรือไม่
                if (!OrganizationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // คืนค่า 204 No Content (อัปเดตสำเร็จแต่ไม่มีข้อมูลคืน)
            return NoContent();
        }

        // --- HTTP DELETE: ลบข้อมูล ---
        // DELETE: api/Organization/5
        [Authorize(Roles = "Admin")] // <<-- ใช้ Role "Admin"
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(Guid id)
        {
            var organization = await _context.Organizations.FindAsync(id);
            if (organization == null)
            {
                return NotFound();
            }

            _context.Organizations.Remove(organization);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- Helper Method: ตรวจสอบว่า Organization มีอยู่หรือไม่ ---
        private bool OrganizationExists(Guid id)
        {
            return _context.Organizations.Any(e => e.OrganizationId == id);
        }
    }
}