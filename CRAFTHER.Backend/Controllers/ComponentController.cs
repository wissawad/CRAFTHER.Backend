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
    public class ComponentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ComponentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- HTTP GET: ดึงข้อมูลทั้งหมด ---
        // GET: api/Component
        [Authorize(Roles = "Admin,User,Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
            // Eager loading: โหลด PurchaseUnit, InventoryUnit และ Organization
            return await _context.Components
                                 .Include(c => c.PurchaseUnit)
                                 .Include(c => c.InventoryUnit)
                                 .Include(c => c.Organization)
                                 .ToListAsync();
        }

        // --- HTTP GET: ดึงข้อมูลตาม ID ---
        // GET: api/Component/5
        [Authorize(Roles = "Admin,User,Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(Guid id)
        {
            // Eager loading: โหลด PurchaseUnit, InventoryUnit และ Organization
            var component = await _context.Components
                                        .Include(c => c.PurchaseUnit)
                                        .Include(c => c.InventoryUnit)
                                        .Include(c => c.Organization)
                                        .FirstOrDefaultAsync(c => c.ComponentId == id);

            if (component == null)
            {
                return NotFound();
            }

            return component;
        }

        // --- HTTP POST: สร้างข้อมูลใหม่ ---
        // POST: api/Component
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component component)
        {
            // Basic validation for Foreign Keys
            if (!await _context.Organizations.AnyAsync(o => o.OrganizationId == component.OrganizationId))
            {
                return BadRequest("Invalid OrganizationId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == component.PurchaseUnitId))
            {
                return BadRequest("Invalid PurchaseUnitId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == component.InventoryUnitId))
            {
                return BadRequest("Invalid InventoryUnitId.");
            }

            // ตั้งค่า CreatedAt และ UpdatedAt
            component.CreatedAt = DateTime.UtcNow;
            component.UpdatedAt = DateTime.UtcNow;

            _context.Components.Add(component);
            await _context.SaveChangesAsync();

            // โหลด Navigation Properties เพื่อให้ Object ที่คืนค่ากลับไปมีข้อมูลสมบูรณ์
            await _context.Entry(component)
                          .Reference(c => c.PurchaseUnit).LoadAsync();
            await _context.Entry(component)
                          .Reference(c => c.InventoryUnit).LoadAsync();
            await _context.Entry(component)
                          .Reference(c => c.Organization).LoadAsync();

            return CreatedAtAction(nameof(GetComponent), new { id = component.ComponentId }, component);
        }

        // --- HTTP PUT: อัปเดตข้อมูล ---
        // PUT: api/Component/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponent(Guid id, Component component)
        {
            if (id != component.ComponentId)
            {
                return BadRequest("Component ID mismatch.");
            }

            // Basic validation for Foreign Keys
            if (!await _context.Organizations.AnyAsync(o => o.OrganizationId == component.OrganizationId))
            {
                return BadRequest("Invalid OrganizationId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == component.PurchaseUnitId))
            {
                return BadRequest("Invalid PurchaseUnitId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == component.InventoryUnitId))
            {
                return BadRequest("Invalid InventoryUnitId.");
            }

            component.UpdatedAt = DateTime.UtcNow;

            _context.Entry(component).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // --- HTTP DELETE: ลบข้อมูล ---
        // DELETE: api/Component/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(Guid id)
        {
            var component = await _context.Components.FindAsync(id);
            if (component == null)
            {
                return NotFound();
            }

            _context.Components.Remove(component);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- Helper Method: ตรวจสอบว่า Component มีอยู่หรือไม่ ---
        private bool ComponentExists(Guid id)
        {
            return _context.Components.Any(e => e.ComponentId == id);
        }
    }
}