using CRAFTHER.Backend.DTOs;
using CRAFTHER.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    [Authorize(Roles = "Admin")] // กำหนดให้เฉพาะ Admin เท่านั้นที่เข้าถึง Controller นี้ได้
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: api/Role - ดึง Role ทั้งหมด
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationRole>>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        // GET: api/Role/{id} - ดึง Role ตาม ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationRole>> GetRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString()); // FindByIdAsync รับค่า string

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // POST: api/Role - สร้าง Role ใหม่
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto model)
        {
            if (string.IsNullOrWhiteSpace(model.RoleName))
            {
                return BadRequest("Role name cannot be empty.");
            }

            // ตรวจสอบว่า Role นี้มีอยู่แล้วหรือยัง
            if (await _roleManager.RoleExistsAsync(model.RoleName))
            {
                return BadRequest($"Role '{model.RoleName}' already exists.");
            }

            var role = new ApplicationRole { Name = model.RoleName, NormalizedName = model.RoleName.ToUpperInvariant() };
            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Role/{id} - ลบ Role
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return NoContent(); // 204 No Content
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(ModelState);
        }
    }
}