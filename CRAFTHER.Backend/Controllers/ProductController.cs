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
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // --- HTTP GET: ดึงข้อมูลทั้งหมด ---
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Eager loading: โหลด Unit และ Organization
            return await _context.Products
                                 .Include(p => p.ProductUnit)
                                 .Include(p => p.BOMItems)
                                    .ThenInclude(bi => bi.UsageUnit)
                                 .ToListAsync();
        }

        // --- HTTP GET: ดึงข้อมูลตาม ID ---
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            // Eager loading: โหลด Unit และ Organization
            var product = await _context.Products
                                        .Include(p => p.ProductUnit)
                                        .Include(p => p.BOMItems)
                                            .ThenInclude(bi => bi.UsageUnit)
                                        .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // --- HTTP POST: สร้างข้อมูลใหม่ ---
        // POST: api/Product
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            // Basic validation for Foreign Keys
            if (!await _context.Organizations.AnyAsync(o => o.OrganizationId == product.OrganizationId))
            {
                return BadRequest("Invalid OrganizationId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == product.ProductUnitId))
            {
                return BadRequest("Invalid UnitOfMeasureId.");
            }

            // ตั้งค่า CreatedAt และ UpdatedAt
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

            // CurrentStockQuantity จะถูกตั้งค่าเริ่มต้นเป็น 0.0000m ตาม DefaultValue ใน Model
            // ไม่ต้องใส่โค้ดตรงนี้เพิ่ม เว้นแต่ต้องการบังคับค่า

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // โหลด Navigation Properties เพื่อให้ Object ที่คืนค่ากลับไปมีข้อมูลสมบูรณ์
            await _context.Entry(product)
                          .Reference(p => p.ProductUnit).LoadAsync();
            await _context.Entry(product)
                          .Reference(p => p.Organization).LoadAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        // --- HTTP PUT: อัปเดตข้อมูล ---
        // PUT: api/Product/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest("Product ID mismatch.");
            }

            // Basic validation for Foreign Keys
            if (!await _context.Organizations.AnyAsync(o => o.OrganizationId == product.OrganizationId))
            {
                return BadRequest("Invalid OrganizationId.");
            }
            if (!await _context.UnitsOfMeasures.AnyAsync(u => u.UnitId == product.ProductUnitId))
            {
                return BadRequest("Invalid UnitOfMeasureId.");
            }

            product.UpdatedAt = DateTime.UtcNow;

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        // DELETE: api/Product/5
        [Authorize(Roles = "Admin,Manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // --- Helper Method: ตรวจสอบว่า Product มีอยู่หรือไม่ ---
        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}