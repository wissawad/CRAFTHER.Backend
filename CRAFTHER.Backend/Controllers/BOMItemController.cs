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
    public class BOMItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BOMItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- HTTP GET: ดึงข้อมูลทั้งหมด ---
        // GET: api/BOMItem
        [Authorize(Roles = "Admin,User,Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BOMItem>>> GetBOMItems()
        {
            // Eager loading: โหลด ParentProduct และ UsageUnit
            // เนื่องจาก ComponentReferenceId ไม่มี Navigation Property โดยตรง, จะไม่สามารถ Include Component/SubProduct ได้ที่นี่
            // หากต้องการข้อมูล Component/SubProduct เต็มๆ ใน Response ต้องใช้ DTO หรือ Query แยก
            return await _context.BOMItems
                                 .Include(b => b.ParentProduct) // โหลด Product หลัก
                                 .Include(b => b.UsageUnit)     // โหลดหน่วยวัด
                                 .ToListAsync();
        }

        // --- HTTP GET: ดึงข้อมูลตาม ID ---
        // GET: api/BOMItem/5
        [Authorize(Roles = "Admin,User,Manager")]
        [HttpGet("{id}")]
        public async Task<ActionResult<BOMItem>> GetBOMItem(Guid id)
        {
            // Eager loading: โหลด ParentProduct และ UsageUnit
            var bomItem = await _context.BOMItems
                                        .Include(b => b.ParentProduct)
                                        .Include(b => b.UsageUnit)
                                        .FirstOrDefaultAsync(b => b.BOMItemId == id);

            if (bomItem == null)
            {
                return NotFound();
            }

            // เนื่องจาก ComponentReferenceId ไม่มี Navigation Property โดยตรง (เช่น Component หรือ SubProduct object ใน BOMItem model)
            // เราจึงไม่สามารถใช้ .Include() หรือ .Reference().LoadAsync() เพื่อโหลด object ของ Component หรือ SubProduct ที่นี่ได้โดยตรง
            // หากต้องการข้อมูลของ Component/SubProduct เต็มๆ ใน Response ต้อง Query เพิ่มเติมแล้วใช้ Data Transfer Object (DTO)
            // เพื่อรวมข้อมูล:
            /*
            if (bomItem.ComponentType.Equals("COMPONENT", StringComparison.OrdinalIgnoreCase))
            {
                var componentDetail = await _context.Components.FindAsync(bomItem.ComponentReferenceId);
                // ในอนาคต อาจจะต้องสร้าง BOMItemDto และใส่ componentDetail เข้าไปใน DTO
            }
            else if (bomItem.ComponentType.Equals("PRODUCT", StringComparison.OrdinalIgnoreCase))
            {
                var subProductDetail = await _context.Products.FindAsync(bomItem.ComponentReferenceId);
                // ในอนาคต อาจจะต้องสร้าง BOMItemDto และใส่ subProductDetail เข้าไปใน DTO
            }
            */

            return bomItem;
        }

        // --- HTTP POST: สร้างข้อมูลใหม่ ---
        // POST: api/BOMItem
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<ActionResult<BOMItem>> PostBOMItem(BOMItem bomItem)
        {
            // Validation: ต้องมี ParentProductId ที่ถูกต้อง
            if (!await _context.Products.AnyAsync(p => p.ProductId == bomItem.ParentProductId))
            {
                return BadRequest("Invalid ParentProductId.");
            }

            // Validation: ต้องมี UsageUnitId ที่ถูกต้อง
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == bomItem.UsageUnitId))
            {
                return BadRequest("Invalid UsageUnitId.");
            }

            // Validation: ตรวจสอบ ComponentType และ ComponentReferenceId
            if (string.IsNullOrWhiteSpace(bomItem.ComponentType))
            {
                return BadRequest("ComponentType is required.");
            }

            bomItem.ComponentType = bomItem.ComponentType.ToUpperInvariant(); // ทำให้เป็นตัวพิมพ์ใหญ่เพื่อความสอดคล้อง

            if (bomItem.ComponentType == "COMPONENT")
            {
                if (!await _context.Components.AnyAsync(c => c.ComponentId == bomItem.ComponentReferenceId))
                {
                    return BadRequest("Invalid ComponentReferenceId for ComponentType 'COMPONENT'.");
                }
            }
            else if (bomItem.ComponentType == "PRODUCT")
            {
                if (!await _context.Products.AnyAsync(p => p.ProductId == bomItem.ComponentReferenceId))
                {
                    return BadRequest("Invalid ComponentReferenceId for ComponentType 'PRODUCT'.");
                }
                // Validation: ป้องกัน Circular Dependency (Product A มี Product A เป็นส่วนประกอบย่อย)
                if (bomItem.ParentProductId == bomItem.ComponentReferenceId)
                {
                    return BadRequest("A product cannot be a sub-product of itself.");
                }
                // Future improvement: Add more complex circular dependency check (e.g., A -> B, B -> C, C -> A)
            }
            else
            {
                return BadRequest("Invalid ComponentType. Must be 'COMPONENT' or 'PRODUCT'.");
            }

            // ตั้งค่า CreatedAt และ UpdatedAt
            bomItem.CreatedAt = DateTime.UtcNow;
            bomItem.UpdatedAt = DateTime.UtcNow;

            _context.BOMItems.Add(bomItem);
            await _context.SaveChangesAsync();

            // โหลด Navigation Properties เพื่อให้ Object ที่คืนค่ากลับไปมีข้อมูลสมบูรณ์
            // สามารถโหลด ParentProduct และ UsageUnit ได้ เพราะมี Navigation Property ตรงๆ
            await _context.Entry(bomItem).Reference(b => b.ParentProduct).LoadAsync();
            await _context.Entry(bomItem).Reference(b => b.UsageUnit).LoadAsync();

            // เนื่องจาก ComponentReferenceId ไม่มี Navigation Property ที่เชื่อมโยงโดยตรง
            // เราไม่สามารถใช้ .Reference().LoadAsync() กับมันได้
            // Response จะมีแค่ ComponentReferenceId (GUID) แต่ไม่มี Object ของ Component/Product นั้นๆ
            // หากต้องการข้อมูล Component/Product เต็มๆ ใน Response ต้องใช้ DTO และ Query แยก
            /*
            if (bomItem.ComponentType == "COMPONENT") {
                var componentDetail = await _context.Components.FindAsync(bomItem.ComponentReferenceId);
                // ต้องรวมข้อมูลนี้เข้ากับ DTO ที่จะส่งกลับ
            } else if (bomItem.ComponentType == "PRODUCT") {
                var subProductDetail = await _context.Products.FindAsync(bomItem.ComponentReferenceId);
                // ต้องรวมข้อมูลนี้เข้ากับ DTO ที่จะส่งกลับ
            }
            */

            return CreatedAtAction(nameof(GetBOMItem), new { id = bomItem.BOMItemId }, bomItem);
        }

        // --- HTTP PUT: อัปเดตข้อมูล ---
        // PUT: api/BOMItem/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBOMItem(Guid id, BOMItem bomItem)
        {
            if (id != bomItem.BOMItemId)
            {
                return BadRequest("BOMItem ID mismatch.");
            }

            // Validation: ต้องมี ParentProductId ที่ถูกต้อง
            if (!await _context.Products.AnyAsync(p => p.ProductId == bomItem.ParentProductId))
            {
                return BadRequest("Invalid ParentProductId.");
            }

            // Validation: ต้องมี UsageUnitId ที่ถูกต้อง
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == bomItem.UsageUnitId))
            {
                return BadRequest("Invalid UsageUnitId.");
            }

            // Validation: ตรวจสอบ ComponentType และ ComponentReferenceId
            if (string.IsNullOrWhiteSpace(bomItem.ComponentType))
            {
                return BadRequest("ComponentType is required.");
            }

            bomItem.ComponentType = bomItem.ComponentType.ToUpperInvariant(); // ทำให้เป็นตัวพิมพ์ใหญ่เพื่อความสอดคล้อง

            if (bomItem.ComponentType == "COMPONENT")
            {
                if (!await _context.Components.AnyAsync(c => c.ComponentId == bomItem.ComponentReferenceId))
                {
                    return BadRequest("Invalid ComponentReferenceId for ComponentType 'COMPONENT'.");
                }
            }
            else if (bomItem.ComponentType == "PRODUCT")
            {
                if (!await _context.Products.AnyAsync(p => p.ProductId == bomItem.ComponentReferenceId))
                {
                    return BadRequest("Invalid ComponentReferenceId for ComponentType 'PRODUCT'.");
                }
                // Validation: ป้องกัน Circular Dependency
                if (bomItem.ParentProductId == bomItem.ComponentReferenceId)
                {
                    return BadRequest("A product cannot be a sub-product of itself.");
                }
            }
            else
            {
                return BadRequest("Invalid ComponentType. Must be 'COMPONENT' or 'PRODUCT'.");
            }

            bomItem.UpdatedAt = DateTime.UtcNow;

            _context.Entry(bomItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOMItemExists(id))
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
        // DELETE: api/BOMItem/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBOMItem(Guid id)
        {
            var bomItem = await _context.BOMItems.FindAsync(id);
            if (bomItem == null)
            {
                return NotFound();
            }

            _context.BOMItems.Remove(bomItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- Helper Method: ตรวจสอบว่า BOMItem มีอยู่หรือไม่ ---
        private bool BOMItemExists(Guid id)
        {
            return _context.BOMItems.Any(e => e.BOMItemId == id);
        }
    }
}